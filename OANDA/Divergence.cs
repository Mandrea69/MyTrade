using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using OANDA.Formula;
using OANDA.Logs;
using System.Linq;


using System.Text.Json;
using OANDA.Model.Communication;

using System.Runtime.CompilerServices;
using System.Globalization;
using OANDA.Utilities;
using System.Reflection;

namespace OANDA
{
    public class Divergence
    {

        public static void OANDA()
        {
            List<Model.Instrument> instruments = Data.Instrument.All();
            foreach (Model.Instrument item in instruments)
            {

                List<MyTrade.Core.Model.Candle> d_candles = MyTrade.OANDA.Data.Prices.GetCandles(item.Name, 80, "D");
                //List<MyTrade.Core.Model.Candle> d_candles = MyTrade.OANDA.Data.Prices.GetCandles("GBP_USD", 80, "D");


                MyTrade.Core.Indicators.CCI cci = new MyTrade.Core.Indicators.CCI(d_candles);

                List<MyTrade.Core.Model.Indicators.CCI> ccis = cci.ReadAll();

                var sortedCCIs = from x in ccis
                                 orderby x.Date descending
                                 select x;
              
              
                List<MyTrade.Core.Model.Indicators.CCI> lastCCIs = ccis.TakeLast(7).ToList();
                var validMax = from x in lastCCIs
                               where x.Value > 120
                               select x;


                if (validMax.Count() > 0)// regolare
                {

                    bool priceGoUP = lastCCIs.FirstOrDefault().Candle.Close < lastCCIs.LastOrDefault().Candle.Close;
                    bool cciGoDown = lastCCIs.FirstOrDefault().Value > lastCCIs.LastOrDefault().Value;
                bool positive = lastCCIs.FirstOrDefault().Value > 0 && lastCCIs.LastOrDefault().Value > 0;
                    if (priceGoUP == true && cciGoDown == true && positive==true)
                    {
                        Console.WriteLine(item.Name + " - " + item.DisplayName);
                        Console.WriteLine("Massimi crescenti (prezzo) massimi descr (cci)");
                    }
                }

                var validMin = from x in lastCCIs
                               where x.Value < -120
                               select x;
                if (validMin.Count() > 0) // regolare
                {

                    bool priceGoDown = lastCCIs.FirstOrDefault().Candle.Close > lastCCIs.LastOrDefault().Candle.Close;
                    bool cciGoUP = lastCCIs.FirstOrDefault().Value < lastCCIs.LastOrDefault().Value;
                bool negative = lastCCIs.FirstOrDefault().Value < 0 && lastCCIs.LastOrDefault().Value < 0;
                if (priceGoDown == true && cciGoUP == true && negative)
                    {
                        Console.WriteLine(item.Name + " - " + item.DisplayName);
                        Console.WriteLine("Minimi crescenti (prezzo) minimi descr (cci)");
                    }
                }

            }

        }
        public static void Alpacha()
        {
            List<MyTrade.Core.Model.Instrument> instruments = MyTrade.Alpaca.Data.Instrument.AllFromDB().Where(x=> x.IsFavorite==true).ToList();
            foreach (MyTrade.Core.Model.Instrument item in instruments)
            {

                List<MyTrade.Core.Model.Candle> d_candles = MyTrade.Alpaca.Data.Prices.GetCandles(item.Name, 80, "1D");
               


                MyTrade.Core.Indicators.CCI cci = new MyTrade.Core.Indicators.CCI(d_candles);

                List<MyTrade.Core.Model.Indicators.CCI> ccis = cci.ReadAll();

                var sortedCCIs = from x in ccis
                                 orderby x.Date descending
                                 select x;
                double startingValueCCI = sortedCCIs.FirstOrDefault().Value;
                int i = 0;

                List<MyTrade.Core.Model.Indicators.CCI> lastCCIs = ccis.TakeLast(5).ToList();
                var validMax = from x in lastCCIs
                               where x.Value > 120
                               select x;


                if (validMax.Count() > 0)// regolare
                {

                    bool priceGoUP = lastCCIs.FirstOrDefault().Candle.Close < lastCCIs.LastOrDefault().Candle.Close;
                    bool cciGoDown = lastCCIs.FirstOrDefault().Value > lastCCIs.LastOrDefault().Value;
                    if (priceGoUP == true && cciGoDown == true)
                    {
                        Console.WriteLine(item.Name + " - " + item.DisplayName);
                        Console.WriteLine("Massimi crescenti (prezzo) massimi descr (cci)");
                    }
                }

                var validMin = from x in lastCCIs
                               where x.Value < -120
                               select x;
                if (validMin.Count() > 0) // regolare
                {

                    bool priceGoDown = lastCCIs.FirstOrDefault().Candle.Close > lastCCIs.LastOrDefault().Candle.Close;
                    bool cciGoUP = lastCCIs.FirstOrDefault().Value < lastCCIs.LastOrDefault().Value;
                    if (priceGoDown == true && cciGoUP == true)
                    {
                        Console.WriteLine(item.Name + " - " + item.DisplayName);
                        Console.WriteLine("Minimi crescenti (prezzo) minimi descr (cci)");
                    }
                }



            }
        }
    }
}
