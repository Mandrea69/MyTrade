using MyTrade.Core.Model;
using MyTrade.OANDA;
using MyTrade.OANDA.Model;
using MyTrade.OANDA.Model.Communication;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;
using static MyTrade.Core.Constants;

namespace MyTrade.OANDA.Data
{
    public class Prices
    {
        public static List<Price> Price(string institution)
        {
            string responseString= Data.OANDARestResponse.Get(Constants.url.RATES + institution);
            var pricesResponse= JsonConvert.DeserializeObject<PricesResponse>(responseString);
            List<Price> prices = new List<Price>();
            prices.AddRange(pricesResponse.prices);

            return prices;

        }
        public static double LastPrice(string institution)
        {
            double lastPrice = 0;
            string responseString = Data.OANDARestResponse.Get(Constants.url.RATES + institution);
            var pricesResponse = JsonConvert.DeserializeObject<PricesResponse>(responseString);
            lastPrice = (Convert.ToDouble(pricesResponse.prices[0].closeoutAsk) + Convert.ToDouble(pricesResponse.prices[0].closeoutBid)) / 2;
                    
            return lastPrice;
        }
        public static List<Candle> GetCandles(string instrument,int numberCandels,string granularity)
        {
            List<Candle> candles = new List<Candle>();
            string responseString = Data.OANDARestResponse.Get(Constants.url.Candels(instrument, numberCandels, granularity));
            var candlesResponse = JsonConvert.DeserializeObject<CandleResponse>(responseString);
            foreach (var item in candlesResponse.candles)
            {

                Candle _candle = new Candle();
                _candle.Instrument = instrument;
                _candle.Open = Convert.ToDouble(item.mid.o);
                _candle.Close = Convert.ToDouble(item.mid.c);
                _candle.High = Convert.ToDouble(item.mid.h);
                _candle.Low = Convert.ToDouble(item.mid.l);
                _candle.Complete = item.complete;
                _candle.Time = item.time.AddDays(1);

                if(_candle.Close>_candle.Open)
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
    }
}
