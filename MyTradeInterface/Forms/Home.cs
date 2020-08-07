using MyTrade.Core;
using MyTrade.Core.Indicators;
using MyTrade.Core.Model;
using MyTrade.Core.Model.Indicators;
using MyTrade.OANDA.Indicators;
using MyTradeInterface.Controls;
using MyTradeInterface.Properties;
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
using static MyTrade.Core.Constants;

namespace MyTradeInterface
{
    public partial class Home : Form
    {

        HA_GridView uc_gwBuy = new HA_GridView();
        HA_GridView uc_gwSell = new HA_GridView();
        HA_GridView uc_gwOther = new HA_GridView();
        List<Result> results = null;
        Calculator calculator = new Calculator();
        public Home()
        {
            InitializeComponent();

            this.pnlCalculator.Controls.Add(calculator);
            this.pnlHA_buy.Controls.Add(uc_gwBuy);
            this.pnlHA_sell.Controls.Add(uc_gwSell);
            this.pnlHA_other.Controls.Add(uc_gwOther);
            uc_gwOther.SelectedRow += Uc_gwOther_SelectedRow;
            uc_gwSell.SelectedRow += Uc_gwOther_SelectedRow;
            uc_gwBuy.SelectedRow += Uc_gwOther_SelectedRow;

            this.cbStrategy.DataSource = Constants.Strategy.Strategies();


        }

        private void Uc_gwOther_SelectedRow(Result result)
        {
            if(this.rbCurrencies.Checked)
            {
                calculator.IsCurrency = true;
            }
            calculator.InstrumentDisplayName = result.Instrument.DisplayName;

          if(result.InstrumentDetails!=null)
            {
                if (result.InstrumentDetails.TimeFrame == TimeFrame.MONTHLY)
                {
                    this.calculator.StopLoss = result.InstrumentDetails.M_PivotPoints.PP.ToString();
                }
                else
                {
                    this.calculator.StopLoss = result.InstrumentDetails.W_PivotPoints.PP.ToString();

                }
            }
          

        }

        int processedItems;
        int processedBuyItems;
        int processedSellItems;
        int processedWaitItems;

        private void cbStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            processedItems = 0;
            processedBuyItems = 0;
            processedSellItems = 0;
            processedWaitItems = 0;

          
           if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HeikenHashiDaily_PPMonthly_EMAs)
            {
                if(this.rbCurrencies.Checked==true)
                {
                    ChangeNameColumns(uc_gwOther, "D");
                    ChangeNameColumns(uc_gwSell, "D");
                    ChangeNameColumns(uc_gwBuy, "D");
                    this.uc_gwOther.Gw.Rows.Clear();
                    this.uc_gwOther.Gw.Refresh();
                    this.uc_gwSell.Gw.Rows.Clear();
                    this.uc_gwSell.Gw.Refresh();
                    this.uc_gwBuy.Gw.Rows.Clear();
                    this.uc_gwBuy.Gw.Refresh();
                    results = new List<Result>();

                    MyTrade.Core.Strategy.HA_EMAs.Daily haHA_EMAs_Strategy = new MyTrade.Core.Strategy.HA_EMAs.Daily();
                    haHA_EMAs_Strategy.GetResult += HaDailyStrategy_GetResult;
                    haHA_EMAs_Strategy.Run();

                }
                else
                {
                    ChangeNameColumns(uc_gwOther, "D");
                    ChangeNameColumns(uc_gwSell, "D");
                    ChangeNameColumns(uc_gwBuy, "D");
                    this.uc_gwOther.Gw.Rows.Clear();
                    this.uc_gwOther.Gw.Refresh();
                    this.uc_gwSell.Gw.Rows.Clear();
                    this.uc_gwSell.Gw.Refresh();
                    this.uc_gwBuy.Gw.Rows.Clear();
                    this.uc_gwBuy.Gw.Refresh();
                    results = new List<Result>();

                    MyTrade.Core.Strategy.HA_EMAs.Stocks.Daily haHA_EMAs_Strategy = new MyTrade.Core.Strategy.HA_EMAs.Stocks.Daily();
                    haHA_EMAs_Strategy.GetResult += HaDailyStrategy_GetResult;
                    haHA_EMAs_Strategy.Run();

                }


             



            }
            else if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HeikenHashiWeekly_PPMonthly_EMAs)
            {
                if (this.rbCurrencies.Checked == true)
                {
                    ChangeNameColumns(uc_gwOther, "W");
                    ChangeNameColumns(uc_gwSell, "W");
                    ChangeNameColumns(uc_gwBuy, "W");
                    this.uc_gwOther.Gw.Rows.Clear();
                    this.uc_gwOther.Gw.Refresh();
                    this.uc_gwSell.Gw.Rows.Clear();
                    this.uc_gwSell.Gw.Refresh();
                    this.uc_gwBuy.Gw.Rows.Clear();
                    this.uc_gwBuy.Gw.Refresh();
                    results = new List<Result>();

                    MyTrade.Core.Strategy.HA_EMAs.Weekly haHA_EMAs_Strategy = new MyTrade.Core.Strategy.HA_EMAs.Weekly();
                    haHA_EMAs_Strategy.GetResult += HaDailyStrategy_GetResult;
                    haHA_EMAs_Strategy.Run();

                }
                else
                {


                }

             



            }
            else if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HeikenHashiMonthly_PPMonthly_EMAs)
            {

                if (this.rbCurrencies.Checked == true)
                {
                    ChangeNameColumns(uc_gwOther, "M");
                    ChangeNameColumns(uc_gwSell, "M");
                    ChangeNameColumns(uc_gwBuy, "M");
                    this.uc_gwOther.Gw.Rows.Clear();
                    this.uc_gwOther.Gw.Refresh();
                    this.uc_gwSell.Gw.Rows.Clear();
                    this.uc_gwSell.Gw.Refresh();
                    this.uc_gwBuy.Gw.Rows.Clear();
                    this.uc_gwBuy.Gw.Refresh();
                    results = new List<Result>();

                    MyTrade.Core.Strategy.HA_EMAs.Monthly haHA_EMAs_Strategy = new MyTrade.Core.Strategy.HA_EMAs.Monthly();
                    haHA_EMAs_Strategy.GetResult += HaDailyStrategy_GetResult;
                    haHA_EMAs_Strategy.Run();

                }
                else
                {


                }
               



            }








            else
            {

                //List<MyTrade.Core.Model.Candle> wcandles=    MyTrade.Core.SqliteDataAccess.WeekyCandles.LoadCandles("EUR_USD");
                //   PivotPoints pps = new PivotPoints();
                //     PivotPoint wpps = pps.Get(wcandles[wcandles.Count - 2]);


                //    List<Candle> candles = MyTrade.OANDA.Data.Prices.GetCandles("EUR_USD", 21, "D");
                //    PivotPoints pps1 = new PivotPoints();
                //   PivotPoint _pps1 = pps.Get(candles[candles.Count - 2]);


                //    MessageBox.Show(wpps.PP.ToString()  + " " + _pps1.PP.ToString());




            }

        }



        private void HaDailyStrategy_GetResult(Result result, int nInstruments)
        {
            this.txtTotalInstruments.Text = nInstruments.ToString();
            this.txtTotalInstruments.Refresh();
            if (result.Action == MyTrade.Core.Constants.Action.BUY)
            {

                CreateRow(uc_gwBuy, result);
                processedBuyItems += 1;
                this.lblBuyItems.Text = processedBuyItems.ToString();
                this.lblBuyItems.Refresh();

                results.Add(result);
            }
            else if (result.Action == MyTrade.Core.Constants.Action.SELL)
            {
                CreateRow(uc_gwSell, result);
                processedSellItems += 1;
                this.lblSellItems.Text = processedSellItems.ToString();
                this.lblSellItems.Refresh();
                results.Add(result);
            }
            else if (result.Action == MyTrade.Core.Constants.Action.WAIT)
            {
                CreateRow(this.uc_gwOther, result);
                processedWaitItems += 1;
                this.lblwait.Text = processedWaitItems.ToString();
                this.lblwait.Refresh();
                results.Add(result);
            }

            processedItems += 1;
            this.txtProcessedItems.Text = processedItems.ToString();
            this.txtProcessedItems.Refresh();


            this.uc_gwBuy.Results = results;
            this.uc_gwSell.Results = results;
            this.uc_gwOther.Results = results;
        }

        void CreateRow(HA_GridView uc_gw, Result result)
        {
            DataGridViewRow row = new DataGridViewRow();


            row.CreateCells(uc_gw.Gw);


            row.Cells[0].Value = result.Instrument.DisplayName;
            if (result.D_RealColor == MyTrade.Core.Constants.CandleColor.GREEN)
            {
                row.Cells[1].Value = Resources.green;
            }
            else
            {
                row.Cells[1].Value = Resources.red;
            }
            if (result.D_HA_Color == MyTrade.Core.Constants.CandleColor.GREEN)
            {
                row.Cells[2].Value = Resources.green;
            }
            else
            {
                row.Cells[2].Value = Resources.red;
            }
            if (result.H4_HA_Color == CandleColor.GREEN)
            {
                row.Cells[3].Value = Resources.green;
            }
            else
            {
                row.Cells[3].Value = Resources.red;
            }
            if (result.H1_HA_Color == CandleColor.GREEN)
            {
                row.Cells[4].Value = Resources.green;
            }
            else
            {
                row.Cells[4].Value = Resources.red;
            }
            if (result.M15_HA_Color == CandleColor.GREEN)
            {
                row.Cells[5].Value = Resources.green;
            }
            else
            {
                row.Cells[5].Value = Resources.red;
            }

            row.Cells[6].Value = result.NumberHaCandles.ToString();
            if (result.PivotPointsPosition != null)
                row.Cells[7].Value = result.PivotPointsPosition.ToString();
            uc_gw.Gw.Rows.Add(row);
            uc_gw.Gw.Refresh();

        }
        void ChangeNameColumns(HA_GridView uc_gw, string type)
        {
            if (type == "W")
            {
                uc_gw.Gw.Columns[2].HeaderText = "W";
                uc_gw.Gw.Columns[3].HeaderText = "D";
                uc_gw.Gw.Columns[4].HeaderText = "H4";
                uc_gw.Gw.Columns[5].HeaderText = "H1";
            }
            else if (type == "D")
            {
                uc_gw.Gw.Columns[2].HeaderText = "D";
                uc_gw.Gw.Columns[3].HeaderText = "H4";
                uc_gw.Gw.Columns[4].HeaderText = "H1";
                uc_gw.Gw.Columns[5].HeaderText = "M15";
            }
            else if (type == "M")
            {

                uc_gw.Gw.Columns[2].HeaderText = "M";
                uc_gw.Gw.Columns[3].HeaderText = "W";
                uc_gw.Gw.Columns[4].HeaderText = "D";
                uc_gw.Gw.Columns[5].HeaderText = "H4";
            }







        }

        private void refreshDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData rd = new RefreshData();
            rd.ShowDialog(this);
        }
        private void strategyTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StrategyTest rd = new StrategyTest();
            rd.ShowDialog(this);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTradeInterface.Forms.Instruments_Currency rd = new MyTradeInterface.Forms.Instruments_Currency();
            rd.ShowDialog(this);
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTradeInterface.Forms.Instuments_Stock rd = new MyTradeInterface.Forms.Instuments_Stock();
            rd.ShowDialog(this);
        }
    }
}
