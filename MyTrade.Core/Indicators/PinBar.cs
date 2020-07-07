using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.Core.Indicators
{
    public class PinBar
    {
      static  int depth = 40;   //Depth of pinbars in percents
      static  int maxRange = 100;  //Maximum range
      static  int minRange = 20;   //Minimum range
      static  bool extremum = true; //Only extremum
      static  double pp = 0.0001;
        static int _digits = 5;

    public static    bool PinUp(DateTime time, double open, double high, double low, double close)
        {
            int range = (int)Math.Round((high - low) / pp);
            int zone = (int)Math.Round(range * depth * 0.01);
            //int shift = iBarShift(_Symbol, PERIOD_D1, time, true);
            double dayHidh = high;//iHigh(_Symbol, PERIOD_D1, shift);
            double level = Math.Round(low + zone * pp, _digits);
            bool check = false;

            if (range > minRange && range < maxRange)
            {
                if ((extremum && high == dayHidh) || !extremum)
                    check = true;
                if (open <= level && close <= level && check)
                {
                    return (true);
                }
            }

            return (false);
        }

        public static bool PinDown(DateTime time, double open, double high, double low, double close)
        {
            int range = (int)Math.Round((high - low) / pp);
            int zone = (int)Math.Round(range * depth * 0.01);                 
            //int shift = iBarShift(_Symbol, PERIOD_D1, time, true);          
            double dayLow = low;// iLow(_Symbol, PERIOD_D1, shift);           
            double level = Math.Round(high - zone * pp, _digits);             
            bool check = false;                                               
                                                                              
            if (range > minRange && range < maxRange)                         
            {                                                                 
                if ((extremum && low == dayLow) || !extremum)                 
                    check = true;                                             
                if (open >= level && close >= level && check)                 
                {                                                             
                    return (true);                                            
                }                                                             
            }                                                                 
                                                                              
            return (false);
        }

    }
}
