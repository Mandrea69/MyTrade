using MyTrade.OANDA;
using MyTrade.OANDA.Model.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyTrade.OANDA.Data
{
    public class Instrument
    {
        public static List<MyTrade.Core.Model.Instrument> All()
        {
            string responseString = Data.OANDARestResponse.Get(Constants.url.INSTRUMENTS);
            var instrumentResponse = JsonConvert.DeserializeObject<InstrumentResponse>(responseString);
            List<MyTrade.Core.Model.Instrument> instruments = new List<MyTrade.Core.Model.Instrument> ();
            foreach (var item in instrumentResponse.instruments)
            {

                MyTrade.Core.Model.Instrument _instrument = new MyTrade.Core.Model.Instrument();
                _instrument.Name = item.name;
                _instrument.DisplayName = item.displayName;
                _instrument.Type = item.type;
                _instrument.PipLocation = Math.Abs(item.pipLocation);


                instruments.Add(_instrument);
            }

            return instruments;

        }
     
        public static List<MyTrade.Core.Model.Instrument> AllFromDB()
        {
          return MyTrade.Core.SqliteDataAccess.Instruments.LoadInstruments(); ;
        }

       

    }
}
