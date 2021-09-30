using System;

namespace GreatestCommonFactor.UI
{
    public class AlgorithmViewModel
    {
        public TimeSpan ExecutionTime { get; set; }
        public double Procents { get; set; }
        public string AlgorithmInfo { get; set; }
        public int GCF { get; }
        public AlgorithmViewModel(string algorithmInfo, int gcf, double procents, TimeSpan executionTime)
        {
            ExecutionTime = executionTime;
            Procents = procents;
            AlgorithmInfo = algorithmInfo;
            GCF = gcf;
        }
    }
}
