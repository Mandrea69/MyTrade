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
            this.lblEMA = new System.Windows.Forms.Label();
            this.imgEma = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgEma)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEMA
            // 
            this.lblEMA.AutoSize = true;
            this.lblEMA.Location = new System.Drawing.Point(278, 46);
            this.lblEMA.Name = "lblEMA";
            this.lblEMA.Size = new System.Drawing.Size(80, 13);
            this.lblEMA.TabIndex = 0;
            this.lblEMA.Text = "Ema 21 periods";
            // 
            // imgEma
            // 
            this.imgEma.Location = new System.Drawing.Point(218, 28);
            this.imgEma.Name = "imgEma";
            this.imgEma.Size = new System.Drawing.Size(41, 31);
            this.imgEma.TabIndex = 1;
            this.imgEma.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Price";
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.Location = new System.Drawing.Point(101, 39);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPrice.TabIndex = 3;
            // 
            // InstrumentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEMA;
        private System.Windows.Forms.PictureBox imgEma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentPrice;
    }
}