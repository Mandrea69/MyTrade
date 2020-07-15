using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using OANDA.Formula;
using OANDA.Logs;
using System.Linq;
using OANDA.Model;

using System.Text.Json;
using OANDA.Model.Communication;
using OANDA.Data;
using System.Runtime.CompilerServices;
using System.Globalization;
using OANDA.Utilities;
using System.Reflection;
using Candle = OANDA.Model.Candle;

namespace OANDA
{
    class Program
    {



        static void Main(string[] args)
        {
            //List<Model.Instrument> instruments= Data.Instrument.All();
            // foreach (Model.Instrument item in instruments)
            // {
            //     List<Candle> d_candles = Data.Prices.GetCandles(item.Name, 2, "D");
            //     foreach (var c in d_candles)
            //     {
            //        if( CandleStick.ShootingStar(c)==true)
            //         {
            //             Console.WriteLine("ShootingStar " + item.DisplayName + " " + c.Time);
            //         }
            //         if (CandleStick.BlackSpinningTop(c) == true)
            //         {
            //             Console.WriteLine("BlackSpinningTop " + item.DisplayName + " " + c.Time);
            //         }
            //         if (CandleStick.BullishDragonflyDoji(c) == true)
            //         {
            //             Console.WriteLine("BullishDragonflyDoji " + item.DisplayName + " " + c.Time);
            //         }
            //         if (CandleStick.Hammer(c) == true)
            //         {
            //             Console.WriteLine("Hammer " + item.DisplayName + " " + c.Time);
            //         }
            //         if (CandleStick.HangingMan(c) == true)
            //         {
            //             Console.WriteLine("HangingMan " + item.DisplayName + " " + c.Time);
            //         }
            //         if (CandleStick.InvertedHammer(c) == true)
            //         {
            //             Console.WriteLine("HangingMan " + item.DisplayName + " " + c.Time);
            //         }

            //         if (CandleStick.WhiteSpinningTop(c) == true)
            //         {
            //             Console.WriteLine("WhiteSpinningTop " + item.DisplayName + " " + c.Time);
            //         }

            //     }
            // }

            DateTime openDate = new DateTime(2020, 6, 5);
            DateTime currentWeekstartDate = openDate;
            DateTime previousWeekStartDate = openDate.AddDays(-1);
            if (Convert.ToInt16(openDate.DayOfWeek) > 1)
            {
                currentWeekstartDate = openDate.AddDays(-(Convert.ToInt16(openDate.DayOfWeek) - 1));
                previousWeekStartDate = currentWeekstartDate.AddDays(-7);
            }


            List<Model.Candle> candles=  Data.Prices.GetCandles("GBP_CAD", previousWeekStartDate, "W");
            Console.WriteLine(candles.FirstOrDefault().Time);
            MyTrade.Core.Indicators.PivotPoints pp = new MyTrade.Core.Indicators.PivotPoints();
          


        }
        public static void Get(Candle candleDayBefore)
        {
          
            double h = candleDayBefore.Hight;
            double l = candleDayBefore.Low;
            double c = candleDayBefore.Close;

           Console.WriteLine("PP " + (h + l + c) / 3);
            //pps.R1 = (2 * pps.PP) - l;
            //pps.S1 = (2 * pps.PP) - h;

            //pps.R2 = pps.PP + (h + l);
            //pps.S2 = pps.PP - (h + l);

            //pps.R3 = h + 2 * (pps.PP - l);
            //pps.S3 = l - 2 * (h - pps.PP);
            //return pps;

        }
    }


}
