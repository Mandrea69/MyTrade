using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Utilities
{
    public class Calculate
    {
        public class Units
        {
            string instument = "";
            double risk = 0;
            double stopLoss = 0;
            double currentPrice = 0;
            public Units(string _instument,double _risk,double _currentPrice, double _stopLoss)
            {
               instument = _instument;
               risk = _risk;
               stopLoss = _stopLoss;
                currentPrice = _currentPrice;
            }
            public double Get()
            {
                double point = 0.00001;

                return risk / Math.Abs(currentPrice - stopLoss)*10*point;
            }

        }

    }
}
