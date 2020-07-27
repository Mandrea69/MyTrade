namespace MyTradeInterface
{
    partial class RefreshData
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
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.lblModified = new System.Windows.Forms.Label();
            this.btnRefreshInstruments = new System.Windows.Forms.Button();
            this.btnWeeklyCandles = new System.Windows.Forms.Button();
            this.gbWeeklyCandles = new System.Windows.Forms.GroupBox();
            this.lblWeeklyRefresh = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblMonthlyRefresh = new System.Windows.Forms.Label();
            this.btMonthlyRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStockInstumentsModiifed = new System.Windows.Forms.Label();
            this.btnStockINstrumentsRefresh = new System.Windows.Forms.Button();
            this.gbInstruments.SuspendLayout();
            this.gbWeeklyCandles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInstruments
            // 
            this.gbInstruments.Controls.Add(this.lblModified);
            this.gbInstruments.Controls.Add(this.btnRefreshInstruments);
            this.gbInstruments.Location = new System.Drawing.Point(12, 41);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Size = new System.Drawing.Size(200, 123);
            this.gbInstruments.TabIndex = 0;
            this.gbInstruments.TabStop = false;
            this.gbInstruments.Text = "Instruments";
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(23, 94);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(0, 13);
            this.lblModified.TabIndex = 1;
            // 
            // btnRefreshInstruments
            // 
            this.btnRefreshInstruments.Location = new System.Drawing.Point(26, 49);
            this.btnRefreshInstruments.Name = "btnRefreshInstruments";
            this.btnRefreshInstruments.Size = new System.Drawing.Size(146, 23);
            this.btnRefreshInstruments.TabIndex = 0;
            this.btnRefreshInstruments.Text = "Refresh";
            this.btnRefreshInstruments.UseVisualStyleBackColor = true;
            this.btnRefreshInstruments.Click += new System.EventHandler(this.btnRefreshInstruments_Click);
            // 
            // btnWeeklyCandles
            // 
            this.btnWeeklyCandles.Location = new System.Drawing.Point(26, 49);
            this.btnWeeklyCandles.Name = "btnWeeklyCandles";
            this.btnWeeklyCandles.Size = new System.Drawing.Size(146, 23);
            this.btnWeeklyCandles.TabIndex = 0;
            this.btnWeeklyCandles.Text = "Refresh";
            this.btnWeeklyCandles.UseVisualStyleBackColor = true;
            this.btnWeeklyCandles.Click += new System.EventHandler(this.btnWeeklyCandles_Click);
            // 
            // gbWeeklyCandles
            // 
            this.gbWeeklyCandles.Controls.Add(this.lblWeeklyRefresh);
            this.gbWeeklyCandles.Controls.Add(this.btnWeeklyCandles);
            this.gbWeeklyCandles.Location = new System.Drawing.Point(256, 41);
            this.gbWeeklyCandles.Name = "gbWeeklyCandles";
            this.gbWeeklyCandles.Size = new System.Drawing.Size(200, 123);
            this.gbWeeklyCandles.TabIndex = 1;
            this.gbWeeklyCandles.TabStop = false;
            this.gbWeeklyCandles.Text = "Weekly Candles";
            // 
            // lblWeeklyRefresh
            // 
            this.lblWeeklyRefresh.AutoSize = true;
            this.lblWeeklyRefresh.Location = new System.Drawing.Point(26, 94);
            this.lblWeeklyRefresh.Name = "lblWeeklyRefresh";
            this.lblWeeklyRefresh.Size = new System.Drawing.Size(0, 13);
            this.lblWeeklyRefresh.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblMonthlyRefresh);
            this.groupBox1.Controls.Add(this.btMonthlyRefresh);
            this.groupBox1.Location = new System.Drawing.Point(495, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 123);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monthly Candles";
            // 
            // LblMonthlyRefresh
            // 
            this.LblMonthlyRefresh.AutoSize = true;
            this.LblMonthlyRefresh.Location = new System.Drawing.Point(26, 94);
            this.LblMonthlyRefresh.Name = "LblMonthlyRefresh";
            this.LblMonthlyRefresh.Size = new System.Drawing.Size(0, 13);
            this.LblMonthlyRefresh.TabIndex = 1;
            // 
            // btMonthlyRefresh
            // 
            this.btMonthlyRefresh.Location = new System.Drawing.Point(26, 49);
            this.btMonthlyRefresh.Name = "btMonthlyRefresh";
            this.btMonthlyRefresh.Size = new System.Drawing.Size(146, 23);
            this.btMonthlyRefresh.TabIndex = 0;
            this.btMonthlyRefresh.Text = "Refresh";
            this.btMonthlyRefresh.UseVisualStyleBackColor = true;
            this.btMonthlyRefresh.Click += new System.EventHandler(this.btMonthlyRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStockInstumentsModiifed);
            this.groupBox2.Controls.Add(this.btnStockINstrumentsRefresh);
            this.groupBox2.Location = new System.Drawing.Point(12, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 123);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock Instruments";
            // 
            // lblStockInstumentsModiifed
            // 
            this.lblStockInstumentsModiifed.AutoSize = true;
            this.lblStockInstumentsModiifed.Location = new System.Drawing.Point(23, 94);
            this.lblStockInstumentsModiifed.Name = "lblStockInstumentsModiifed";
            this.lblStockInstumentsModiifed.Size = new System.Drawing.Size(0, 13);
            this.lblStockInstumentsModiifed.TabIndex = 1;
            // 
            // btnStockINstrumentsRefresh
            // 
            this.btnStockINstrumentsRefresh.Location = new System.Drawing.Point(26, 49);
            this.btnStockINstrumentsRefresh.Name = "btnStockINstrumentsRefresh";
            this.btnStockINstrumentsRefresh.Size = new System.Drawing.Size(146, 23);
            this.btnStockINstrumentsRefresh.TabIndex = 0;
            this.btnStockINstrumentsRefresh.Text = "Refresh";
            this.btnStockINstrumentsRefresh.UseVisualStyleBackColor = true;
            this.btnStockINstrumentsRefresh.Click += new System.EventHandler(this.btnStockINstrumentsRefresh_Click);
            // 
            // RefreshData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 559);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbWeeklyCandles);
            this.Controls.Add(this.gbInstruments);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefreshData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Refresh Data";
            this.gbInstruments.ResumeLayout(false);
            this.gbInstruments.PerformLayout();
            this.gbWeeklyCandles.ResumeLayout(false);
            this.gbWeeklyCandles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInstruments;
        private System.Windows.Forms.Button btnRefreshInstruments;
        private System.Windows.Forms.Button btnWeeklyCandles;
        private System.Windows.Forms.GroupBox gbWeeklyCandles;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.Label lblWeeklyRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblMonthlyRefresh;
        private System.Windows.Forms.Button btMonthlyRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStockInstumentsModiifed;
        private System.Windows.Forms.Button btnStockINstrumentsRefresh;
    }
}