
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

namespace MyTrade.OANDA.Strategy
{
    public class Strategy_HA_H4_PP_DAily
    {

        static List<Instrument> instruments;
        public delegate void InstrumentResult(Result result, int nInstruments);
        public event InstrumentResult GetResult;
        public void Run()
        {



            instruments = Data.Instrument.AllFromDB().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();

            foreach (Instrument instrument in instruments)
            {
                //if (instrument.Name == "EUR_JPY")
                //{
                InstrumentDetails instrumentDetails = null;
                List<Candle> ha_H4_Candles = HA_H4_Candles(instrument, out instrumentDetails);

                Candle ha_H1_LastCandle = HA_H1_Candles(instrument);
                Candle ha_M15_LastCandle = HA_M15_Candles(instrument); ;
                Candle ha_M5_LastCandle = HA_M5_Candles(instrument);
                Result result = OANDA.Results.GetResult(instrument, ha_H4_Candles, ha_H1_LastCandle.HaColor, ha_M15_LastCandle.HaColor, ha_M5_LastCandle.HaColor, instrumentDetails);
                if (result != null)
                    GetResult(result, instruments.Count());
                //}
            }

        }


        public static List<Candle> HA_H4_Candles(Instrument instrument, out InstrumentDetails instrumentDetails)
        {

            instrumentDetails = new InstrumentDetails();
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            int emaPeriod = 21;
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, emaPeriod, "H4");
            EMA ema = new EMA(emaPeriod);

            List<Candle> d_candles = Data.Prices.GetCandles(instrument.Name, 10, "D");
            PivotPoints pps = new PivotPoints();
            MyTrade.Core.Model.Indicators.PivotPoint d_pps = pps.Get(d_candles[d_candles.Count - 2]);
            instrumentDetails.D_PivotPoints = d_pps;

            for (int i = 0; i < candles.Count; i++)
            {


                instrumentDetails.Max = Math.Max(instrumentDetails.Max, candles[i].High);
                instrumentDetails.Current = candles.LastOrDefault().Close;
                if (i == 0)
                {
                    instrumentDetails.Min = candles[i].Low;
                    instrumentDetails.Min = Math.Min(candles[i].Low, instrumentDetails.Min);
                    haPreviounsCandle = Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }

                else
                {

                    haCurrentCandle = Data.HACandle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

                if (i < (emaPeriod - 1))
                {
                    ema.AddDataPoint(candles[i].Close);
                }
                else
                {
                    instrumentDetails.EMA = ema.Average;
                }

            }


            return haCandles;


        }
        public static Candle HA_M5_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = Data.Prices.GetCandles(instrument.Name, 10, "M5");
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
