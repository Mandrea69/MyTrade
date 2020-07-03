namespace MyTradeInterface.Dialog
{
    partial class InstrumentDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentDetails));
            this.lblEMA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.imgEma = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtD_R1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtD_PP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtD_R2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtD_S2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtD_S1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtW_S1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtW_S2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtW_R2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtW_PP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtW_R1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgEma)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEMA
            // 
            this.lblEMA.AutoSize = true;
            this.lblEMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMA.Location = new System.Drawing.Point(242, 46);
            this.lblEMA.Name = "lblEMA";
            this.lblEMA.Size = new System.Drawing.Size(94, 13);
            this.lblEMA.TabIndex = 0;
            this.lblEMA.Text = "Ema 21 periods";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Price";
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.Location = new System.Drawing.Point(105, 39);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPrice.TabIndex = 3;
            // 
            // imgEma
            // 
            this.imgEma.Image = ((System.Drawing.Image)(resources.GetObject("imgEma.Image")));
            this.imgEma.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgEma.InitialImage")));
            this.imgEma.Location = new System.Drawing.Point(207, 39);
            this.imgEma.Name = "imgEma";
            this.imgEma.Size = new System.Drawing.Size(29, 30);
            this.imgEma.TabIndex = 1;
            this.imgEma.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtD_S1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtD_S2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtD_R2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtD_PP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtD_R1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(30, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 180);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daily Pivot Points";
            // 
            // txtD_R1
            // 
            this.txtD_R1.Location = new System.Drawing.Point(54, 55);
            this.txtD_R1.Name = "txtD_R1";
            this.txtD_R1.ReadOnly = true;
            this.txtD_R1.Size = new System.Drawing.Size(100, 20);
            this.txtD_R1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "R1";
            // 
            // txtD_PP
            // 
            this.txtD_PP.Location = new System.Drawing.Point(54, 81);
            this.txtD_PP.Name = "txtD_PP";
            this.txtD_PP.ReadOnly = true;
            this.txtD_PP.Size = new System.Drawing.Size(100, 20);
            this.txtD_PP.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "PP";
            // 
            // txtD_R2
            // 
            this.txtD_R2.Location = new System.Drawing.Point(54, 29);
            this.txtD_R2.Name = "txtD_R2";
            this.txtD_R2.ReadOnly = true;
            this.txtD_R2.Size = new System.Drawing.Size(100, 20);
            this.txtD_R2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "R2";
            // 
            // txtD_S2
            // 
            this.txtD_S2.Location = new System.Drawing.Point(54, 133);
            this.txtD_S2.Name = "txtD_S2";
            this.txtD_S2.ReadOnly = true;
            this.txtD_S2.Size = new System.Drawing.Size(100, 20);
            this.txtD_S2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "S2";
            // 
            // txtD_S1
            // 
            this.txtD_S1.Location = new System.Drawing.Point(54, 107);
            this.txtD_S1.Name = "txtD_S1";
            this.txtD_S1.ReadOnly = true;
            this.txtD_S1.Size = new System.Drawing.Size(100, 20);
            this.txtD_S1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "S1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtW_S1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtW_S2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtW_R2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtW_PP);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtW_R1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(245, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 180);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Weekly Pivot Points";
            // 
            // txtW_S1
            // 
            this.txtW_S1.Location = new System.Drawing.Point(54, 107);
            this.txtW_S1.Name = "txtW_S1";
            this.txtW_S1.ReadOnly = true;
            this.txtW_S1.Size = new System.Drawing.Size(100, 20);
            this.txtW_S1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "S1";
            // 
            // txtW_S2
            // 
            this.txtW_S2.Location = new System.Drawing.Point(54, 133);
            this.txtW_S2.Name = "txtW_S2";
            this.txtW_S2.ReadOnly = true;
            this.txtW_S2.Size = new System.Drawing.Size(100, 20);
            this.txtW_S2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "S2";
            // 
            // txtW_R2
            // 
            this.txtW_R2.Location = new System.Drawing.Point(54, 29);
            this.txtW_R2.Name = "txtW_R2";
            this.txtW_R2.ReadOnly = true;
            this.txtW_R2.Size = new System.Drawing.Size(100, 20);
            this.txtW_R2.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "R2";
            // 
            // txtW_PP
            // 
            this.txtW_PP.Location = new System.Drawing.Point(54, 81);
            this.txtW_PP.Name = "txtW_PP";
            this.txtW_PP.ReadOnly = true;
            this.txtW_PP.Size = new System.Drawing.Size(100, 20);
            this.txtW_PP.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "PP";
            // 
            // txtW_R1
            // 
            this.txtW_R1.Location = new System.Drawing.Point(54, 55);
            this.txtW_R1.Name = "txtW_R1";
            this.txtW_R1.ReadOnly = true;
            this.txtW_R1.Size = new System.Drawing.Size(100, 20);
            this.txtW_R1.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "R1";
            // 
            // InstrumentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 342);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCurrentPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgEma);
            this.Controls.Add(this.lblEMA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstrumentDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrument Details";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InstrumentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgEma)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEMA;
        private System.Windows.Forms.PictureBox imgEma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtD_S1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtD_S2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtD_R2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtD_PP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtD_R1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtW_S1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtW_S2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtW_R2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtW_PP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtW_R1;
        private System.Windows.Forms.Label label11;
    }
}