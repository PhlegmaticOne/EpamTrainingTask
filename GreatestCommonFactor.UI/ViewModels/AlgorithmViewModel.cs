using GreatestCommonFactor.Lib;
using System;

namespace GreatestCommonFactor.UI
{
    public class AlgorithmViewModel : BaseViewModel
    {
        public TimeSpan ExecutionTime { get; set; }
        public double Procents { get; set; }
        public AlgorithmViewModel(GCFAlgorithm algorithm)
        {
            if (algorithm is null) throw new ArgumentNullException(nameof(algorithm));
            var collection = new GCFAlgorithmCollection(algorithm);
            var timeAlgorithm = new GCFTimeAlgorithm(collection);
            var result = timeAlgorithm.GetAlgorithmsExecutionTime();
            ExecutionTime = result[algorithm];
            Procents = 100;
        }
    }
}
