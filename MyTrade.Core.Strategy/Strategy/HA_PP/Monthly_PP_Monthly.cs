
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

namespace MyTrade.Core.Strategy.HA_PP
{
    public class Monthly_PP_Monthly
    {

        static List<Instrument> instruments;
        public delegate void InstrumentResult(Result result, int nInstruments);
        public event InstrumentResult GetResult;
        public void Run()
        {



            instruments = OANDA.Data.Instrument.AllFromDB().OrderBy(x => x.Type).OrderBy(x => x.DisplayName).ToList();

            foreach (Instrument instrument in instruments)
            {
                InstrumentDetails instrumentDetails = null;
                List<Candle> ha_M_Candles = HA_M_Candles(instrument, out instrumentDetails);
                Candle ha_W_LastCandle = HA_W_Candles(instrument);
                Candle ha_D_LastCandle = HA_D_Candles(instrument); ;
                Candle ha_H4_LastCandle = HA_H4_Candles(instrument);


                Result result = Results.GetResult_HA_PP(instrument, ha_M_Candles, ha_W_LastCandle.HaColor, ha_D_LastCandle.HaColor, ha_H4_LastCandle.HaColor, instrumentDetails);
                if (result != null)
                    GetResult(result, instruments.Count());

            }

        }

        public static List<Candle> HA_M_Candles(Instrument instrument, out InstrumentDetails instrumentDetails)
        {

            instrumentDetails = new InstrumentDetails();
            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            int emaPeriod = 21;
            List<Candle> candles = MyTrade.Core.SqliteDataAccess.MonthlyCandles.LoadCandles(instrument.Name);
            instrumentDetails.Current = candles.LastOrDefault().Close;
            EMA ema = new EMA(emaPeriod);
            PivotPoints pps = new PivotPoints();
            PivotPoint _pps = pps.Get(candles[candles.Count - 2], instrumentDetails.Current);
            instrumentDetails.M_PivotPoints = _pps;
            instrumentDetails.TimeFrame = Core.Constants.TimeFrame.MONTHLY;
            for (int i = 0; i < candles.Count; i++)
            {


                instrumentDetails.Max = Math.Max(instrumentDetails.Max, candles[i].High);

                if (i == 0)
                {
                    instrumentDetails.Min = candles[i].Low;
                    instrumentDetails.Min = Math.Min(candles[i].Low, instrumentDetails.Min);
                    haPreviounsCandle = OANDA.Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }

                else
                {

                    haCurrentCandle = OANDA.Data.HACandle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }


                if (i == (candles.Count - 1))
                {
                    instrumentDetails.EMAs = new List<Core.Model.Indicators.EMA>();
                    ema.AddDataPoint(candles[i].Close);
                    instrumentDetails.EMAs.Add(new Core.Model.Indicators.EMA() { Period = 21, Value = ema.Average });
                }
                else
                {
                    ema.AddDataPoint(candles[i].Close);
                }

            }


            return haCandles;


        }
        public static Candle HA_D_Candles(Instrument instrument)
        {


            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, 10, "D");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {

                    haPreviounsCandle = OANDA.Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }

                else
                {

                    haCurrentCandle = OANDA.Data.HACandle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }

            return haCandles.LastOrDefault(); ;

        }
        public static Candle HA_H4_Candles(Instrument instrument)
        {

            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, 10, "H4");
            for (int i = 0; i < candles.Count; i++)
            {
                if (i == 0)
                {
                    haPreviounsCandle = OANDA.Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }
                else
                {

                    haCurrentCandle = OANDA.Data.HACandle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }

            }


            return haCandles.LastOrDefault();


        }
        public static Candle HA_W_Candles(Instrument instrument)
        {


            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();
            List<Candle> candles = MyTrade.Core.SqliteDataAccess.WeekyCandles.LoadCandles(instrument.Name);

            for (int i = 0; i < candles.Count; i++)
            {




                if (i == 0)
                {

                    haPreviounsCandle = OANDA.Data.HACandle.GeneratePrevious(candles[i]);
                    haCandles.Add(haPreviounsCandle);

                }

                else
                {

                    haCurrentCandle = OANDA.Data.HACandle.Generate(haPreviounsCandle, candles[i]);

                    haCandles.Add(haCurrentCandle);
                    haPreviounsCandle = haCurrentCandle;
                }


            }


            return haCandles.LastOrDefault();


        }




    }
}
