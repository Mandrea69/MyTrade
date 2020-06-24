using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model.Communication
{
   public  class WDIntradayResponse
    {
        public dataIntraday[] data { get; set; }
       public pagination pagination { get; set; }
    }

    public class dataIntraday
    {
       public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
           
        public DateTime date { get; set; }
    }

    


}
