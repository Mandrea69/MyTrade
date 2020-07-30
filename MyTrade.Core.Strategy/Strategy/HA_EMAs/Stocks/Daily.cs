
using MyTrade.Core.Indicators;
using MyTrade.Core.Model;
using MyTrade.Core.Model.Indicators;
using MyTrade.OANDA.Indicators;
using MyTrade.OANDA.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;
using EMA = MyTrade.Core.Indicators.EMA;

namespace MyTrade.Core.Strategy.HA_EMAs.Stocks
{
    public class Daily
    {

        static List<Instrument> instruments;
        public delegate void InstrumentResult(Result result,int nInstruments);
        public event InstrumentResult GetResult;
        public  void Run()
        {

            instruments = MyTrade.Core.SqliteDataAccess.StockInstruments.LoadInstruments().Where(x=>x.IsFavorite==true ).OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();

            foreach (Instrument instrument in instruments)
            {
                //if (instrument.Name == "CHF_JPY")
                //{

                    InstrumentDetails instrumentDetails = null;
                    List<Candle> ha_D_Candles = HA_D_Candles(instrument, out instrumentDetails);
                    Candle ha_H4_LastCandle = HA_H4_Candles(instrument);
                    Candle ha_H1_LastCandle = HA_H1_Candles(instrument);
                    Candle ha_M15_LastCandle = HA_M15_Candles(instrument); ;
                    Result result = Results.GetResult_HA_EMAs(instrument, ha_D_Candles[ha_D_Candles.Count-1].OriginalColor, ha_D_Candles, ha_H4_LastCandle.HaColor, ha_H1_LastCandle.HaColor, ha_M15_LastCandle.HaColor, instrumentDetails);
                    if (result != null)
                        GetResult(result, instruments.Count());
                //}
            }
          
        }

        
        public static List<Candle> HA_D_Candles(Instrument instrument, out InstrumentDetails instrumentDetails)
        {

            instrumentDetails = new InstrumentDetails();
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
             int ema50Period = 50;
            int ema9Period = 9;
            List<Candle> candles = Alpaca.Data.Prices.GetCandles(instrument.Name, ema50Period, "1D");
            instrumentDetails.Current = candles.LastOrDefault().Close;
            EMA ema50 = new EMA(ema50Period);
            EMA ema9 = new EMA(ema9Period);
            List<MyTrade.Core.Model.Candle> wcandles = MyTrade.Core.SqliteDataAccess.WeekyStocksCandles.LoadCandles(instrument.Name);
            PivotPoints pps = new PivotPoints();
            PivotPoint wpps = pps.Get(wcandles.FirstOrDefault(), instrumentDetails.Current);
            instrumentDetails.W_PivotPoints = wpps;
            List<MyTrade.Core.Model.Candle> mcandles = MyTrade.Core.SqliteDataAccess.MonthlyStocksCandles.LoadCandles(instrument.Name);
            PivotPoint mpps = pps.Get(mcandles.FirstOrDefault(), instrumentDetails.Current);
            instrumentDetails.M_PivotPoints = mpps;
            instrumentDetails.TimeFrame = Core.Constants.TimeFrame.DAILY;
            for (int i = 0; i < candles.Count; i++)
            {


                instrumentDetails.Max = Math.Max(instrumentDetails.Max, candles[i].High);
               
                if (i == 0)
                {
                    instrumentDetails.Min = candles[i].Low;
                    instrumentDetails.Min = Math.Min(candles[i].Low, instrumentDetails.Min);
                    haPreviounsCandle = HeikinAshi.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                    
                }

                else
                {

                    haCurrentCandle = HeikinAshi.Generate(haPreviounsCandle, candles[i]);
                   
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }


                if (i == (candles.Count - 1))
                {
                    if (instrumentDetails.EMAs == null)
                    {
                        instrumentDetails.EMAs = new List<Core.Model.Indicators.EMA>();
                    }
                    ema50.AddDataPoint(candles[i].Close);
                    ema9.AddDataPoint(candles[i].Close);
                    instrumentDetails.EMAs.Add(new Core.Model.Indicators.EMA() { Period = 50, Value = ema50.Average });
                    instrumentDetails.EMAs.Add(new Core.Model.Indicators.EMA() { Period = 9, Value = ema9.Average });
                }
                else
                {
                    ema50.AddDataPoint(candles[i].Close);
                    ema9.AddDataPoint(candles[i].Close);
                }

              

            }


            return haCandles;


        }
        public static Candle HA_H4_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = MyTrade.Alpaca.Data.Prices.GetCandles(instrument.Name, 10, "15Min");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = HeikinAshi.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }
                else
                {

                    haCurrentCandle = HeikinAshi.Generate(haPreviounsCandle, candles[i]);

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
            List<Candle> candles = MyTrade.Alpaca.Data.Prices.GetCandles(instrument.Name, 10, "15Min");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = HeikinAshi.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                   
                }
                else
                {

                    haCurrentCandle = HeikinAshi.Generate(haPreviounsCandle, candles[i]);
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
            List<Candle> candles = MyTrade.Alpaca.Data.Prices.GetCandles(instrument.Name, 10, "15Min");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = HeikinAshi.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);
                   
                }
                else
                {

                    haCurrentCandle = HeikinAshi.Generate(haPreviounsCandle, candles[i]);
                  
                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }



    }
}
