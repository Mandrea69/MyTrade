
using MyTrade.Alpaca.Model.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyTrade.Alpaca.Data
{
    public class Instrument
    {
        public static List<MyTrade.Core.Model.Instrument> All()
        {
            string responseString = Data.Call.Get(Constants.url.Instruments);

            JArray a = JArray.Parse(responseString);
            IList<jInstrument> jInstruments = a.Select(p => new jInstrument
            {   name= (string)p["name"],
                  symbol= (string)p["symbol"],
                 tradable = (bool)p["tradable"],
                easy_to_borrow = (bool)p["easy_to_borrow"],
                 exchange = (string)p["exchange"]
                
            }).ToList();

           
            var tradable = from x in jInstruments
                           where x.tradable == true && x.easy_to_borrow==true && x.exchange== "NASDAQ"
                           orderby x.name
                           select x;


            List<MyTrade.Core.Model.Instrument> instruments = new List<MyTrade.Core.Model.Instrument>();
            foreach (var item in tradable)
            {
                MyTrade.Core.Model.Instrument _instrument = new MyTrade.Core.Model.Instrument();
                _instrument.Name = item.symbol;
                _instrument.DisplayName = item.name;
                _instrument.Type = item.exchange;
                _instrument.PipLocation = 1;
                _instrument.IsFavorite = false;
                instruments.Add(_instrument);

            }




            //foreach (var item in instrumentResponse.instruments)
            //{

            //   
            //}

            return instruments;

        }
     
        public static List<MyTrade.Core.Model.Instrument> AllFromDB()
        {
          return MyTrade.Core.SqliteDataAccess.StockInstruments.LoadInstruments(); ;
        }

       

    }
}
