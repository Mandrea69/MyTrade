using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MaTrade.Core.Model;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Alphavantage
{
    public class Stocks
    {
        public static List<Candle> GetDaysCandles(string instrument)
        {
            List<Candle> candles = new List<Candle>();
            string responseString = Data.Rest.Get(Constants.url.TIME_SERIES_DAILY(instrument));
            var jObject = (JObject)JsonConvert.DeserializeObject(responseString);
            Model.StockTimeSeries  stockTimeSeries= Parsing.Parsing.ParseStockQuotes(jObject);
            var a = "a";
          


            return candles;
        }
        public static List<Candle> GetIntraDaysCandles(string instrument)
        {
            List<Candle> candles = new List<Candle>();
            string responseString = Data.Rest.Get(Constants.url.TIME_SERIES_INTRADAY(instrument,Constants.Interval.minutes15));
            var jObject = (JObject)JsonConvert.DeserializeObject(responseString);
            Model.StockTimeSeries stockTimeSeries = Parsing.Parsing.ParseStockQuotes(jObject);
            var a = "a";


            //foreach (var item in candlesResponse.Where(x=>x.numberOfTrades>0))
            //{

            //    Model.Candle _candle = new Model.Candle();
            //    _candle.Open = Convert.ToDouble(item.open);
            //    _candle.Close = Convert.ToDouble(item.close);
            //    _candle.Hight = Convert.ToDouble(item.high);
            //    _candle.Low = Convert.ToDouble(item.low);
            //    _candle.Complete = true;
            //    string[] hm = item.minute.Split(':');
            //    _candle.Time = new DateTime(item.date.Year, item.date.Month, item.date.Day, Convert.ToInt16(hm[0]), Convert.ToInt16(hm[1]), 0);
            //    if (_candle.Close > _candle.Open)
            //    {
            //        _candle.OriginalColor = Constants.CandelColour.GREEN;
            //    }
            //    else if (_candle.Close < _candle.Open)
            //    {
            //        _candle.OriginalColor = Constants.CandelColour.RED;
            //    }

            //    candles.Add(_candle);
            //}


            return candles;
        }
    
    }
}


