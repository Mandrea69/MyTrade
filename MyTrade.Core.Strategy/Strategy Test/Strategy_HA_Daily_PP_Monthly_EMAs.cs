
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

namespace MyTrade.Core.StrategyTest
{
    public class Strategy_HA_Daily_PP_Monthly_EMAs
    {


        public delegate void InstrumentResult(TestResult_Order result);
        public event InstrumentResult GetResult;
        public void Run(Instrument instrument)
        {


            List<Candle> ha_D_Candles = HA_D_Candles(instrument);
            TestResult_Order order = null;
            EMA ema50 = new EMA(50);
            EMA ema9 = new EMA(9);
            for (int i = 0; i < ha_D_Candles.Count; i++)
            {
                ema50.AddDataPoint(ha_D_Candles[i].Close);
                ema9.AddDataPoint(ha_D_Candles[i].Close);
                if (i > 50)
                {

                   order= Results.GetResult_HA_EMAs(instrument, ha_D_Candles[i-1], ha_D_Candles[i], ema50.Average, ema9.Average, order);
                    if (order!=null && order.Close == true)
                    {
                        GetResult(order);
                        order = null;
                    }


                }

            }



        }


        private List<Candle> HA_D_Candles(Instrument instrument)
        {


            Candle haPreviounsCandle = null;
            Candle haCurrentCandle = null;
            List<Candle> haCandles = new List<Candle>();

            List<Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, new DateTime(2020, 01, 01).AddDays(-50), "D");


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


            return haCandles;


        }


    }

}

