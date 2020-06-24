using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace OANDA.Data.WD
{
    public class Stocks
    {

       
       public static void DailyCandles(string instrument)
        {

            string responseString = Data.RestResponse.WDGet(Constants.url.WD.Hystory(instrument));
            var candlesHistoryResponse = JsonConvert.DeserializeObject<Model.Communication.WDHystoryResponse>(responseString);
            
            
            foreach (var item in candlesHistoryResponse.data)
            {

                Model.Candle _candle = new Model.Candle();
                _candle.Open = Convert.ToDouble(item.open);
                _candle.Close = Convert.ToDouble(item.close);
                _candle.Hight = Convert.ToDouble(item.high);
                _candle.Low = Convert.ToDouble(item.low);
                _candle.Complete = true;
                _candle.Time = item.date;
                if (_candle.Close > _candle.Open)
                {
                    _candle.OriginalColor = Constants.CandelColour.GREEN;
                    Console.WriteLine("GREEN" + " " + _candle.Time);
                }
                else if (_candle.Close < _candle.Open)
                {
                    _candle.OriginalColor = Constants.CandelColour.RED;
                    Console.WriteLine("RED" + " " + _candle.Time);
                }
               
            }



        }
        public static List<Model.Candle> IntradayCandles(string instrument,string interval)
        {

           List<Model.Candle> candles = new List<Model.Candle>();

            string responseString = Data.RestResponse.WDGet(Constants.url.WD.Intraday(instrument,interval));
            var candlesHistoryResponse = JsonConvert.DeserializeObject<Model.Communication.WDIntradayResponse>(responseString);
            foreach (var item in candlesHistoryResponse.data)
            {

                Model.Candle _candle = new Model.Candle();
                _candle.Open = Convert.ToDouble(item.open);
                _candle.Close = Convert.ToDouble(item.close);
                _candle.Hight = Convert.ToDouble(item.high);
                _candle.Low = Convert.ToDouble(item.low);
                _candle.Complete = true;
                _candle.Time = item.date;
                if (_candle.Close > _candle.Open)
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
        public static void StocksList()
        {
            string responseString = System.IO.File.ReadAllText(@"C:\Users\Andrea\source\repos\OANDA\OANDA\Model\Communication\WD\tickers.json");
             var candlesResponse = JsonConvert.DeserializeObject<Model.Communication.WDstocksListResponse>(responseString);





        }

        static Model.Candle TodayCandle(string instrument)
        {
            Model.Candle _candle = new Model.Candle();
            OANDA.Data.WD.Stocks.IntradayCandles(instrument, "15min");

            return _candle;

        }

      
    }
}


