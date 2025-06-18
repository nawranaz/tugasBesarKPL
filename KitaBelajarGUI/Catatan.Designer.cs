namespace CatatanGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtJudul = new TextBox();
            label2 = new Label();
            txtIsi = new TextBox();
            btnTambah = new Button();
            lstCatatan = new ListBox();
            label3 = new Label();
            lblDetail = new Label();
            btnKembali = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "JUDUL";
            // 
            // txtJudul
            // 
            txtJudul.Location = new Point(12, 32);
            txtJudul.Name = "txtJudul";
            txtJudul.Size = new Size(269, 27);
            txtJudul.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 2;
            label2.Text = "CATATAN";
            // 
            // txtIsi
            // 
            txtIsi.Location = new Point(12, 115);
            txtIsi.Multiline = true;
            txtIsi.Name = "txtIsi";
            txtIsi.ScrollBars = ScrollBars.Both;
            txtIsi.Size = new Size(269, 27);
            txtIsi.TabIndex = 3;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(78, 177);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(94, 29);
            btnTambah.TabIndex = 4;
            btnTambah.Text = "SIMPAN";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // lstCatatan
            // 
            lstCatatan.FormattingEnabled = true;
            lstCatatan.Location = new Point(12, 271);
            lstCatatan.Name = "lstCatatan";
            lstCatatan.Size = new Size(150, 64);
            lstCatatan.TabIndex = 5;
            lstCatatan.Click += lstCatatan_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 234);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 6;
            label3.Text = "LIST CATATAN";
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.BackColor = SystemColors.Control;
            lblDetail.BorderStyle = BorderStyle.Fixed3D;
            lblDetail.ForeColor = SystemColors.ActiveCaptionText;
            lblDetail.Location = new Point(12, 366);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(81, 22);
            lblDetail.TabIndex = 7;
            lblDetail.Text = "isi catatan:";
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(78, 460);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(94, 29);
            btnKembali.TabIndex = 8;
            btnKembali.Text = "KEMBALI";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(293, 519);
            Controls.Add(btnKembali);
            Controls.Add(lblDetail);
            Controls.Add(label3);
            Controls.Add(lstCatatan);
            Controls.Add(btnTambah);
            Controls.Add(txtIsi);
            Controls.Add(label2);
            Controls.Add(txtJudul);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtJudul;
        private Label label2;
        private TextBox txtIsi;
        private Button btnTambah;
        private ListBox lstCatatan;
        private Label label3;
        private Label lblDetail;
        private Button btnKembali;
    }
}
