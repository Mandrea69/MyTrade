﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyTrade.Alpaca
{
    public class Constants
    {
       
        public static string oaAccessToken = "101-004-15144635-001";
         public class url
        {
            public static string Instruments = "https://paper-api.alpaca.markets/v2/assets";

            public static string Candles(string instrument, int numberCandels, string granularity)
            {
                return "https://data.alpaca.markets/v1/bars/" + granularity + "?symbols=" + instrument + "&limit=" + numberCandels;
            }
            public static string Candles(string instrument, DateTime from, string granularity)
            {
                string url= "https://data.alpaca.markets/v1/bars/" + granularity + "?symbols=" + instrument + "&start=" + from.ToString("yyyy-MM-dd");
               
                return url;
            }
        }
      
    }
}
