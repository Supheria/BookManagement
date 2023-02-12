namespace BookManagement
{
    public static class OnBehalf
    {
        /// <summary>
        /// 当前汇率
        /// </summary>
        public static double EXCHANGE_RATE = 2.5;
        public delegate int DelOnBehalf(int originalPrice);
        public static DelOnBehalf[] OnBehalfs = new DelOnBehalf[]
        {
            OnBehalf_1,
            OnBehalf_2,
            OnBehalf_3
        };
        /// <summary>
        /// 代购1
        /// </summary>
        /// <param name="originalPrice"></param>
        /// <returns></returns>
        public static int OnBehalf_1(int originalPrice)
        {
            double temp = originalPrice / EXCHANGE_RATE;
            return (int)Math.Round(temp + temp * 0.1, 0);
        }
        /// <summary>
        /// 代购2
        /// </summary>
        /// <param name="originalPrice"></param>
        /// <returns></returns>
        public static int OnBehalf_2(int originalPrice)
        {
            return (int)Math.Round((originalPrice / EXCHANGE_RATE));
        }
        /// <summary>
        /// 代购3
        /// </summary>
        /// <param name="originalPrice"></param>
        /// <returns></returns>
        public static int OnBehalf_3(int originalPrice)
        {
            return (int)Math.Round((originalPrice / EXCHANGE_RATE));
        }
    }
}
