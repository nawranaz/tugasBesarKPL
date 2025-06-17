using System;
using System.Windows.Forms;
using TubesKPL_KitaBelajar;
using TubesKPL_KitaBelajar.Controllers;
using TubesKPL_KitaBelajar.Library.Model;

namespace KitaBelajarGUI
{
    public partial class LatihanSoal : Form
    {
        // Controller untuk mengatur logika latihan soal
        private readonly LatihanSoalController controller;

        // Konstruktor form
        public LatihanSoal()
        {
            InitializeComponent();

            // Inisialisasi controller
            controller = new LatihanSoalController();

            // Injeksi callback dari controller ke UI
            controller.ShowToUser = ShowMessageToUser;
            controller.ShowSoalKeUser = ShowQuestionAndOptions;
            controller.TampilkanHasil = ShowResult;

            // Tombol submit dan opsi belum aktif sampai user pilih mapel
            groupBoxOptions.Enabled = false;
            buttonSubmitAnswer.Enabled = false;

            // Tambahkan daftar mata pelajaran ke ComboBox
            comboBoxSubject.Items.AddRange(new string[] { "Matematika", "IPA", "Bahasa Inggris", "IPS" });

            // Tambahkan event handler saat user memilih mapel dan klik submit
            comboBoxSubject.SelectedIndexChanged += comboBoxSubject_SelectedIndexChanged;
            buttonSubmitAnswer.Click += buttonSubmitAnswer_Click;
        }

        // Event saat user memilih mata pelajaran dari ComboBox
        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubject.SelectedItem == null) return;

            // Ambil nama mapel yang dipilih
            string subject = comboBoxSubject.SelectedItem.ToString();

            // Kirim ke controller untuk memilih soal sesuai mapel
            controller.SelectSubject(subject);

            // Aktifkan opsi dan tombol submit
            groupBoxOptions.Enabled = true;
            buttonSubmitAnswer.Enabled = true;

            // Tampilkan soal pertama
            var soal = controller.GetCurrentQuestion();
            if (soal != null)
                DisplayQuestion(soal);
        }

        // Event saat tombol "Kirim Jawaban" ditekan
        private void buttonSubmitAnswer_Click(object sender, EventArgs e)
        {
            // Default nilai kosong
            char jawabanUser = ' ';

            // Cek radio button mana yang dipilih
            if (radioButtonA.Checked) jawabanUser = 'A';
            else if (radioButtonB.Checked) jawabanUser = 'B';
            else if (radioButtonC.Checked) jawabanUser = 'C';
            else if (radioButtonD.Checked) jawabanUser = 'D';
            else
            {
                // Jika belum ada yang dipilih, beri peringatan
                MessageBox.Show("Pilih jawaban terlebih dahulu.", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kirim jawaban ke controller
            controller.KirimJawaban(jawabanUser.ToString());

            // Ambil soal selanjutnya dan tampilkan (jika ada)
            var soal = controller.GetCurrentQuestion();
            if (soal != null)
                DisplayQuestion(soal);
        }

        // Menampilkan feedback ke pengguna (benar/salah)
        private void ShowMessageToUser(string message)
        {
            // Gunakan Invoke untuk akses UI dari thread lain
            InvokeUI(() =>
            {
                labelFeedback.Text = message;

                // Warna teks hijau jika benar, merah jika salah
                labelFeedback.ForeColor = message.Contains("benar")
                    ? System.Drawing.Color.Green
                    : System.Drawing.Color.Red;
            });
        }

        // Menampilkan soal dan opsi jawaban
        private void ShowQuestionAndOptions(string question, string[] options)
        {
            InvokeUI(() =>
            {
                // Set teks soal
                textBoxQuestion.Text = question;

                // Set opsi jawaban A-D
                radioButtonA.Text = "A. " + options[0];
                radioButtonB.Text = "B. " + options[1];
                radioButtonC.Text = "C. " + options[2];
                radioButtonD.Text = "D. " + options[3];

                // Kosongkan centang
                ClearSelection();
            });
        }

        // Menampilkan hasil latihan ke pengguna
        private void ShowResult(int benar, int salah, int nilai)
        {
            // Tampilkan hasil dalam MessageBox
            MessageBox.Show(
                $"Latihan selesai!\nBenar: {benar}\nSalah: {salah}\nNilai: {nilai}%\n\nKlik OK untuk kembali ke Menu.",
                "Hasil Latihan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Reset tampilan form
            ResetForm();

            // Kembali ke menu utama
            Program.CurrentState = Program.AppState.MENU;
            this.Close();
        }

        // Menampilkan satu soal ke layar
        private void DisplayQuestion(SoalLatihan soal)
        {
            // Validasi data agar tidak error
            if (soal == null || soal.Options == null || soal.Options.Length < 4) return;

            // Set soal dan opsi ke UI
            textBoxQuestion.Text = soal.Question;
            radioButtonA.Text = "A. " + soal.Options[0];
            radioButtonB.Text = "B. " + soal.Options[1];
            radioButtonC.Text = "C. " + soal.Options[2];
            radioButtonD.Text = "D. " + soal.Options[3];

            ClearSelection();
        }

        // Menghapus semua pilihan jawaban
        private void ClearSelection()
        {
            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
            radioButtonD.Checked = false;
        }

        // Reset form kembali ke kondisi awal
        private void ResetForm()
        {
            labelFeedback.Text = "Pilih mata pelajaran untuk memulai";
            textBoxQuestion.Text = "";
            ClearSelection();
            comboBoxSubject.SelectedIndex = -1;
            groupBoxOptions.Enabled = false;
            buttonSubmitAnswer.Enabled = false;
        }

        // Fungsi pembantu untuk update UI secara thread-safe
        private void InvokeUI(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}
