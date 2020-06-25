using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model
{
    public class Price
    {
        public string instrument { get; set; }
        public DateTime time { get; set; }
        public List<bid> bids { get; set; }
        public List<ask> asks { get; set; }

        public string closeoutAsk { get; set; }
        public string closeoutBid { get; set; }
    }

    public class ask
    {
        public string price { get; set; }
    }
    public class bid
    {
        public string price { get; set; }
    }



}
