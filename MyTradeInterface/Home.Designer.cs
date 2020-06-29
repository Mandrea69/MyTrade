namespace MyTradeInterface
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.cbStrategy = new System.Windows.Forms.ComboBox();
            this.gwBuy = new System.Windows.Forms.DataGridView();
            this.instrumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.D_HA_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.HA_H4_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.HA_H1_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.HA_M15_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.N_Candles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcessedItems = new System.Windows.Forms.TextBox();
            this.lblBuyItems = new System.Windows.Forms.Label();
            this.lblSellItems = new System.Windows.Forms.Label();
            this.gwSell = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalInstruments = new System.Windows.Forms.TextBox();
            this.gwWait = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblwait = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlCalculator = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gwBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwWait)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStrategy
            // 
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Items.AddRange(new object[] {
            "HA Daily",
            "HA Weekly"});
            this.cbStrategy.Location = new System.Drawing.Point(12, 12);
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(257, 21);
            this.cbStrategy.TabIndex = 0;
            this.cbStrategy.SelectedIndexChanged += new System.EventHandler(this.cbStrategy_SelectedIndexChanged);
            // 
            // gwBuy
            // 
            this.gwBuy.AllowUserToAddRows = false;
            this.gwBuy.AllowUserToDeleteRows = false;
            this.gwBuy.AllowUserToResizeColumns = false;
            this.gwBuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwBuy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.instrumentName,
            this.D_Candle,
            this.D_HA_Candle,
            this.HA_H4_Candle,
            this.HA_H1_Candle,
            this.HA_M15_Candle,
            this.N_Candles});
            this.gwBuy.Location = new System.Drawing.Point(15, 51);
            this.gwBuy.Name = "gwBuy";
            this.gwBuy.RowTemplate.Height = 32;
            this.gwBuy.Size = new System.Drawing.Size(464, 217);
            this.gwBuy.TabIndex = 1;
            // 
            // instrumentName
            // 
            this.instrumentName.DataPropertyName = "Name";
            this.instrumentName.Frozen = true;
            this.instrumentName.HeaderText = "Name";
            this.instrumentName.Name = "instrumentName";
            this.instrumentName.ReadOnly = true;
            // 
            // D_Candle
            // 
            this.D_Candle.Description = "Real Daily Candle";
            this.D_Candle.HeaderText = "D Real";
            this.D_Candle.Name = "D_Candle";
            this.D_Candle.ToolTipText = "Real Daily Candle";
            this.D_Candle.Width = 50;
            // 
            // D_HA_Candle
            // 
            this.D_HA_Candle.HeaderText = "D";
            this.D_HA_Candle.Name = "D_HA_Candle";
            this.D_HA_Candle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D_HA_Candle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.D_HA_Candle.Width = 50;
            // 
            // HA_H4_Candle
            // 
            this.HA_H4_Candle.HeaderText = "H4";
            this.HA_H4_Candle.Name = "HA_H4_Candle";
            this.HA_H4_Candle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HA_H4_Candle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HA_H4_Candle.Width = 50;
            // 
            // HA_H1_Candle
            // 
            this.HA_H1_Candle.HeaderText = "H1";
            this.HA_H1_Candle.Name = "HA_H1_Candle";
            this.HA_H1_Candle.Width = 50;
            // 
            // HA_M15_Candle
            // 
            this.HA_M15_Candle.HeaderText = "M15";
            this.HA_M15_Candle.Name = "HA_M15_Candle";
            this.HA_M15_Candle.Width = 50;
            // 
            // N_Candles
            // 
            this.N_Candles.HeaderText = "N";
            this.N_Candles.Name = "N_Candles";
            this.N_Candles.Width = 50;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(275, 12);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(97, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Instuments to buy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Instuments to sell";
            // 
            // txtProcessedItems
            // 
            this.txtProcessedItems.Location = new System.Drawing.Point(831, 12);
            this.txtProcessedItems.Name = "txtProcessedItems";
            this.txtProcessedItems.Size = new System.Drawing.Size(62, 20);
            this.txtProcessedItems.TabIndex = 7;
            // 
            // lblBuyItems
            // 
            this.lblBuyItems.AutoSize = true;
            this.lblBuyItems.Location = new System.Drawing.Point(128, 37);
            this.lblBuyItems.Name = "lblBuyItems";
            this.lblBuyItems.Size = new System.Drawing.Size(13, 13);
            this.lblBuyItems.TabIndex = 8;
            this.lblBuyItems.Text = "0";
            // 
            // lblSellItems
            // 
            this.lblSellItems.AutoSize = true;
            this.lblSellItems.Location = new System.Drawing.Point(611, 37);
            this.lblSellItems.Name = "lblSellItems";
            this.lblSellItems.Size = new System.Drawing.Size(13, 13);
            this.lblSellItems.TabIndex = 9;
            this.lblSellItems.Text = "0";
            // 
            // gwSell
            // 
            this.gwSell.AllowUserToAddRows = false;
            this.gwSell.AllowUserToDeleteRows = false;
            this.gwSell.AllowUserToResizeColumns = false;
            this.gwSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwSell.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn2,
            this.dataGridViewImageColumn3,
            this.dataGridViewImageColumn4,
            this.dataGridViewImageColumn5,
            this.dataGridViewImageColumn6,
            this.dataGridViewTextBoxColumn2});
            this.gwSell.Location = new System.Drawing.Point(499, 53);
            this.gwSell.Name = "gwSell";
            this.gwSell.RowTemplate.Height = 32;
            this.gwSell.Size = new System.Drawing.Size(464, 217);
            this.gwSell.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.Description = "Real Daily Candle";
            this.dataGridViewImageColumn2.HeaderText = "D Real";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Real Daily Candle";
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "D";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 50;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "H4";
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn4.Width = 50;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.HeaderText = "H1";
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.Width = 50;
            // 
            // dataGridViewImageColumn6
            // 
            this.dataGridViewImageColumn6.HeaderText = "M15";
            this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
            this.dataGridViewImageColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "N";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // txtTotalInstruments
            // 
            this.txtTotalInstruments.Location = new System.Drawing.Point(899, 12);
            this.txtTotalInstruments.Name = "txtTotalInstruments";
            this.txtTotalInstruments.Size = new System.Drawing.Size(62, 20);
            this.txtTotalInstruments.TabIndex = 11;
            // 
            // gwWait
            // 
            this.gwWait.AllowUserToAddRows = false;
            this.gwWait.AllowUserToDeleteRows = false;
            this.gwWait.AllowUserToResizeColumns = false;
            this.gwWait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwWait.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewImageColumn7,
            this.dataGridViewImageColumn8,
            this.dataGridViewImageColumn9,
            this.dataGridViewImageColumn10,
            this.dataGridViewImageColumn11,
            this.dataGridViewTextBoxColumn4});
            this.gwWait.Location = new System.Drawing.Point(15, 287);
            this.gwWait.Name = "gwWait";
            this.gwWait.RowTemplate.Height = 32;
            this.gwWait.Size = new System.Drawing.Size(464, 210);
            this.gwWait.TabIndex = 12;
            this.gwWait.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewImageColumn7
            // 
            this.dataGridViewImageColumn7.Description = "Real Daily Candle";
            this.dataGridViewImageColumn7.HeaderText = "D Real";
            this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
            this.dataGridViewImageColumn7.ToolTipText = "Real Daily Candle";
            this.dataGridViewImageColumn7.Width = 50;
            // 
            // dataGridViewImageColumn8
            // 
            this.dataGridViewImageColumn8.HeaderText = "D";
            this.dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
            this.dataGridViewImageColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn8.Width = 50;
            // 
            // dataGridViewImageColumn9
            // 
            this.dataGridViewImageColumn9.HeaderText = "H4";
            this.dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
            this.dataGridViewImageColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn9.Width = 50;
            // 
            // dataGridViewImageColumn10
            // 
            this.dataGridViewImageColumn10.HeaderText = "H1";
            this.dataGridViewImageColumn10.Name = "dataGridViewImageColumn10";
            this.dataGridViewImageColumn10.Width = 50;
            // 
            // dataGridViewImageColumn11
            // 
            this.dataGridViewImageColumn11.HeaderText = "M15";
            this.dataGridViewImageColumn11.Name = "dataGridViewImageColumn11";
            this.dataGridViewImageColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "N";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Instuments to wait";
            // 
            // lblwait
            // 
            this.lblwait.AutoSize = true;
            this.lblwait.Location = new System.Drawing.Point(129, 271);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(13, 13);
            this.lblwait.TabIndex = 14;
            this.lblwait.Text = "0";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Image";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // pnlCalculator
            // 
            this.pnlCalculator.Location = new System.Drawing.Point(499, 287);
            this.pnlCalculator.Name = "pnlCalculator";
            this.pnlCalculator.Size = new System.Drawing.Size(462, 207);
            this.pnlCalculator.TabIndex = 15;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 506);
            this.Controls.Add(this.pnlCalculator);
            this.Controls.Add(this.lblwait);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gwWait);
            this.Controls.Add(this.gwSell);
            this.Controls.Add(this.txtTotalInstruments);
            this.Controls.Add(this.lblSellItems);
            this.Controls.Add(this.lblBuyItems);
            this.Controls.Add(this.txtProcessedItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.gwBuy);
            this.Controls.Add(this.cbStrategy);
            this.Name = "Home";
            this.Text = "My Trade";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gwBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStrategy;
        private System.Windows.Forms.DataGridView gwBuy;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox txtProcessedItems;
        private System.Windows.Forms.Label lblBuyItems;
        private System.Windows.Forms.Label lblSellItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentName;
        private System.Windows.Forms.DataGridViewImageColumn D_Candle;
        private System.Windows.Forms.DataGridViewImageColumn D_HA_Candle;
        private System.Windows.Forms.DataGridViewImageColumn HA_H4_Candle;
        private System.Windows.Forms.DataGridViewImageColumn HA_H1_Candle;
        private System.Windows.Forms.DataGridViewImageColumn HA_M15_Candle;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_Candles;
        private System.Windows.Forms.DataGridView gwSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtTotalInstruments;
        private System.Windows.Forms.DataGridView gwWait;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn8;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn9;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn10;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblwait;
        private System.Windows.Forms.Panel pnlCalculator;
    }
}

