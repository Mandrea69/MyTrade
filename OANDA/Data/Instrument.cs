using OANDA.Model;
using OANDA.Model.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace OANDA.Data
{
    public class Instrument
    {
        public static List<Model.Instrument> All()
        {
            string responseString = Data.OANDARestResponse.Get(Constants.url.INSTRUMENTS);
            var instrumentResponse = JsonSerializer.Deserialize<InstrumentResponse>(responseString);
            List<Model.Instrument> instruments = new List<Model.Instrument>();
            foreach (var item in instrumentResponse.instruments)
            {

                Model.Instrument _instrument = new Model.Instrument();
                _instrument.Name = item.name;
                _instrument.DisplayName = item.displayName;
                _instrument.Type = item.type;
                _instrument.PipLocation = Math.Abs(item.pipLocation);


                instruments.Add(_instrument);
            }

            return instruments;

        }

        public static List<Model.Instrument> AllFromFile()
        {
            string responseString = System.IO.File.ReadAllText(Constants.AssemblyPath() + @"\Data\OANDA\Instruments.json");
            
            
            var instrumentResponse = JsonSerializer.Deserialize<InstrumentResponse>(responseString);
            List<Model.Instrument> instruments = new List<Model.Instrument>();
            foreach (var item in instrumentResponse.instruments)
            {

                Model.Instrument _instrument = new Model.Instrument();
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
