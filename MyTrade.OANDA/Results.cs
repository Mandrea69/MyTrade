
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

        public static void Get(Instrument instrument, string HA_M15_Color, string HA_H1_Color, string HA_H4_Color, List<Candle> haDaily, MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            string dCandleColor = "";
            string originalCandleColor = "";

            int i = haDaily.Count() - 1;
            while (i > 0)
            {

                if (haDaily[i].HaColor == CandleColor.GREEN && haDaily[i - 1].HaColor == CandleColor.RED)
                {
                    if (haDaily.Count - i < 4)
                    {
                        originalCandleColor = haDaily[haDaily.Count() - 1].OriginalColor.ToString();
                        dCandleColor = haDaily[haDaily.Count() - 1].HaColor.ToString();
                        string statusPrice = "";
                        if (instrumentDetails.Current > instrumentDetails.EMA)
                        {
                            statusPrice = "BUY";
                        }
                        else
                        {
                            statusPrice = "WAIT";
                        }

                        double sl = haDaily[haDaily.Count - 2].Open;
                        string alert = instrument.DisplayName + Environment.NewLine;
                        alert += string.Format("{0,-15}{1,-10}{2,-5}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}", instrument.Name, instrument.Type, (haDaily.Count - i).ToString(), originalCandleColor, dCandleColor, HA_H4_Color, HA_H1_Color, HA_M15_Color, statusPrice, sl);


                        if (statusPrice == "BUY")
                        {
                            if (originalCandleColor == CandleColor.GREEN.ToString())
                            {
                                if (originalCandleColor == dCandleColor && HA_H1_Color == dCandleColor && HA_H4_Color == dCandleColor && HA_M15_Color == dCandleColor)
                                {
                                    //GreenAlerts.Add(alert);
                                }
                                else if (originalCandleColor == dCandleColor && originalCandleColor == HA_M15_Color)
                                {
                                    //YellowAlerts.Add(alert);
                                }

                                //else if (originalCandleColor == dCandleColor)
                                //{
                                //    BlueAlerts.Add(alert);
                                //}
                            }
                        }
                        else
                        {

                            Console.WriteLine(alert);
                            Console.WriteLine();
                        }

                        break;
                    }
                }

                else if (haDaily[i].HaColor == CandleColor.RED && haDaily[i - 1].HaColor == CandleColor.GREEN)
                {
                    if (haDaily.Count - i < 4)
                    {
                        originalCandleColor = haDaily[haDaily.Count() - 1].OriginalColor.ToString();
                        dCandleColor = haDaily[haDaily.Count() - 1].HaColor.ToString();
                        string statusPrice = "";
                        if (instrumentDetails.Current < instrumentDetails.EMA)
                        {
                            statusPrice = "SELL";
                        }
                        else
                        {
                            statusPrice = "WAIT";
                        }

                        double sl = haDaily[haDaily.Count - 2].Open;
                        string alert = instrument.DisplayName + Environment.NewLine;
                        alert += string.Format("{0,-15}{1,-10}{2,-5}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}", instrument.Name, instrument.Type, (haDaily.Count - i).ToString(), originalCandleColor, dCandleColor, HA_H4_Color, HA_H1_Color, HA_M15_Color, statusPrice, sl);



                        if (statusPrice == "SELL")
                        {
                            if (originalCandleColor == CandleColor.RED.ToString())
                            {
                                if (originalCandleColor == dCandleColor && HA_H1_Color == dCandleColor && HA_H4_Color == dCandleColor && HA_M15_Color == dCandleColor)
                                {
                                    //GreenAlerts.Add(alert);
                                }
                                else if (originalCandleColor == dCandleColor && originalCandleColor == HA_M15_Color)
                                {
                                    //YellowAlerts.Add(alert);
                                }

                                //else if (originalCandleColor == dCandleColor)
                                //{
                                //    BlueAlerts.Add(alert);
                                //}
                            }
                        }
                        else
                        {

                            Console.WriteLine(alert);
                            Console.WriteLine();
                        }

                        break;
                    }
                }

                i -= 1;
            }


        }
        public static Result GetResult(Instrument instrument, List<Candle> haDaily, CandleColor H4_HA_Color, CandleColor H1_HA_Color, CandleColor M15_HA_Color, MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            Result result = null;


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
                                   ((instrumentDetails.Current> instrumentDetails.PivotPoints.PP && instrumentDetails.Current < instrumentDetails.PivotPoints.R1)||
                                   (instrumentDetails.Current > instrumentDetails.PivotPoints.R1 && instrumentDetails.Current < instrumentDetails.PivotPoints.R2)
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
                                   ((instrumentDetails.Current < instrumentDetails.PivotPoints.PP && instrumentDetails.Current > instrumentDetails.PivotPoints.S1) ||
                                   (instrumentDetails.Current < instrumentDetails.PivotPoints.S1 && instrumentDetails.Current > instrumentDetails.PivotPoints.S2)
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
