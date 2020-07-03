using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTradeInterface.Controls
{
    public partial class HA_GridView : UserControl
    {
        public HA_GridView()
        {
            InitializeComponent();
        }
        List<MyTrade.Core.Model.Result> results;
        public List<MyTrade.Core.Model.Result> Results
        {
            set
            {
                results=value;
            }
        }
        public DataGridView Gw
        {
            get
            {
                return this.gw;
            }
        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           string instrumentDisplayName = this.gw.Rows[e.RowIndex].Cells[0].Value.ToString();

            var _result = from x in this.results
                          where x.DisplayName == instrumentDisplayName
                          select x;

            if (_result.FirstOrDefault().Action != MyTrade.Core.Constants.Action.WAIT)
            {
                Dialog.InstrumentDetails iDetails = new Dialog.InstrumentDetails();
                iDetails.Result = _result.FirstOrDefault();
                iDetails.Show();
            }
            
          
        }
    }
}
