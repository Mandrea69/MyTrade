


using OANDA.Logs;
using OANDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OANDA.Rules
{
    public class HeikenHashi
    {
        public class Rule1
        {
            public class ChangeColorRSI
            {
                public static bool OpenOrder(double realPrice, Model.Order currentOrder,
               Candle currentCandel, Constants.TrendPhase trendPhase,double rsi)
            {
                bool openOrder = false;
                if (trendPhase == Constants.TrendPhase.LONG)
                {
                    if ( currentCandel.Color == Constants.CandelColour.GREEN  && rsi>50 && currentOrder==null)
                    {
                        openOrder = true;
                      
                    }


                }
                else if (trendPhase == Constants.TrendPhase.SHORT)
                {
                    if (currentCandel.Color == Constants.CandelColour.RED && rsi < 50 && currentOrder == null)
                    {
                        openOrder = true;
                        
                    }


                }
              

                return openOrder;

            }
            }
            public class ChangeColor
            {
                public static bool OpenOrder(double realPrice, Model.Order currentOrder,
              Candle currentCandle, Candle previousCandle,Constants.TrendPhase trendPhase)
            {
                bool openOrder = false;
                if (trendPhase == Constants.TrendPhase.LONG)
                {
                    if (currentCandle.Color == Constants.CandelColour.GREEN && previousCandle.Color == Constants.CandelColour.RED && currentOrder == null)
                    {
                        openOrder = true;

                    }


                }
                else if (trendPhase == Constants.TrendPhase.SHORT)
                {
                    if (currentCandle.Color == Constants.CandelColour.RED && previousCandle.Color == Constants.CandelColour.GREEN && currentOrder == null)
                    {
                        openOrder = true;

                    }


                }


                return openOrder;

            }
                public static bool CloseOrder(double currentPrice, Model.Order order,  Constants.TrendPhase trendPhase, Candle currentCandle, Candle previousCandle)
                {
                    bool closeOrder = false;
                    if (order != null)
                    {
                        if (trendPhase == Constants.TrendPhase.LONG)
                        {
                            if (currentCandle.Color == Constants.CandelColour.RED && previousCandle.Color == Constants.CandelColour.GREEN && order != null)
                            {
                                closeOrder = true; 
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice);
                                LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice);
                                Console.ResetColor();
                            }
                           


                        }
                        else if (trendPhase == Constants.TrendPhase.SHORT)
                        {

                            if (currentCandle.Color == Constants.CandelColour.GREEN && previousCandle.Color == Constants.CandelColour.RED && order != null)
                            {
                                closeOrder = true; Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice);
                                LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice);
                                Console.ResetColor();
                            }
                           


                        }

                    }

                    return closeOrder;
                }
            }
            public class SL_TP
            {
                public static bool CloseOrder(Model.Order order, double currentPrice, Constants.TrendPhase trendPhase )
            {
                bool closeOrder = false;
                if (order != null)
                {
                    if (trendPhase == Constants.TrendPhase.LONG)
                    {
                        if (currentPrice >= order.TakeProfit && order!=null)
                        {
                            closeOrder = true; Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice + " TP :" + order.TakeProfit);
                            LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice + " TP :" + order.TakeProfit);
                            Console.ResetColor();
                        }
                        else if (currentPrice <= order.StopLoss && order != null)
                        {
                            closeOrder = true;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                            LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                            Console.ResetColor();
                        }
                       

                    }
                    else if (trendPhase == Constants.TrendPhase.SHORT)
                    {

                        if (currentPrice <= order.TakeProfit)
                        {
                            closeOrder = true;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice + " TP :" + order.TakeProfit);
                            LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER:" + currentPrice + " TP :" + order.TakeProfit);
                            Console.ResetColor();
                        }
                        else if (currentPrice >= order.StopLoss)
                        {
                            closeOrder = true;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                            LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                            Console.ResetColor();
                        }
                       

                    }

                }

                return closeOrder;
            }
            }

            public class  SL
            {
                public static bool CloseOrder(Model.Order order, double currentPrice, Constants.TrendPhase trendPhase)
                {
                    bool closeOrder = false;
                    if (order != null)
                    {
                        if (trendPhase == Constants.TrendPhase.LONG)
                        {
                          if (currentPrice <= order.StopLoss && order != null)
                            {
                                closeOrder = true;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                                LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                                Console.ResetColor();
                            }


                        }
                        else if (trendPhase == Constants.TrendPhase.SHORT)
                        {

                            if (currentPrice >= order.StopLoss)
                            {
                                closeOrder = true;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                                LogWriter.WriteLog(DateTime.Now + " CLOSE ORDER :" + currentPrice + " SL :" + order.StopLoss);
                                Console.ResetColor();
                            }


                        }

                    }

                    return closeOrder;
                }
            }



        }
    }
}
