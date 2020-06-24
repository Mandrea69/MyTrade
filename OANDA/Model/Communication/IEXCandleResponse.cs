using OANDA.Model.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model.Communication
{
    public class IEXCandleResponse
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double marketOpen { get; set; }
        public double marketClose { get; set; }
        public double marketHigh { get; set; }
        public double marketLow { get; set; }
        public int numberOfTrades { get; set; }
       public string minute { get; set; }

    }
   
}
