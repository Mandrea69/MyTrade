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

        public double uOpen { get; set; }
        public double uClose { get; set; }
        public double uHigh { get; set; }
        public double uLow { get; set; }


    }
   
}
