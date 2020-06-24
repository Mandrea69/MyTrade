using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model
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
    }
}
