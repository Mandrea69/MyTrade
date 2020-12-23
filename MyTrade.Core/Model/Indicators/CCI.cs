using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core.Model.Indicators
{
    public class CCI
    {
        public DateTime Date
        {
            get;set;
        }
        public double Value
        {
            get;set;
        }
        public bool Over
        {
            get;set;
        }
        public Model.Candle Candle
        {
            get;set;
        }
    }
}
