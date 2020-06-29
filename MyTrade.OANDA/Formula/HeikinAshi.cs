using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTrade.OANDA.Formula
{
    public class HeikinAshi
    {
        public static double OpenValue(double openpreviousbar, double closepreviousbar) {
            double openValue = (openpreviousbar+ closepreviousbar)/2;

            return Math.Round(openValue,5);
        }

        public static double CloseValue(double opencurrentbar, double closecurrentbar, double maxcurrentbar, double mincurrentbar)
        {
            double closeValue = (opencurrentbar + closecurrentbar + maxcurrentbar + mincurrentbar) / 4;

            return Math.Round(closeValue, 5);
        }

        public static double MinValue(double mincurrentbar, double openValue, double closeValue)
        {
            double minValue =Math.Min(Math.Min(mincurrentbar,openValue),closeValue);

            return Math.Round(minValue, 5);
        }

        public static double MaxValue(double maxcurrentbar, double openValue, double closeValue)
        {
            double maxValue = Math.Max(Math.Max(maxcurrentbar, openValue), closeValue);

            return Math.Round(maxValue, 5);
        }
    }
}
