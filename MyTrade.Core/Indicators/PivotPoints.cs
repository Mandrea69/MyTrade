using MyTrade.Core.Model;
using MyTrade.Core.Model.Indicators;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyTrade.Core.Indicators
{
    public class PivotPoints
    {
        public PivotPoint Get(Candle candleDayBefore,double currentPrice)
        {
            PivotPoint pps = new PivotPoint();
            double h = candleDayBefore.High;
            double l = candleDayBefore.Low;
            double c = candleDayBefore.Close;

            pps.PP = (h + l + c) / 3;
            pps.R1 = (2 * pps.PP) - l;
            pps.S1 = (2 * pps.PP) - h;

            pps.R2 = pps.PP + h-l;
            pps.S2 = pps.PP - h + l;

            pps.R3 =h + 2*(pps.PP - l);
            pps.S3 = l - 2 * (h- pps.PP );


            if(currentPrice>pps.PP && currentPrice< pps.R1)
            {
                pps.Position = "PP-R1";
            }
            else if (currentPrice > pps.R1 && currentPrice < pps.R2)
            {
                pps.Position = "R1-R2";
            }
            else if (currentPrice < pps.PP && currentPrice > pps.S1)
            {
                pps.Position = "PP-S1";
            }
            else if (currentPrice < pps.S1 && currentPrice > pps.S2)
            {
                pps.Position = "S1-S2";
            }
            return pps;

        }


    }
}
