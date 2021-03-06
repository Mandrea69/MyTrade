﻿namespace MyTradeInterface
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcessedItems = new System.Windows.Forms.TextBox();
            this.lblBuyItems = new System.Windows.Forms.Label();
            this.lblSellItems = new System.Windows.Forms.Label();
            this.txtTotalInstruments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblwait = new System.Windows.Forms.Label();
            this.pnlCalculator = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strategyTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHA_buy = new System.Windows.Forms.Panel();
            this.pnlHA_sell = new System.Windows.Forms.Panel();
            this.pnlHA_other = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.rbCurrencies = new System.Windows.Forms.RadioButton();
            this.rbStocks = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbStrategy
            // 
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(12, 56);
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(257, 21);
            this.cbStrategy.TabIndex = 0;
            this.cbStrategy.SelectedIndexChanged += new System.EventHandler(this.cbStrategy_SelectedIndexChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(275, 56);
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
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Instuments to buy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(500, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Instuments to sell";
            // 
            // txtProcessedItems
            // 
            this.txtProcessedItems.Location = new System.Drawing.Point(850, 59);
            this.txtProcessedItems.Name = "txtProcessedItems";
            this.txtProcessedItems.Size = new System.Drawing.Size(62, 20);
            this.txtProcessedItems.TabIndex = 7;
            // 
            // lblBuyItems
            // 
            this.lblBuyItems.AutoSize = true;
            this.lblBuyItems.Location = new System.Drawing.Point(128, 81);
            this.lblBuyItems.Name = "lblBuyItems";
            this.lblBuyItems.Size = new System.Drawing.Size(13, 13);
            this.lblBuyItems.TabIndex = 8;
            this.lblBuyItems.Text = "0";
            // 
            // lblSellItems
            // 
            this.lblSellItems.AutoSize = true;
            this.lblSellItems.Location = new System.Drawing.Point(615, 79);
            this.lblSellItems.Name = "lblSellItems";
            this.lblSellItems.Size = new System.Drawing.Size(13, 13);
            this.lblSellItems.TabIndex = 9;
            this.lblSellItems.Text = "0";
            // 
            // txtTotalInstruments
            // 
            this.txtTotalInstruments.Location = new System.Drawing.Point(918, 59);
            this.txtTotalInstruments.Name = "txtTotalInstruments";
            this.txtTotalInstruments.Size = new System.Drawing.Size(62, 20);
            this.txtTotalInstruments.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Instuments to wait";
            // 
            // lblwait
            // 
            this.lblwait.AutoSize = true;
            this.lblwait.Location = new System.Drawing.Point(129, 315);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(13, 13);
            this.lblwait.TabIndex = 14;
            this.lblwait.Text = "0";
            // 
            // pnlCalculator
            // 
            this.pnlCalculator.Location = new System.Drawing.Point(503, 328);
            this.pnlCalculator.Name = "pnlCalculator";
            this.pnlCalculator.Size = new System.Drawing.Size(481, 217);
            this.pnlCalculator.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.instrumentsToolStripMenuItem,
            this.orderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshDataToolStripMenuItem,
            this.strategyTestToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // refreshDataToolStripMenuItem
            // 
            this.refreshDataToolStripMenuItem.Name = "refreshDataToolStripMenuItem";
            this.refreshDataToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.refreshDataToolStripMenuItem.Text = "Refresh Data";
            this.refreshDataToolStripMenuItem.Click += new System.EventHandler(this.refreshDataToolStripMenuItem_Click);
            // 
            // strategyTestToolStripMenuItem
            // 
            this.strategyTestToolStripMenuItem.Name = "strategyTestToolStripMenuItem";
            this.strategyTestToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.strategyTestToolStripMenuItem.Text = "Strategy Test";
            this.strategyTestToolStripMenuItem.Click += new System.EventHandler(this.strategyTestToolStripMenuItem_Click);
            // 
            // instrumentsToolStripMenuItem
            // 
            this.instrumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currencyToolStripMenuItem,
            this.stockToolStripMenuItem});
            this.instrumentsToolStripMenuItem.Name = "instrumentsToolStripMenuItem";
            this.instrumentsToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.instrumentsToolStripMenuItem.Text = "Instruments";
            // 
            // currencyToolStripMenuItem
            // 
            this.currencyToolStripMenuItem.Name = "currencyToolStripMenuItem";
            this.currencyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.currencyToolStripMenuItem.Text = "Currency";
            this.currencyToolStripMenuItem.Click += new System.EventHandler(this.currencyToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // pnlHA_buy
            // 
            this.pnlHA_buy.Location = new System.Drawing.Point(12, 95);
            this.pnlHA_buy.Name = "pnlHA_buy";
            this.pnlHA_buy.Size = new System.Drawing.Size(480, 217);
            this.pnlHA_buy.TabIndex = 17;
            // 
            // pnlHA_sell
            // 
            this.pnlHA_sell.Location = new System.Drawing.Point(503, 95);
            this.pnlHA_sell.Name = "pnlHA_sell";
            this.pnlHA_sell.Size = new System.Drawing.Size(480, 217);
            this.pnlHA_sell.TabIndex = 18;
            this.pnlHA_sell.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlHA_other
            // 
            this.pnlHA_other.Location = new System.Drawing.Point(12, 328);
            this.pnlHA_other.Name = "pnlHA_other";
            this.pnlHA_other.Size = new System.Drawing.Size(480, 217);
            this.pnlHA_other.TabIndex = 19;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Image";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // rbCurrencies
            // 
            this.rbCurrencies.AutoSize = true;
            this.rbCurrencies.Checked = true;
            this.rbCurrencies.Location = new System.Drawing.Point(15, 33);
            this.rbCurrencies.Name = "rbCurrencies";
            this.rbCurrencies.Size = new System.Drawing.Size(75, 17);
            this.rbCurrencies.TabIndex = 20;
            this.rbCurrencies.TabStop = true;
            this.rbCurrencies.Text = "Currencies";
            this.rbCurrencies.UseVisualStyleBackColor = true;
            // 
            // rbStocks
            // 
            this.rbStocks.AutoSize = true;
            this.rbStocks.Location = new System.Drawing.Point(106, 33);
            this.rbStocks.Name = "rbStocks";
            this.rbStocks.Size = new System.Drawing.Size(58, 17);
            this.rbStocks.TabIndex = 21;
            this.rbStocks.Text = "Stocks";
            this.rbStocks.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 559);
            this.Controls.Add(this.rbStocks);
            this.Controls.Add(this.rbCurrencies);
            this.Controls.Add(this.pnlHA_other);
            this.Controls.Add(this.pnlHA_sell);
            this.Controls.Add(this.pnlHA_buy);
            this.Controls.Add(this.pnlCalculator);
            this.Controls.Add(this.lblwait);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalInstruments);
            this.Controls.Add(this.lblSellItems);
            this.Controls.Add(this.lblBuyItems);
            this.Controls.Add(this.txtProcessedItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cbStrategy);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Trade";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStrategy;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox txtProcessedItems;
        private System.Windows.Forms.Label lblBuyItems;
        private System.Windows.Forms.Label lblSellItems;
        private System.Windows.Forms.TextBox txtTotalInstruments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblwait;
        private System.Windows.Forms.Panel pnlCalculator;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshDataToolStripMenuItem;
        private System.Windows.Forms.Panel pnlHA_buy;
        private System.Windows.Forms.Panel pnlHA_sell;
        private System.Windows.Forms.Panel pnlHA_other;
        private System.Windows.Forms.ToolStripMenuItem strategyTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbCurrencies;
        private System.Windows.Forms.RadioButton rbStocks;
    }
}

