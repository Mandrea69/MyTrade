using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA
{
    public class CandleStick
    {
        public static bool Hammer(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;



            return (((H - L) > 3 * (O - C)) && ((C - L) / (0.001 + H - L) > 0.6) && ((O - L) / (.001 + H - L) > 0.6));
                }
        public static bool HangingMan(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;

            return   (((H - L) > 4 * (O - C)) &&((C - L) / (0.001 + H - L) >= 0.75) &&((O - L) / (0.001 + H - L) >= 0.75));
        }
        public static bool BullishDragonflyDoji(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;

            return ((H - L) > 3 * Math.Abs(O - C)) && ((C - L) > 0.8 * (H - L)) && ((O - L) > 0.8 * (H - L));
        }

        public static bool BlackSpinningTop(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;

            return (O > C) &&((H - L) > (3 * (O - C)) &&(((H - O) / (0.001 + H - L)) < 0.4) &&(((C - L) / (0.001 + H - L)) < 0.4));
        }
        public static bool WhiteSpinningTop(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;

            return ((C > O &&((H - L) > (3 * (C - O))) &&(((H - C) / (0.001 + H - L)) < 0.4) &&(((O - L) / (0.001 + H - L)) < 0.4)));
        }

        public static bool InvertedHammer(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;



            return (((H - L) > 3 * (O - C)) &&((H - C) / (.001 + H - L) > 0.6) &&((H - O) / (.001 + H - L) > 0.6));
        }
        public static bool ShootingStar(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;



            return (((H - L) > 4 * (O - C)) && ((H - C) / (.001 + H - L) >= 0.75) && ((H - O) / (.001 + H - L) >= 0.75));
        }
        public static bool BullishEngulfing(Model.Candle candle)
        {
            double H = candle.Hight;
            double L = candle.Low;
            double O = candle.Open;
            double C = candle.Close;



            return (((H - L) > 4 * (O - C)) && ((H - C) / (.001 + H - L) >= 0.75) && ((H - O) / (.001 + H - L) >= 0.75));

        }
        public static bool BearichEngulfing(Model.Candle lastcandle, Model.Candle previouscandle)
        {

            if(lastcandle.Color== Constants.CandelColour.RED && previouscandle.Color== Constants.CandelColour.GREEN)
            {
                double P_H = previouscandle.Hight;
                double P_L = previouscandle.Low;
                double P_O = previouscandle.Open;
                double P_C = previouscandle.Close;

                double L_H = lastcandle.Hight;
                double L_L = lastcandle.Low;
                double L_O = lastcandle.Open;
                double L_C = lastcandle.Close;


                return true; /*((C1 > O1) AND(O > C) AND(O >= C1) AND(O1 >= C) AND((O - C) > (C1 - O1)))*/

            }
            else
            {
                return false;
            }







            return true; /*(((H - L) > 4 * (O - C)) && ((H - C) / (.001 + H - L) >= 0.75) && ((H - O) / (.001 + H - L) >= 0.75));*/
        }


    }
}
