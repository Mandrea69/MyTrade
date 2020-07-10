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
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcessedItems = new System.Windows.Forms.TextBox();
            this.lblBuyItems = new System.Windows.Forms.Label();
            this.lblSellItems = new System.Windows.Forms.Label();
            this.txtTotalInstruments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblwait = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlCalculator = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHA_buy = new System.Windows.Forms.Panel();
            this.pnlHA_sell = new System.Windows.Forms.Panel();
            this.pnlHA_other = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbStrategy
            // 
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Items.AddRange(new object[] {
            "Heiken Hashi Daily - Pivot Point Weekly",
            "Heiken Hashi Daily - Pivot Point Monthly",
            "Heiken Hashi Weekly - Pivot Point Weekly",
            "Heiken Hashi Monthly - Pivot Point Monthly"});
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
            this.txtProcessedItems.TextChanged += new System.EventHandler(this.txtProcessedItems_TextChanged);
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
            this.txtTotalInstruments.TextChanged += new System.EventHandler(this.txtTotalInstruments_TextChanged);
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
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Image";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
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
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshDataToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // refreshDataToolStripMenuItem
            // 
            this.refreshDataToolStripMenuItem.Name = "refreshDataToolStripMenuItem";
            this.refreshDataToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.refreshDataToolStripMenuItem.Text = "Refresh Data";
            this.refreshDataToolStripMenuItem.Click += new System.EventHandler(this.refreshDataToolStripMenuItem_Click);
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
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 559);
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
            this.Load += new System.EventHandler(this.Home_Load);
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
    }
}

