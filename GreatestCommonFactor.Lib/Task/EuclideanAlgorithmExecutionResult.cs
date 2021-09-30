using System;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents instance for wrapping algorithm execution results
    /// </summary>
    public class EuclideanAlgorithmExecutionResult
    {
        /// <summary>
        /// Algorithm name
        /// </summary>
        public string AlgorithmName { get; }
        /// <summary>
        /// Algorith execution time
        /// </summary>
        public TimeSpan ExecutionTime { get; }
        /// <summary>
        /// Initializes instance of EuclideanAlgorithmExecutionResult
        /// </summary>
        /// <param name="algorithmName">Algorigth name</param>
        /// <param name="executionTime">Algorith execution time</param>
        public EuclideanAlgorithmExecutionResult(string algorithmName, TimeSpan executionTime)
        {
            if (string.IsNullOrWhiteSpace(algorithmName))
            {
                throw new ArgumentException($"\"{nameof(algorithmName)}\" cannot be empty or white space", nameof(algorithmName));
            }
            AlgorithmName = algorithmName;
            ExecutionTime = executionTime;
        }
    }
}
