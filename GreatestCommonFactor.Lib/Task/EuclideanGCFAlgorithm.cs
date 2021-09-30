using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents instance for calculating GCF between numbers
    /// </summary>
    public static class EuclideanGCFAlgorithm
    {
        /// <summary>
        /// Calculates the GCF of two numbers by Euclid's method in a loop
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <exception cref="ArgumentException"><paramref name="firstNumber"/>Less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="secondNumber"/>Less than zero</exception>
        /// <returns>GCF of two numbers</returns>
        public static int GCF(int firstNumber, int secondNumber)
        {
            if (firstNumber < 0) throw new ArgumentException("Number cannot be less than zero", nameof(firstNumber));
            if (secondNumber < 0) throw new ArgumentException("Number cannot be less than zero", nameof(secondNumber));
            return ExecuteGCFAlgorithm(firstNumber, secondNumber);
        }
        /// <summary>
        /// Calculates the GCF of two numbers by Euclid's method in a loop with out parameter which will equal to execution time of algorithm
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <param name="runTime">Execution time of algorithm</param>
        /// <exception cref="ArgumentException"><paramref name="firstNumber"/>Less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="secondNumber"/>Less than zero</exception>
        /// <returns>GCF of two numbers</returns>
        public static int GCF(int firstNumber, int secondNumber, out TimeSpan runTime)
        {
            Stopwatch timer = new();
            timer.Start();
            int gcf;
            try { gcf = GCF(firstNumber, secondNumber); }
            catch (ArgumentException) { throw; }
            finally { timer.Stop(); }
            runTime = timer.Elapsed;
            return gcf;
        }
        /// <summary>
        /// Calculates GCF with any amount of numbers
        /// </summary>
        /// <param name="numbers">Number for GCF calculating</param>
        /// <exception cref="ArgumentException">If at least one of number less than zero</exception>
        /// <returns>GCF of numbers</returns>
        public static int GCF(params int[] numbers)
        {
            if (numbers is null) throw new ArgumentNullException("Cannot be null", nameof(numbers));
            if (numbers.Length == 0) throw new ArgumentException("Must have at least one number", nameof(numbers));
            if (numbers.Length == 1) return numbers[0];

            int[] temp = new int[numbers.Length];
            Array.Copy(numbers, temp, numbers.Length);

            for (int i = 0; i < temp.Length - 1; i++)
            {
                try { temp[i + 1] = GCF(temp[i], temp[i + 1]); }
                catch(ArgumentException) { throw; }
            }
            return temp[temp.Length - 1];
        }
        /// <summary>
        /// Calculates the GCF of two numbers by Steins's binary method
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <exception cref="ArgumentException"><paramref name="firstNumber"/>Less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="secondNumber"/>Less than zero</exception>
        /// <returns>GCF of two numbers</returns>
        public static int BinaryGCF(int firstNumber, int secondNumber)
        {
            if (firstNumber < 0) throw new ArgumentException("Number cannot be less than zero", nameof(firstNumber));
            if (secondNumber < 0) throw new ArgumentException("Number cannot be less than zero", nameof(secondNumber));
            return ExecuteBinaryGCFAlgorithm(firstNumber, secondNumber);
        }
        /// <summary>
        /// Calculates the GCF of two numbers by Steins's binary method with out parameter which will equal to execution time of algorithm
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <param name="runTime">Execution time of algorithm</param>
        /// <exception cref="ArgumentException"><paramref name="firstNumber"/>Less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="secondNumber"/>Less than zero</exception>
        /// <returns>GCF of two numbers</returns>
        public static int BinaryGCF(int firstNumber, int secondNumber, out TimeSpan runTime)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int gcf;
            try { gcf = BinaryGCF(firstNumber, secondNumber); }
            catch (ArgumentException) { throw; }
            finally { timer.Stop(); }
            runTime = timer.Elapsed;
            return gcf;
        }
        /// <summary>
        /// Gets execution time of two algorithms with same parameters
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <exception cref="ArgumentException"><paramref name="firstNumber"/>Less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="secondNumber"/>Less than zero</exception>
        /// <returns>Collection of <c>EuclideanAlgorithmExecutionResult</c>. Include execution time and algorithm name</returns>
        public static IEnumerable<EuclideanAlgorithmExecutionResult> GetAlgorithmsExecutionTimeResults(int firstNumber, int secondNumber)
        {
            List<EuclideanAlgorithmExecutionResult> result = new();
            TimeSpan gcfExecutionTime, binaryGcfExecutionTime;

            try { GCF(firstNumber, secondNumber, out gcfExecutionTime); }
            catch(ArgumentException) { throw; }
            result.Add(new EuclideanAlgorithmExecutionResult("EuclideanAlgorithm", gcfExecutionTime));

            try { BinaryGCF(firstNumber, secondNumber, out binaryGcfExecutionTime); }
            catch (ArgumentException) { throw; }
            result.Add(new EuclideanAlgorithmExecutionResult("SteinsAlgorithm", binaryGcfExecutionTime));

            return result;
        }
        /// <summary>
        /// Main logic of Euclidean GCF algorithm
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>GCF of two numbers</returns>
        private static int ExecuteGCFAlgorithm(int firstNumber, int secondNumber)
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
        /// Main logic of Steins GCF algorithm
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>GCF of two numbers</returns>
        private static int ExecuteBinaryGCFAlgorithm(int firstNumber, int secondNumber)
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
    }
}
