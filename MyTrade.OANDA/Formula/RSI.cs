using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyTrade.OANDA.Formula
{
    public class RSI
    {
        public static double Get(List<Model.Candle> candles)
        {
           
            var candlesCompleted = from x in candles
                                   where x.Complete == true
                                   orderby x.Time ascending
                                   select x;
          

            double mup = 0;
           double mdown = 0;

            for (int i = 0; i < candlesCompleted.Count(); i++)
            {
                if (i > 0 )
                  {
                   
                    double difference =candlesCompleted.ToList<Model.Candle>()[i].Close- candlesCompleted.ToList<Model.Candle>()[i-1].Close;
                   if (difference > 0)
                    {
                        mup += Math.Abs(difference);
                       
                    }
                    else 
                    {
                        mdown += Math.Abs(difference);
                       
                    }
                }
            }
          
            
            mdown = mdown / (candlesCompleted.Count()-1);
            mup = mup / (candlesCompleted.Count()-1);
            double rsiValue = 0;
            if (mdown==0)
            {
                rsiValue = 0;

            }
            else
            {
                 rsiValue = 100 - (100 / (1 + (mup / mdown)));

            }

            


            return Math.Round(rsiValue,4);
        }
    }
}
