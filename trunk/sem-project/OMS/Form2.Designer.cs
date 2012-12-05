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
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.cmbAlg = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
      this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblTotalTime = new System.Windows.Forms.Label();
      this.lblRecall = new System.Windows.Forms.Label();
      this.lblPrecision = new System.Windows.Forms.Label();
      this.lblWeightedTime = new System.Windows.Forms.Label();
      this.lblAvgTime = new System.Windows.Forms.Label();
      this.btnImgPrev = new System.Windows.Forms.Button();
      this.btnImgNext = new System.Windows.Forms.Button();
      this.btnImgPlay = new System.Windows.Forms.Button();
      this.btnFocus = new System.Windows.Forms.Button();
      this.imgMain = new Emgu.CV.UI.ImageBox();
      this.lblLoading = new System.Windows.Forms.Label();
      this.tmrStats = new System.Windows.Forms.Timer(this.components);
      this.lblImgName = new System.Windows.Forms.Label();
      this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
      this.label10 = new System.Windows.Forms.Label();
      this.lblWarning = new System.Windows.Forms.Label();
      this.lblNotice = new System.Windows.Forms.Label();
      this.tmrPlay = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(24, 25);
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
      this.cmbType.Location = new System.Drawing.Point(73, 22);
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
      this.cmbAlg.Location = new System.Drawing.Point(307, 22);
      this.cmbAlg.Name = "cmbAlg";
      this.cmbAlg.Size = new System.Drawing.Size(145, 28);
      this.cmbAlg.TabIndex = 3;
      this.cmbAlg.SelectedIndexChanged += new System.EventHandler(this.cmbAlg_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(267, 25);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Alg:";
      // 
      // shapeContainer1
      // 
      this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
      this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
      this.shapeContainer1.Name = "shapeContainer1";
      this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
      this.shapeContainer1.Size = new System.Drawing.Size(809, 578);
      this.shapeContainer1.TabIndex = 5;
      this.shapeContainer1.TabStop = false;
      // 
      // lineShape1
      // 
      this.lineShape1.BorderColor = System.Drawing.Color.Gray;
      this.lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
      this.lineShape1.BorderWidth = 2;
      this.lineShape1.Name = "lineShape1";
      this.lineShape1.X1 = 491;
      this.lineShape1.X2 = 491;
      this.lineShape1.Y1 = 11;
      this.lineShape1.Y2 = 558;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(620, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 24);
      this.label3.TabIndex = 6;
      this.label3.Text = "Stats:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(537, 236);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(77, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "Precision:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(537, 188);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(119, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Weighted Time:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(537, 140);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(78, 20);
      this.label6.TabIndex = 9;
      this.label6.Text = "Avg Time:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(537, 92);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(86, 20);
      this.label7.TabIndex = 10;
      this.label7.Text = "Total Time:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(537, 284);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(57, 20);
      this.label8.TabIndex = 11;
      this.label8.Text = "Recall:";
      // 
      // lblTotalTime
      // 
      this.lblTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTotalTime.Location = new System.Drawing.Point(664, 92);
      this.lblTotalTime.Name = "lblTotalTime";
      this.lblTotalTime.Size = new System.Drawing.Size(100, 22);
      this.lblTotalTime.TabIndex = 12;
      // 
      // lblRecall
      // 
      this.lblRecall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblRecall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblRecall.Location = new System.Drawing.Point(664, 280);
      this.lblRecall.Name = "lblRecall";
      this.lblRecall.Size = new System.Drawing.Size(100, 22);
      this.lblRecall.TabIndex = 15;
      // 
      // lblPrecision
      // 
      this.lblPrecision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPrecision.Location = new System.Drawing.Point(664, 233);
      this.lblPrecision.Name = "lblPrecision";
      this.lblPrecision.Size = new System.Drawing.Size(100, 22);
      this.lblPrecision.TabIndex = 16;
      // 
      // lblWeightedTime
      // 
      this.lblWeightedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblWeightedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblWeightedTime.Location = new System.Drawing.Point(664, 186);
      this.lblWeightedTime.Name = "lblWeightedTime";
      this.lblWeightedTime.Size = new System.Drawing.Size(100, 22);
      this.lblWeightedTime.TabIndex = 17;
      // 
      // lblAvgTime
      // 
      this.lblAvgTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblAvgTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAvgTime.Location = new System.Drawing.Point(664, 139);
      this.lblAvgTime.Name = "lblAvgTime";
      this.lblAvgTime.Size = new System.Drawing.Size(100, 22);
      this.lblAvgTime.TabIndex = 18;
      // 
      // btnImgPrev
      // 
      this.btnImgPrev.BackColor = System.Drawing.Color.Black;
      this.btnImgPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnImgPrev.Location = new System.Drawing.Point(28, 506);
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
      this.btnImgNext.Location = new System.Drawing.Point(373, 506);
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
      this.btnImgPlay.Location = new System.Drawing.Point(201, 535);
      this.btnImgPlay.Name = "btnImgPlay";
      this.btnImgPlay.Size = new System.Drawing.Size(78, 28);
      this.btnImgPlay.TabIndex = 21;
      this.btnImgPlay.Text = "Play";
      this.btnImgPlay.UseVisualStyleBackColor = false;
      this.btnImgPlay.Click += new System.EventHandler(this.btnImgPlay_Click);
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
      // imgMain
      // 
      this.imgMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.imgMain.Location = new System.Drawing.Point(28, 56);
      this.imgMain.Name = "imgMain";
      this.imgMain.Size = new System.Drawing.Size(423, 445);
      this.imgMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.imgMain.TabIndex = 2;
      this.imgMain.TabStop = false;
      // 
      // lblLoading
      // 
      this.lblLoading.AutoSize = true;
      this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLoading.ForeColor = System.Drawing.Color.Silver;
      this.lblLoading.Location = new System.Drawing.Point(564, 428);
      this.lblLoading.Name = "lblLoading";
      this.lblLoading.Size = new System.Drawing.Size(174, 24);
      this.lblLoading.TabIndex = 24;
      this.lblLoading.Text = "LOADING STATS...";
      // 
      // tmrStats
      // 
      this.tmrStats.Tick += new System.EventHandler(this.tmrStats_Tick);
      // 
      // lblImgName
      // 
      this.lblImgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblImgName.ForeColor = System.Drawing.Color.DarkGray;
      this.lblImgName.Location = new System.Drawing.Point(143, 506);
      this.lblImgName.Name = "lblImgName";
      this.lblImgName.Size = new System.Drawing.Size(193, 23);
      this.lblImgName.TabIndex = 25;
      this.lblImgName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lineShape2
      // 
      this.lineShape2.BorderColor = System.Drawing.Color.Gray;
      this.lineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
      this.lineShape2.BorderWidth = 2;
      this.lineShape2.Name = "lineShape2";
      this.lineShape2.X1 = 792;
      this.lineShape2.X2 = 510;
      this.lineShape2.Y1 = 349;
      this.lineShape2.Y2 = 349;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(617, 380);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(76, 24);
      this.label10.TabIndex = 27;
      this.label10.Text = "Notice:";
      // 
      // lblWarning
      // 
      this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblWarning.ForeColor = System.Drawing.Color.Olive;
      this.lblWarning.Location = new System.Drawing.Point(510, 475);
      this.lblWarning.Name = "lblWarning";
      this.lblWarning.Size = new System.Drawing.Size(283, 24);
      this.lblWarning.TabIndex = 28;
      this.lblWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lblNotice
      // 
      this.lblNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNotice.ForeColor = System.Drawing.Color.White;
      this.lblNotice.Location = new System.Drawing.Point(510, 522);
      this.lblNotice.Name = "lblNotice";
      this.lblNotice.Size = new System.Drawing.Size(283, 24);
      this.lblNotice.TabIndex = 29;
      this.lblNotice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // tmrPlay
      // 
      this.tmrPlay.Interval = 2000;
      this.tmrPlay.Tick += new System.EventHandler(this.tmrPlay_Tick);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(809, 578);
      this.Controls.Add(this.lblNotice);
      this.Controls.Add(this.lblWarning);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.lblImgName);
      this.Controls.Add(this.lblLoading);
      this.Controls.Add(this.imgMain);
      this.Controls.Add(this.btnFocus);
      this.Controls.Add(this.btnImgPlay);
      this.Controls.Add(this.btnImgNext);
      this.Controls.Add(this.btnImgPrev);
      this.Controls.Add(this.lblAvgTime);
      this.Controls.Add(this.lblWeightedTime);
      this.Controls.Add(this.lblPrecision);
      this.Controls.Add(this.lblRecall);
      this.Controls.Add(this.lblTotalTime);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
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
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblRecall;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.Label lblWeightedTime;
        private System.Windows.Forms.Label lblAvgTime;
        private System.Windows.Forms.Button btnImgPrev;
        private System.Windows.Forms.Button btnImgNext;
        private System.Windows.Forms.Button btnImgPlay;
        private System.Windows.Forms.Button btnFocus;
        private Emgu.CV.UI.ImageBox imgMain;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer tmrStats;
        private System.Windows.Forms.Label lblImgName;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Timer tmrPlay;

    }
}

