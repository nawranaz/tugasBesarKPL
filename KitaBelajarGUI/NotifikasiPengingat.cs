using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using KitaBelajarGUI.model;
using TubesKPL_KitaBelajar; 
using TubesKPL_KitaBelajar.Controllers;

namespace KitaBelajarGUI
{
    public partial class NotifikasiPengingat : Form
    {
        private LatihanSoalController controller;

        public NotifikasiPengingat()
        {
            InitializeComponent();
        }

        private void NotifikasiPengingat_Load(object sender, EventArgs e)
        {
            try
            {
                InisialisasiComboBox();
                InisialisasiController();
            }
            catch (Exception ex)
            {
                LogError("Gagal saat inisialisasi", ex);
                MessageBox.Show("Terjadi kesalahan saat memuat halaman.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void InisialisasiComboBox()
        {
            comboBox1.Items.AddRange(new string[]
            {
                "Menonton video materi",
                "Membaca materi"
            });
        }

        private void InisialisasiController()
        {
            controller = new LatihanSoalController();

            controller.ShowToUser = pesan => MessageBox.Show(pesan, "Info");

            controller.ShowSoalKeUser = (pertanyaan, opsi) =>
            {
                string opsiFormat = string.Join("\n", opsi.Select((x, i) => $"{(char)('A' + i)}. {x}"));
                MessageBox.Show($"{pertanyaan}\n\n{opsiFormat}", "Soal");
            };

            controller.TampilkanHasil = (benar, salah, nilai) =>
            {
                MessageBox.Show($"Jawaban Benar: {benar}\nSalah: {salah}\nNilai: {nilai}", "Hasil");
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> pelajaranDipilih = AmbilPelajaranDipilih();
                if (!pelajaranDipilih.Any())
                {
                    TampilkanPeringatan("Pilih minimal satu mata pelajaran!");
                    return;
                }

                string kegiatan = comboBox1.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(kegiatan))
                {
                    TampilkanPeringatan("Pilih kegiatan terlebih dahulu!");
                    return;
                }

                DateTime tanggal = monthCalendar1.SelectionStart;
                TampilkanNotifikasi(kegiatan, pelajaranDipilih, tanggal);

                SimpanNotifikasiKeJson(kegiatan, pelajaranDipilih, tanggal);

                DialogResult hasil = MessageBox.Show("Kembali ke Menu?", "Selesai", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (hasil == DialogResult.OK)
                {
                    Program.CurrentState = Program.AppState.MENU;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogError("Gagal saat memproses notifikasi", ex);
                MessageBox.Show("Terjadi kesalahan saat mengatur pengingat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private List<string> AmbilPelajaranDipilih()
        {
            List<string> pelajaran = new();
            if (checkBox1.Checked) pelajaran.Add("Matematika");
            if (checkBox2.Checked) pelajaran.Add("Bahasa Inggris");
            if (checkBox3.Checked) pelajaran.Add("IPA");
            if (checkBox4.Checked) pelajaran.Add("IPS");
            return pelajaran;
        }

        private void TampilkanPeringatan(string pesan)
        {
            MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TampilkanNotifikasi(string kegiatan, List<string> pelajaran, DateTime tanggal)
        {
            string pesan = $"Notifikasi untuk \"{kegiatan}\" pelajaran {string.Join(", ", pelajaran)} pada tanggal {tanggal:dd/MM/yyyy} telah diatur.";
            MessageBox.Show(pesan, "Pengingat Diatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LogError(string context, Exception ex)
        {
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            string logEntry = $"[{DateTime.Now}] {context}: {ex.Message}\n{ex.StackTrace}\n";
            File.AppendAllText(logFile, logEntry);
        }

        private void SimpanNotifikasiKeJson(string kegiatan, List<string> pelajaran, DateTime tanggal)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(kegiatan) || pelajaran == null || pelajaran.Count == 0)
                    throw new ArgumentException("Data notifikasi tidak lengkap.");

                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataNotifikasi");
                Directory.CreateDirectory(folder); // Pastikan folder ada

                // Bikin nama file unik berdasarkan timestamp
                string fileName = $"notifikasi_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string filePath = Path.Combine(folder, fileName);

                Notifikasi item = new()
                {
                    Kegiatan = kegiatan,
                    Pelajaran = pelajaran,
                    Tanggal = tanggal
                };

                string jsonContent = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                LogError("Gagal menyimpan JSON baru", ex);
            }
        }


        // Event kosong
        private void label1_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox4_CheckedChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
    }
}
