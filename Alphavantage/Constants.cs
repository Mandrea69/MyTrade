using System;
using System.Collections.Generic;
using System.Text;

namespace Alphavantage
{
   public  class Constants
    {

       
        public static string avAccessToken = "0DLPJNE8MSX5QS13";
        public class url
        {
          
            public static string TIME_SERIES_DAILY(string instrument)
            {
                  return "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=" + instrument + "&apikey=" + avAccessToken;
             }
            public static string TIME_SERIES_INTRADAY(string instrument, string interval)
            {

                return "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=" + instrument + "&interval=" + interval + "&apikey=" + avAccessToken;
                      

}

        }
        public class Interval
        {
            public const string stockQuotesHeader = "Stock Quotes";
            public static string minutes1 = "1min";
            public static string minutes5 = "5min";
            public static string minutes15 = "15min";
            public static string minutes30 = "30min";
            public static string minutes60 = "60min";

        }
        public class Parsing
        {
            internal static class MetaDataJsonTokens
        {
            public const string MetaDataHeader = "Meta Data";

            public const string InformationToken = "1. Information";
            public const string SymbolToken = "2. Symbol";
            public const string RefreshTimeToken = "3. Last Refreshed";
        }
            internal static class TimeSeriesJsonTokens
            {
                public const string TimeSeriesHeader = "Time Series";

                public const string AdjustedToken_1 = "Daily Time Series with Splits and Dividend Events";
                public const string AdjustedToken_2 = "Adjusted";

                public const string IntradayTimeSeriesTypeToken = "Intraday";
                public const string DailyTimeSeriesTypeToken = "Daily";
                public const string WeeklyTimeSeriesTypeToken = "Weekly";
                public const string MonthlyTimeSeriesTypeToken = "Monthly";

                public const string OpeningPriceToken = "1. open";
                public const string HighestPriceToken = "2. high";
                public const string LowestPriceToken = "3. low";
                public const string ClosingPriceToken = "4. close";

                public const string VolumeNonAdjustedToken = "5. volume";

                public const string VolumeAdjustedToken = "6. volume";
                public const string AdjustedClosingPriceToken = "5. adjusted close";
                public const string DividendAmountToken = "7. dividend amount";
                public const string SplitCoefficientToken = "8. split coefficient";

            }
        }
    }
}
