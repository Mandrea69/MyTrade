using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.OANDA.Model
{
   public class Instrument
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
       public int PipLocation { get; set; }
    }
}
