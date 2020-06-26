using OANDA.Formula;
using OANDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OANDA
{
    public class Results
    {
       

        public static List<string> GreenAlerts = new List<string>();
        public static List<string> YellowAlerts = new List<string>();
        public static List<string> BlueAlerts = new List<string>();
        public static void Get(Instrument instrument, string HA_M15_Color, string HA_H1_Color, string HA_H4_Color, List<Model.Candle> haDaily, Model.InstrumentDayPrice instrumentDayPrice)
        {

            string dCandleColor = "";
            string originalCandleColor = "";

            int i = haDaily.Count() - 1;
            while (i > 0)
            {

                if (haDaily[i].Color == Constants.CandelColour.GREEN && haDaily[i - 1].Color == Constants.CandelColour.RED)
                {
                    if (haDaily.Count - i < 4)
                    {
                        originalCandleColor = haDaily[haDaily.Count() - 1].OriginalColor.ToString();
                        dCandleColor = haDaily[haDaily.Count() - 1].Color.ToString();
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
                            if (originalCandleColor == Constants.CandelColour.GREEN.ToString())
                            {
                                if (originalCandleColor == dCandleColor && HA_H1_Color == dCandleColor && HA_H4_Color == dCandleColor && HA_M15_Color == dCandleColor)
                                {
                                    GreenAlerts.Add(alert);
                                }
                                else if (originalCandleColor == dCandleColor &&   originalCandleColor == HA_M15_Color)
                                {
                                    YellowAlerts.Add(alert);
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

                else if (haDaily[i].Color == Constants.CandelColour.RED && haDaily[i - 1].Color == Constants.CandelColour.GREEN)
                {
                    if (haDaily.Count - i < 4)
                    {
                        originalCandleColor = haDaily[haDaily.Count() - 1].OriginalColor.ToString();
                        dCandleColor = haDaily[haDaily.Count() - 1].Color.ToString();
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
                            if (originalCandleColor == Constants.CandelColour.RED.ToString())
                            {
                                if (originalCandleColor == dCandleColor && HA_H1_Color == dCandleColor && HA_H4_Color == dCandleColor && HA_M15_Color == dCandleColor)
                                {
                                    GreenAlerts.Add(alert);
                                }
                                else if (originalCandleColor == dCandleColor && originalCandleColor == HA_M15_Color)
                                {
                                    YellowAlerts.Add(alert);
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

    }
}
