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

namespace MyTradeInterface
{
    public partial class Home : Form
    {
     
        public Home()
        {
            InitializeComponent();

            this.pnlCalculator.Controls.Add(new Calculator());
         
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

            if (cbStrategy.SelectedItem.ToString() == MyTrade.Core.Constants.Strategy.HA_Daily)
            {
                this.gwWait.Rows.Clear();
                this.gwWait.Refresh();
                this.gwSell.Rows.Clear();
                this.gwSell.Refresh();
                this.gwBuy.Rows.Clear();
                this.gwBuy.Refresh();


                MyTrade.OANDA.Strategy.HA_Daily haDailyStrategy = new MyTrade.OANDA.Strategy.HA_Daily();
                haDailyStrategy.GetResult += HaDailyStrategy_GetResult ;
                haDailyStrategy.Run();



            }
            else
            {
                List<MyTrade.OANDA.Model.Instrument> instruments = MyTrade.OANDA.Data.Instrument.AllFromFile(); ;
                var instrumentDetails = from x in instruments
                                        where x.Name == "NAS100_USD"
                                        select x;
              MessageBox.Show(  MyTrade.OANDA.Strategy.HA_Daily.HA_M15_Candles(instrumentDetails.FirstOrDefault()).HaColor.ToString());
            }

        }

       

        private void HaDailyStrategy_GetResult(MyTrade.OANDA.Model.Result result, int nInstruments)
        {
            this.txtTotalInstruments.Text = nInstruments.ToString();
            this.txtTotalInstruments.Refresh();
            if (result.Action == MyTrade.OANDA.Constants.Action.BUY)
            {
                CreateRow(gwBuy, result);
                processedBuyItems += 1;
                this.lblBuyItems.Text = processedBuyItems.ToString();
                this.lblBuyItems.Refresh();


            }
            else if (result.Action == MyTrade.OANDA.Constants.Action.SELL)
            {
                CreateRow(gwSell, result);
                processedSellItems += 1;
                this.lblSellItems.Text = processedSellItems.ToString();
                this.lblSellItems.Refresh();
            }
            else if (result.Action == MyTrade.OANDA.Constants.Action.WAIT)
            {
                CreateRow(gwWait, result);
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

        void CreateRow(DataGridView gw,MyTrade.OANDA.Model.Result result)
        {
            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(gw);

            row.Cells[0].Value = result.DisplayName;
            if (result.D_RealColor == MyTrade.OANDA.Constants.CandleColor.GREEN)
            {
                row.Cells[1].Value = Resources.green;
            }
            else
            {
                row.Cells[1].Value = Resources.red;
            }
            if (result.D_HA_Color == MyTrade.OANDA.Constants.CandleColor.GREEN)
            {
                row.Cells[2].Value = Resources.green;
            }
            else
            {
                row.Cells[2].Value = Resources.red;
            }
            if (result.H4_HA_Color == MyTrade.OANDA.Constants.CandleColor.GREEN)
            {
                row.Cells[3].Value = Resources.green;
            }
            else
            {
                row.Cells[3].Value = Resources.red;
            }
            if (result.H1_HA_Color == MyTrade.OANDA.Constants.CandleColor.GREEN)
            {
                row.Cells[4].Value = Resources.green;
            }
            else
            {
                row.Cells[4].Value = Resources.red;
            }
            if (result.M15_HA_Color == MyTrade.OANDA.Constants.CandleColor.GREEN)
            {
                row.Cells[5].Value = Resources.green;
            }
            else
            {
                row.Cells[5].Value = Resources.red;
            }

            row.Cells[6].Value = result.NumberHaCandles.ToString();
            gw.Rows.Add(row);
            gw.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
