using GreatestCommonFactor.Lib;
using System;
using System.Collections.Generic;

namespace GreatestCommonFactor.UI
{
    public class AlgorithmsViewModel : BaseViewModel
    {
        private GCFAlgorithmCollection _algorithms;
        public AlgorithmsViewModel(params GCFAlgorithm[] algorithms)
        {
            _algorithms = new GCFAlgorithmCollection(algorithms);
        }
        public IEnumerable<AlgorithmViewModel> ToAlgorithmViewModels()
        {
            var timeAlgorithm = new GCFTimeAlgorithm(_algorithms);
            var times = timeAlgorithm.GetAlgorithmsExecutionTime();
            var totalTime = TimeSummator.GetSum(times.Values);
            foreach (GCFAlgorithm algorithm in _algorithms)
            {
                yield return new AlgorithmViewModel(algorithm.ToString(), algorithm.Execute(), times[algorithm] * 100 / totalTime, times[algorithm]);
            }
        }
    }
}
