using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrade.OANDA.Formula
{
   public class Currentvalue
    {
       public static double Get(double bid, double ask)
        {
            double current = (bid + ask) / 2;

            return Math.Round(current, 5); ;
        }
    }
}
