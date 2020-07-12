using MyTrade.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTradeInterface
{
    public partial class StrategyTest : Form
    {

        TextBox txtInstrument;
        TextBox txtYear;
        List<Instrument> instruments = null;
        public StrategyTest()
        {
            InitializeComponent();

            instruments = MyTrade.OANDA.Data.Instrument.AllFromDB();
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
                Width = 150,
                Visible = true
            };

            this.pnlAutocomplete.Controls.Add(txtInstrument);

            var source1 = new AutoCompleteStringCollection();

            for (int i = 2010; i <= DateTime.Today.Year; i++)
            {
                source.Add(i.ToString());
            }
            txtYear = new TextBox
            {
                AutoCompleteCustomSource = source,
                AutoCompleteMode =
                          AutoCompleteMode.SuggestAppend,
                AutoCompleteSource =
                          AutoCompleteSource.CustomSource,
                Location = new Point(0, 0),
                Width = 100,
                Visible = true
            };

            this.pnlYear.Controls.Add(txtYear);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

        }
    }
}
