using System;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Extensions for TimeSpan
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Calculates part in procents of two times
        /// </summary>
        /// <param name="divident">Time to calculate it part of the total time</param>
        /// <param name="divisor">Total time</param>
        /// <returns>Procent of time in common time</returns>
        public static double Procents(this TimeSpan divident, TimeSpan divisor) => divident.Ticks / (double)divisor.Ticks;
    }
}
