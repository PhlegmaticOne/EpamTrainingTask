using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Class to calculate algorithms execution time
    /// </summary>
    public class GCFTimeAlgorithm
    {
        /// <summary>
        /// GCF algrorithm collection
        /// </summary>
        private readonly GCFAlgorithmCollection _algorithms;
        /// <summary>
        /// Initializes new GCFTimeAlgorithm instance with collection of GCFAlgorithms
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="algorithms"/>Collection is null</exception>
        /// <param name="algorithms">GCFAlgorithm collections</param>
        public GCFTimeAlgorithm(GCFAlgorithmCollection algorithms)
        {
            if(algorithms is null) throw new ArgumentNullException("Algorithms cannot be null", nameof(algorithms));
            if(algorithms.Count == 0) throw new ArgumentException("Algorithms cannot be empty", nameof(algorithms));
            _algorithms = algorithms;
        }
        /// <summary>
        /// Calculate algorithms execution time. If algorithms hashes are equal nothing will be added
        /// </summary>
        /// <returns>Returns dictionary, whose keys are GCFAlgorithms and values are thei execution times</returns>
        public IDictionary<GCFAlgorithm, TimeSpan> GetAlgorithmsExecutionTime()
        {
            Dictionary<GCFAlgorithm, TimeSpan> result = new();
            Stopwatch timer = new();
            foreach (GCFAlgorithm algorithm in _algorithms)
            {
                timer.Restart();
                algorithm.Execute();
                timer.Stop();
                result.TryAdd(algorithm, timer.Elapsed);
            }
            return result;
        }
    }
}
