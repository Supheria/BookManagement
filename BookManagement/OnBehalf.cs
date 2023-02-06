using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    public static class OnBehalf
    {
        /// <summary>
        /// 当前汇率
        /// </summary>
        public static double EXCHANGE_RATE;
        public delegate double DelOnBehalf(int originalPrice);
        /// <summary>
        /// 代购1
        /// </summary>
        /// <param name="originalPrice"></param>
        /// <returns></returns>
        public static double OnBehalf_1(int originalPrice)
        {
            double temp = originalPrice / EXCHANGE_RATE;
            return temp + temp * 0.1;
        }
        /// <summary>
        /// 代购2
        /// </summary>
        /// <param name="originalPrice"></param>
        /// <returns></returns>
        public static double OnBehalf_2(int originalPrice)
        {
            return originalPrice / EXCHANGE_RATE;
        }
        /// <summary>
        /// 代购3
        /// </summary>
        /// <param name="originalPrice"></param>
        /// <returns></returns>
        public static double OnBehalf_3(int originalPrice)
        {
            return originalPrice / EXCHANGE_RATE;
        }
    }
}
