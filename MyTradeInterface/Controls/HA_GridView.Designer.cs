namespace MyTradeInterface.Controls
{
    partial class HA_GridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gw = new System.Windows.Forms.DataGridView();
            this.instrumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.D_HA_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.HA_H4_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.HA_H1_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.HA_M15_Candle = new System.Windows.Forms.DataGridViewImageColumn();
            this.N_Candles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PPPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.SuspendLayout();
            // 
            // gw
            // 
            this.gw.AllowUserToAddRows = false;
            this.gw.AllowUserToDeleteRows = false;
            this.gw.AllowUserToResizeColumns = false;
            this.gw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.instrumentName,
            this.D_Candle,
            this.D_HA_Candle,
            this.HA_H4_Candle,
            this.HA_H1_Candle,
            this.HA_M15_Candle,
            this.N_Candles,
            this.PPPosition});
            this.gw.Location = new System.Drawing.Point(0, 0);
            this.gw.Name = "gw";
            this.gw.ReadOnly = true;
            this.gw.RowTemplate.Height = 32;
            this.gw.Size = new System.Drawing.Size(487, 220);
            this.gw.TabIndex = 2;
            this.gw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellDoubleClick);
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
            this.D_Candle.ReadOnly = true;
            this.D_Candle.ToolTipText = "Real Daily Candle";
            this.D_Candle.Width = 50;
            // 
            // D_HA_Candle
            // 
            this.D_HA_Candle.HeaderText = "D";
            this.D_HA_Candle.Name = "D_HA_Candle";
            this.D_HA_Candle.ReadOnly = true;
            this.D_HA_Candle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D_HA_Candle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.D_HA_Candle.Width = 50;
            // 
            // HA_H4_Candle
            // 
            this.HA_H4_Candle.HeaderText = "H4";
            this.HA_H4_Candle.Name = "HA_H4_Candle";
            this.HA_H4_Candle.ReadOnly = true;
            this.HA_H4_Candle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HA_H4_Candle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HA_H4_Candle.Width = 50;
            // 
            // HA_H1_Candle
            // 
            this.HA_H1_Candle.HeaderText = "H1";
            this.HA_H1_Candle.Name = "HA_H1_Candle";
            this.HA_H1_Candle.ReadOnly = true;
            this.HA_H1_Candle.Width = 50;
            // 
            // HA_M15_Candle
            // 
            this.HA_M15_Candle.HeaderText = "M15";
            this.HA_M15_Candle.Name = "HA_M15_Candle";
            this.HA_M15_Candle.ReadOnly = true;
            this.HA_M15_Candle.Width = 50;
            // 
            // N_Candles
            // 
            this.N_Candles.HeaderText = "N";
            this.N_Candles.Name = "N_Candles";
            this.N_Candles.ReadOnly = true;
            this.N_Candles.Width = 20;
            // 
            // PPPosition
            // 
            this.PPPosition.HeaderText = "PP";
            this.PPPosition.Name = "PPPosition";
            this.PPPosition.ReadOnly = true;
            this.PPPosition.Width = 50;
            // 
            // HA_GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gw);
            this.Name = "HA_GridView";
            this.Size = new System.Drawing.Size(465, 220);
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentName;
        private System.Windows.Forms.DataGridViewImageColumn D_Candle;
        private System.Windows.Forms.DataGridViewImageColumn D_HA_Candle;
        private System.Windows.Forms.DataGridViewImageColumn HA_H4_Candle;
        private System.Windows.Forms.DataGridViewImageColumn HA_H1_Candle;
        private System.Windows.Forms.DataGridViewImageColumn HA_M15_Candle;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_Candles;
        private System.Windows.Forms.DataGridViewTextBoxColumn PPPosition;
    }
}
