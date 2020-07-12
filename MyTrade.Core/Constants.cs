using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core
{
   public class Constants
    {
        public class Strategy
        {
            public static string HeikenHashiDaily_PPMonthly_EMAs= "HA Daily - PP Monthly - EMAs";
            public static string HeikenHashiDaily_PivotPointWeekly = "HA Daily - PP Weekly";
            public static string HeikenHashiWeekly_PivotPointWeekly = "HA Weekly - PP Weekly";
            public static string HeikenHashiDaily_PivotPointMonthly = "HA Daily - PP Monthly";
            public static string HeikenHashiMonthly_PivotPointMonthly = "HA Monthly - PP Monthly";

        }
        public enum CandleColor
        {
            GREEN, RED
        }
        public enum Action
        {
            WAIT, BUY, SELL
        }
        public enum TimeFrame
        {
            DAILY,WEEKLY,MONTHLY
        }
        

    }
}
