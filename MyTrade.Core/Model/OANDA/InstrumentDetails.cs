using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core.Model
{
   public  class InstrumentDetails
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
        public Indicators.PivotPoint D_PivotPoints
        {
            get; set;
        }
        public Indicators.PivotPoint W_PivotPoints
        {
            get; set;
        }

    }
}
