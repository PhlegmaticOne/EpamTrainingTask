namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents Euclidean algorithm for calculating GCF
    /// </summary>
    public class EuclideanAlgorithm : GCFAlgorithm
    {
        /// <summary>
        /// Initializes new EuclideanAlgorithm instance with an array of numbers
        /// </summary>
        /// <param name="numbers"></param>
        public EuclideanAlgorithm(params int[] numbers) : base(numbers) { }
        /// <summary>
        /// Do main logic for calculating GCF by Euclidean method
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>GCF of two numbers</returns>
        protected override int GetGCFBetween(int firstNumber, int secondNumber)
        {
            if (firstNumber == secondNumber) return firstNumber;
            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            while (secondNumber > 0)
            {
                firstNumber %= secondNumber;
                Swapper.Swap(ref firstNumber, ref secondNumber);
            }
            return firstNumber;
        }
        /// <summary>
        /// String representation of EuclideanAlgorithm instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "EuclideanAlgorithm: " + string.Join(',', _numbers);
        }
    }
}
