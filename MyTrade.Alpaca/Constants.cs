using System;
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


            public static string LastPrice(string instrument)
            {
             
                return "https://data.alpaca.markets/v1/last_quote/stocks/" +  instrument;
            }

            public static string Candles(string instrument, int numberCandels, string granularity)
            {
                return "https://data.alpaca.markets/v1/bars/" + granularity + "?symbols=" + instrument + "&limit=" + numberCandels;
            }
            public static string Candles(string instrument, DateTime from, string granularity)
            {
                string _from = from.ToString("yyyy-MM-dd");
                string url= "https://data.alpaca.markets/v1/bars/" + granularity + "?symbols=" + instrument + "&start=" + _from + "T09: 30:00 - 04:00";
               
                return url;
            }

            public static string Candles(string instrument, DateTime from, DateTime to, string granularity)
            {
                string _from = from.ToString("yyyy-MM-dd");
                string _to = to.ToString("yyyy-MM-dd");
                string url = "https://data.alpaca.markets/v1/bars/" + granularity + "?symbols=" + instrument + "&start=" + _from + "T09:30:00-04:00&end=" + _to  + "T09:30:00-04:00";

                return url;
            }
        }
      
    }
}
