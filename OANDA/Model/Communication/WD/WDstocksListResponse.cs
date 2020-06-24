using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model.Communication
{
   public  class WDstocksListResponse
    {
        public data[] data { get; set; }
       public pagination pagination { get; set; }
    }

    public class data
    {
        public string name{ get; set; }
        public string symbol{ get; set; }

    }

    public class pagination  {
        public string limit { get; set; }
        public string offset { get; set; }
        public string count { get; set; }
        public string total { get; set; }
    }


}
