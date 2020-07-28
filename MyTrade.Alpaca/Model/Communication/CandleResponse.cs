
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Alpaca.Model.Communication
{
    public class CandleResponse
    {
         
        public double o { get; set; }
        public double h { get; set; }
        public double l { get; set; }
        public double c { get; set; }
        public long t { get; set; }



    }
}
