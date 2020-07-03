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

        public Home()
        {
            InitializeComponent();

            this.pnlCalculator.Controls.Add(new Calculator());
            this.pnlHA_buy.Controls.Add(uc_gwBuy);
            this.pnlHA_sell.Controls.Add(uc_gwSell);
            this.pnlHA_other.Controls.Add(uc_gwOther);

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
            processedItems=0;
          processedBuyItems=0;
          processedSellItems=0;
          processedWaitItems=0;

            if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HeikenHashiDaily_PivotPointDaily)
            {
                this.uc_gwOther.Gw.Rows.Clear();
                this.uc_gwOther.Gw.Refresh();
                this.uc_gwSell.Gw.Rows.Clear();
                this.uc_gwSell.Refresh();
                this.uc_gwBuy.Gw.Rows.Clear();
                this.uc_gwBuy.Gw.Refresh();


                MyTrade.OANDA.Strategy.Strategy_HA_Daily_PP_DAily haDailyStrategy = new MyTrade.OANDA.Strategy.Strategy_HA_Daily_PP_DAily();
                haDailyStrategy.GetResult += HaDailyStrategy_GetResult ;
                haDailyStrategy.Run();



            }
           else if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HeikenHashiDaily_PivotPointWeekly)
            {
                this.uc_gwOther.Gw.Rows.Clear();
                this.uc_gwOther.Gw.Refresh();
                this.uc_gwSell.Gw.Rows.Clear();
                this.uc_gwSell.Gw.Refresh();
                this.uc_gwBuy.Gw.Rows.Clear();
                this.uc_gwBuy.Gw.Refresh();


                MyTrade.OANDA.Strategy.Strategy_HA_Daily_PP_Weekly haDailyStrategy = new MyTrade.OANDA.Strategy.Strategy_HA_Daily_PP_Weekly();
                haDailyStrategy.GetResult += HaDailyStrategy_GetResult;
                haDailyStrategy.Run();



            }
            else
            {

            List<MyTrade.Core.Model.Candle> wcandles=    MyTrade.Core.SqliteDataAccess.WeekyCandles.LoadCandles("EUR_USD");
               PivotPoints pps = new PivotPoints();
                 PivotPoint wpps = pps.Get(wcandles[wcandles.Count - 2]);


                List<Candle> candles = MyTrade.OANDA.Data.Prices.GetCandles("EUR_USD", 21, "D");
                PivotPoints pps1 = new PivotPoints();
               PivotPoint _pps1 = pps.Get(candles[candles.Count - 2]);


                MessageBox.Show(wpps.PP.ToString()  + " " + _pps1.PP.ToString());




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


            }
            else if (result.Action == MyTrade.Core.Constants.Action.SELL)
            {
                CreateRow(uc_gwSell, result);
                processedSellItems += 1;
                this.lblSellItems.Text = processedSellItems.ToString();
                this.lblSellItems.Refresh();
            }
            else if (result.Action == MyTrade.Core.Constants.Action.WAIT)
            {
                CreateRow(this.uc_gwOther, result);
                processedWaitItems += 1;
                this.lblwait.Text = processedWaitItems.ToString();
                this.lblwait.Refresh();
            }

            processedItems += 1;
            this.txtProcessedItems.Text = processedItems.ToString();
            this.txtProcessedItems.Refresh();

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        void CreateRow(HA_GridView uc_gw, Result result)
        {
            DataGridViewRow row = new DataGridViewRow();
            uc_gw.Result = result;

            row.CreateCells(uc_gw.Gw);
           

            row.Cells[0].Value = result.DisplayName;
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
            if (result.H4_HA_Color ==CandleColor.GREEN)
            {
                row.Cells[3].Value = Resources.green;
            }
            else
            {
                row.Cells[3].Value = Resources.red;
            }
            if (result.H1_HA_Color ==CandleColor.GREEN)
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
            uc_gw.Gw.Rows.Add(row);
            uc_gw.Gw.Refresh();
           
        }


        private void refreshDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData rd = new RefreshData();
            rd.ShowDialog(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
