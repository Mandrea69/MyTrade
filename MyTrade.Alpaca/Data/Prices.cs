
using MyTrade.Alpaca.Model;
using MyTrade.Alpaca.Model.Communication;
using MyTrade.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MyTrade.Core.Constants;

namespace MyTrade.Alpaca.Data
{
    public class Prices
    {
        //public static List<Price> Price(string institution)
        //{
        //    string responseString= Data.Call.Get(Constants.url.RATES + institution);
        //    var pricesResponse= JsonConvert.DeserializeObject<PricesResponse>(responseString);
        //    List<Price> prices = new List<Price>();
        //    prices.AddRange(pricesResponse.prices);

        //    return prices;

        //}
        public static double LastPrice(string instruments)
        {
            double lastPrice = 0;
            string responseString = Data.Call.Get(Constants.url.LastPrice(instruments));
            var pricesResponse = JsonConvert.DeserializeObject<PricesResponse>(responseString);
            lastPrice = (Convert.ToDouble(pricesResponse.last.askprice) + Convert.ToDouble(pricesResponse.last.bidprice)) / 2;

            return lastPrice;
        }
        public static List<Candle> GetCandles(string instrument,int numberCandels,string granularity)
        {
            List<Candle> candles = new List<Candle>();
            string responseString = Data.Call.Get(Constants.url.Candles(instrument, numberCandels, granularity));

            int index = responseString.IndexOf(":");

            responseString = responseString.Substring(index + 1);
            int index1 = responseString.LastIndexOf("}");
            responseString = responseString.Substring(0, index1);

            JArray a = JArray.Parse(responseString);
          
            IList<CandleResponse> jCandles = a.Select(p => new CandleResponse
            {
                o = (double)p["o"],
                c = (double)p["c"],
                h = (double)p["h"],
                 l = (double)p["l"],
                t = (long)p["t"],


            }).ToList();

            foreach (var item in jCandles)
            {

                Candle _candle = new Candle();
                _candle.Instrument = instrument;
                _candle.Open = Convert.ToDouble(item.o);
                _candle.Close = Convert.ToDouble(item.c);
                _candle.High = Convert.ToDouble(item.h);
                _candle.Low = Convert.ToDouble(item.l);
                _candle.Complete = true;
                _candle.Time = FromUnixTime(item.t);

                if (_candle.Close>_candle.Open)
                {
                    _candle.OriginalColor = CandleColor.GREEN;
                        }
                else if (_candle.Close < _candle.Open)
                {
                    _candle.OriginalColor = CandleColor.RED;
                }

                candles.Add(_candle);
            }

    

            return candles;
        }
        public static List<Candle> GetCandles(string instrument, DateTime from, string granularity)
        {
            List<Candle> candles = new List<Candle>();
            string responseString = Data.Call.Get(Constants.url.Candles(instrument, from, granularity));
            int index = responseString.IndexOf(":");

            responseString = responseString.Substring(index + 1);
            int index1 = responseString.LastIndexOf("}");
            responseString = responseString.Substring(0, index1);
            JArray a = JArray.Parse(responseString);
            IList<CandleResponse> jCandles = a.Select(p => new CandleResponse
            {
                o = (double)p["o"],
                c = (double)p["c"],
                h = (double)p["h"],
                l = (double)p["l"],
                t = (long)p["t"],


            }).ToList();

            foreach (var item in jCandles)
            {

                Candle _candle = new Candle();
                _candle.Instrument = instrument;
                _candle.Open = Convert.ToDouble(item.o);
                _candle.Close = Convert.ToDouble(item.c);
                _candle.High = Convert.ToDouble(item.h);
                _candle.Low = Convert.ToDouble(item.l);
                _candle.Complete = true;
                _candle.Time = FromUnixTime(item.t);

                if (_candle.Close > _candle.Open)
                {
                    _candle.OriginalColor = CandleColor.GREEN;
                }
                else if (_candle.Close < _candle.Open)
                {
                    _candle.OriginalColor = CandleColor.RED;
                }

                candles.Add(_candle);
            }



            return candles;
        }
        public static List<Candle> GetCandles(string instrument, DateTime from, DateTime to, string granularity)
        {
            List<Candle> candles = new List<Candle>();
            string responseString = Data.Call.Get(Constants.url.Candles(instrument, from,to, granularity));
            int index = responseString.IndexOf(":");
           
            responseString = responseString.Substring(index+1);
            int index1 = responseString.LastIndexOf("}");
            responseString = responseString.Substring(0,index1);


            JArray a = JArray.Parse(responseString);
            IList<CandleResponse> jCandles = a.Select(p => new CandleResponse
            {
                o = (double)p["o"],
                c = (double)p["c"],
                h = (double)p["h"],
                l = (double)p["l"],
                t = (long)p["t"],


            }).ToList();

            foreach (var item in jCandles)
            {

                Candle _candle = new Candle();
                _candle.Instrument = instrument;
                _candle.Open = Convert.ToDouble(item.o);
                _candle.Close = Convert.ToDouble(item.c);
                _candle.High = Convert.ToDouble(item.h);
                _candle.Low = Convert.ToDouble(item.l);
                _candle.Complete = true;
                _candle.Time = FromUnixTime(item.t);

                if (_candle.Close > _candle.Open)
                {
                    _candle.OriginalColor = CandleColor.GREEN;
                }
                else if (_candle.Close < _candle.Open)
                {
                    _candle.OriginalColor = CandleColor.RED;
                }

                candles.Add(_candle);
            }



            return candles;
        }

        static DateTime FromUnixTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
           
        }
      
    }
}
