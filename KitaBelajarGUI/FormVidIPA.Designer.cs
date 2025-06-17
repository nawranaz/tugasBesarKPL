namespace KitaBelajarGUI
{
    partial class FormVidIPA
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
            labelJudul = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            labelBack = new Label();
            lblVideo = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            flowBab = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Location = new Point(139, 19);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(80, 45);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Ilmu\r\nPengetahuan \r\nAlam\r\n";
            labelJudul.Click += label1_Click_1;
            // 
            // labelBack
            // 
            labelBack.AutoSize = true;
            labelBack.Location = new Point(14, 8);
            labelBack.Name = "labelBack";
            labelBack.Size = new Size(15, 15);
            labelBack.TabIndex = 1;
            labelBack.Text = "<";
            labelBack.Click += label2_Click;
            // 
            // lblVideo
            // 
            lblVideo.AutoSize = true;
            lblVideo.Location = new Point(0, 81);
            lblVideo.Name = "lblVideo";
            lblVideo.Size = new Size(112, 15);
            lblVideo.TabIndex = 2;
            lblVideo.Text = "Video Pembelajaran";
            lblVideo.Click += lblVideo_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labelJudul);
            panel1.Controls.Add(lblVideo);
            panel1.Location = new Point(12, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 96);
            panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Physics;
            pictureBox1.Location = new Point(98, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 37);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // flowBab
            // 
            flowBab.AutoScroll = true;
            flowBab.Location = new Point(-1, 110);
            flowBab.Name = "flowBab";
            flowBab.Size = new Size(329, 432);
            flowBab.TabIndex = 4;
            flowBab.Paint += flowBab_Paint;
            // 
            // FormVidIPA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 554);
            Controls.Add(flowBab);
            Controls.Add(labelBack);
            Controls.Add(panel1);
            Name = "FormVidIPA";
            Text = "Form1";
            Load += FormHome_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelJudul;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label labelBack;
        private Label lblVideo;
        private Panel panel1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowBab;
    }
}
