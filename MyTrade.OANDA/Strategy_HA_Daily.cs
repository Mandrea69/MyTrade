
using MyTrade.OANDA.Indicators;
using MyTrade.OANDA.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;

namespace MyTrade.OANDA.Strategy
{
    public class HA_Daily
    {

        static List<Instrument> instruments;
        public delegate void InstrumentResult(Model.Result result,int nInstruments);
        public event InstrumentResult GetResult;
        public  void Run()
        {
            
           Console.ForegroundColor = ConsoleColor.White;

            instruments = Data.Instrument.AllFromFile().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();
        
            foreach (Instrument instrument in instruments)
            {
                Model.InstrumentDayPrice instrumentDayPrice = null;
                List<Model.Candle> ha_D_Candles = HA_D_Candles(instrument, out instrumentDayPrice);
                Model.Candle ha_H4_LastCandle = HA_H4_Candles(instrument);
                Model.Candle ha_H1_LastCandle = HA_H1_Candles(instrument);
                Model.Candle ha_M15_LastCandle =HA_M15_Candles(instrument); ;
                Model.Result result=  OANDA.Results.GetResult(instrument, ha_D_Candles, ha_H4_LastCandle.HaColor, ha_M15_LastCandle.HaColor, ha_H1_LastCandle.HaColor, instrumentDayPrice);
                if(result!=null)
                GetResult(result, instruments.Count());

            }
          
        }
    
        public static Model.Candle HA_W_Candles(Instrument instrument)
        {



            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "W");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                    
                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static List<Model.Candle> HA_D_Candles(Instrument instrument, out InstrumentDayPrice instrumentDayPrice)
        {

            instrumentDayPrice = new InstrumentDayPrice();
            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 22, "D");
            EMA ema = new EMA(22);
            PivotPoints pp = new PivotPoints();

            for (int i = 0; i < candles.Count; i++)
            {


                instrumentDayPrice.Max = Math.Max(instrumentDayPrice.Max, candles[i].Hight);
                instrumentDayPrice.Current = candles.LastOrDefault().Close;
                if (i == 0)
                {
                    instrumentDayPrice.Min = candles[i].Low;
                    instrumentDayPrice.Min = Math.Min(candles[i].Low, instrumentDayPrice.Min);
                    haPreviounsCandle = Data.Candle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                    
                }

                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                     haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

                if (i < 5)
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
        public static Model.Candle HA_H4_Candles(Instrument instrument)
        {

            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "H4");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static Model.Candle HA_H1_Candles(Instrument instrument)
        {

            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "H1");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                    
                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static Model.Candle HA_M15_Candles(Instrument instrument)
        {

            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "M15");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                  
                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }



    }
}
