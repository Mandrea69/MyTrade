using OANDA.Formula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OANDA.Data
{
    public class Candle
    {
        public static Model.Candle Generate(Model.Candle HApreviousCandel, Model.Candle currentCandel)
        {


            Model.Candle HAcandel = new Model.Candle();
            HAcandel.Time = currentCandel.Time;
            HAcandel.Open = HeikinAshi.OpenValue(HApreviousCandel.Open, HApreviousCandel.Close);
            HAcandel.Close = HeikinAshi.CloseValue(currentCandel.Open, currentCandel.Close, currentCandel.Hight, currentCandel.Low);
            double low = HeikinAshi.MinValue(currentCandel.Low, HAcandel.Open, HAcandel.Close);
            double high = HeikinAshi.MaxValue(currentCandel.Hight, HAcandel.Open, HAcandel.Close);
            HAcandel.OriginalColor = currentCandel.OriginalColor;
            if (HAcandel.Open < HAcandel.Close)
            {
                HAcandel.Low = low;
                HAcandel.Hight = high;
                HAcandel.Color = Constants.CandelColour.GREEN;
            }
            else
            {
                HAcandel.Low = high;
                HAcandel.Hight = low;
                HAcandel.Color = Constants.CandelColour.RED;
            }
            return HAcandel;

        }
        public static Model.Candle GeneratePrevious(Model.Candle currentCandel)
        {
            Model.Candle HAcandel = new Model.Candle();
            if (currentCandel.Open < currentCandel.Close)
            {
                HAcandel.Low = currentCandel.Low;
                HAcandel.Hight = currentCandel.Hight;
                HAcandel.Color = Constants.CandelColour.GREEN;

            }
            else
            {
                HAcandel.Low = currentCandel.Hight;
                HAcandel.Hight = currentCandel.Low;

                HAcandel.Color = Constants.CandelColour.RED;
            }
            HAcandel.OriginalColor = currentCandel.OriginalColor;
            HAcandel.Open = currentCandel.Open;
            HAcandel.Close = currentCandel.Close;
            HAcandel.Time = currentCandel.Time;
            return HAcandel;

        }

    }
}
