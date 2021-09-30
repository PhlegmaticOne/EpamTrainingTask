namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents instance for swapping any type objects
    /// </summary>
    public static class Swapper
    {
        /// <summary>
        /// Swaps two intances of any type
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="firstValue">First value to swap</param>
        /// <param name="secondValue">Second value to swap</param>
        public static void Swap<T>(ref T firstValue, ref T secondValue)
        {
            T temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }
    }
}
