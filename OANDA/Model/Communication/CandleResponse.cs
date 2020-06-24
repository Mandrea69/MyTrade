using OANDA.Model.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model.Communication
{
    public class CandleResponse
    {
            public DateTime time { get; set; }
        public List<candle> candles { get; set; }


    }
    public class candle
    {
        public bool complete { get; set; }
        public DateTime time { get; set; }
        public Mid mid { get; set; }
    }
    public class Mid
    {
        public string o { get; set; }
        public string h { get; set; }
        public string l { get; set; }
        public string c { get; set; }
    }
}
