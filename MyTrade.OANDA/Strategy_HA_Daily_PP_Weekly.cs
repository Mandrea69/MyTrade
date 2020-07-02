
using MyTrade.Core.Model;
using MyTrade.OANDA.Indicators;
using MyTrade.OANDA.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;

namespace MyTrade.OANDA.Strategy
{
    public class Strategy_HA_Daily_PP_Weekly
    {

        static List<Instrument> instruments;
        public delegate void InstrumentResult(Result result,int nInstruments);
        public event InstrumentResult GetResult;
        public  void Run()
        {
            
          

            instruments = Data.Instrument.AllFromDB().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();

            foreach (Instrument instrument in instruments)
            {
                    Model.InstrumentDayPrice instrumentDayPrice = null;
                    List<Candle> ha_D_Candles = HA_D_Candles(instrument, out instrumentDayPrice);
                    Candle ha_H4_LastCandle = HA_H4_Candles(instrument);
                    Candle ha_H1_LastCandle = HA_H1_Candles(instrument);
                    Candle ha_M15_LastCandle = HA_M15_Candles(instrument); ;
                    Result result = OANDA.Results.GetResult(instrument, ha_D_Candles, ha_H4_LastCandle.HaColor, ha_H1_LastCandle.HaColor, ha_M15_LastCandle.HaColor, instrumentDayPrice);
                    if (result != null)
                        GetResult(result, instruments.Count());
                
            }
          
        }
    
        public static Candle HA_W_Candles(Instrument instrument)
        {



            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "W");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                    
                }
                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static List<Candle> HA_D_Candles(Instrument instrument, out InstrumentDayPrice instrumentDayPrice)
        {

            instrumentDayPrice = new InstrumentDayPrice();
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
           int emaPeriod = 21;
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, emaPeriod, "D");
            EMA ema = new EMA(emaPeriod);
            List<MyTrade.Core.Model.Candle> wcandles = MyTrade.Core.SqliteDataAccess.WeekyCandles.LoadCandles(instrument.Name);
            PivotPoints pps = new PivotPoints();
            MyTrade.Model.Indicators.PivotPoint _pps = pps.Get(candles[candles.Count - 2]);
                   
            instrumentDayPrice.PivotPoints = _pps;
            for (int i = 0; i < candles.Count; i++)
            {


                instrumentDayPrice.Max = Math.Max(instrumentDayPrice.Max, candles[i].High);
                instrumentDayPrice.Current = candles.LastOrDefault().Close;
                if (i == 0)
                {
                    instrumentDayPrice.Min = candles[i].Low;
                    instrumentDayPrice.Min = Math.Min(candles[i].Low, instrumentDayPrice.Min);
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                    
                }

                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);
                   
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

                if (i < (emaPeriod-1))
                {
                    ema.AddDataPoint(candles[i].Close);
                }
                else
                {
                    instrumentDayPrice.EMA = ema.Average;
                }

            }


            return haCandles;


        }
        public static Candle HA_H4_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "H4");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }
                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static Candle HA_H1_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "H1");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                   
                }
                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static Candle HA_M15_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "M15");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                   
                }
                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);
                  
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }



    }
}
