using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTradeInterface.Forms
{
    public partial class Instuments_Stock : Form
    {
        bool loaded = false;
        List<MyTrade.Core.Model.Instrument> instruments = null;
        public Instuments_Stock()
        {
            InitializeComponent();
            instruments = MyTrade.Core.SqliteDataAccess.StockInstruments.LoadInstruments();
            this.gwInstruments.DataSource = instruments;
            loaded = true;


        }

        private void gwInstruments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void gwInstruments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(loaded==true)
            {
                if (e.ColumnIndex == 4)
                {
                    DataGridViewTextBoxCell cellID = (DataGridViewTextBoxCell)gwInstruments.Rows[e.RowIndex].Cells[5];
                    int ID = Convert.ToInt32(cellID.Value);


                    DataGridViewCheckBoxCell cellIsFavorite = (DataGridViewCheckBoxCell)gwInstruments.Rows[e.RowIndex].Cells[e.ColumnIndex];
                 MyTrade.Core.Model.Instrument instrument= (MyTrade.Core.Model.Instrument)   gwInstruments.Rows[e.RowIndex].DataBoundItem;
                    instrument.IsFavorite =Convert.ToBoolean( cellIsFavorite.Value);
                    MyTrade.Core.SqliteDataAccess.StockInstruments.UpdateIsFavorite(instrument);

                    
                }
            }


        }

       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filtered = from x in instruments
                           where x.DisplayName.ToLower().Contains(this.txtSearch.Text.ToLower()) || x.Name.ToLower().Contains(this.txtSearch.Text.ToLower())
                           select x;
            this.gwInstruments.DataSource = filtered.ToList<MyTrade.Core.Model.Instrument>();
        }
    }
}
