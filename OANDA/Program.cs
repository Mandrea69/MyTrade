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

namespace OANDA
{
    class Program
    {



        static void Main(string[] args)
        {

            Console.WriteLine("1 Indeces and Currency");
            Console.WriteLine("2 Stocks");
            string selectedOption = Console.ReadLine();
            if (selectedOption == "1")
            {
                HA_IndicesAndCurrency.Run();

            }
            else
            {

                HA_Stocks.Run();
            }

            //OANDA.Data.WD.Stocks.DailyCandles("GOOG");
            //OANDA.Data.WD.Stocks.IntradayCandles("AAPL", "15min");
            //OANDA.Data.WD.Stocks.IntradayCandles("AAPL", "1h");

        }
    }
}
