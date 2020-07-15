using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core.Model
{
   public  class TestResult_Order
    {
      

        public DateTime OpenDate { get; set; }
        public double OpenPrice { get; set; }

        public DateTime CloseDate { get; set; }
        public double ClosePrice { get; set; }
        public Constants.Action Action { get; set; }
      
        public double Pips { get; set; }
        public bool Close { get; set; }

    }
}
