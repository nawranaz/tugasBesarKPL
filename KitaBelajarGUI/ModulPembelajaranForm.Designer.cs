namespace KitaBelajarGUI
{
    partial class ModulPembelajaranForm
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
            btnCari = new Button();
            txtKeyword = new TextBox();
            cmbMapel = new ComboBox();
            lstModul = new ListBox();
            txtKonten = new RichTextBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // btnCari
            // 
            btnCari.Location = new Point(187, 53);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(75, 29);
            btnCari.TabIndex = 0;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = true;
            btnCari.Click += btnCari_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(33, 12);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(229, 27);
            txtKeyword.TabIndex = 2;
            // 
            // cmbMapel
            // 
            cmbMapel.FormattingEnabled = true;
            cmbMapel.Location = new Point(33, 54);
            cmbMapel.Name = "cmbMapel";
            cmbMapel.Size = new Size(151, 28);
            cmbMapel.TabIndex = 3;
            cmbMapel.SelectedIndexChanged += cmbMapel_SelectedIndexChanged;
            // 
            // lstModul
            // 
            lstModul.FormattingEnabled = true;
            lstModul.Location = new Point(33, 108);
            lstModul.Name = "lstModul";
            lstModul.Size = new Size(229, 104);
            lstModul.TabIndex = 4;
            lstModul.SelectedIndexChanged += lstModul_SelectedIndexChanged;
            // 
            // txtKonten
            // 
            txtKonten.Location = new Point(33, 218);
            txtKonten.Name = "txtKonten";
            txtKonten.Size = new Size(229, 306);
            txtKonten.TabIndex = 5;
            txtKonten.Text = "";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(34, 85);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(35, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Info";
            // 
            // ModulPembelajaranForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(293, 536);
            Controls.Add(lblStatus);
            Controls.Add(txtKonten);
            Controls.Add(lstModul);
            Controls.Add(cmbMapel);
            Controls.Add(txtKeyword);
            Controls.Add(btnCari);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModulPembelajaranForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModulPembelajaran";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCari;
        private TextBox txtKeyword;
        private ComboBox cmbMapel;
        private ListBox lstModul;
        private RichTextBox txtKonten;
        private Label lblStatus;
    }
}