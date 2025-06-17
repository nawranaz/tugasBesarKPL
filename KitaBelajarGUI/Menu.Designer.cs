namespace KitaBelajarGUI
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            labelMenu = new Label();
            latihanSoalButton = new Button();
            pictureBox1 = new PictureBox();
            modulPembelajaranButton = new Button();
            videoPembelajaranButton = new Button();
            forumDiskusiButton = new Button();
            notifikasiPengingatButton = new Button();
            catatanButton = new Button();
            exitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelMenu
            // 
            labelMenu.AutoSize = true;
            labelMenu.Font = new Font("MS Reference Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMenu.ForeColor = SystemColors.ButtonHighlight;
            labelMenu.Location = new Point(23, 45);
            labelMenu.Name = "labelMenu";
            labelMenu.Size = new Size(318, 40);
            labelMenu.TabIndex = 0;
            labelMenu.Text = "Menu Kita Belajar";
            // 
            // latihanSoalButton
            // 
            latihanSoalButton.BackColor = Color.LightSkyBlue;
            latihanSoalButton.ForeColor = SystemColors.HighlightText;
            latihanSoalButton.Location = new Point(35, 316);
            latihanSoalButton.Name = "latihanSoalButton";
            latihanSoalButton.Size = new Size(94, 94);
            latihanSoalButton.TabIndex = 1;
            latihanSoalButton.Text = "Latihan Soal";
            latihanSoalButton.UseVisualStyleBackColor = false;
            latihanSoalButton.Click += latihanSoalButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(286, 210);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // modulPembelajaranButton
            // 
            modulPembelajaranButton.BackColor = Color.LightSkyBlue;
            modulPembelajaranButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            modulPembelajaranButton.ForeColor = SystemColors.HighlightText;
            modulPembelajaranButton.Location = new Point(135, 316);
            modulPembelajaranButton.Name = "modulPembelajaranButton";
            modulPembelajaranButton.Size = new Size(94, 94);
            modulPembelajaranButton.TabIndex = 3;
            modulPembelajaranButton.Text = "Modul Pembelajaran";
            modulPembelajaranButton.UseVisualStyleBackColor = false;
            modulPembelajaranButton.Click += modulPembelajaranButton_Click;
            // 
            // videoPembelajaranButton
            // 
            videoPembelajaranButton.BackColor = Color.LightSkyBlue;
            videoPembelajaranButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            videoPembelajaranButton.ForeColor = SystemColors.HighlightText;
            videoPembelajaranButton.Location = new Point(235, 316);
            videoPembelajaranButton.Name = "videoPembelajaranButton";
            videoPembelajaranButton.Size = new Size(94, 94);
            videoPembelajaranButton.TabIndex = 4;
            videoPembelajaranButton.Text = "Video Pembelajaran";
            videoPembelajaranButton.UseVisualStyleBackColor = false;
            videoPembelajaranButton.Click += videoPembelajaranButton_Click;
            // 
            // forumDiskusiButton
            // 
            forumDiskusiButton.BackColor = Color.LightSkyBlue;
            forumDiskusiButton.ForeColor = SystemColors.HighlightText;
            forumDiskusiButton.Location = new Point(135, 416);
            forumDiskusiButton.Name = "forumDiskusiButton";
            forumDiskusiButton.Size = new Size(94, 94);
            forumDiskusiButton.TabIndex = 5;
            forumDiskusiButton.Text = "Forum Diskusi";
            forumDiskusiButton.UseVisualStyleBackColor = false;
            forumDiskusiButton.Click += forumDiskusiButton_Click;
            // 
            // notifikasiPengingatButton
            // 
            notifikasiPengingatButton.BackColor = Color.LightSkyBlue;
            notifikasiPengingatButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            notifikasiPengingatButton.ForeColor = SystemColors.HighlightText;
            notifikasiPengingatButton.Location = new Point(35, 416);
            notifikasiPengingatButton.Name = "notifikasiPengingatButton";
            notifikasiPengingatButton.Size = new Size(94, 94);
            notifikasiPengingatButton.TabIndex = 6;
            notifikasiPengingatButton.Text = "Notifikasi Pengingat";
            notifikasiPengingatButton.UseVisualStyleBackColor = false;
            notifikasiPengingatButton.Click += notifikasiPengingatButton_Click;
            // 
            // catatanButton
            // 
            catatanButton.BackColor = Color.LightSkyBlue;
            catatanButton.ForeColor = SystemColors.HighlightText;
            catatanButton.Location = new Point(235, 416);
            catatanButton.Name = "catatanButton";
            catatanButton.Size = new Size(94, 94);
            catatanButton.TabIndex = 7;
            catatanButton.Text = "Catatan";
            catatanButton.UseVisualStyleBackColor = false;
            catatanButton.Click += catatanButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.CornflowerBlue;
            exitButton.ForeColor = SystemColors.HighlightText;
            exitButton.Location = new Point(35, 516);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(294, 53);
            exitButton.TabIndex = 8;
            exitButton.Text = "Keluar Aplikasi";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(366, 649);
            Controls.Add(exitButton);
            Controls.Add(catatanButton);
            Controls.Add(notifikasiPengingatButton);
            Controls.Add(forumDiskusiButton);
            Controls.Add(videoPembelajaranButton);
            Controls.Add(modulPembelajaranButton);
            Controls.Add(pictureBox1);
            Controls.Add(latihanSoalButton);
            Controls.Add(labelMenu);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMenu;
        private Button latihanSoalButton;
        private PictureBox pictureBox1;
        private Button modulPembelajaranButton;
        private Button videoPembelajaranButton;
        private Button forumDiskusiButton;
        private Button notifikasiPengingatButton;
        private Button catatanButton;
        private Button exitButton;
    }
}