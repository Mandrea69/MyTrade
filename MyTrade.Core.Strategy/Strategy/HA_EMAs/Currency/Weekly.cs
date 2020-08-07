
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

namespace MyTrade.Core.Strategy.HA_EMAs
{
    public class Weekly
    {

        static List<Instrument> instruments;
        public delegate void InstrumentResult(Result result,int nInstruments);
        public event InstrumentResult GetResult;
        public  void Run()
        {
            
          

            instruments = OANDA.Data.Instrument.AllFromDB().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();

            foreach (Instrument instrument in instruments)
            {
                //if (instrument.DisplayName == "Brent Crude Oil")
                //{

                    InstrumentDetails instrumentDetails = null;
                List<Candle> ha_W_Candles = HA_W_Candles(instrument, out instrumentDetails);
                Candle ha_H4_LastCandle = HA_H4_Candles(instrument);
                Candle ha_H1_LastCandle = HA_H1_Candles(instrument);
                Candle ha_D_LastCandle = HA_D_Candles(instrument);
                Constants.CandleColor daily_CandleColor = OANDA.Data.Prices.GetCandles(instrument.Name, 2, "D").LastOrDefault().OriginalColor;
                Result result = Results.GetResult_HA_EMAs(instrument, daily_CandleColor, ha_W_Candles, ha_D_LastCandle.HaColor, ha_H4_LastCandle.HaColor, ha_H1_LastCandle.HaColor, instrumentDetails);
                if (result != null)
                    GetResult(result, instruments.Count());
            //}
            }
          
        }

        
         static List<Candle> HA_W_Candles(Instrument instrument, out InstrumentDetails instrumentDetails)
        {

            instrumentDetails = new InstrumentDetails();
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
             int ema50Period = 50;
            int ema9Period = 9;
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, ema50Period, "W");
            instrumentDetails.Current = candles.LastOrDefault().Close;
            EMA ema50 = new EMA(ema50Period);
            EMA ema9 = new EMA(ema9Period);
            List<MyTrade.Core.Model.Candle> wcandles = MyTrade.Core.SqliteDataAccess.WeekyCandles.LoadCandles(instrument.Name);
            PivotPoints pps = new PivotPoints();
            PivotPoint wpps = pps.Get(wcandles[wcandles.Count - 2], instrumentDetails.Current);
            instrumentDetails.W_PivotPoints = wpps;
            List<MyTrade.Core.Model.Candle> mcandles = MyTrade.Core.SqliteDataAccess.MonthlyCandles.LoadCandles(instrument.Name);
            PivotPoint mpps = pps.Get(mcandles[mcandles.Count - 2], instrumentDetails.Current);
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
         static Candle HA_H4_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, 10, "H4");
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
         static Candle HA_H1_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, 10, "H1");
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
         static Candle HA_D_Candles(Instrument instrument)
        {


            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, 10, "D");
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

            return haCandles.LastOrDefault(); ;

        }

        public static InstrumentDetails WeeklyinstrumentDetails (Instrument instrument)
        {

            InstrumentDetails instrumentDetails = new InstrumentDetails();
            int ema50Period = 50;
            int ema9Period = 9;
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, ema50Period, "W");
            instrumentDetails.Current = candles.LastOrDefault().Close;
            EMA ema50 = new EMA(ema50Period);
            EMA ema9 = new EMA(ema9Period);
            List<MyTrade.Core.Model.Candle> wcandles = MyTrade.Core.SqliteDataAccess.WeekyCandles.LoadCandles(instrument.Name);
            PivotPoints pps = new PivotPoints();
            PivotPoint wpps = pps.Get(wcandles[wcandles.Count - 2], instrumentDetails.Current);
            instrumentDetails.W_PivotPoints = wpps;
          
            instrumentDetails.TimeFrame = Core.Constants.TimeFrame.DAILY;
            for (int i = 0; i < candles.Count; i++)
            {


                instrumentDetails.Max = Math.Max(instrumentDetails.Max, candles[i].High);

                if (i == 0)
                {
                    instrumentDetails.Min = candles[i].Low;
                    instrumentDetails.Min = Math.Min(candles[i].Low, instrumentDetails.Min);
               

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


            return instrumentDetails;


        }

    }
}
