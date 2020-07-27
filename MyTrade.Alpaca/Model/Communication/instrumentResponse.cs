using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Alpaca.Model.Communication
{

    public class jInstrument
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public bool tradable { get; set; }
        public bool easy_to_borrow { get; set; }

        public string exchange { get; set; }
    }

    }
