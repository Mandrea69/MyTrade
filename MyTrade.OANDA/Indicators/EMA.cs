using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrade.OANDA.Indicators
{
    public class EMA
    {

        private bool _isInitialized;
        private readonly int _lookback;
        private readonly double _weightingMultiplier;
        private double _previousAverage;

        private double average;
        public double Average
        {
            get
            {
                return Math.Round(average, 5);
            }
            private set
            {
                average = value;
            }
        }
        public double Slope { get; private set; }

        public EMA(int lookback)
        {
            _lookback = lookback;
            _weightingMultiplier = 2.0 / (lookback + 1);
        }

        public void AddDataPoint(double dataPoint)
        {
            if (!_isInitialized)
            {
                Average = dataPoint;
                Slope = 0;
                _previousAverage = Average;
                _isInitialized = true;
                return;
            }

            Average = ((dataPoint - _previousAverage) * _weightingMultiplier) + _previousAverage;
            Slope = Average - _previousAverage;

            //update previous average 
            _previousAverage = Average;
        }
    }

}
