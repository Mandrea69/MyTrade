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
                List<Candle> candles= MyTrade.OANDA.Data.Prices.GetCandles(instrument.Name, 21, "W");
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
                List<Candle> candles = MyTrade.OANDA.Data.Prices.GetCandles(instrument.Name, 21, "M");
                MyTrade.Core.SqliteDataAccess.MonthlyCandles.SaveCandles(candles);
                this.LblMonthlyRefresh.Text = DateTime.Now.ToString();
            }
        }
    }
}
