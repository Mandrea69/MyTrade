using OANDA.Formula;
using OANDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OANDA
{
    public class HA_Stocks
    {
       
        static List<Instrument> instruments = new List<Instrument>();
        static List<string> greenAlert = new List<string>();
        static List<string> magentaAlert = new List<string>();
        static List<string> blueAlert = new List<string>();
       
        public static void Run()
        {
            

            foreach (Instrument instrument in instruments)
            {

                Data.Stocks.FillCandles(instrument.Name);
                List<Model.Candle> M15 = Data.Stocks.M15;
                List<Model.Candle> H1 = Data.Stocks.H1;
                List<Model.Candle> H4 = Data.Stocks.H4;
                List<Model.Candle> D = Data.Stocks.D;
                Model.InstrumentDayPrice instrumentDayPrice = null;
                List<Model.Candle> HA_D = HA_D_Candles(D,out  instrumentDayPrice);
                Model.Candle ha_H4_LastCandle= HA_H4_LastCandle(H4);
                Model.Candle ha_H1_LastCandle = HA_H1_LastCandle(H1);
                Model.Candle ha_M15_LastCandle = HA_M15_LastCandle(M15);



                OANDA.Results.Get(instrument, ha_M15_LastCandle.Color.ToString(), ha_H1_LastCandle.Color.ToString(), ha_H4_LastCandle.Color.ToString(), HA_D, instrumentDayPrice);
           
        }
        }

      public   static List<Model.Candle> HA_D_Candles(List<Model.Candle> D, out InstrumentDayPrice instrumentDayPrice) 
        {


            instrumentDayPrice = new InstrumentDayPrice();
            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
            EMA ema = new EMA(5);
            for (int i = 0; i < D.Count; i++)
            {
                if (i == 0)
                {
                    instrumentDayPrice.Max = Math.Max(instrumentDayPrice.Max, D[i].Hight);
                    instrumentDayPrice.Current = D.LastOrDefault().Close;
                    haPreviounsCandle = Data.Candle.GeneratePrevious(D[i]);
                    haCandles.Add(haPreviounsCandle);

                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, D[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

                if (i < 5)
                {
                    ema.AddDataPoint(D[i].Close);
                }
                else
                {
                    instrumentDayPrice.EMA = ema.Average;
                }

            }


            return haCandles;


        }
        public static Model.Candle HA_H4_LastCandle(List<Model.Candle> H4)
        {

            Model.Candle haPreviounsCandle = null;
            Model.Candle haCurrentCandle = null;
            List<Model.Candle> haCandles = new List<Candle>();
           
            for (int i = 0; i < H4.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(H4[i]);
                    haCandles.Add(haPreviounsCandle);
                  

                }
                else
                {

                    haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, H4[i]);
                  
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static Model.Candle HA_H1_LastCandle(List<Model.Candle> H1)
        {

            Model.Candle haPreviounsCandle = null;
           
            List<Model.Candle> haCandles = new List<Candle>();
           
            for (int i = 0; i < H1.Count; i++)
            {
               
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(H1[i]);
                    haCandles.Add(haPreviounsCandle);
           
                }
                else
                {

                    Model.Candle haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, H1[i]);
                             
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }

            return haCandles.LastOrDefault();


        }
        public static Model.Candle HA_M15_LastCandle(List<Model.Candle> M15)
        {

            Model.Candle haPreviounsCandle = null;
           
            List<Model.Candle> haCandles = new List<Candle>();
          
            for (int i = 0; i < M15.Count; i++)
            {
               
                if (i == 0)
                {
                    haPreviounsCandle = Data.Candle.GeneratePrevious(M15[i]);
                    haCandles.Add(haPreviounsCandle);
                   

                }
                else
                {

                    Model.Candle haCurrentCandle = Data.Candle.Generate(haPreviounsCandle, M15[i]);
            
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }

        

    }
}
