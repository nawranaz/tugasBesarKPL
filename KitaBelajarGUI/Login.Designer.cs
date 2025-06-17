namespace KitaBelajarGUI
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Label judul "Kita Belajar"
            labelTitle = new Label();
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("MS Reference Sans Serif", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(59, 53);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(241, 45);
            labelTitle.Text = "Kita Belajar";

            // Label subjudul
            labelSubtitle = new Label();
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            labelSubtitle.Location = new Point(59, 98);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(246, 32);
            labelSubtitle.Text = "Teman belajarmu ! ^^";

            // Gambar siswa SD
            pictureIllustration = new PictureBox();
            pictureIllustration.Image = Properties.Resources.siswaSDAngkatTangan;
            pictureIllustration.Location = new Point(59, 133);
            pictureIllustration.Name = "pictureIllustration";
            pictureIllustration.Size = new Size(241, 174);
            pictureIllustration.TabStop = false;

            // Label Username
            labelUsername = new Label();
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            labelUsername.Location = new Point(59, 327);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(115, 27);
            labelUsername.Text = "Username :";

            // TextBox Username
            textBoxUsername = new TextBox();
            textBoxUsername.Location = new Point(63, 357);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(237, 31);

            // Label Password
            labelPassword = new Label();
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            labelPassword.Location = new Point(59, 399);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(109, 27);
            labelPassword.Text = "Password :";

            // TextBox Password
            textBoxPassword = new TextBox();
            textBoxPassword.Location = new Point(63, 429);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(237, 31);
            textBoxPassword.PasswordChar = '*';

            // Label hasil login
            labelLoginResult = new Label();
            labelLoginResult.AutoSize = true;
            labelLoginResult.Location = new Point(63, 463);
            labelLoginResult.Name = "labelLoginResult";
            labelLoginResult.Size = new Size(91, 25);
            labelLoginResult.Text = "hasilLogin";
            labelLoginResult.Visible = false;

            // Tombol Masuk
            buttonLogin = new Button();
            buttonLogin.BackColor = Color.RoyalBlue;
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(59, 491);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(237, 58);
            buttonLogin.Text = "Masuk Sekarang";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += ButtonLogin_Click;

            // Konfigurasi utama Form
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(366, 649);
            ForeColor = Color.White;
            Name = "Login";
            Text = "Login";

            // Tambah komponen ke Form
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(pictureIllustration);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelLoginResult);
            Controls.Add(buttonLogin);

            ((System.ComponentModel.ISupportInitialize)pictureIllustration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Komponen UI
        private Label labelTitle;
        private Label labelSubtitle;
        private PictureBox pictureIllustration;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelLoginResult;
        private Button buttonLogin;
    }
}
