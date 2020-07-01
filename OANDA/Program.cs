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

namespace OANDA
{
    class Program
    {



        static void Main(string[] args)
        {

         

            //Console.WriteLine("1 Indeces and Currency - Daily");
            //Console.WriteLine("2 Indeces and Currency - Weekly");
            //Console.WriteLine("3 Calcolate Units");
            //Console.WriteLine("4 Pivot Point");
            //string selectedOption = Console.ReadLine();
            //if (selectedOption == "1")
            //{
            //    HA_IndicesAndCurrency.Run();

            //}
            //else if (selectedOption == "2")
            //{
            //    HA_IndicesAndCurrencyW.Run();

            //}
            //else if (selectedOption == "3")
            //{
            //    Console.WriteLine("Insert Instrument");
               
            //    Model.Instrument instrument = AutoComplete.Run();
            //    Console.WriteLine("Insert stop loss");
            //    double sl = Convert.ToDouble(Console.ReadLine());
            //    double currentPrice = Data.Prices.LastPrice(instrument.Name);
            //    Utilities.Calculate.Units units = new Utilities.Calculate.Units(instrument, 100, currentPrice, sl);
            //    Console.WriteLine(units.Get());


            //}
            //else if (selectedOption == "4")
            //{
                double h = 0;
                double l = 0;
                double c = 0;
            double av_h = 0;
            double av_l = 0;
            double av_c = 0;
            List<Model.Candle> candles= Data.Prices.GetCandles("EUR_NZD", 16, "D");
            for (int i = 0; i < candles.Count-1; i++)
            {

                h += candles[i].Hight;
                l += candles[i].Low;
                c += candles[i].Close;
            }

            //foreach (Model.Candle item in candles)
            //    {
            //        h += item.Hight;
            //        l += item.Low;
            //        c += item.Close;
            //    }
            av_h = candles[candles.Count-2].Hight;
            Console.WriteLine("h - " + av_h);
            av_l = candles[candles.Count - 2].Low;
            Console.WriteLine("l - " + av_l);
            av_c = candles[candles.Count - 2].Close;
            Console.WriteLine("c - " + av_c);

            double av_o = candles[candles.Count - 2].Open;
            Console.WriteLine("o - " + av_o);
            //av_h =  h / 15;
            //av_l = l / 15;
            //av_c = c / 15;

            double pp = (av_h + av_l + av_c) / 3;
            Console.WriteLine("pp - " + pp);
            double R1 = (2 * pp) - av_l;
            Console.WriteLine("r1 -" + R1);
            double S1 = (2 * pp) - av_h;
            Console.WriteLine("s1 -" + S1);
            double R2 = (pp - S1) + R1;
            Console.WriteLine("r2 -" + R2);
            double S2 = pp - (R1 - S1);
            Console.WriteLine("s2 - " + S2);
            double R3 = R2 + (av_h - av_l);
            Console.WriteLine("r3 - "+ R3);
            double S3 = S2 - (av_h - av_l);
            Console.WriteLine("s3 - " + S3);
            //}
            //else
            //{

            //    HA_Stocks.Run();
            //}

        }
    }


}
