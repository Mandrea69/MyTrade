using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core
{
   public class Constants
    {
        public class Strategy
        {
            public static List<string> Strategies()
            {
                List<string> st = new List<string>();
                st.Add("HA Daily - EMAs");
                st.Add("HA Weekly - EMAs");
                st.Add("HA Monthly - EMAs");
                return st;
            }
            public static string HeikenHashiDaily_PPMonthly_EMAs= "HA Daily - EMAs";
            public static string HeikenHashiWeekly_PPMonthly_EMAs = "HA Weekly - EMAs";
            public static string HeikenHashiMonthly_PPMonthly_EMAs = "HA Monthly - EMAs";
          
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
