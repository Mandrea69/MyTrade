using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model.Communication
{
   public  class WDHystoryResponse
    {
        public dataHistory[] data { get; set; }
       public pagination pagination { get; set; }
    }

    public class dataHistory
    {
       public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
        public double adj_high { get; set; }
        public double adj_low { get; set; }
        public double adj_close { get; set; }
        public double adj_open { get; set; }
     
        public DateTime date { get; set; }
    }

    


}
