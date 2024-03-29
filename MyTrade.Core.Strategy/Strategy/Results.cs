﻿
using MyTrade.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MyTrade.Core.Constants;

namespace MyTrade.Core.Strategy
{
    public class Results
    {

        public static Result GetResult_HA_PP(Instrument instrument, List<Candle> haDaily, CandleColor H4_HA_Color, CandleColor H1_HA_Color, CandleColor M15_HA_Color, MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            Result result = null;
            string ppPosition = "";
            Core.Model.Indicators.PivotPoint pps = instrumentDetails.W_PivotPoints;
            if (instrumentDetails.TimeFrame == TimeFrame.MONTHLY)
            {
                pps = instrumentDetails.M_PivotPoints;
                ppPosition = pps.Position;
            }
            else
            {
                ppPosition = pps.Position;

            }




            CandleColor D_RealColor = CandleColor.GREEN;
            CandleColor D_HA_Color = CandleColor.GREEN;
            int i = haDaily.Count() - 1;
            D_RealColor = haDaily[haDaily.Count() - 1].OriginalColor;

            var ema = from x in instrumentDetails.EMAs
                      where x.Period == 21
                      select x;

            if (instrumentDetails.Current > ema.FirstOrDefault().Value)// UPTREND
            {

                while (i > 0)
                {

                    if (haDaily[i].HaColor == CandleColor.GREEN && haDaily[i - 1].HaColor == CandleColor.RED)
                    {
                        if (haDaily.Count - i < 4)
                        {
                            if (D_RealColor == CandleColor.GREEN)
                            {


                                if ((instrumentDetails.Current > pps.PP && instrumentDetails.Current < pps.R1) ||
                                   (instrumentDetails.Current > pps.R1 && instrumentDetails.Current < pps.R2)
                                   )
                                {
                                    result = new Result();
                                    D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                                    result.Instrument = instrument;
                                    result.NumberHaCandles = haDaily.Count - i;
                                    result.D_HA_Color = D_HA_Color;
                                    result.D_RealColor = D_RealColor;
                                    result.H4_HA_Color = H4_HA_Color;
                                    result.H1_HA_Color = H1_HA_Color;
                                    result.M15_HA_Color = M15_HA_Color;
                                    result.InstrumentDetails = instrumentDetails;
                                    result.PivotPointsPosition = ppPosition;
                                    if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                                    {
                                        result.Action = Core.Constants.Action.BUY;
                                    }
                                    else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                    {
                                        result.Action = Core.Constants.Action.BUY;
                                    }
                                    else
                                    {
                                        result.Action = Core.Constants.Action.WAIT;

                                    }

                                }
                                break;
                            }
                        }
                    }

                    i -= 1;
                }
            }
            if (instrumentDetails.Current < ema.FirstOrDefault().Value)//DOWNTREND
            {


                while (i > 0)
                {


                    if (haDaily[i].HaColor == CandleColor.RED && haDaily[i - 1].HaColor == CandleColor.GREEN)
                    {
                        if (haDaily.Count - i < 4)
                        {
                            if (D_RealColor == CandleColor.RED)
                            {
                                D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                                result = new Result();

                                result.Instrument = instrument;

                                result.NumberHaCandles = haDaily.Count - i;
                                result.D_HA_Color = D_HA_Color;
                                result.D_RealColor = D_RealColor;
                                result.H4_HA_Color = H4_HA_Color;
                                result.H1_HA_Color = H1_HA_Color;
                                result.M15_HA_Color = M15_HA_Color;
                                result.InstrumentDetails = instrumentDetails;
                                result.PivotPointsPosition = ppPosition;


                                if ((instrumentDetails.Current < pps.PP && instrumentDetails.Current > pps.S1) ||
                                   (instrumentDetails.Current < pps.S1 && instrumentDetails.Current > pps.S2)
                                   )
                                {

                                    if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                                    {
                                        result.Action = Core.Constants.Action.SELL;
                                    }
                                    else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                    {
                                        result.Action = Core.Constants.Action.SELL;
                                    }
                                    else
                                    {
                                        result.Action = Core.Constants.Action.WAIT;

                                    }

                                }
                                break;

                            }




                        }
                    }
                    i -= 1;
                }
            }







            if (result == null)
            {

                result = new Result();
                result.Instrument = instrument;

                result.NumberHaCandles = 0;
                result.D_HA_Color = D_HA_Color;
                result.D_RealColor = D_RealColor;
                result.H4_HA_Color = H4_HA_Color;
                result.H1_HA_Color = H1_HA_Color;
                result.M15_HA_Color = M15_HA_Color;
                result.Action = Core.Constants.Action.WAIT;
                result.PivotPointsPosition = ppPosition;
            }
            return result;
        }
        public static Result GetResult_HA_EMAs(Instrument instrument, CandleColor Daily_RealColor, List<Candle> haDaily, CandleColor H4_HA_Color, CandleColor H1_HA_Color, CandleColor M15_HA_Color, MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            Result result = null;
            string ppPosition = "";
            Core.Model.Indicators.PivotPoint pps = instrumentDetails.W_PivotPoints;
            if (instrumentDetails.TimeFrame == TimeFrame.MONTHLY)
            {
                pps = instrumentDetails.M_PivotPoints;
                ppPosition = pps.Position;
            }
            else
            {
                ppPosition = pps.Position;

            }




            CandleColor D_RealColor = CandleColor.GREEN;
            CandleColor D_HA_Color = CandleColor.GREEN;
            int i = haDaily.Count() - 1;
            D_RealColor = Daily_RealColor;

            var ema50 = from x in instrumentDetails.EMAs
                        where x.Period == 50
                        select x;
            var ema9 = from x in instrumentDetails.EMAs
                       where x.Period == 9
                       select x;

            while (i > 0)
            {

                if (haDaily[i].HaColor == CandleColor.GREEN && haDaily[i - 1].HaColor == CandleColor.RED)
                {
                    if (haDaily.Count - i < 4)
                    {
                        //if (D_RealColor == CandleColor.GREEN)
                        //{
                        if (haDaily[haDaily.Count() - 1].Close > ema50.FirstOrDefault().Value &&
                        haDaily[haDaily.Count() - 1].Close > ema9.FirstOrDefault().Value)
                        {

                            result = new Result();
                                D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                                result.Instrument = instrument;

                                result.NumberHaCandles = haDaily.Count - i;
                                result.D_HA_Color = D_HA_Color;
                                result.D_RealColor = D_RealColor;
                                result.H4_HA_Color = H4_HA_Color;
                                result.H1_HA_Color = H1_HA_Color;
                                result.M15_HA_Color = M15_HA_Color;
                                result.InstrumentDetails = instrumentDetails;
                                result.PivotPointsPosition = ppPosition;

                                if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                               {
                                    result.Action = Core.Constants.Action.BUY;
                                }
                                else
                                {
                                    result.Action = Core.Constants.Action.WAIT;

                                }
                                break;
                        }

                        //}
                    }
                }
                else if (haDaily[i].HaColor == CandleColor.RED && haDaily[i - 1].HaColor == CandleColor.GREEN)
                {
                    if (haDaily.Count - i < 8)
                    {
                        //if (D_RealColor == CandleColor.RED)
                        //{
                            D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                            result = new Result();

                            result.Instrument = instrument;

                            result.NumberHaCandles = haDaily.Count - i;
                            result.D_HA_Color = D_HA_Color;
                            result.D_RealColor = D_RealColor;
                            result.H4_HA_Color = H4_HA_Color;
                            result.H1_HA_Color = H1_HA_Color;
                            result.M15_HA_Color = M15_HA_Color;
                            result.InstrumentDetails = instrumentDetails;
                            result.PivotPointsPosition = ppPosition;


                        if (haDaily[haDaily.Count() - 1].Close < ema50.FirstOrDefault().Value &&
                        haDaily[haDaily.Count() - 1].Close < ema9.FirstOrDefault().Value)

                        {


                            if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                {
                                    result.Action = Core.Constants.Action.SELL;
                                }
                                else
                                {
                                    result.Action = Core.Constants.Action.WAIT;

                                }
                                break;



                        }

                    }
                }
                i -= 1;
            }

            if (result == null)
            {

                result = new Result();
                result.Instrument = instrument;

                result.NumberHaCandles = 0;
                result.D_HA_Color = D_HA_Color;
                result.D_RealColor = D_RealColor;
                result.H4_HA_Color = H4_HA_Color;
                result.H1_HA_Color = H1_HA_Color;
                result.M15_HA_Color = M15_HA_Color;
                result.Action = Core.Constants.Action.WAIT;
                result.PivotPointsPosition = ppPosition;
            }
            return result;
        }
        public static Result GetResult_HA_EMAs1(Instrument instrument, List<Candle> haDailys, CandleColor H4_HA_Color, CandleColor H1_HA_Color, CandleColor M15_HA_Color, MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            Result result = null;
            string ppPosition = "";
            Core.Model.Indicators.PivotPoint pps = instrumentDetails.W_PivotPoints;
            if (instrumentDetails.TimeFrame == TimeFrame.MONTHLY)
            {
                pps = instrumentDetails.M_PivotPoints;
                ppPosition = pps.Position;
            }
            else
            {
                ppPosition = pps.Position;

            }




            CandleColor D_RealColor = CandleColor.GREEN;
            CandleColor D_HA_Color = CandleColor.GREEN;

            D_RealColor = haDailys[haDailys.Count() - 1].OriginalColor;

            var ema50 = from x in instrumentDetails.EMAs
                        where x.Period == 50
                        select x;
            var ema9 = from x in instrumentDetails.EMAs
                       where x.Period == 9
                       select x;



            List<Model.Candle> last_ha_candles = haDailys.Reverse<Model.Candle>().Take(5).Reverse().ToList<Model.Candle>();
            int i = last_ha_candles.Count() - 1;
            while (i > 0)
            {
                Model.Candle current = last_ha_candles[i];
                Model.Candle previous = null;

                previous = last_ha_candles[i - 1];
                if ((current.HaColor == CandleColor.GREEN && previous.HaColor == CandleColor.RED))
                {

                    if (D_RealColor == CandleColor.GREEN)
                    {

                        if (current.Close > ema50.FirstOrDefault().Value && current.Close > ema9.FirstOrDefault().Value)
                        {
                            result = new Result();
                            D_HA_Color = current.HaColor;
                            result.Instrument = instrument;

                            result.NumberHaCandles = last_ha_candles.Count - i;
                            result.D_HA_Color = D_HA_Color;
                            result.D_RealColor = D_RealColor;
                            result.H4_HA_Color = H4_HA_Color;
                            result.H1_HA_Color = H1_HA_Color;
                            result.M15_HA_Color = M15_HA_Color;
                            result.InstrumentDetails = instrumentDetails;
                            result.PivotPointsPosition = ppPosition;
                            if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                            {
                                result.Action = Core.Constants.Action.BUY;
                            }
                            else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                            {
                                result.Action = Core.Constants.Action.BUY;
                            }
                            else
                            {
                                result.Action = Core.Constants.Action.WAIT;

                            }
                            break;

                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                else if (current.HaColor == CandleColor.RED && previous.HaColor == CandleColor.GREEN)

                {
                    if (D_RealColor == CandleColor.RED)
                    {
                        if (current.Close < ema50.FirstOrDefault().Value && current.Close < ema9.FirstOrDefault().Value)
                        {
                            D_HA_Color = current.HaColor;
                            result = new Result();

                            result.Instrument = instrument;

                            result.NumberHaCandles = last_ha_candles.Count - i;
                            result.D_HA_Color = D_HA_Color;
                            result.D_RealColor = D_RealColor;
                            result.H4_HA_Color = H4_HA_Color;
                            result.H1_HA_Color = H1_HA_Color;
                            result.M15_HA_Color = M15_HA_Color;
                            result.InstrumentDetails = instrumentDetails;
                            result.PivotPointsPosition = ppPosition;

                            if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                            {
                                result.Action = Core.Constants.Action.SELL;
                            }
                            else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                            {
                                result.Action = Core.Constants.Action.SELL;
                            }
                            else
                            {
                                result.Action = Core.Constants.Action.WAIT;

                            }
                            break;
                        }
                        else
                        {
                            break;
                        }


                    }
                    else
                    {
                        break;
                    }

                }

                i -= 1;

            }


            if (result == null)
            {

                result = new Result();
                result.Instrument = instrument;

                result.NumberHaCandles = 0;
                result.D_HA_Color = D_HA_Color;
                result.D_RealColor = D_RealColor;
                result.H4_HA_Color = H4_HA_Color;
                result.H1_HA_Color = H1_HA_Color;
                result.M15_HA_Color = M15_HA_Color;
                result.Action = Core.Constants.Action.WAIT;
                result.PivotPointsPosition = ppPosition;
            }
            return result;
        }


    }
}

