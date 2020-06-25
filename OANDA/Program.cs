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

namespace OANDA
{
    class Program
    {



        static void Main(string[] args)
        {



            Console.WriteLine("1 Indeces and Currency - Daily");
            Console.WriteLine("2 Indeces and Currency - Weekly");
            Console.WriteLine("3 Calcolate Units");
            string selectedOption = Console.ReadLine();
            if (selectedOption == "1")
            {
                HA_IndicesAndCurrency.Run();

            }
            else if (selectedOption == "2")
            {
                HA_IndicesAndCurrencyW.Run();

            }
            else if (selectedOption == "3")
            {
                Console.WriteLine("Insert Instrument");
               
                string instrument = AutoComplete.Run();
                Console.WriteLine("Insert stop loss");
                double sl = Convert.ToDouble(Console.ReadLine());
                double currentPrice = Data.Prices.LastPrice(instrument);
                Utilities.Calculate.Units units = new Utilities.Calculate.Units(instrument, 100, 1, sl);
                Console.WriteLine(units.Get());


            }
            else
            {

                HA_Stocks.Run();
            }
           

        }
    }


}
