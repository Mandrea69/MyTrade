﻿using MyTrade.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyTrade.OANDA.Indicators
{
    public class PivotPoints
    {
        public MyTrade.Model.Indicators.PivotPoint Get(Candle candleDayBefore)
        {
            MyTrade.Model.Indicators.PivotPoint pps = new MyTrade.Model.Indicators.PivotPoint();
            double h = candleDayBefore.High;
            double l = candleDayBefore.Low;
            double c = candleDayBefore.Close;

            pps.PP = (h + l + c) / 3;
            pps.R1 = (2 * pps.PP) - l;
            pps.S1 = (2 * pps.PP) - h;

            pps.R2 = pps.PP + (h+l);
            pps.S2 = pps.PP - (h + l);

            pps.R3 =h + 2*(pps.PP - l);
            pps.S3 = l - 2 * (h- pps.PP );
            return pps;

        }


    }
}