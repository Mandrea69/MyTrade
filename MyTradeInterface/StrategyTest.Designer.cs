namespace MyTradeInterface
{
    partial class StrategyTest
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.cbStrategy = new System.Windows.Forms.ComboBox();
            this.cbTimeFrame = new System.Windows.Forms.ComboBox();
            this.pnlAutocomplete = new System.Windows.Forms.Panel();
            this.pnlYear = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gwResults = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gwResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(667, 39);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(97, 23);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cbStrategy
            // 
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Items.AddRange(new object[] {
            "HA Daily - PP Weekly",
            "HA Daily - PP Monthly",
            "HA Weekly - PP Weekly",
            "HA Monthly - PP Monthly",
            "HA Daily - PP Monthly - EMAs"});
            this.cbStrategy.Location = new System.Drawing.Point(12, 39);
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(257, 21);
            this.cbStrategy.TabIndex = 3;
            // 
            // cbTimeFrame
            // 
            this.cbTimeFrame.FormattingEnabled = true;
            this.cbTimeFrame.Items.AddRange(new object[] {
            "Daily",
            "Weely",
            "Monthly"});
            this.cbTimeFrame.Location = new System.Drawing.Point(275, 39);
            this.cbTimeFrame.Name = "cbTimeFrame";
            this.cbTimeFrame.Size = new System.Drawing.Size(121, 21);
            this.cbTimeFrame.TabIndex = 5;
            // 
            // pnlAutocomplete
            // 
            this.pnlAutocomplete.Location = new System.Drawing.Point(402, 39);
            this.pnlAutocomplete.Name = "pnlAutocomplete";
            this.pnlAutocomplete.Size = new System.Drawing.Size(151, 36);
            this.pnlAutocomplete.TabIndex = 6;
            // 
            // pnlYear
            // 
            this.pnlYear.Location = new System.Drawing.Point(561, 39);
            this.pnlYear.Name = "pnlYear";
            this.pnlYear.Size = new System.Drawing.Size(100, 36);
            this.pnlYear.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Strategy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Timeframe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(399, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Instrument";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(558, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Year";
            // 
            // gwResults
            // 
            this.gwResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.OpenDate,
            this.OpenPrice,
            this.CloseDate,
            this.ClosePrice,
            this.Pips});
            this.gwResults.Location = new System.Drawing.Point(15, 106);
            this.gwResults.Name = "gwResults";
            this.gwResults.Size = new System.Drawing.Size(796, 441);
            this.gwResults.TabIndex = 12;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // OpenDate
            // 
            this.OpenDate.HeaderText = "Open Date";
            this.OpenDate.Name = "OpenDate";
            // 
            // OpenPrice
            // 
            this.OpenPrice.HeaderText = "Open Price";
            this.OpenPrice.Name = "OpenPrice";
            // 
            // CloseDate
            // 
            this.CloseDate.HeaderText = "Close Date";
            this.CloseDate.Name = "CloseDate";
            // 
            // ClosePrice
            // 
            this.ClosePrice.HeaderText = "Close Price";
            this.ClosePrice.Name = "ClosePrice";
            // 
            // Pips
            // 
            this.Pips.HeaderText = "Pips";
            this.Pips.Name = "Pips";
            // 
            // StrategyTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 559);
            this.Controls.Add(this.gwResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlYear);
            this.Controls.Add(this.pnlAutocomplete);
            this.Controls.Add(this.cbTimeFrame);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cbStrategy);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StrategyTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Strategy Test";
            ((System.ComponentModel.ISupportInitialize)(this.gwResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cbStrategy;
        private System.Windows.Forms.ComboBox cbTimeFrame;
        private System.Windows.Forms.Panel pnlAutocomplete;
        private System.Windows.Forms.Panel pnlYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gwResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pips;
    }
}