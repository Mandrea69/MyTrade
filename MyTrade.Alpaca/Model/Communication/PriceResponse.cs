using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Alpaca.Model
{

    public class PricesResponse
    {
        public DateTime time { get; set; }
        public string symbol { get; set; }
        public last last{get;set;}

   }
    public class last
    {
        public double askprice { get; set; }
        public double bidprice { get; set; }
    }
}
