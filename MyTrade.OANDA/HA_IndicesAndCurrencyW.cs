
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
    public class HA_IndicesAndCurrencyW
    {
        
        static List<MyTrade.Core.Model.Instrument> instruments;
      
        public static void Run()
        {

            Console.ForegroundColor = ConsoleColor.White;

            instruments = Data.Instrument.AllFromDB().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();
         
            foreach (MyTrade.Core.Model.Instrument instrument in instruments)
            {

                InstrumentDetails instrumentWeeklyPrice = null;
                    List<Candle> ha_W_Candles = HA_W_Candles(instrument, out instrumentWeeklyPrice);
                Candle ha_D_LastCandle = HA_IndicesAndCurrencyW.HA_D_Candles(instrument);
                Candle ha_H4_LastCandle = HA_IndicesAndCurrencyW.HA_H4_Candles(instrument);
                Candle ha_H1_LastCandle = HA_IndicesAndCurrencyW.HA_H1_Candles(instrument);
             

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
       
    

     public   static List<Candle> HA_W_Candles(Instrument instrument,out InstrumentDetails instrumentWeeklyPrice)
        {

            instrumentWeeklyPrice = new InstrumentDetails();
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "W");
            EMA ema = new EMA(5);
            
            for (int i = 0; i < candles.Count; i++)
            {


                instrumentWeeklyPrice.Max = Math.Max(instrumentWeeklyPrice.Max, candles[i].High);
                instrumentWeeklyPrice.Current = candles.LastOrDefault().Close;
                if (i == 0)
                {
                    instrumentWeeklyPrice.Min = candles[i].Low;
                    instrumentWeeklyPrice.Min = Math.Min(candles[i].Low, instrumentWeeklyPrice.Min);
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                   
                }

                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);
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

     public static  Candle HA_D_Candles(Instrument instrument)
        {

           
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "D");
            EMA ema = new EMA(5);

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
     public   static Candle HA_H4_Candles(Instrument instrument)
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
     public   static Candle HA_H1_Candles(Instrument instrument)
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
     
    


    }
}
