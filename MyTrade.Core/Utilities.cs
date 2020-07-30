using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTrade.Core
{
    public class Utilities
    {
        public class Calculate
        {
            public class Date
            {
                public static void StartEndOfMonthBefore(DateTime date,out DateTime start, out DateTime end)
                {
                    start = date;
                    end = date;

                    date = date.AddMonths(-1);
                    start = new DateTime(date.Year, date.Month, 1);
                    end = start.AddMonths(1).AddDays(-1);
              

                }

                public static void StartEndOfWeekBefore(DateTime date, out DateTime start, out DateTime end)
                {
                   
                    int diff = Convert.ToInt32(date.DayOfWeek) - 1;
                    DateTime currentWeek_start = date.AddDays(-diff);

                    //past week
                    start = currentWeek_start.AddDays(-7);
                    end = start.AddDays(5);
                 


                }
            }
            public class Bars
            {
                public static MyTrade.Core.Model.Candle MonthlyBar(List<MyTrade.Core.Model.Candle> candles)
                {
                    MyTrade.Core.Model.Candle candle = new Model.Candle();
                   
                    double mHigh = 0;
                    double mOPen = 0;
                    double mClose = 0;
                    double mLow = 0;
                    int i = 0;
                    foreach (var item in candles.OrderBy(x => x.Time))
                    {
                        if (i == 0)
                        {
                            mClose = item.Close;
                            mLow = item.Low;
                        }

                        mHigh = Math.Max(item.High, mHigh);
                        mOPen = Math.Max(item.Open, mOPen);
                        mClose = Math.Min(item.Close, mClose);
                        mLow = Math.Min(item.Low, mLow);

                        i += 1;
                    }

                    candle.Open = mOPen;
                    candle.High = mHigh;
                    candle.Low = mLow;
                    candle.Close = mClose;
                    return candle;
                }
                public static MyTrade.Core.Model.Candle WeeklyBar(List<MyTrade.Core.Model.Candle> candles)
                {
                    MyTrade.Core.Model.Candle candle = new Model.Candle();

                    double mHigh = 0;
                    double mOPen = 0;
                    double mClose = 0;
                    double mLow = 0;
                    int i = 0;
                    foreach (var item in candles.OrderBy(x => x.Time))
                    {
                        if (i == 0)
                        {
                            mClose = item.Close;
                            mLow = item.Low;
                        }

                        mHigh = Math.Max(item.High, mHigh);
                        mOPen = Math.Max(item.Open, mOPen);
                        mClose = Math.Min(item.Close, mClose);
                        mLow = Math.Min(item.Low, mLow);

                        i += 1;
                    }

                    candle.Open = mOPen;
                    candle.High = mHigh;
                    candle.Low = mLow;
                    candle.Close = mClose;
                    return candle;
                }

            }
        }
        
    }
}
