namespace MyTradeInterface.Forms
{
    partial class Instruments_Currency
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
            this.gwInstruments = new System.Windows.Forms.DataGridView();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFavorite = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PipLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gwInstruments)).BeginInit();
            this.SuspendLayout();
            // 
            // gwInstruments
            // 
            this.gwInstruments.AllowUserToAddRows = false;
            this.gwInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwInstruments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Name,
            this.DisplayName,
            this.Type,
            this.IsFavorite,
            this.PipLocation,
            this.ID});
            this.gwInstruments.Location = new System.Drawing.Point(12, 55);
            this.gwInstruments.Name = "gwInstruments";
            this.gwInstruments.Size = new System.Drawing.Size(796, 492);
            this.gwInstruments.TabIndex = 1;
            this.gwInstruments.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gwInstruments_CellValueChanged);
            // 
            // _Name
            // 
            this._Name.DataPropertyName = "Name";
            this._Name.HeaderText = "Name";
            this._Name.Name = "_Name";
            this._Name.Width = 150;
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Width = 400;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // IsFavorite
            // 
            this.IsFavorite.DataPropertyName = "IsFavorite";
            this.IsFavorite.HeaderText = "Is Favorite";
            this.IsFavorite.Name = "IsFavorite";
            this.IsFavorite.Width = 80;
            // 
            // PipLocation
            // 
            this.PipLocation.DataPropertyName = "PipLocation";
            this.PipLocation.HeaderText = "PipLocation";
            this.PipLocation.Name = "PipLocation";
            this.PipLocation.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(194, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Instruments_Currency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 559);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gwInstruments);
            this.Name = "Instruments_Currency";
            this.Text = "Instruments Currency";
            ((System.ComponentModel.ISupportInitialize)(this.gwInstruments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gwInstruments;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFavorite;
        private System.Windows.Forms.DataGridViewTextBoxColumn PipLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}