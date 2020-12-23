using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyTrade.Core.Indicators
{
    public class CCI
    {

        //calcolare l'ultimo typical price. {\displaystyle TP=(H+L+C)/3}{\displaystyle TP=(H+L+C)/3} dove H è il massimo, L il minimo e C la chiusura;
        //calcolare la media mobile semplice a 20 periodi del typical price SMATP;
        //calcolare la deviazione media.Prima si calcoli il valore assoluto della differenza tra la SMATP dell'ultimo periodo ed il typical price per ognuno dei 20 periodi passati, poi si sommino tutti questi valori assoluti e si divida per 20. Si ottiene così la deviazione media;
        //il passo finale è applicare questi valori calcolati e la costante (0.015) nella seguente formula:
        //{\displaystyle CCI = (TP - SMATP) / (0.015 * Deviazionemedia)}{\displaystyle CCI = (TP - SMATP) / (0.015 * Deviazionemedia)}
      
        List<Model.Candle> candlesInPeriods;
        public CCI(List<Model.Candle> _candlesInPeriods)
        {

            candlesInPeriods = _candlesInPeriods;
        }



        public double TP(double H,double L, double  C)
        {
            double T;
            T= (H + L+C)/ 3;
            return T;
        }
        public double DevMedia(List<Model.Candle> candles)
        {
            
                
                double devMedia = 0;
                double sumAbs = 0;
                foreach (Model.Candle candle in candles)
                {
                    sumAbs += Math.Abs( TP(candle.High, candle.Low, candle.Close)- SMATP(candles));
                }

            return devMedia = sumAbs / 20;

           
        }
        public double SMATP(List<Model.Candle> candles)
        {
                double SMATP = 0;
                double TPsum = 0;
                foreach (Model.Candle candle in candles)
                {
                    TPsum += TP(candle.High, candle.Low, candle.Close);
                }

                return SMATP = TPsum / 20;

            

        }
       
        public double _CCI(List<Model.Candle> candles)
        {

          
                double cci = 0;
                double lastTP = TP(candles.LastOrDefault().High, candles.LastOrDefault().Low, candles.LastOrDefault().Close);
                cci = (lastTP - SMATP(candles)) / (0.015 * DevMedia(candles));
                return cci;



            
        }

        public List<MyTrade.Core.Model.Indicators.CCI> ReadAll()
        {
            List<MyTrade.Core.Model.Indicators.CCI> ccis = new List<Model.Indicators.CCI>();
            int totalCandles = candlesInPeriods.Count();
            for (int i = 0; i < totalCandles; i++)
            {
                if (i == 20)
                {



                    List<Model.Candle> candlesInRange = candlesInPeriods.Skip(0).Take(20).ToList<Model.Candle>();
                 double cci=  _CCI(candlesInRange);
                    //Console.WriteLine(cci + " - " + candlesInRange.FirstOrDefault().Time + " - " + candlesInRange.LastOrDefault().Time);
                    bool over = false;
                    if (cci > 120 || cci < -120)
                    {
                        over = true;
                    }
                    ccis.Add(new Model.Indicators.CCI()
                    {
                        Date = candlesInRange.LastOrDefault().Time,
                        Value = cci,
                        Over = over,
                         Candle= candlesInRange.LastOrDefault()



                    });
                }
                else if (i > 20)
                {
                    List<Model.Candle> candlesInRange = candlesInPeriods.Skip(i-20).Take(20).ToList<Model.Candle>();
                    double cci = _CCI(candlesInRange);
                    //Console.WriteLine(cci + " - " + candlesInRange.FirstOrDefault().Time + " - " + candlesInRange.LastOrDefault().Time);
                    bool over = false;
                    if (cci > 120 || cci < -120)
                    {
                        over = true;
                    }
                    ccis.Add(new Model.Indicators.CCI()
                    {
                        Date = candlesInRange.LastOrDefault().Time,
                        Value = cci,
                        Over = over,
                        Candle = candlesInRange.LastOrDefault()



                    });
                }

               
              
            }
 return ccis;
          

        }
    }
}
