using GreatestCommonFactor.Lib;
using System;
using System.Linq;

namespace GreatestCommonFactor.UI
{
    public class MainViewModel : BaseViewModel
    {
        public InputModel InputModel { get; set; } = new();
        public DelegateCommand EuclidAlgorithmCommand { get; set; }
        public DelegateCommand SteinAlgorithmCommand { get; set; }
        public DelegateCommand BothAlgorithmCommand { get; set; }
        public AlgorithmViewModel EuclidAlgorithmViewModel { get; set; }
        public AlgorithmViewModel SteinAlgorithmViewModel { get; set; }
        public string AlgorithmView { get; set; }
        public MainViewModel()
        {
            EuclidAlgorithmCommand = new DelegateCommand(SetEuclidTime, IsRightDataWrited);
            SteinAlgorithmCommand = new DelegateCommand(SetSteinTime, IsRightDataWrited);
            BothAlgorithmCommand = new DelegateCommand(SetBothTime, IsRightDataWrited);
            InputModel.DataChanged += InputModel_DataChanged;
        }

        private void InputModel_DataChanged(object sender, EventArgs e)
        {
            EuclidAlgorithmCommand.RaiseCanExecute();
            SteinAlgorithmCommand.RaiseCanExecute();
            BothAlgorithmCommand.RaiseCanExecute();
        }
        private void SetEuclidTime(object obj)
        {
            SteinAlgorithmViewModel = null;
            var algorithm = new EuclideanAlgorithm(InputModel.GetInputNumbers().ToArray());
            EuclidAlgorithmViewModel = new AlgorithmViewModel(algorithm);
            AlgorithmView = algorithm.ToString();
        }
        private void SetSteinTime(object obj)
        {
            EuclidAlgorithmViewModel = null;
            var algorithm = new SteinsAlgorithm(InputModel.GetInputNumbers().ToArray());
            SteinAlgorithmViewModel = new AlgorithmViewModel(algorithm);
            AlgorithmView = algorithm.ToString();
        }
        private void SetBothTime(object obj)
        {
            EuclidAlgorithmViewModel = null;
            SteinAlgorithmViewModel = null;

            var data = InputModel.GetInputNumbers().ToArray();
            var euclidAlgorithm = new EuclideanAlgorithm(data);
            var steinsAlgorithm = new SteinsAlgorithm(data);
            
            SteinAlgorithmViewModel = new AlgorithmViewModel(euclidAlgorithm);
            EuclidAlgorithmViewModel = new AlgorithmViewModel(steinsAlgorithm);

            AlgorithmView = euclidAlgorithm.ToString();

            SteinAlgorithmViewModel.Procents = GetProcentsOfTime(SteinAlgorithmViewModel.ExecutionTime) * 100;
            EuclidAlgorithmViewModel.Procents = GetProcentsOfTime(EuclidAlgorithmViewModel.ExecutionTime) * 100;
        }
        private double GetProcentsOfTime(TimeSpan executionTime)
        {
            return executionTime.Procents(SteinAlgorithmViewModel.ExecutionTime + EuclidAlgorithmViewModel.ExecutionTime);
        }
        private bool IsRightDataWrited(object obj) => InputModel.IsValid;
    }
}
