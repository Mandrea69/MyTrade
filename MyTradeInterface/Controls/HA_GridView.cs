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
        MyTrade.Core.Model.Result result;
        public MyTrade.Core.Model.Result Result
        {
            set
            {
                result = value;
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

          
            Dialog.InstrumentDetails iDetails = new Dialog.InstrumentDetails();
            iDetails.Result = this.result;
            iDetails.Show();
            
          
        }
    }
}
