using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTradeInterface.Dialog
{
    public partial class InstrumentDetails : Form
    {
        MyTrade.Core.Model.Result result;
        public MyTrade.Core.Model.Result Result
        {
            set
            {
                result = value;
                this.Text = "Details: " + this.result.DisplayName;
            }
        }
        public InstrumentDetails()
        {
            InitializeComponent();
        

        }

        private void InstrumentDetails_Load(object sender, EventArgs e)
        {
            this.txtCurrentPrice.Text = result.InstrumentDetails.Current.ToString();
        }
    }
}
