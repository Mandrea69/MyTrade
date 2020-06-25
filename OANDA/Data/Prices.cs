using OANDA.Model;
using OANDA.Model.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace OANDA.Data
{
    public class Prices
    {
        public static List<Price> Price(string institution)
        {
            string responseString= Data.OANDARestResponse.Get(Constants.url.RATES + institution);
            var pricesResponse= JsonSerializer.Deserialize<PricesResponse>(responseString);
            List<Price> prices = new List<Price>();
            prices.AddRange(pricesResponse.prices);

            return prices;

        }
        public static double LastPrice(string institution)
        {
            double lastPrice = 0;
            string responseString = Data.OANDARestResponse.Get(Constants.url.RATES + institution);
            var pricesResponse = JsonSerializer.Deserialize<PricesResponse>(responseString);
            lastPrice = (Convert.ToDouble(pricesResponse.prices[0].closeoutAsk) + Convert.ToDouble(pricesResponse.prices[0].closeoutBid)) / 2;
                    
            return lastPrice;
        }


        public static List<Model.Candle> GetCandles(string instrument,int numberCandels,string granularity)
        {
            List<Model.Candle> candles = new List<Model.Candle>();
            string responseString = Data.OANDARestResponse.Get(Constants.url.Candels(instrument, numberCandels, granularity));
            var candlesResponse = JsonSerializer.Deserialize<CandleResponse>(responseString);
            foreach (var item in candlesResponse.candles)
            {
               
                Model.Candle _candle = new Model.Candle();
                _candle.Open = Convert.ToDouble(item.mid.o);
                _candle.Close = Convert.ToDouble(item.mid.c);
                _candle.Hight = Convert.ToDouble(item.mid.h);
                _candle.Low = Convert.ToDouble(item.mid.l);
                _candle.Complete = item.complete;
                _candle.Time = item.time.AddDays(1);

                if(_candle.Close>_candle.Open)
                {
                    _candle.OriginalColor = Constants.CandelColour.GREEN;
                        }
                else if (_candle.Close < _candle.Open)
                {
                    _candle.OriginalColor = Constants.CandelColour.RED;
                }

                candles.Add(_candle);
            }

    

            return candles;
        }
    }
}
