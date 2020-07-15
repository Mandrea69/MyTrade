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
            if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HeikenHashiDaily_PPMonthly_EMAs)
            {
                //ChangeNameColumns(uc_gwOther, "D");
                //ChangeNameColumns(uc_gwSell, "D");
                //ChangeNameColumns(uc_gwBuy, "D");
                //this.uc_gwOther.Gw.Rows.Clear();
                //this.uc_gwOther.Gw.Refresh();
                //this.uc_gwSell.Gw.Rows.Clear();
                //this.uc_gwSell.Gw.Refresh();
                //this.uc_gwBuy.Gw.Rows.Clear();
                //this.uc_gwBuy.Gw.Refresh();
                //results = new List<Result>();

                MyTrade.Core.StrategyTest.Strategy_HA_Daily_PP_Monthly_EMAs strategy = new MyTrade.Core.StrategyTest.Strategy_HA_Daily_PP_Monthly_EMAs();
                strategy.GetResult += Strategy_GetResult; ;

                var instrument = from x in instruments
                                        where x.DisplayName == this.txtInstrument.Text
                                        select x;
                if (instrument.Count() > 0)
                {
                    strategy.Run(instrument.FirstOrDefault());
                }



            }
        }

        private void Strategy_GetResult(TestResult_Order result)
        {
            CreateRow(this.gwResults, result);
        }

        void CreateRow(DataGridView gw, TestResult_Order order)
        {
            DataGridViewRow row = new DataGridViewRow();


            row.CreateCells(gw);


            row.Cells[0].Value = order.Action;
            row.Cells[1].Value = order.OpenDate;
            row.Cells[2].Value = order.OpenPrice;
            row.Cells[3].Value = order.CloseDate;
            row.Cells[4].Value = order.ClosePrice;
            row.Cells[5].Value = order.Pips;
            gw.Rows.Add(row);
            gw.Refresh();

        }
    }
}
