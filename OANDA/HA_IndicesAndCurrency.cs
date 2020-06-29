using OANDA.Formula;
using OANDA.Model;
using OANDA.Model.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;

namespace OANDA
{
    public class HA_IndicesAndCurrency
    {
        
        static List<Instrument> instruments;
      
        public static void Run()
        {

            Console.ForegroundColor = ConsoleColor.White;

            instruments = Data.Instrument.AllFromFile().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();
            //Timer t = new Timer(TimerCallback, null, 0, 60000);
            foreach (Instrument instrument in instruments)
            {
                if (instrument.DisplayName == "France 40")
                {

                    Model.InstrumentDayPrice instrumentDayPrice = null;
                    List<Model.Candle> ha_D_Candles = HA_D_Candles(instrument, out instrumentDayPrice);
                    Model.Candle ha_H4_LastCandle = HA_IndicesAndCurrency.HA_H4_Candles(instrument);
                    Model.Candle ha_H1_LastCandle = HA_IndicesAndCurrency.HA_H1_Candles(instrument);
                    Model.Candle ha_M15_LastCandle = HA_IndicesAndCurrency.HA_M15_Candles(instrument); ;

                    OANDA.Results.Get(instrument, ha_M15_LastCandle.Color.ToString(), ha_H1_LastCandle.Color.ToString(), ha_H4_LastCandle.Color.ToString(), ha_D_Candles, instrumentDayPrice);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string item in OANDA.Results.GreenAlerts)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string item in OANDA.Results.YellowAlerts)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string item in OANDA.Results.BlueAlerts)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        private static void TimerCallback(Object o)
        {


        }
     public    static Model.Candle HA_W_Candles(Instrument instrument)
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
                    //Console.WriteLine(haPreviounsCandle.Color);
                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    //Console.WriteLine(haCurrentCandle.Color);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }

     public   static List<Model.Candle> HA_D_Candles(Instrument instrument,out InstrumentDayPrice instrumentDayPrice)
        {

            instrumentDayPrice = new InstrumentDayPrice();
            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 22, "D");
            EMA ema = new EMA(22);
            
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
                    //Console.WriteLine(haPreviounsCandle.OriginalColor);
                }

                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    //Console.WriteLine(haCurrentCandle.OriginalColor);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

                if(i<5)
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
     public   static Model.Candle HA_H4_Candles(Instrument instrument)
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
     public   static Model.Candle HA_H1_Candles(Instrument instrument)
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
                    //Console.WriteLine(haPreviounsCandle.Color);
                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    //Console.WriteLine(haCurrentCandle.Color);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
     public   static Model.Candle HA_M15_Candles(Instrument instrument)
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
                    //Console.WriteLine(haPreviounsCandle.Color);
                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, candles[i]);
                    //Console.WriteLine(haCurrentCandle.Color);
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
    


    }
}
