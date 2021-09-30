namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents Steins algorithm for calculating GCF of two numbers
    /// </summary>
    public class SteinsAlgorithm : GCFAlgorithm
    {
        /// <summary>
        /// Initializes new SteinsAlgorithm instance with an array of numbers
        /// </summary>
        /// <param name="numbers"></param>
        public SteinsAlgorithm(params int[] numbers) : base(numbers) { }
        /// <summary>
        /// Do main logic for calculating GCF by Steins method
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>GCF of two numbers</returns>
        protected override int GetGCFBetween(int firstNumber, int secondNumber) => BinaryGCF(firstNumber, secondNumber);
        /// <summary>
        /// Since this method is recursive, it is moved to a separate method
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>GCF of two numbers</returns>
        private int BinaryGCF(int firstNumber, int secondNumber)
        {
            if (firstNumber == secondNumber) return firstNumber;

            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            if (firstNumber % 2 == 0)
            {
                return (secondNumber % 2 == 1) ?
                    BinaryGCF(firstNumber / 2, secondNumber) :
                    BinaryGCF(firstNumber / 2, secondNumber / 2) * 2;
            }
            else
            {
                if (secondNumber % 2 == 0) return BinaryGCF(firstNumber, secondNumber / 2);

                return (firstNumber > secondNumber) ?
                    BinaryGCF((firstNumber - secondNumber) / 2, secondNumber) :
                    BinaryGCF((secondNumber - firstNumber) / 2, firstNumber);
            }
        }
        /// <summary>
        /// String representation of SteinAlgorithm instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "SteinsAlgorithm: " + string.Join(',', _numbers);
        }
    }
}
