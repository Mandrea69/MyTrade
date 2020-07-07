
using MyTrade.Core.Model;
using MyTrade.OANDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MyTrade.Core.Constants;

namespace MyTrade.OANDA
{
    public class Results
    {

        public static Result GetResult(Instrument instrument, List<Candle> haDaily, CandleColor H4_HA_Color, CandleColor H1_HA_Color, CandleColor M15_HA_Color, MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            Result result = null;
            Core.Model.Indicators.PivotPoint pps = instrumentDetails.D_PivotPoints;
            if (pps == null)
            {
                pps = instrumentDetails.W_PivotPoints;
            }

            CandleColor D_RealColor = CandleColor.GREEN;
            CandleColor D_HA_Color = CandleColor.GREEN;
            //if (instrument.DisplayName == "GBP/CAD")
            //{
            int i = haDaily.Count() - 1;
            while (i > 0)
            {

                if (haDaily[i].HaColor == CandleColor.GREEN && haDaily[i - 1].HaColor == CandleColor.RED)
                {
                    if (haDaily.Count - i < 4)
                    {
                        result = new Result();
                        D_RealColor = haDaily[haDaily.Count() - 1].OriginalColor;
                        D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                        result.DisplayName = instrument.DisplayName;
                        result.Name = instrument.Name;
                        result.Type = instrument.Type;
                        result.NumberHaCandles = haDaily.Count - i;
                        result.D_HA_Color = D_HA_Color;
                        result.D_RealColor = D_RealColor;
                        result.H4_HA_Color = H4_HA_Color;
                        result.H1_HA_Color = H1_HA_Color;
                        result.M15_HA_Color = M15_HA_Color;
                        result.InstrumentDetails = instrumentDetails;
                      

                        if (D_RealColor == CandleColor.GREEN)
                        {
                            if (instrumentDetails.Current > instrumentDetails.EMA &&
                               ((instrumentDetails.Current > pps.PP && instrumentDetails.Current < pps.R1) ||
                               (instrumentDetails.Current > pps.R1 && instrumentDetails.Current < pps.R2)
                               ))
                            {

                                if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                                {
                                    result.Action = Core.Constants.Action.BUY;
                                }
                                else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                {
                                    result.Action = Core.Constants.Action.BUY;
                                }
                            }
                            else
                            {
                                result.Action = Core.Constants.Action.WAIT;

                            }

                        }
                        else
                        {
                            result.Action = Core.Constants.Action.WAIT;

                        }



                        break;
                    }
                }

                else if (haDaily[i].HaColor == CandleColor.RED && haDaily[i - 1].HaColor == CandleColor.GREEN)
                {
                    if (haDaily.Count - i < 4)
                    {
                        D_RealColor = haDaily[haDaily.Count() - 1].OriginalColor;
                        D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                        result = new Result();

                        result.DisplayName = instrument.DisplayName;
                        result.Name = instrument.Name;
                        result.Type = instrument.Type;
                        result.NumberHaCandles = haDaily.Count - i;
                        result.D_HA_Color = D_HA_Color;
                        result.D_RealColor = D_RealColor;
                        result.H4_HA_Color = H4_HA_Color;
                        result.H1_HA_Color = H1_HA_Color;
                        result.M15_HA_Color = M15_HA_Color;
                        result.InstrumentDetails = instrumentDetails;

                        if (D_RealColor == CandleColor.RED)
                        {

                            if (instrumentDetails.Current < instrumentDetails.EMA &&
                               ((instrumentDetails.Current < pps.PP && instrumentDetails.Current > pps.S1) ||
                               (instrumentDetails.Current < pps.S1 && instrumentDetails.Current > pps .S2)
                               ))
                            {

                                if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                                {
                                    result.Action = Core.Constants.Action.SELL;
                                }
                                else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                {
                                    result.Action = Core.Constants.Action.SELL;
                                }


                            }
                            else
                            {
                                result.Action = Core.Constants.Action.WAIT;

                            }
                        }
                        else
                        {
                            result.Action = Core.Constants.Action.WAIT;

                        }


                        break;
                    }
                }

                i -= 1;
            }

            if (result == null)
            {
                D_RealColor = haDaily[haDaily.Count() - 1].OriginalColor;
                D_HA_Color = haDaily[haDaily.Count() - 1].HaColor;
                result = new Result();
                result.DisplayName = instrument.DisplayName;
                result.Name = instrument.Name;
                result.Type = instrument.Type;
                result.NumberHaCandles = 0;
                result.D_HA_Color = D_HA_Color;
                result.D_RealColor = D_RealColor;
                result.H4_HA_Color = H4_HA_Color;
                result.H1_HA_Color = H1_HA_Color;
                result.M15_HA_Color = M15_HA_Color;
                result.Action = Core.Constants.Action.WAIT;
            }
            //}

            return result;
        }

    }
}
