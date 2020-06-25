using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OANDA
{
    public class Constants
    {

        public static string oaAccessToken = "101-004-15144635-001";
        public static string avAccessToken = "0DLPJNE8MSX5QS13";
        public static string iexAccessToken = "pk_00f25b7de71b4afcb414bf6356a8170c";
        public static string wdAccessToken = "441554a2a2e0c0536c06c2862ad46c0a";

        public class url
        {
            public static string RATES = "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/pricing?instruments=";
            public static string INSTRUMENTS = "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/instruments";
            public static string Candels(string instrument, int numberCandels, string granularity)
            {
                return "https://api-fxpractice.oanda.com/v3/accounts/" + oaAccessToken + "/instruments/" + instrument + "/candles?count=" + numberCandels + "&granularity=" + granularity;
            }
            public class IEX
            {
                public static string DAY_Candels(string instrument)
                {
                    return "https://cloud.iexapis.com/stable/stock/" + instrument + "/chart/5d?token=" + iexAccessToken + "&includeToday=true";

                }
                public static string IntraDAY_Candels(string instrument)
                {
                    string url = "https://cloud.iexapis.com/stable/stock/" + instrument + "/intraday-prices?token=" + iexAccessToken + "&chartInterval=1";
                    return url;


                }


            }
            public class WD
            {

                public static string STOCKSLIST()
                {
                    return "http://api.marketstack.com/v1/tickers?access_key=" + wdAccessToken;

                }
                public static string Hystory(string instrument)
                {
                    DateTime startDate = DateTime.Today.AddDays(-15);
                    return "http://api.marketstack.com/v1/eod?access_key=" + wdAccessToken + "&symbols=" + instrument + "&date_from=" + startDate.Year + "-" + startDate.Month.ToString().PadLeft(2, '0') + "-" + startDate.Day.ToString().PadLeft(2, '0');
                }
                public static string Intraday(string instrument, string interval)
                {

                    //return "https://api.marketstack.com/v1/intraday?access_key=" + wdAccessToken + "&symbols=" + instrument + "&interval=" + interval + "&date_from=" + DateTime.Today.Year + "-" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "-" + (DateTime.Today.Day-1).ToString().PadLeft(2, '0'); ;
                    return "https://api.marketstack.com/v1/intraday?access_key=" + wdAccessToken + "&symbols=" + instrument + "&interval=" + interval + "&date_from=" + DateTime.Today.Year + "-" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Today.Day.ToString().PadLeft(2, '0'); ;
                }



            }
        }

        public enum CandelColour
        {
            GREEN, RED
        }
        public enum TrendPhase
        {
            LONG, SHORT, BOTH
        }

        public static string AssemblyPath()
        {
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string theDirectory = Path.GetDirectoryName(fullPath);
            return theDirectory.Replace("bin\\Debug\\netcoreapp3.0", "");
        }
    }
}
