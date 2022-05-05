
namespace CLCControl.Forms
{
    partial class CLCMessageBox
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
            this.components = new System.ComponentModel.Container();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.closePic = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.msgLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePic)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPic
            // 
            this.logoPic.Image = global::CLCControl.Properties.Resources.info;
            this.logoPic.Location = new System.Drawing.Point(12, 12);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(48, 48);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            // 
            // closePic
            // 
            this.closePic.Image = global::CLCControl.Properties.Resources.close;
            this.closePic.Location = new System.Drawing.Point(256, 21);
            this.closePic.Name = "closePic";
            this.closePic.Size = new System.Drawing.Size(32, 32);
            this.closePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.closePic.TabIndex = 1;
            this.closePic.TabStop = false;
            this.closePic.Click += new System.EventHandler(this.ClosePic_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // msgLbl
            // 
            this.msgLbl.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgLbl.ForeColor = System.Drawing.Color.White;
            this.msgLbl.Location = new System.Drawing.Point(72, 12);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(170, 48);
            this.msgLbl.TabIndex = 2;
            this.msgLbl.Text = "label1";
            this.msgLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CLCMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(300, 70);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.closePic);
            this.Controls.Add(this.logoPic);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(300, 70);
            this.Name = "CLCMessageBox";
            this.Text = "CLCMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPic;
        internal System.Windows.Forms.PictureBox closePic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label msgLbl;
    }
}