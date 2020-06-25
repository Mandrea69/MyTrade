using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model
{
    
      public  class PricesResponse
        {
            public DateTime time { get; set; }

            public List<Price> prices { get; set; }
        }
}