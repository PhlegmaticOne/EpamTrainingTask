using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GreatestCommonFactor.Lib
{
    /// <summary>
    /// Represents a collection for GCF algorithms
    /// </summary>
    public class GCFAlgorithmCollection : IEnumerable<GCFAlgorithm>
    {
        /// <summary>
        /// Collection of GCF algorithms
        /// </summary>
        private ICollection<GCFAlgorithm> _algorithms;
        /// <summary>
        /// Amount of algorithms in collection
        /// </summary>
        public int Count => _algorithms.Count;
        /// <summary>
        /// Initializes new GCFAlgorithmCollection instance
        /// </summary>
        /// <param name="algorithms">Array of GCFAlgorithms</param>
        public GCFAlgorithmCollection(params GCFAlgorithm[] algorithms) : this(algorithms.ToList()) { }
        /// <summary>
        /// Initializes new GCFAlgorithmCollection instance
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="algorithms"/>Collection is null</exception>
        /// <exception cref="ArgumentException"><paramref name="algorithms"/>Collection is empty</exception>
        /// <param name="algorithms">Collection of GCFAlgorithms</param>
        public GCFAlgorithmCollection(ICollection<GCFAlgorithm> algorithms)
        {
            if (algorithms is null) throw new ArgumentNullException("Algorithms cannot be null", nameof(algorithms));
            if (algorithms.Count == 0) throw new ArgumentException("Algorithms cannot be empty", nameof(algorithms));
            _algorithms = algorithms;
        }
        /// <summary>
        /// Initializes new GCFAlgorithmCollection instance
        /// </summary>
        public GCFAlgorithmCollection() => _algorithms = new List<GCFAlgorithm>();
        /// <summary>
        /// Adds new GCFAlgorithm instance to colletion. If algorithm is null nothing will be added
        /// </summary>
        /// <param name="algorithm">GCFAlgorithm instance to add</param>
        /// <returns>Instance of this collection</returns>
        public GCFAlgorithmCollection Add(GCFAlgorithm algorithm)
        {
            if(algorithm != null)
            {
                _algorithms.Add(algorithm);
            }
            return this;
        }
        /// <summary>
        /// Enumarate GCFAlgorithms
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection</returns>
        public IEnumerator<GCFAlgorithm> GetEnumerator() => _algorithms.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
