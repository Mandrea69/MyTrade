using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace MyTrade.Core
{
    public class SqliteDataAccess
    {
        public class Instruments
        {
            public static List<Model.Instrument> LoadInstruments()
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<Model.Instrument>("select * from Instruments", new DynamicParameters());
                    return output.ToList();
                }
            }
            public static void SaveInstruments(List<Model.Instrument> instruments)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM Instruments");
                }
                foreach (var instrument in instruments)
                {


                    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                    {
                        cnn.Execute("insert into Instruments (Name, Type,DisplayName,PipLocation) values (@Name, @Type,@DisplayName,@PipLocation)", instrument);
                    }
                }
            }



        }
        public class WeekyCandles
        {
            public static List<Model.Candle> LoadCandles(string instrument)
            {
                var dictionary = new Dictionary<string, object>
                {
                    { "@instrument", instrument }
                };
                var parameters = new DynamicParameters(dictionary);
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<Model.Candle>("select * from WeeklyCandles where instrument=@instrument", parameters);
                    return output.ToList();
                }
            }

            public static void CleanData()
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM WeeklyCandles");
                }
            }


            public static void SaveCandles(List<Model.Candle> candles)
            {
               
                foreach (var candle in candles)
                {


                    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                    {
                        cnn.Execute("insert into WeeklyCandles (Open, Close,High,Low,Time,Instrument,OriginalColor) values (@Open, @Close,@High,@Low,@Time,@Instrument,@OriginalColor)", candle);
                    }
                }
            }



        }
        public class MonthlyCandles
        {
            public static List<Model.Candle> LoadCandles(string instrument)
            {
                var dictionary = new Dictionary<string, object>
                {
                    { "@instrument", instrument }
                };
                var parameters = new DynamicParameters(dictionary);
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<Model.Candle>("select * from MonthlyCandles where instrument=@instrument", parameters);
                    return output.ToList();
                }
            }

            public static void CleanData()
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM MonthlyCandles");
                }
            }


            public static void SaveCandles(List<Model.Candle> candles)
            {

                foreach (var candle in candles)
                {


                    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                    {
                        cnn.Execute("insert into MonthlyCandles (Open, Close,High,Low,Time,Instrument,OriginalColor) values (@Open, @Close,@High,@Low,@Time,@Instrument,@OriginalColor)", candle);
                    }
                }
            }



        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
