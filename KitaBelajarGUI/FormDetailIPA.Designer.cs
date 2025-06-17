namespace KitaBelajarGUI
{
    partial class FormDetailIPA
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
            lblDeskripsi = new Label();
            lblBab = new Label();
            lblNama = new Label();
            panel1 = new Panel();
            labelBack = new Label();
            pictureBox2 = new PictureBox();
            labelJudul = new Label();
            flowVideo = new FlowLayoutPanel();
            flowNextBab = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblDeskripsi
            // 
            lblDeskripsi.Location = new Point(2, 321);
            lblDeskripsi.Name = "lblDeskripsi";
            lblDeskripsi.Size = new Size(326, 129);
            lblDeskripsi.TabIndex = 7;
            lblDeskripsi.Text = "Deskripsi";
            lblDeskripsi.TextAlign = ContentAlignment.MiddleCenter;
            lblDeskripsi.Click += lblDeskripsi_Click;
            // 
            // lblBab
            // 
            lblBab.AutoSize = true;
            lblBab.Location = new Point(151, 262);
            lblBab.Name = "lblBab";
            lblBab.Size = new Size(27, 15);
            lblBab.TabIndex = 0;
            lblBab.Text = "Bab";
            // 
            // lblNama
            // 
            lblNama.Location = new Point(83, 277);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(184, 44);
            lblNama.TabIndex = 8;
            lblNama.Text = "Judul";
            lblNama.TextAlign = ContentAlignment.TopCenter;
            lblNama.Click += lblNama_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelBack);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(labelJudul);
            panel1.Location = new Point(2, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 96);
            panel1.TabIndex = 9;
            // 
            // labelBack
            // 
            labelBack.AutoSize = true;
            labelBack.Location = new Point(3, 4);
            labelBack.Name = "labelBack";
            labelBack.Size = new Size(15, 15);
            labelBack.TabIndex = 4;
            labelBack.Text = "<";
            labelBack.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Physics;
            pictureBox2.Location = new Point(98, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 37);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Location = new Point(139, 19);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(80, 45);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Ilmu\r\nPengetahuan \r\nAlam\r\n";
            // 
            // flowVideo
            // 
            flowVideo.Location = new Point(2, 107);
            flowVideo.Name = "flowVideo";
            flowVideo.Size = new Size(326, 152);
            flowVideo.TabIndex = 10;
            flowVideo.Paint += flowVideo_Paint;
            // 
            // flowNextBab
            // 
            flowNextBab.AutoScroll = true;
            flowNextBab.AutoScrollMargin = new Size(3100, 0);
            flowNextBab.AutoScrollMinSize = new Size(10, 10);
            flowNextBab.Location = new Point(2, 469);
            flowNextBab.Name = "flowNextBab";
            flowNextBab.Size = new Size(326, 84);
            flowNextBab.TabIndex = 11;
            flowNextBab.Paint += flowBabLain_Paint_1;
            // 
            // FormDetailIPA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 554);
            Controls.Add(flowNextBab);
            Controls.Add(flowVideo);
            Controls.Add(lblDeskripsi);
            Controls.Add(panel1);
            Controls.Add(lblNama);
            Controls.Add(lblBab);
            Name = "FormDetailIPA";
            Text = "FormDetailMtk";
            Load += FormDetailIPA_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Button button1;
        private Label lblDeskripsi;
        private Label lblBab;
        private Label lblNama;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label labelJudul;
        private FlowLayoutPanel flowVideo;
        private FlowLayoutPanel flowNextBab;
        private Label labelBack;
    }
}