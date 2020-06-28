using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.OANDA.Model
{
    
      public  class PricesResponse
        {
            public DateTime time { get; set; }

            public List<Price> prices { get; set; }
        }
}