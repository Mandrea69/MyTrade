using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core.Model
{
   public  class Result
    {
        
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Constants.CandleColor W_RealColor { get; set; }

        public Constants.CandleColor W_HA_Color { get; set; }
        public Constants.CandleColor D_RealColor { get; set; }

        public Constants.CandleColor D_HA_Color { get; set; }
        public Constants.CandleColor H4_HA_Color { get; set; }
        public Constants.CandleColor H1_HA_Color { get; set; }
        public Constants.CandleColor M15_HA_Color { get; set; }

        public Constants.Action Action { get; set; }
        public string Type { get; set; }
        public int NumberHaCandles { get; set; }

    }
}
