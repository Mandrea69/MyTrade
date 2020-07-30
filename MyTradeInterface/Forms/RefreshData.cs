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
    public partial class RefreshData : Form
    {
        public RefreshData()
        {
            InitializeComponent();
        }

        private void btnRefreshInstruments_Click(object sender, EventArgs e)
        {
           List<Instrument> instruments= MyTrade.OANDA.Data.Instrument.All();
           MyTrade.Core.SqliteDataAccess.Instruments.SaveInstruments(instruments);
            this.lblModified.Text = DateTime.Now.ToString();
          
        }

        private void btnWeeklyCandles_Click(object sender, EventArgs e)
        {
            MyTrade.Core.SqliteDataAccess.WeekyCandles.CleanData();
            List<Instrument> instruments = MyTrade.OANDA.Data.Instrument.AllFromDB();
            foreach (var instrument in instruments)
            {
                List<Candle> candles= MyTrade.OANDA.Data.Prices.GetCandles(instrument.Name, 50, "W");
                MyTrade.Core.SqliteDataAccess.WeekyCandles.SaveCandles(candles);
                this.lblWeeklyRefresh.Text = DateTime.Now.ToString();
            }
        }

        private void btMonthlyRefresh_Click(object sender, EventArgs e)
        {
            MyTrade.Core.SqliteDataAccess.MonthlyCandles.CleanData();
            List<Instrument> instruments = MyTrade.OANDA.Data.Instrument.AllFromDB();
            foreach (var instrument in instruments)
            {
                List<Candle> candles = MyTrade.OANDA.Data.Prices.GetCandles(instrument.Name, 50, "M");
                MyTrade.Core.SqliteDataAccess.MonthlyCandles.SaveCandles(candles);
                this.LblMonthlyRefresh.Text = DateTime.Now.ToString();
            }
        }

        private void btnStockINstrumentsRefresh_Click(object sender, EventArgs e)
        {
            List<Instrument> instruments = MyTrade.Alpaca.Data.Instrument.All();
            MyTrade.Core.SqliteDataAccess.StockInstruments.SaveInstruments(instruments);
            this.lblStockInstumentsModiifed.Text = DateTime.Now.ToString();
        }

        private void btnStocksMontly_Click(object sender, EventArgs e)
        {
            MyTrade.Core.SqliteDataAccess.MonthlyStocksCandles.CleanData();
            List<Instrument> instruments = MyTrade.Alpaca.Data.Instrument.AllFromDB().Where(x=>x.IsFavorite==true).ToList();
            DateTime start = new DateTime();
            DateTime end = new DateTime();

            MyTrade.Core.Utilities.Calculate.Date.StartEndOfMonthBefore(DateTime.Now,out start,out end);
            foreach (Instrument  item in instruments)
            {
              List<MyTrade.Core.Model.Candle> candles = MyTrade.Alpaca.Data.Prices.GetCandles(item.Name, start, end, "1D");
                List<MyTrade.Core.Model.Candle> _candles = new List<Candle>();
                MyTrade.Core.Model.Candle monthlyBar=MyTrade.Core.Utilities.Calculate.Bars.MonthlyBar(candles);
                monthlyBar.Instrument = item.Name;
                _candles.Add(monthlyBar);
                MyTrade.Core.SqliteDataAccess.MonthlyStocksCandles.SaveCandles(_candles);
            }
        }

        private void btnStocksWeeklyCandles_Click(object sender, EventArgs e)
        {

            MyTrade.Core.SqliteDataAccess.WeekyStocksCandles.CleanData();
            List<Instrument> instruments = MyTrade.Alpaca.Data.Instrument.AllFromDB().Where(x => x.IsFavorite == true).ToList();
            DateTime start = new DateTime();
            DateTime end = new DateTime();

            MyTrade.Core.Utilities.Calculate.Date.StartEndOfWeekBefore(DateTime.Now, out start, out end);
            foreach (Instrument item in instruments)
            {
                List<MyTrade.Core.Model.Candle> candles = MyTrade.Alpaca.Data.Prices.GetCandles(item.Name, start, end, "1D");
                List<MyTrade.Core.Model.Candle> _candles = new List<Candle>();
                MyTrade.Core.Model.Candle weeklyBar = MyTrade.Core.Utilities.Calculate.Bars.WeeklyBar(candles);
                weeklyBar.Instrument = item.Name;
                _candles.Add(weeklyBar);
                MyTrade.Core.SqliteDataAccess.WeekyStocksCandles.SaveCandles(_candles);
            }

        }
    }
}
