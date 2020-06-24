using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alphavantage.Parsing
{
    public class Parsing
    {
        public static Model.StockTimeSeries ParseStockQuotes(JObject jObject)
        {

            var properties = jObject.Children().Select(ch => (JProperty)ch).ToArray();

            var metadataJson = properties.FirstOrDefault(p => p.Name == Constants.Parsing.MetaDataJsonTokens.MetaDataHeader);
            var timeSeriesJson =
                properties.FirstOrDefault(p => p.Name.Contains(Constants.Parsing.TimeSeriesJsonTokens.TimeSeriesHeader));

            if (metadataJson == null || timeSeriesJson == null)
                throw new StocksParsingException("Unable to parse time-series json");

            var result = new Model.StockTimeSeries();
            FillMetadata(metadataJson, result);

            result.DataPoints = GetStockDataPoints(timeSeriesJson);

            return result;


        }
        private static ICollection<MaTrade.Core.Model.Candle> GetStockDataPoints(JProperty timeSeriesJson)
        {
            var result = new List<MaTrade.Core.Model.Candle>();

            var timeseriesContent = timeSeriesJson.Children().Single();
            var contentDict = new Dictionary<string, string>();
            foreach (var dataPointJson in timeseriesContent)
            {
                var dataPointJsonProperty = dataPointJson as JProperty;
                if (dataPointJsonProperty == null)
                    throw new StocksParsingException("Unable to parse time-series");

                contentDict.Add("timestamp", dataPointJsonProperty.Name);

                var dataPointContent = dataPointJsonProperty.Single();
                foreach (var field in dataPointContent)
                {
                    var property = (JProperty)field;
                    contentDict.Add(property.Name, property.Value.ToString());
                }

                var dataPoint = ComposeDataPoint(contentDict);

                result.Add(dataPoint);
                contentDict.Clear();
            }

            return result;
        }
        private static MaTrade.Core.Model.Candle ComposeDataPoint(Dictionary<string, string> dataPointContent)
        {


            var dataPoint = new MaTrade.Core.Model.Candle(); ;

            dataPoint.Time = DateTime.Parse(dataPointContent["timestamp"]);
            dataPoint.Open = Double.Parse(dataPointContent[Constants.Parsing.TimeSeriesJsonTokens.OpeningPriceToken]);
            dataPoint.Hight = Double.Parse(dataPointContent[Constants.Parsing.TimeSeriesJsonTokens.HighestPriceToken]);
            dataPoint.Low = Double.Parse(dataPointContent[Constants.Parsing.TimeSeriesJsonTokens.LowestPriceToken]);
            dataPoint.Close = Double.Parse(dataPointContent[Constants.Parsing.TimeSeriesJsonTokens.ClosingPriceToken]);
            if (dataPoint.Close > dataPoint.Open)
            {
                dataPoint.OriginalColor = MaTrade.Core.Constants.CandelColour.GREEN;
            }
            else if (dataPoint.Close < dataPoint.Open)
            {
                dataPoint.OriginalColor = MaTrade.Core.Constants.CandelColour.RED;
            }


            return dataPoint;
        }
        private static void FillMetadata(JProperty metadataJson, Model.StockTimeSeries timeSeries)
        {
            var metadatas = metadataJson.Children().Single();

            foreach (var metadataItem in metadatas)
            {
                var metadataProperty = (JProperty)metadataItem;
                var metadataItemName = metadataProperty.Name;
                var metadataItemValue = metadataProperty.Value.ToString();

           
                 if (metadataItemName.Contains(Constants.Parsing.MetaDataJsonTokens.RefreshTimeToken))
                {
                    var refreshTime = DateTime.Parse(metadataItemValue);
                    timeSeries.LastRefreshed = DateTime.SpecifyKind(refreshTime, DateTimeKind.Local);
                }
                else if (metadataItemName.Contains(Constants.Parsing.MetaDataJsonTokens.SymbolToken))
                {
                    timeSeries.Symbol = metadataItemValue;
                }
            }
        }

    }
}
