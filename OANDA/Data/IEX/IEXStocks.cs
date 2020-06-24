using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace OANDA.Data
{
    public class IEXStocks
    {

        public static List<Model.Candle> M15 = null;
        public static List<Model.Candle> H1 = null;
        public static List<Model.Candle> H4 = null;
        public static List<Model.Candle> D = null;
        static List<Model.Candle> D1 = null;
        static void DailyCandles(string instrument)
        {
            D = new List<Model.Candle>();
            string responseString = Data.RestResponse.Get(Constants.url.IEX.DAY_Candels(instrument));
            var candlesResponse = JsonConvert.DeserializeObject<Model.Communication.IEXCandleResponse[]>(responseString, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            List<Model.Candle> intradaycandles = D1;

            foreach (var item in candlesResponse)
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
                D.Add(_candle);
            }
            foreach (var item in intradaycandles)
            {

                Model.Candle _candle = new Model.Candle();
                _candle.Open = Convert.ToDouble(item.Open);
                _candle.Close = Convert.ToDouble(item.Close);
                _candle.Hight = Convert.ToDouble(item.Hight);
                _candle.Low = Convert.ToDouble(item.Low);
                _candle.Complete = true;
                _candle.Time = item.Time;
                if (_candle.Close > _candle.Open)
                {
                    _candle.OriginalColor = Constants.CandelColour.GREEN;
                }
                else if (_candle.Close < _candle.Open)
                {
                    _candle.OriginalColor = Constants.CandelColour.RED;
                }
                D.Add(_candle);
            }



        }
        static void IntraDayCandles(string instrument)
        {
            List<Model.Candle> candles = new List<Model.Candle>();
            string responseString = Data.RestResponse.Get(Constants.url.IEX.IntraDAY_Candels(instrument));
            var candlesResponse = JsonConvert.DeserializeObject<Model.Communication.IEXCandleResponse[]>(responseString, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            M15 = _M15(candlesResponse);
            H1 = _H1(candlesResponse);
            H4 = _H4(candlesResponse);
            D1 = _D1(candlesResponse);


        }
        static List<Model.Candle> _M15(Model.Communication.IEXCandleResponse[] candlesResponse)
        {
            int i = 0;
            int counter = 1;

            List<Model.Candle> candles = new List<Model.Candle>();
            Model.Candle _candle = null;
            foreach (var item in candlesResponse)
            {


                if (i == 0)
                {
                    _candle = new Model.Candle();
                    _candle.Open = Convert.ToDouble(item.marketOpen);
                    _candle.Hight = Convert.ToDouble(item.marketHigh);
                    _candle.Low = Convert.ToDouble(item.marketLow);
                    string[] hm = item.minute.Split(':');
                    _candle.Time = new DateTime(item.date.Year, item.date.Month, item.date.Day, Convert.ToInt16(hm[0]), Convert.ToInt16(hm[1]), 0);

                    i += 1;
                }
                else if (i == 14 || counter == candlesResponse.Count())

                {
                    _candle.Close = Convert.ToDouble(item.marketClose);
                    _candle.Complete = true;
                      if (_candle.Close > _candle.Open)
                    {
                        _candle.OriginalColor = Constants.CandelColour.GREEN;
                    }
                    else if (_candle.Close < _candle.Open)
                    {
                        _candle.OriginalColor = Constants.CandelColour.RED;
                    }
                    candles.Add(_candle);
                    i = 0;
                }
                else if (i < 14)
                {

                    _candle.Hight = Math.Max(_candle.Hight, Convert.ToDouble(item.marketHigh));
                    _candle.Low = Math.Min(_candle.Low, Convert.ToDouble(item.marketLow));
                    i += 1;

                }

                counter += 1;

            }

            return candles;
        }
        static List<Model.Candle> _H1(Model.Communication.IEXCandleResponse[] candlesResponse)
        {
            int i = 0;
            int counter = 1;
            List<Model.Candle> candles = new List<Model.Candle>();
            Model.Candle _candle = null;
            foreach (var item in candlesResponse)
            {

                if (i == 0)
                {
                    //double open = item.open;
                    //if (item.open == 0)
                    //{
                    //    open = item.marketOpen;
                    //}
                    _candle = new Model.Candle();
                        _candle.Open = Convert.ToDouble(item.marketOpen);

                        _candle.Hight = Convert.ToDouble(item.marketHigh);
                        _candle.Low = Convert.ToDouble(item.marketLow);
                    string[] hm = item.minute.Split(':');
                    _candle.Time = new DateTime(item.date.Year, item.date.Month, item.date.Day, Convert.ToInt16(hm[0]), Convert.ToInt16(hm[1]), 0);

                    i += 1;
                    
                }
                else if (i == 59 || counter == candlesResponse.Count())
                {
                    //double close = item.close;
                    //if (item.close == 0)
                    //{
                    //    close = item.marketClose;
                    //}

                    _candle.Close = Convert.ToDouble(item.marketClose);
                    _candle.Complete = true;
                    if (_candle.Close > _candle.Open)
                    {
                        _candle.OriginalColor = Constants.CandelColour.GREEN;
                    }
                    else if (_candle.Close < _candle.Open)
                    {
                        _candle.OriginalColor = Constants.CandelColour.RED;
                    }
                    candles.Add(_candle);
                    i = 0;
                }
                else if (i < 59)
                {

                    _candle.Hight = Math.Max(_candle.Hight, Convert.ToDouble(item.marketHigh));
                    _candle.Low = Math.Min(_candle.Low, Convert.ToDouble(item.marketLow));
                    i += 1;

                }

                counter += 1;

            }
            return candles;
        }
        static List<Model.Candle> _H4(Model.Communication.IEXCandleResponse[] candlesResponse)
        {
            int i = 0;
            int counter = 1;
            List<Model.Candle> candles = new List<Model.Candle>();
            Model.Candle _candle = null;
            foreach (var item in candlesResponse)
            {

                if (i == 0)
                {
                    _candle = new Model.Candle();
                    _candle.Open = Convert.ToDouble(item.marketOpen);

                    _candle.Hight = Convert.ToDouble(item.marketHigh);
                    _candle.Low = Convert.ToDouble(item.marketLow);
                    string[] hm = item.minute.Split(':');
                    _candle.Time = new DateTime(item.date.Year, item.date.Month, item.date.Day, Convert.ToInt16(hm[0]), Convert.ToInt16(hm[1]), 0);
                    i += 1;
                }
                else if (i == 239 || counter == candlesResponse.Count())
                {
                    _candle.Close = Convert.ToDouble(item.marketClose);
                    _candle.Complete = true;

                    if (_candle.Close > _candle.Open)
                    {
                        _candle.OriginalColor = Constants.CandelColour.GREEN;
                    }
                    else if (_candle.Close < _candle.Open)
                    {
                        _candle.OriginalColor = Constants.CandelColour.RED;
                    }
                    candles.Add(_candle);
                    i = 0;
                }
                else if (i < 239)
                {

                    _candle.Hight = Math.Max(_candle.Hight, Convert.ToDouble(item.marketHigh));
                    _candle.Low = Math.Min(_candle.Low, Convert.ToDouble(item.marketLow));
                    i += 1;

                }

                counter += 1;

            }
            return candles;
        }
        static List<Model.Candle> _D1(Model.Communication.IEXCandleResponse[] candlesResponse)
        {

            int counter = 1;
            List<Model.Candle> candles = new List<Model.Candle>();
            Model.Candle _candle = null;
            foreach (var item in candlesResponse)
            {

                if (counter == 1)
                {
                    _candle = new Model.Candle();
                    _candle.Open = Convert.ToDouble(item.open);

                    _candle.Hight = Convert.ToDouble(item.high);
                    _candle.Low = Convert.ToDouble(item.low);
                    string[] hm = item.minute.Split(':');
                    _candle.Time = new DateTime(item.date.Year, item.date.Month, item.date.Day, Convert.ToInt16(hm[0]), Convert.ToInt16(hm[1]), 0);


                }
                else if (counter == candlesResponse.Count())
                {
                    _candle.Close = Convert.ToDouble(item.close);
                    _candle.Complete = true;
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
                else
                {

                    _candle.Hight = Math.Max(_candle.Hight, Convert.ToDouble(item.high));
                    _candle.Low = Math.Min(_candle.Low, Convert.ToDouble(item.low));


                }

                counter += 1;

            }
            return candles;
        }
        public static void FillCandles(string instrument)
        {
            IntraDayCandles(instrument);
            DailyCandles(instrument);
        }

        public static List<Model.Stock> StocksList()
        {
            string responseString = System.IO.File.ReadAllText(@"C:\Users\SPProjectFarm\source\repos\MyTrade\OANDA\Data\IEX\tickers.json");
            var stocksResponse = JsonConvert.DeserializeObject<Model.Communication.IEXstocksListResponse>(responseString);
            List<Model.Stock> stocks = new List<Model.Stock>();
            foreach (var item in stocksResponse.data)
            {
                stocks.Add(new Model.Stock() { name = item.name, symbol = item.symbol });
            }

            return stocks;


        }

    }
}


