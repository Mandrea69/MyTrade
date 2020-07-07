using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA
{
    public class PinBar
    {
      static  int depth = 40;   //Depth of pinbars in percents
      static  int MaxRange = 100;  //Maximum range
      static  int MinRange = 20;   //Minimum range
      static  bool Extremum = true; //Only extremum
      static  double Pp = 0.0001;
        static int _Digits = 5;

    public static    bool PinUp(DateTime time, double open, double high, double low, double close)
        {
            int range = (int)Math.Round((high - low) / Pp);
            int zone = (int)Math.Round(range * depth * 0.01);
            //int shift = iBarShift(_Symbol, PERIOD_D1, time, true);
            double dayHidh = high;//iHigh(_Symbol, PERIOD_D1, shift);
            double level = Math.Round(low + zone * Pp, _Digits);
            bool check = false;

            if (range > MinRange && range < MaxRange)
            {
                if ((Extremum && high == dayHidh) || !Extremum)
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
            int range = (int)Math.Round((high - low) / Pp);
            int zone = (int)Math.Round(range * depth * 0.01);                      //////////////////////////////////////
            //int shift = iBarShift(_Symbol, PERIOD_D1, time, true);                 //                                  //
            double dayLow = low;// iLow(_Symbol, PERIOD_D1, shift);                        //       |      --|      --|        //
            double level = Math.Round(high - zone * Pp, _Digits);              //      ---       |        |        //
            bool check = false;                                                     //      | |       |-- zone |        //
                                                                                    //      | |       |        |        //
            if (range > MinRange && range < MaxRange)                               //      ---     --|- level |        //
            {                                                                      //       |                 |        //
                if ((Extremum && low == dayLow) || !Extremum)                         //       |                 |- range //
                    check = true;                                                        //       |                 |        //
                if (open >= level && close >= level && check)                         //       |                 |        //
                {                                                                    //       |                 |        //
                    return (true);                                                       //       |                 |        //
                }                                                                    //       |               --|        //
            }                                                                      //                                  //
                                                                                   //////////////////////////////////////
            return (false);
        }

    }
}
