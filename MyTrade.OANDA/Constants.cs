using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyTrade.OANDA
{
    public class Constants
    {

        public static string oaAccessToken = "101-004-15144635-001";
         public class url
        {
            public static string RATES = "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/pricing?instruments=";
            public static string INSTRUMENTS = "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/instruments";
            public static string Candels(string instrument, int numberCandels, string granularity)
            {
                return "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/instruments/" + instrument + "/candles?count=" + numberCandels + "&granularity=" + granularity;
            }
            public static string Candels(string instrument, DateTime from, string granularity)
            {

                string url = "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/instruments/" + instrument + "/candles?from=" + from.ToString("yyyy-MM-dd") + "&granularity=" + granularity;

                return url;
            }
        }
      
    }
}
