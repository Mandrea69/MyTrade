using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.OANDA.Formula
{
    public class SMA
    {
        public SMA() {
            datapoints = new List<double>();
        }
        private double average;
        List<double> datapoints = null;
        public double Avarage
        {
          get
            {
                double avg = 0;
                foreach ( double item in datapoints)
                {
                    avg += item;
                }

                return Math.Round(average, 5);
            }
        }

        public void AddDataPoint(double dataPoint)
        {
            datapoints.Add(dataPoint);
        }
    }
}


