using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using OANDA.Formula;
using OANDA.Logs;
using System.Linq;
using OANDA.Model;

using System.Text.Json;
using OANDA.Model.Communication;
using OANDA.Data;
using System.Runtime.CompilerServices;
using System.Globalization;
using OANDA.Utilities;
using System.Reflection;
using Candle = OANDA.Model.Candle;

namespace OANDA
{
    class Program
    {



        static void Main(string[] args)
        {
           List<Model.Instrument> instruments= Data.Instrument.All();
            foreach (Model.Instrument item in instruments)
            {
                List<Candle> d_candles = Data.Prices.GetCandles(item.Name, 5, "D");
                foreach (var c in d_candles)
                {
                    if (PinBar.PinUp(DateTime.Now, c.Open, c.Hight, c.Low, c.Close) == true)
                    {
                        Console.WriteLine(item.DisplayName +    " UP " + c.Time);
                    }
                    else if (PinBar.PinDown(DateTime.Now, c.Open, c.Hight, c.Low, c.Close) == true)
                    {
                        Console.WriteLine(item.DisplayName + " DOWN " + c.Time);
                    }

                }
            }
         
            //var a = "----------------------------";
            //Console.WriteLine(a);
            //Candle c = d_candles[d_candles.Count - 2];
            //Console.WriteLine(c.Time);
            //Console.WriteLine(c.Hight);
            //Console.WriteLine(c.Low);
            //Console.WriteLine(c.Hight);
            //Console.WriteLine(c.Close);

            //Get(c);


        }
        public static void Get(Candle candleDayBefore)
        {
          
            double h = candleDayBefore.Hight;
            double l = candleDayBefore.Low;
            double c = candleDayBefore.Close;

           Console.WriteLine("PP " + (h + l + c) / 3);
            //pps.R1 = (2 * pps.PP) - l;
            //pps.S1 = (2 * pps.PP) - h;

            //pps.R2 = pps.PP + (h + l);
            //pps.S2 = pps.PP - (h + l);

            //pps.R3 = h + 2 * (pps.PP - l);
            //pps.S3 = l - 2 * (h - pps.PP);
            //return pps;

        }
    }


}
