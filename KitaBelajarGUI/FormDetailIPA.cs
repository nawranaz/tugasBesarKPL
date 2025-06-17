using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TubesKPL_KitaBelajar;

namespace KitaBelajarGUI
{
    public partial class FormDetailIPA : Form
    {
        private int bab;
        private string title;

        private Dictionary<int, string> deskripsiBab = new Dictionary<int, string>()
        {
            { 1, "Membahas tentang sistem rangka manusia, fungsi-fungsinya, dan cara menjaga kesehatan rangka. Rangka manusia merupakan struktur pendukung tubuh yang terdiri dari tulang-tulang dan sendi." +
                " Rangka berfungsi untuk menopang tubuh, melindungi organ dalam, dan memungkinkan gerakan. Pemeliharaan rangka meliputi menjaga postur tubuh, mengonsumsi makanan bergizi, dan menghindari kebiasaan buruk yang dapat merusak tulang." },
            { 2, "Membahas tentang kelima indera manusia (panca indera), yaitu mata, telinga, hidung, lidah, dan kulit. Materi ini menjelaskan fungsi, struktur, dan cara kerja masing-masing indera dalam menerima rangsangan dari lingkungan sekitar. " },
            { 3, "Menjelaskan bagian-bagian tumbuhan seperti akar, batang, daun, dan fungsinya." },
            { 4, "Sama seperti BAB 1 namun versi lanjutannya." },
            { 5, "Mengenal jenis-jenis hewan berdasarkan makanan (herbivora, karnivora, omnivora)." },
            { 6, "Menjelaskan Energi dalam kehidupan sehari-hari dan perubahan bentuk energi." },
            { 7, "Menjelaskan Konsep gaya dan penerapannya di sekitar kita." },
            { 8, "Mengenal lingkungan tempat tinggal dan kenampakan alam." },
            { 9, "Mengenal Cuaca, iklim, dan pengaruh perubahan iklim terhadap lingkungan." },
            { 10, "Mengenal Wujud zat (padat, cair, gas) dan bagaimana perubahan antarwujud terjadi." }
        };

        private (string, string)[] babList = new (string, string)[]
        {
            ("BAB 1", "Rangka Manusia, Fungsi, \ndan Pemeliharaannya"),
            ("BAB 2", "Alat Indera Manusia, Fungsi, \ndan Pemeliharaannya"),
            ("BAB 3", "Bagian-bagian Tumbuhan \ndan Fungsinya"),
            ("BAB 4", "Rangka Manusia, Fungsi, \ndan Pemeliharaannya"),
            ("BAB 5", "Jenis-jenis Hewan berdasarkan \nJenis Makanannya"),
            ("BAB 6", "Energi dan Perubahannya"),
            ("BAB 7", "Gaya di Sekitar Kita"),
            ("BAB 8", "Di Sini Tempat Tinggalku!"),
            ("BAB 9", "Iklim dan Perubahannya"),
            ("BAB 10", "Wujud Zat dan Perubahannya")
        };

        public FormDetailIPA(int bab, string title)
        {
            InitializeComponent();

            this.bab = bab;
            this.title = title;

            // Set judul form sesuai title yang dikirim
            this.Text = title;

            lblBab.Text = $"BAB {bab}";
            lblNama.Text = $"{title}";

        }

        private void FormDetailIPA_Load(object sender, EventArgs e)
        {
            if (deskripsiBab.ContainsKey(bab))
            {
                lblDeskripsi.Text = deskripsiBab[bab];
            }
            else
            {
                lblDeskripsi.Text = "Deskripsi belum tersedia untuk BAB ini.";
            }

            // file path untuk video
            string videoBasePath = Path.Combine(Application.StartupPath, "Resources", "Vid");

            var videoList = new string[]
            {
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4"),
                Path.Combine(videoBasePath, "videotest.mp4")
            };


            for (int i = 0; i < babList.Length; i++)
            {
                var b = babList[i];

                string path = Path.Combine(Application.StartupPath, "Resources", "tnd.jpg");
                // Buat thumbnail untuk video

                PictureBox thumbnail = new PictureBox()
                {
                    Image = Properties.Resources.tnd,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = flowVideo.Width,
                    Height = flowVideo.Height,
                    Location = new Point(10, 15),
                    Tag = videoList[i] // Simpan path video di Tag
                };

                thumbnail.Click += Thumbnail_Click; // Tambahkan event handler

                flowVideo.Controls.Add(thumbnail);
            }

            foreach (var bab in babList.Select((value, index) => new { value, index }))
            {
                Panel panel = new Panel()
                {
                    Width = flowNextBab.Width - 25,
                    Height = 60,
                    BackColor = Color.MistyRose,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand,
                    Tag = bab.index + 1 // simpan nomor bab sebagai tag
                };

                Label lbl = new Label()
                {
                    Text = $"{bab.value.Item2}",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10)
                };

                panel.Controls.Add(lbl);

                // Tambah event click ke panel dan label supaya bisa klik di mana aja
                panel.Click += PanelNextBab_Click;
                lbl.Click += PanelNextBab_Click;

                flowNextBab.Controls.Add(panel);
            }
        }
        private void Thumbnail_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null && pic.Tag is string videoPath)
            {
                try
                {
                    if (File.Exists(videoPath))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", $"\"{videoPath}\"");
                    }
                    else
                    {
                        MessageBox.Show("Video tidak ditemukan:\n" + videoPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membuka video:\n" + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PanelNextBab_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;

            // Ambil panel, karena klik bisa dari label juga
            Panel panel = null;
            if (ctrl is Panel)
            {
                panel = (Panel)ctrl;
            }
            else if (ctrl.Parent is Panel)
            {
                panel = (Panel)ctrl.Parent;
            }

            if (panel != null && panel.Tag is int selectedBab)
            {
                // Update bab sekarang
                bab = selectedBab;

                // Update judul form dan konten
                this.Text = babList[bab - 1].Item2;

                LoadContentByBab(bab);
            }
        }

        private void LoadContentByBab(int bab)
        {
            if (deskripsiBab.ContainsKey(bab))
            {
                lblDeskripsi.Text = deskripsiBab[bab];
            }
            else
            {
                lblDeskripsi.Text = "Deskripsi belum tersedia untuk BAB ini.";
            }

            lblBab.Text = $"BAB {bab}";
            lblNama.Text = babList[bab - 1].Item2;

            // Bisa update video thumbnail/videoPath juga kalau perlu
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            Program.CurrentState = Program.AppState.VIDEO;

            this.Close();  // Tutup FormDetailIPA
        }


        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void lblSubJudul_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void flowBabLain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }
        private void lblDeskripsi_Click(object sender, EventArgs e)
        {

        }

        private void flowVideo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void flowBabLain_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            this.Close();  // Tutup FormDetailIPA
        }
    }

}
