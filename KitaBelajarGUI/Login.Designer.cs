namespace KitaBelajarGUI
{
    partial class Login
    {
        // Komponen UI yang digunakan dalam Form
        private System.ComponentModel.IContainer components = null;

        // Method untuk menghapus resource (clean up memory)
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Buang resource yang dipakai
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Method utama untuk mendesain layout form Login
        private void InitializeComponent()
        {
            // Inisialisasi label judul aplikasi "Kita Belajar"
            labelKitaBelajar = new Label();
            labelKitaBelajar.AutoSize = true;
            labelKitaBelajar.Font = new Font("MS Reference Sans Serif", 18F, FontStyle.Bold);
            labelKitaBelajar.Location = new Point(59, 53);
            labelKitaBelajar.Name = "labelKitaBelajar";
            labelKitaBelajar.Size = new Size(241, 45);
            labelKitaBelajar.TabIndex = 0;
            labelKitaBelajar.Text = "Kita Belajar";

            // Label subjudul "Teman belajarmu ! ^^"
            label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            label1.Location = new Point(59, 98);
            label1.Name = "label1";
            label1.Size = new Size(246, 32);
            label1.TabIndex = 1;
            label1.Text = "Teman belajarmu ! ^^";

            // Gambar ilustrasi siswa SD
            pictureBox1 = new PictureBox();
            pictureBox1.Image = Properties.Resources.siswaSDAngkatTangan;
            pictureBox1.Location = new Point(59, 133);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 174);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;

            // Label untuk "Username"
            label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            label2.Location = new Point(59, 327);
            label2.Name = "label2";
            label2.Size = new Size(115, 27);
            label2.TabIndex = 3;
            label2.Text = "Username :";

            // TextBox input username
            textBox1 = new TextBox();
            textBox1.Location = new Point(63, 357);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(237, 31);
            textBox1.TabIndex = 4;

            // TextBox input password
            textBox2 = new TextBox();
            textBox2.Location = new Point(63, 429);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(237, 31);
            textBox2.TabIndex = 6;
            textBox2.PasswordChar = '*'; // Karakter tersembunyi untuk password

            // Label untuk "Password"
            label3 = new Label();
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            label3.Location = new Point(59, 399);
            label3.Name = "label3";
            label3.Size = new Size(109, 27);
            label3.TabIndex = 5;
            label3.Text = "Password :";

            // Tombol "Masuk Sekarang"
            tombolMasuk = new Button();
            tombolMasuk.BackColor = Color.RoyalBlue;
            tombolMasuk.ForeColor = Color.White;
            tombolMasuk.Location = new Point(59, 491);
            tombolMasuk.Name = "tombolMasuk";
            tombolMasuk.Size = new Size(237, 58);
            tombolMasuk.TabIndex = 7;
            tombolMasuk.Text = "Masuk Sekarang";
            tombolMasuk.UseVisualStyleBackColor = false;
            tombolMasuk.Click += TombolMasuk_Click; // Event handler tombol

            // Label untuk hasil login (benar/salah)
            hasilLogin = new Label();
            hasilLogin.AutoSize = true;
            hasilLogin.Location = new Point(63, 463);
            hasilLogin.Name = "hasilLogin";
            hasilLogin.Size = new Size(91, 25);
            hasilLogin.TabIndex = 8;
            hasilLogin.Text = "hasilLogin";
            hasilLogin.Visible = false; // Tersembunyi awalnya

            // Atur properti utama Form Login
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue; // Warna latar belakang
            ClientSize = new Size(366, 649); // Ukuran form

            // Tambahkan semua komponen ke Form
            Controls.Add(hasilLogin);
            Controls.Add(tombolMasuk);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(labelKitaBelajar);

            ForeColor = Color.White;
            Name = "Login";
            Text = "Login";

            // Selesaikan inisialisasi komponen
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout(); // Terapkan semua layout komponen
        }

        #endregion

        // Deklarasi semua komponen yang digunakan dalam form
        private Label labelKitaBelajar;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Button tombolMasuk;
        private Label hasilLogin;
    }
}
