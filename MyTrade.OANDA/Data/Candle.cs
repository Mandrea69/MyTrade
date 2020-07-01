
using MyTrade.OANDA.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrade.OANDA.Data
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
                HAcandel.HaColor = Constants.CandleColor.GREEN;
            }
            else
            {
                HAcandel.Low = high;
                HAcandel.Hight = low;
                HAcandel.HaColor = Constants.CandleColor.RED;
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
                HAcandel.HaColor = Constants.CandleColor.GREEN;

            }
            else
            {
                HAcandel.Low = currentCandel.Hight;
                HAcandel.Hight = currentCandel.Low;

                HAcandel.HaColor = Constants.CandleColor.RED;
            }
            HAcandel.OriginalColor = currentCandel.OriginalColor;
            HAcandel.Open = currentCandel.Open;
            HAcandel.Close = currentCandel.Close;
            HAcandel.Time = currentCandel.Time;
            return HAcandel;

        }

    }
}
