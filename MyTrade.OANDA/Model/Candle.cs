using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrade.OANDA.Model
{
    public class Candle
    {
        public DateTime Time { get; set; }
        public double Open {
            get;set;
        }
        public double Close {
            get; set;
        }
        public double Hight {
            get; set;
        }
        public double Low {
            get; set;
        }
        public bool Complete
        {
            get; set;
        }
        public Constants.CandleColor HaColor
        {
            get; set;
        }
        public Constants.CandleColor OriginalColor
        {
            get; set;
        }
    }
}
