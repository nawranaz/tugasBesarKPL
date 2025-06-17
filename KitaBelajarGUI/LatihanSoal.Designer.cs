namespace KitaBelajarGUI
{
    partial class LatihanSoal
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Membersihkan resource yang sedang digunakan
        /// </summary>
        /// <param name="disposing">true jika sedang membuang resource terkelola</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Clean up komponen
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Inisialisasi komponen UI untuk form Latihan Soal
        /// </summary>
        private void InitializeComponent()
        {
            // KomboBox mata pelajaran
            comboBoxSubject = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(26, 135),
                Name = "comboBoxSubject",
                Size = new Size(312, 36),
                TabIndex = 0
            };

            // Label instruksi awal atau nomor soal
            labelQuestionNumber = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = SystemColors.ButtonHighlight,
                Location = new Point(9, 86),
                Name = "labelQuestionNumber",
                Size = new Size(351, 28),
                TabIndex = 1,
                Text = "Pilih mata pelajaran untuk memulai"
            };

            // TextBox soal (hanya dibaca, tidak bisa diedit)
            textBoxQuestion = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(26, 190),
                Multiline = true,
                Name = "textBoxQuestion",
                ReadOnly = true, // Secure coding: cegah user mengedit
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(312, 130),
                TabIndex = 2
            };

            // Grup opsi jawaban
            groupBoxOptions = new GroupBox
            {
                Controls = {
                    (radioButtonD = new RadioButton
                    {
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(15, 131),
                        Name = "radioButtonD",
                        Size = new Size(122, 29),
                        TabIndex = 3,
                        TabStop = true,
                        Text = "Jawaban D",
                        UseVisualStyleBackColor = true
                    }),
                    (radioButtonC = new RadioButton
                    {
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(15, 96),
                        Name = "radioButtonC",
                        Size = new Size(120, 29),
                        TabIndex = 2,
                        TabStop = true,
                        Text = "Jawaban C",
                        UseVisualStyleBackColor = true
                    }),
                    (radioButtonB = new RadioButton
                    {
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(15, 63),
                        Name = "radioButtonB",
                        Size = new Size(119, 29),
                        TabIndex = 1,
                        TabStop = true,
                        Text = "Jawaban B",
                        UseVisualStyleBackColor = true
                    }),
                    (radioButtonA = new RadioButton
                    {
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(15, 30),
                        Name = "radioButtonA",
                        Size = new Size(121, 29),
                        TabIndex = 0,
                        TabStop = true,
                        Text = "Jawaban A",
                        UseVisualStyleBackColor = true
                    })
                },
                Enabled = false, // Secure: hanya aktif setelah soal muncul
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = SystemColors.ButtonHighlight,
                Location = new Point(26, 326),
                Name = "groupBoxOptions",
                Size = new Size(312, 168),
                TabIndex = 3,
                TabStop = false,
                Text = "Pilih Jawaban"
            };

            // Tombol untuk mengirim jawaban
            buttonSubmitAnswer = new Button
            {
                BackColor = Color.LightCyan,
                Enabled = false, // Secure: default disable, aktif saat soal aktif
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(26, 506),
                Name = "buttonSubmitAnswer",
                Size = new Size(312, 48),
                TabIndex = 4,
                Text = "Kirim Jawaban",
                UseVisualStyleBackColor = false
            };

            // Label untuk menampilkan feedback jawaban
            labelFeedback = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(26, 572),
                Name = "labelFeedback",
                Size = new Size(0, 28),
                TabIndex = 5
            };

            // Judul form
            labelSoalLatihan = new Label
            {
                AutoSize = true,
                Font = new Font("MS Reference Sans Serif", 18F, FontStyle.Bold),
                ForeColor = SystemColors.ButtonHighlight,
                Location = new Point(41, 30),
                Name = "labelSoalLatihan",
                Size = new Size(256, 45),
                TabIndex = 6,
                Text = "Soal Latihan"
            };

            // Tombol kembali ke menu
            buttonBackToMenu = new Button
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(26, 610),
                Name = "buttonBackToMenu",
                Size = new Size(312, 48),
                TabIndex = 7,
                Text = "Kembali ke Menu",
                UseVisualStyleBackColor = true,
                Visible = false // Secure: tidak ditampilkan saat awal
            };

            // Konfigurasi Form
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(366, 670);
            Controls.Add(labelSoalLatihan);
            Controls.Add(labelFeedback);
            Controls.Add(buttonBackToMenu);
            Controls.Add(buttonSubmitAnswer);
            Controls.Add(groupBoxOptions);
            Controls.Add(textBoxQuestion);
            Controls.Add(labelQuestionNumber);
            Controls.Add(comboBoxSubject);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LatihanSoal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Latihan Soal";

            groupBoxOptions.ResumeLayout(false);
            groupBoxOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxSubject;
        private Label labelQuestionNumber;
        private TextBox textBoxQuestion;
        private GroupBox groupBoxOptions;
        private RadioButton radioButtonD;
        private RadioButton radioButtonC;
        private RadioButton radioButtonB;
        private RadioButton radioButtonA;
        private Button buttonSubmitAnswer;
        private Label labelFeedback;
        private Label labelSoalLatihan;
        private Button buttonBackToMenu;
    }
}
