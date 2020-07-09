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


    }
}
