using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OANDA.Model
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
        public Constants.CandelColour Color
        {
            get; set;
        }
        public Constants.CandelColour OriginalColor
        {
            get; set;
        }
    }
}
