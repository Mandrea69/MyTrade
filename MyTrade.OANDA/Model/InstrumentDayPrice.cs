using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.OANDA.Model
{
   public  class InstrumentDayPrice
    {
        public double Current
        {
            get; set;
        }
        public double Min
        {
            get; set;
        }
        public double Max
        {
            get; set;
        }
        public double EMA
        {
            get; set;
        }
        public MyTrade.Model.Indicators.PivotPoint PivotPoints
        {
            get; set;
        }
       
    }
}
