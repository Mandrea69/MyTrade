
using MyTrade.OANDA.Formula;
using MyTrade.OANDA.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;

namespace MyTrade.OANDA.Strategy
{
    public class HA_IndicesAndCurrencyW
    {
        
        static List<Instrument> instruments;
      
        public static void Run()
        {

            Console.ForegroundColor = ConsoleColor.White;

            instruments = Data.Instrument.AllFromFile().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();
         
            foreach (Instrument instrument in instruments)
            {
              
                    Model.InstrumentDayPrice instrumentWeeklyPrice = null;
                    List<Model.Candle> ha_W_Candles = HA_W_Candles(instrument, out instrumentWeeklyPrice);
                Model.Candle ha_D_LastCandle = HA_IndicesAndCurrencyW.HA_D_Candles(instrument);
                Model.Candle ha_H4_LastCandle = HA_IndicesAndCurrencyW.HA_H4_Candles(instrument);
                Model.Candle ha_H1_LastCandle = HA_IndicesAndCurrencyW.HA_H1_Candles(instrument);
             

                OANDA.Results.Get(instrument, ha_H1_LastCandle.HaColor.ToString(), ha_H4_LastCandle.HaColor.ToString(), ha_D_LastCandle.HaColor.ToString(), ha_W_Candles, instrumentWeeklyPrice);
         
        }
            //Console.ForegroundColor = ConsoleColor.Green;
            //foreach (string item in OANDA.Results.GreenAlerts)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}
            //Console.ResetColor();

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //foreach (string item in OANDA.Results.YellowAlerts)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}

            //Console.ForegroundColor = ConsoleColor.Blue;
            //foreach (string item in OANDA.Results.BlueAlerts)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}
        }
       
    

     public   static List<Model.Candle> HA_W_Candles(Instrument instrument,out InstrumentDayPrice instrumentWeeklyPrice)
        {

            instrumentWeeklyPrice = new InstrumentDayPrice();
            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "W");
            EMA ema = new EMA(5);
            
            for (int i = 0; i < candles.Count; i++)
            {


                instrumentWeeklyPrice.Max = Math.Max(instrumentWeeklyPrice.Max, candles[i].Hight);
                instrumentWeeklyPrice.Current = candles.LastOrDefault().Close;
                if (i == 0)
                {
                    instrumentWeeklyPrice.Min = candles[i].Low;
                    instrumentWeeklyPrice.Min = Math.Min(candles[i].Low, instrumentWeeklyPrice.Min);
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
                    instrumentWeeklyPrice.EMA = ema.Average;
                }

            }


            return haCandles;


        }

     public static  Model.Candle HA_D_Candles(Instrument instrument)
        {

           
            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            List<Model.Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "D");
            EMA ema = new EMA(5);

            for (int i = 0; i < candles.Count; i++)
            {


              
                if (i == 0)
                {
                   
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

                

            }


            return haCandles.LastOrDefault();


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
     
    


    }
}
