namespace OMS.CVApp
{
    partial class Form2
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
      this.label1 = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.cmbAlg = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.imgMain = new System.Windows.Forms.PictureBox();
      this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
      this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblTotalTime = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.btnImgPrev = new System.Windows.Forms.Button();
      this.btnImgNext = new System.Windows.Forms.Button();
      this.btnImgPlay = new System.Windows.Forms.Button();
      this.btnFocus = new System.Windows.Forms.Button();
      this.btnDetect = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Type:";
      // 
      // cmbType
      // 
      this.cmbType.BackColor = System.Drawing.Color.Black;
      this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbType.ForeColor = System.Drawing.Color.White;
      this.cmbType.FormattingEnabled = true;
      this.cmbType.Location = new System.Drawing.Point(59, 22);
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size(157, 28);
      this.cmbType.TabIndex = 1;
      this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
      // 
      // cmbAlg
      // 
      this.cmbAlg.BackColor = System.Drawing.Color.Black;
      this.cmbAlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbAlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbAlg.ForeColor = System.Drawing.Color.White;
      this.cmbAlg.FormattingEnabled = true;
      this.cmbAlg.Location = new System.Drawing.Point(311, 22);
      this.cmbAlg.Name = "cmbAlg";
      this.cmbAlg.Size = new System.Drawing.Size(145, 28);
      this.cmbAlg.TabIndex = 3;
      this.cmbAlg.SelectedIndexChanged += new System.EventHandler(this.cmbAlg_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(271, 25);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Alg:";
      // 
      // imgMain
      // 
      this.imgMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.imgMain.Location = new System.Drawing.Point(32, 67);
      this.imgMain.Name = "imgMain";
      this.imgMain.Size = new System.Drawing.Size(424, 451);
      this.imgMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.imgMain.TabIndex = 4;
      this.imgMain.TabStop = false;
      // 
      // shapeContainer1
      // 
      this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
      this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
      this.shapeContainer1.Name = "shapeContainer1";
      this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
      this.shapeContainer1.Size = new System.Drawing.Size(809, 569);
      this.shapeContainer1.TabIndex = 5;
      this.shapeContainer1.TabStop = false;
      // 
      // lineShape1
      // 
      this.lineShape1.BorderColor = System.Drawing.Color.Gray;
      this.lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
      this.lineShape1.BorderWidth = 2;
      this.lineShape1.Name = "lineShape1";
      this.lineShape1.X1 = 496;
      this.lineShape1.X2 = 496;
      this.lineShape1.Y1 = 11;
      this.lineShape1.Y2 = 558;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(607, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 24);
      this.label3.TabIndex = 6;
      this.label3.Text = "Stats:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(539, 264);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(77, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "Precision:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(539, 216);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(119, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Weighted Time:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(539, 168);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(78, 20);
      this.label6.TabIndex = 9;
      this.label6.Text = "Avg Time:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(539, 120);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(86, 20);
      this.label7.TabIndex = 10;
      this.label7.Text = "Total Time:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(539, 312);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(57, 20);
      this.label8.TabIndex = 11;
      this.label8.Text = "Recall:";
      // 
      // lblTotalTime
      // 
      this.lblTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTotalTime.Location = new System.Drawing.Point(666, 120);
      this.lblTotalTime.Name = "lblTotalTime";
      this.lblTotalTime.Size = new System.Drawing.Size(100, 22);
      this.lblTotalTime.TabIndex = 12;
      // 
      // label11
      // 
      this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(666, 308);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(100, 22);
      this.label11.TabIndex = 15;
      // 
      // label12
      // 
      this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(666, 261);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(100, 22);
      this.label12.TabIndex = 16;
      // 
      // label13
      // 
      this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(666, 214);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(100, 22);
      this.label13.TabIndex = 17;
      // 
      // label14
      // 
      this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(666, 167);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(100, 22);
      this.label14.TabIndex = 18;
      // 
      // btnImgPrev
      // 
      this.btnImgPrev.BackColor = System.Drawing.Color.Black;
      this.btnImgPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnImgPrev.Location = new System.Drawing.Point(32, 524);
      this.btnImgPrev.Name = "btnImgPrev";
      this.btnImgPrev.Size = new System.Drawing.Size(78, 28);
      this.btnImgPrev.TabIndex = 19;
      this.btnImgPrev.Text = "Prev";
      this.btnImgPrev.UseVisualStyleBackColor = false;
      this.btnImgPrev.Click += new System.EventHandler(this.btnImgPrev_Click);
      // 
      // btnImgNext
      // 
      this.btnImgNext.BackColor = System.Drawing.Color.Black;
      this.btnImgNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnImgNext.Location = new System.Drawing.Point(377, 524);
      this.btnImgNext.Name = "btnImgNext";
      this.btnImgNext.Size = new System.Drawing.Size(78, 28);
      this.btnImgNext.TabIndex = 20;
      this.btnImgNext.Text = "Next";
      this.btnImgNext.UseVisualStyleBackColor = false;
      this.btnImgNext.Click += new System.EventHandler(this.btnImgNext_Click);
      // 
      // btnImgPlay
      // 
      this.btnImgPlay.BackColor = System.Drawing.Color.Black;
      this.btnImgPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnImgPlay.Location = new System.Drawing.Point(147, 524);
      this.btnImgPlay.Name = "btnImgPlay";
      this.btnImgPlay.Size = new System.Drawing.Size(78, 28);
      this.btnImgPlay.TabIndex = 21;
      this.btnImgPlay.Text = "Play";
      this.btnImgPlay.UseVisualStyleBackColor = false;
      // 
      // btnFocus
      // 
      this.btnFocus.BackColor = System.Drawing.Color.Black;
      this.btnFocus.FlatAppearance.BorderSize = 0;
      this.btnFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnFocus.Location = new System.Drawing.Point(784, 545);
      this.btnFocus.Name = "btnFocus";
      this.btnFocus.Size = new System.Drawing.Size(1, 1);
      this.btnFocus.TabIndex = 22;
      this.btnFocus.Text = "button4";
      this.btnFocus.UseVisualStyleBackColor = false;
      // 
      // btnDetect
      // 
      this.btnDetect.BackColor = System.Drawing.Color.Black;
      this.btnDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDetect.Location = new System.Drawing.Point(262, 524);
      this.btnDetect.Name = "btnDetect";
      this.btnDetect.Size = new System.Drawing.Size(78, 28);
      this.btnDetect.TabIndex = 23;
      this.btnDetect.Text = "Detect";
      this.btnDetect.UseVisualStyleBackColor = false;
      this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(809, 569);
      this.Controls.Add(this.btnDetect);
      this.Controls.Add(this.btnFocus);
      this.Controls.Add(this.btnImgPlay);
      this.Controls.Add(this.btnImgNext);
      this.Controls.Add(this.btnImgPrev);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.lblTotalTime);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.imgMain);
      this.Controls.Add(this.cmbAlg);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cmbType);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.shapeContainer1);
      this.ForeColor = System.Drawing.Color.White;
      this.Name = "Form2";
      this.Text = "Detector";
      this.Load += new System.EventHandler(this.Form2_Load);
      this.Click += new System.EventHandler(this.Form2_Click);
      ((System.ComponentModel.ISupportInitialize)(this.imgMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbAlg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox imgMain;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnImgPrev;
        private System.Windows.Forms.Button btnImgNext;
        private System.Windows.Forms.Button btnImgPlay;
        private System.Windows.Forms.Button btnFocus;
        private System.Windows.Forms.Button btnDetect;

    }
}

