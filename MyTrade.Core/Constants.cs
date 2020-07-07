using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core
{
   public class Constants
    {
        public class Strategy
        {
            public static string HeikenHashiDaily_PivotPointDaily= "Heiken Hashi Daily - Pivot Point Daily";
            public static string HeikenHashiDaily_PivotPointWeekly = "Heiken Hashi Daily - Pivot Point Weekly";
            public static string HeikenHashiWeekly_PivotPointWeekly = "Heiken Hashi Weekly - Pivot Point Weekly";
            public static string HeikenHashiH4_PivotPointDaily = "Heiken Hashi H4 - Pivot Point Daily";


        }
        public enum CandleColor
        {
            GREEN, RED
        }
        public enum Action
        {
            WAIT, BUY, SELL
        }

        

    }
}
