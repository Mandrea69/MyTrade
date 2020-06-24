using System;
using System.Collections.Generic;
using System.Text;

namespace Alphavantage.Model
{
    public class StockTimeSeries
    {
    

        public DateTime LastRefreshed { get; set; }

        public string Symbol { get; set; }

        public ICollection<MaTrade.Core.Model.Candle> DataPoints { get; set; }
    }
}
