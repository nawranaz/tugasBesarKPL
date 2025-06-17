using TubesKPL_KitaBelajar;

namespace KitaBelajarGUI
{
    public partial class FormVidIPA : Form
    {
        public FormVidIPA()
        {
            InitializeComponent();
            this.Load += FormHome_Load;
            this.labelBack.Click += new System.EventHandler(this.labelBack_Click);

        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            // Ganti state ke MENU
            Program.CurrentState = Program.AppState.MENU;

            // Tutup form 
            this.Close();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void lblVideo_Click(object sender, EventArgs e)
        {

        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            flowBab.Controls.Clear(); // biar gak dobel

            var babList = new (string Title, string SubTitle)[]
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

            for (int i = 0; i < babList.Length; i++)
            {
                const int panelWidth = 290;
                const int panelHeight = 80;
                const int iconSize = 50;
                const int iconMargin = 50;

                // Path ke gambar thumbnail
                string imgPath = Path.Combine(Application.StartupPath, "Resources", "tnh.jpeg");


                var bab = babList[i];
                // Buat panel untuk setiap bab
                Panel panel = new Panel()
                {
                    Width = panelWidth,
                    Height = panelHeight,
                    BackColor = Color.MistyRose,
                    Margin = new Padding(10),
                    Cursor = Cursors.Hand,
                    Tag = (i + 1, bab.SubTitle) // kirim bab dan judul pake Tag
                };

                // Buat komponen di dalam panel
                PictureBox icon = new PictureBox()
                {
                    //Image = Image.FromFile(@"E:\anu\kpl\tugasBesarKPL\FormVideoEdukasi\Resources\tnh.jpeg"), // buat gambar icon play 
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = iconSize,
                    Height = iconMargin,
                    Location = new Point(10, 15)
                };

                // Validasi apakah file gambar ada
                if (File.Exists(imgPath))
                {
                    icon.Image = Image.FromFile(imgPath);
                }
                else
                {
                    // Gambar fallback jika file tidak ditemukan
                    icon.BackColor = Color.Gray;
                }

                Label title = new Label()
                {
                    Text = bab.Title,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(80, 15),
                    AutoSize = true
                };

                Label sub = new Label()
                {
                    Text = bab.SubTitle,
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(80, 40),
                    AutoSize = true
                };

                // Tambah event klik ke semua komponen
                panel.Click += Panel_Click;
                icon.Click += Panel_Click;
                title.Click += Panel_Click;
                sub.Click += Panel_Click;

                // Masukkan ke panel
                panel.Controls.Add(icon);
                panel.Controls.Add(title);
                panel.Controls.Add(sub);

                flowBab.Controls.Add(panel);
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            try
            {
                Control clicked = sender as Control;
                Panel panel = clicked as Panel ?? clicked.Parent as Panel;
                if (panel == null || panel.Tag == null) return;

                // Validasi aman terhadap data tuple
                if (panel.Tag is ValueTuple<int, string> tagData)
                {
                    int bab = tagData.Item1;
                    string title = tagData.Item2;

                    FormDetailIPA formDetail = new FormDetailIPA(bab, title);
                    formDetail.FormClosed += (s, e) => this.Show(); // Ketika formDetail ditutup, munculkan FormVidIPA lagi
                    this.Hide(); // Sembunyikan FormVidIPA
                    formDetail.Show();
                }
                else
                {
                    MessageBox.Show("Data bab tidak valid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void flowBab_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
