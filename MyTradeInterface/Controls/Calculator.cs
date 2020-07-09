using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyTrade.OANDA;
using MyTrade.Core.Model;

namespace MyTradeInterface.Controls
{
    public partial class Calculator : UserControl
    {

        TextBox txtInstrument;
        List<Instrument> instruments = null;
        public string InstrumentDisplayName
        {
            set { this.txtInstrument.Text = value; }
        }
        public string StopLoss
        {
            set { this.txtStopLoss.Text = value; this.txtResult.Text = ""; }
        }

        public Calculator()
        {
            InitializeComponent();
         instruments=   MyTrade.OANDA.Data.Instrument.AllFromDB();
            var source = new AutoCompleteStringCollection();

            foreach (Instrument item in instruments)
            {
                source.Add(item.DisplayName);
            }
            

            txtInstrument = new TextBox
            {
                AutoCompleteCustomSource = source,
                AutoCompleteMode =
                           AutoCompleteMode.SuggestAppend,
                AutoCompleteSource =
                           AutoCompleteSource.CustomSource,
                Location = new Point(0, 0),
                Width = ClientRectangle.Width - 40,
                Visible = true
            };

            this.pnlAutocomplete.Controls.Add(txtInstrument);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if(this.txtInstrument.Text!="" && this.txtStopLoss.Text!="")
            {
                var instrumentDetails = from x in instruments
                                        where x.DisplayName == this.txtInstrument.Text
                                        select x;
                if(instrumentDetails.Count()>0)
                {
                    double currentPrice =MyTrade.OANDA.Data.Prices.LastPrice(instrumentDetails.FirstOrDefault().Name);
                    Calculate.Units units = new Calculate.Units(instrumentDetails.FirstOrDefault(), 100, currentPrice, Convert.ToDouble( this.txtStopLoss.Text));
                    this.txtResult.Text = units.Get().ToString();
                }
            }
        }
    }
}
