using MyTrade.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MyTrade.Core.Constants;

namespace MyTrade.Core.Indicators
{
    public class HeikinAshi
    {
         static double OpenValue(double openpreviousbar, double closepreviousbar) {
            double openValue = (openpreviousbar+ closepreviousbar)/2;

            return Math.Round(openValue,5);
        }

         static double CloseValue(double opencurrentbar, double closecurrentbar, double maxcurrentbar, double mincurrentbar)
        {
            double closeValue = (opencurrentbar + closecurrentbar + maxcurrentbar + mincurrentbar) / 4;

            return Math.Round(closeValue, 5);
        }

         static double MinValue(double mincurrentbar, double openValue, double closeValue)
        {
            double minValue =Math.Min(Math.Min(mincurrentbar,openValue),closeValue);

            return Math.Round(minValue, 5);
        }

         static double MaxValue(double maxcurrentbar, double openValue, double closeValue)
        {
            double maxValue = Math.Max(Math.Max(maxcurrentbar, openValue), closeValue);

            return Math.Round(maxValue, 5);
        }

        public static Candle Generate(Candle HApreviousCandel, Candle currentCandel)
        {


            Candle HAcandel = new Candle();
            HAcandel.Time = currentCandel.Time;
            HAcandel.Open = HeikinAshi.OpenValue(HApreviousCandel.Open, HApreviousCandel.Close);
            HAcandel.Close = HeikinAshi.CloseValue(currentCandel.Open, currentCandel.Close, currentCandel.High, currentCandel.Low);
            double low = HeikinAshi.MinValue(currentCandel.Low, HAcandel.Open, HAcandel.Close);
            double high = HeikinAshi.MaxValue(currentCandel.High, HAcandel.Open, HAcandel.Close);
            HAcandel.OriginalColor = currentCandel.OriginalColor;
            if (HAcandel.Open < HAcandel.Close)
            {
                HAcandel.Low = low;
                HAcandel.High = high;
                HAcandel.HaColor = CandleColor.GREEN;
            }
            else
            {
                HAcandel.Low = high;
                HAcandel.High = low;
                HAcandel.HaColor = CandleColor.RED;
            }
            return HAcandel;

        }
        public static Candle GeneratePrevious(Candle currentCandel)
        {
            Candle HAcandel = new Candle();
            if (currentCandel.Open < currentCandel.Close)
            {
                HAcandel.Low = currentCandel.Low;
                HAcandel.High = currentCandel.High;
                HAcandel.HaColor = CandleColor.GREEN;

            }
            else
            {
                HAcandel.Low = currentCandel.High;
                HAcandel.High = currentCandel.Low;

                HAcandel.HaColor = CandleColor.RED;
            }
            HAcandel.OriginalColor = currentCandel.OriginalColor;
            HAcandel.Open = currentCandel.Open;
            HAcandel.Close = currentCandel.Close;
            HAcandel.Time = currentCandel.Time;
            return HAcandel;

        }
    }
}
