
using MyTrade.OANDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTrade.OANDA
{
    public class Results
    {

        public static void Get(Instrument instrument, string HA_M15_Color, string HA_H1_Color, string HA_H4_Color, List<Model.Candle> haDaily, Model.InstrumentDayPrice instrumentDayPrice)
        {
            string dCandleColor = "";
            string originalCandleColor = "";

            int i = haDaily.Count() - 1;
            while (i > 0)
            {

                if (haDaily[i].HaColor == Constants.CandleColor.GREEN && haDaily[i - 1].HaColor == Constants.CandleColor.RED)
                {
                    if (haDaily.Count - i < 4)
                    {
                        originalCandleColor = haDaily[haDaily.Count() - 1].OriginalColor.ToString();
                        dCandleColor = haDaily[haDaily.Count() - 1].HaColor.ToString();
                        string statusPrice = "";
                        if (instrumentDayPrice.Current > instrumentDayPrice.EMA)
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
                            if (originalCandleColor == Constants.CandleColor.GREEN.ToString())
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

                else if (haDaily[i].HaColor == Constants.CandleColor.RED && haDaily[i - 1].HaColor == Constants.CandleColor.GREEN)
                {
                    if (haDaily.Count - i < 4)
                    {
                        originalCandleColor = haDaily[haDaily.Count() - 1].OriginalColor.ToString();
                        dCandleColor = haDaily[haDaily.Count() - 1].HaColor.ToString();
                        string statusPrice = "";
                        if (instrumentDayPrice.Current < instrumentDayPrice.EMA)
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
                            if (originalCandleColor == Constants.CandleColor.RED.ToString())
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
        public static Model.Result GetResult(Instrument instrument, List<Model.Candle> haDaily, Constants.CandleColor H4_HA_Color, Constants.CandleColor H1_HA_Color, Constants.CandleColor M15_HA_Color, Model.InstrumentDayPrice instrumentDayPrice)
        {
            Model.Result result = null;


            Constants.CandleColor D_RealColor = Constants.CandleColor.GREEN;
            Constants.CandleColor D_HA_Color = Constants.CandleColor.GREEN;
            //if (instrument.DisplayName == "GBP/CAD")
            //{
                int i = haDaily.Count() - 1;
                while (i > 0)
                {

                    if (haDaily[i].HaColor == Constants.CandleColor.GREEN && haDaily[i - 1].HaColor == Constants.CandleColor.RED)
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

                            if (D_RealColor == Constants.CandleColor.GREEN)
                            {
                                if (instrumentDayPrice.Current > instrumentDayPrice.EMA && instrumentDayPrice.Current> instrumentDayPrice.PivotPoints.PP && 
                                instrumentDayPrice.Current < instrumentDayPrice.PivotPoints.R1)
                                {

                                    if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                                    {
                                        result.Action = Constants.Action.BUY;
                                    }
                                    else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                    {
                                        result.Action = Constants.Action.BUY;
                                    }
                                }
                                else
                                {
                                    result.Action = Constants.Action.WAIT;

                                }
                               
                            }
                            else
                            {
                                result.Action = Constants.Action.WAIT;

                            }
                           


                            break;
                        }
                }

                else if (haDaily[i].HaColor == Constants.CandleColor.RED && haDaily[i - 1].HaColor == Constants.CandleColor.GREEN)
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

                           
                            if (D_RealColor == Constants.CandleColor.RED)
                            {

                                if (instrumentDayPrice.Current < instrumentDayPrice.EMA && instrumentDayPrice.Current < instrumentDayPrice.PivotPoints.PP && instrumentDayPrice.Current > instrumentDayPrice.PivotPoints.S1)
                                {

                                    if (D_RealColor == D_HA_Color && H1_HA_Color == D_HA_Color && H4_HA_Color == D_HA_Color && M15_HA_Color == D_HA_Color)
                                    {
                                        result.Action = Constants.Action.SELL;
                                    }
                                    else if (D_RealColor == D_HA_Color && D_RealColor == M15_HA_Color)
                                    {
                                        result.Action = Constants.Action.SELL;
                                    }


                                }
                                else
                                {
                                    result.Action = Constants.Action.WAIT;

                                }
                            }
                            else
                            {
                                result.Action = Constants.Action.WAIT;

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
                result.Action = Constants.Action.WAIT;
            }
            //}

            return result;
        }

    }
}
