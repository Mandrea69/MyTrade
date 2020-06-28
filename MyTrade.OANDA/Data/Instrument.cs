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
        public static List<MyTrade.OANDA.Model.Instrument> All()
        {
            string responseString = Data.OANDARestResponse.Get(Constants.url.INSTRUMENTS);
            var instrumentResponse = JsonConvert.DeserializeObject<InstrumentResponse>(responseString);
            List<MyTrade.OANDA.Model.Instrument> instruments = new List<MyTrade.OANDA.Model.Instrument> ();
            foreach (var item in instrumentResponse.instruments)
            {

                MyTrade.OANDA.Model.Instrument _instrument = new MyTrade.OANDA.Model.Instrument();
                _instrument.Name = item.name;
                _instrument.DisplayName = item.displayName;
                _instrument.Type = item.type;
                _instrument.PipLocation = Math.Abs(item.pipLocation);


                instruments.Add(_instrument);
            }

            return instruments;

        }

        public static List<MyTrade.OANDA.Model.Instrument> AllFromFile()
        {
            string responseString = System.IO.File.ReadAllText(Constants.AssemblyPath() + @"\MyTrade.OANDA\Data\OANDA\Instruments.json");
            
            
            var instrumentResponse = JsonConvert.DeserializeObject<InstrumentResponse>(responseString);
            List<MyTrade.OANDA.Model.Instrument> instruments = new List<MyTrade.OANDA.Model.Instrument>();
            foreach (var item in instrumentResponse.instruments)
            {

                MyTrade.OANDA.Model.Instrument _instrument = new MyTrade.OANDA.Model.Instrument();
                _instrument.Name = item.name;
                _instrument.DisplayName = item.displayName;
                _instrument.Type = item.type;
                _instrument.PipLocation =Math.Abs( item.pipLocation);

                instruments.Add(_instrument);
            }

            return instruments;


        }
    }
}
