namespace KitaBelajarGUI
{
    partial class ModulViewer
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
            lstMapel = new ListBox();
            lstModul = new ListBox();
            txtJudul = new TextBox();
            txtDeskripsi = new TextBox();
            txtKontenMultiline = new TextBox();
            btnSearch = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lstMapel
            // 
            lstMapel.FormattingEnabled = true;
            lstMapel.Location = new Point(47, 42);
            lstMapel.Name = "lstMapel";
            lstMapel.Size = new Size(182, 104);
            lstMapel.TabIndex = 0;
            lstMapel.SelectedIndexChanged += lstMapel_SelectedIndexChanged;
            // 
            // lstModul
            // 
            lstModul.FormattingEnabled = true;
            lstModul.Location = new Point(47, 152);
            lstModul.Name = "lstModul";
            lstModul.Size = new Size(182, 104);
            lstModul.TabIndex = 1;
            lstModul.SelectedIndexChanged += lstModul_SelectedIndexChanged;
            // 
            // txtJudul
            // 
            txtJudul.Location = new Point(47, 275);
            txtJudul.Name = "txtJudul";
            txtJudul.ReadOnly = true;
            txtJudul.Size = new Size(182, 27);
            txtJudul.TabIndex = 2;
            // 
            // txtDeskripsi
            // 
            txtDeskripsi.Location = new Point(47, 308);
            txtDeskripsi.Multiline = true;
            txtDeskripsi.Name = "txtDeskripsi";
            txtDeskripsi.ReadOnly = true;
            txtDeskripsi.Size = new Size(182, 27);
            txtDeskripsi.TabIndex = 3;
            // 
            // txtKontenMultiline
            // 
            txtKontenMultiline.Location = new Point(47, 357);
            txtKontenMultiline.Multiline = true;
            txtKontenMultiline.Name = "txtKontenMultiline";
            txtKontenMultiline.ReadOnly = true;
            txtKontenMultiline.ScrollBars = ScrollBars.Vertical;
            txtKontenMultiline.Size = new Size(182, 153);
            txtKontenMultiline.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(86, 7);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(11, 13);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(28, 29);
            btnBack.TabIndex = 6;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ModulViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(293, 536);
            Controls.Add(btnBack);
            Controls.Add(btnSearch);
            Controls.Add(txtKontenMultiline);
            Controls.Add(txtDeskripsi);
            Controls.Add(txtJudul);
            Controls.Add(lstModul);
            Controls.Add(lstMapel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModulViewer";
            Text = "ModulViewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMapel;
        private ListBox lstModul;
        private TextBox txtJudul;
        private TextBox txtDeskripsi;
        private TextBox txtKontenMultiline;
        private Button btnSearch;
        private Button btnBack;
    }
}