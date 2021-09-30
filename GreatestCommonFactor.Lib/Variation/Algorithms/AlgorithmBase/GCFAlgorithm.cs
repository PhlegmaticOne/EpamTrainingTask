using System;
using System.Linq;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents base instance for GCF algorithms
    /// </summary>
    public abstract class GCFAlgorithm
    {
        /// <summary>
        /// Numbers which will be used to find their GCF
        /// </summary>
        protected int[] _numbers;
        /// <summary>
        /// Property for getting numbers which are used for calculating GCF
        /// </summary>
        public int[] Numbers => _numbers;
        /// <summary>
        /// Initializes GCFAlgorithm instance with numbers for calculating their GCF
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="numbers"/>Collection of numbers is null</exception>
        /// <exception cref="ArgumentException"><paramref name="numbers"/>Collection has no numbers</exception>
        /// <exception cref="ArgumentException"><paramref name="numbers"/>Collection contains negative number(s)</exception>
        /// <param name="numbers">Collection of numbers</param>
        protected GCFAlgorithm(params int[] numbers)
        {
            if (numbers is null) throw new ArgumentNullException("Cannot be null", nameof(numbers));
            if (numbers.Length == 0) throw new ArgumentException("Must have at least one number", nameof(numbers));
            if (numbers.Any(num => num < 0)) throw new ArgumentException("All numbers must be non negative");
            _numbers = numbers;
        }
        /// <summary>
        /// Method which passed through all numbers and find their GCF by using overrided  GCF algorithm in childs algorithm classes
        /// </summary>
        /// <returns>GCF of all numbers</returns>
        public int Execute()
        {
            int[] temp = new int[_numbers.Length];
            Array.Copy(_numbers, temp, _numbers.Length);

            if (temp.Length == 1) return temp[0];
            for (int i = 0; i < temp.Length - 1; i++)
            {
                temp[i + 1] = GetGCFBetween(temp[i], temp[i + 1]);
            }
            return temp[temp.Length - 1];
        }
        /// <summary>
        /// Abstract algorithm of calculating GCF of two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>GCF of two numbers</returns>
        protected abstract int GetGCFBetween(int firstNumber, int secondNumber);
        /// <summary>
        /// Overrided GetHashCode method
        /// </summary>
        /// <returns>Hash code of GCFAlgorithm class</returns>
        public override int GetHashCode()
        {
            int hc = _numbers.Length;
            int typeHash = GetType().GetHashCode();
            for (int i = 0; i < _numbers.Length; i++)
            {
                hc = unchecked(hc * 314159 + _numbers[i]);
            }
            return hc + typeHash;
        }

        /// <summary>
        /// Overrided Equals method for two GCFAlgorithm classes
        /// </summary>
        /// <param name="obj">Object to check equality</param>
        /// <returns>true - objects are equal, false - they are not equal</returns>
        public override bool Equals(object obj)
        {
            if(obj is GCFAlgorithm algorithm)
            {
                if (ReferenceEquals(algorithm, this)) return true;
                if (algorithm.GetType() != GetType()) return false;
                if (_numbers.Length != algorithm._numbers.Length) return false;
                for (int i = 0; i < _numbers.Length; i++)
                {
                    if(_numbers[i] != algorithm._numbers[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
