using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Alphavantage.Model.Communication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonDayResponse
    {
        //public DateTime date { get; set; }
        //public double open { get; set; }
        //public double close { get; set; }
        //public double high { get; set; }
        //public double low { get; set; }
        //[JsonProperty("Meta Data")]
        //public Metadata Metadata { get; set; }
        //[JsonProperty("Time Series (Daily)")]
        //public List<JArray> TimeSeries { get; set; }


    }
   


    public class Metadata {
        [JsonProperty("1. Information")]
        public string Information { get; set; }
    }
   



    public class TimeSeries
    {


        [JsonProperty("1. open")]
        public double open { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double low { get; set; }
    }
}
