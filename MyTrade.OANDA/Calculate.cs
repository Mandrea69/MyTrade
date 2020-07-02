using MyTrade.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrade.OANDA
{
    public class Calculate
    {
        public class Units
        {
            Instrument instrument =null;
            double risk = 0;
            double stopLoss = 0;
            double currentPrice = 0;
            public Units(Instrument _instrument,double _risk,double _currentPrice, double _stopLoss)
            {
               instrument = _instrument;
               risk = _risk;
               stopLoss = _stopLoss;
                currentPrice = _currentPrice;
            }
            public double Get()
            {
                //double point = 0;
                //if(instrument.PipLocation==0)
                //{
                //    point = 1;
                //}
                //else if (instrument.PipLocation == 1)
                //{
                //    point = 0.01;
                //}
                //else if (instrument.PipLocation == 2)
                //{
                //    point = 0.001;
                //}
                //else if (instrument.PipLocation == 3)
                //{
                //    point = 0.0001;
                //}
                //else if (instrument.PipLocation == 4)
                //{
                //    point = 0.00001;
                //}
               


                //return risk / Math.Abs(currentPrice - stopLoss)*10*point;
                return Math.Round( risk / Math.Abs(currentPrice - stopLoss),4) ;
            }

        }

    }
}
