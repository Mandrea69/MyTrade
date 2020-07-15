
using MyTrade.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MyTrade.Core.Constants;

namespace MyTrade.Core.StrategyTest
{
    public class Results
    {

        public static TestResult_Order GetResult_HA_EMAs(Instrument instrument,Candle previous_HA_candle, Candle current_HA_candle, double ema50, double ema9, TestResult_Order order)
        {
            double currentPrice = current_HA_candle.Close;
            if ((current_HA_candle.HaColor == CandleColor.GREEN && previous_HA_candle.HaColor == CandleColor.RED))
            {

                if (current_HA_candle.Close > ema50 &&
            current_HA_candle.Close > ema9)
                {
                    if (order == null)
                    {
                        order = new TestResult_Order();
                        order.OpenDate = current_HA_candle.Time;
                        order.OpenPrice = current_HA_candle.Close;
                        order.Action = Core.Constants.Action.BUY;
                        order.Close = false;
                    }

                }

            }
            else if (current_HA_candle.HaColor == CandleColor.RED && previous_HA_candle.HaColor == CandleColor.GREEN)

            {

                if (current_HA_candle.Close < ema50 &&
                     current_HA_candle.Close < ema9)
                {
                    if (order == null)
                    {
                        order = new TestResult_Order();
                        order.OpenDate = current_HA_candle.Time;
                        order.OpenPrice = current_HA_candle.Close;
                        order.Action = Core.Constants.Action.SELL;
                        order.Close = false;
                    }


                }



            }

            if (order != null)
            {
               
                if (order.Action == Constants.Action.BUY)
                {

                    if(current_HA_candle.HaColor== CandleColor.RED)
                    { 
                   
                        order.CloseDate = current_HA_candle.Time;
                        order.ClosePrice = current_HA_candle.Close;
                        order.Pips = order.ClosePrice - order.OpenPrice;
                        order.Close = true;

                    }

                }
                else if (order.Action == Constants.Action.SELL)
                {
                    if (current_HA_candle.HaColor == CandleColor.GREEN)
                    {
                        order.CloseDate = current_HA_candle.Time;
                        order.ClosePrice = current_HA_candle.Open;
                        order.Pips = order.OpenPrice - order.ClosePrice;
                        order.Close = true;
                    }
                }


            }

            return order;
        }
        public static Model.Indicators.PivotPoint CalculatePP(Instrument instrument, DateTime openDate,double currentPrice)
        {
           
            DateTime currentWeekstartDate = openDate;
            DateTime previousWeekStartDate = openDate.AddDays(-1);
            if (Convert.ToInt16(openDate.DayOfWeek) > 1)
            {
                currentWeekstartDate = openDate.AddDays(-(Convert.ToInt16(openDate.DayOfWeek) - 1));
                previousWeekStartDate = currentWeekstartDate.AddDays(-7);
            }


            List<Model.Candle> candles = OANDA.Data.Prices.GetCandles(instrument.Name, previousWeekStartDate, "W");
           
            MyTrade.Core.Indicators.PivotPoints pp = new MyTrade.Core.Indicators.PivotPoints();
          return  pp.Get(candles.FirstOrDefault(), currentPrice);
        }

    }
}

