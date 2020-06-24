using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OANDA.Model
{
    public class Order
    {
        public enum _Type
        {
                BUY,SELL
        }
        public _Type Type;
        public double ClosePrice;
        public DateTime CloseTime;
        public double OpenPrice;
        public DateTime OpenTime;
        public double StopLoss { 
        get
            {
                if(this.Type== _Type.BUY)
                {
                    return OpenPrice - 0.0005;
                }
                else
                    return OpenPrice + 0.0005;
            }
        }
        public double TakeProfit
        {
            get
            {
                if (this.Type == _Type.BUY)
                {
                    return OpenPrice + 0.0006;
                }
                else
                    return OpenPrice - 0.0006;

            }
        }

    }
}
