using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents time calculator
    /// </summary>
    public static class TimeSummator
    {
        /// <summary>
        /// Calculating sum of times
        /// </summary>
        /// <param name="times">Times to sum</param>
        /// <returns>Sum of times</returns>
        public static TimeSpan GetSum(ICollection<TimeSpan> times)
        {
            var result = new TimeSpan();
            for (int i = 0; i < times.Count; i++)
            {
                result += times.ElementAt(i);
            }
            return result;
        }
    }
}
