using GreatestCommonFactor.Lib;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GreatestCommonFactor.UI
{
    public class MainViewModel : BaseViewModel
    {
        public InputModel InputModel { get; set; } = new();
        public DelegateCommand EuclidAlgorithmCommand { get; set; }
        public DelegateCommand SteinAlgorithmCommand { get; set; }
        public DelegateCommand BothAlgorithmCommand { get; set; }
        public ObservableCollection<AlgorithmViewModel> Algorithms { get; set; } = new();
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
            Algorithms.Clear();
            var euclidAlgorithm = new EuclideanAlgorithm(InputModel.GetInputNumbers().ToArray());
            var algorithmsViewModel = new AlgorithmsViewModel(euclidAlgorithm);
            foreach (var algorithm in algorithmsViewModel.ToAlgorithmViewModels())
            {
                Algorithms.Add(algorithm);
            }
        }
        private void SetSteinTime(object obj)
        {
            Algorithms.Clear();
            var steinAlgorithm = new EuclideanAlgorithm(InputModel.GetInputNumbers().ToArray());
            var algorithmsViewModel = new AlgorithmsViewModel(steinAlgorithm);
            foreach (var algorithm in algorithmsViewModel.ToAlgorithmViewModels())
            {
                Algorithms.Add(algorithm);
            }
        }
        private void SetBothTime(object obj)
        {
            Algorithms.Clear();
            var data = InputModel.GetInputNumbers().ToArray();
            var euclidAlgorithm = new EuclideanAlgorithm(data);
            var steinsAlgorithm = new SteinsAlgorithm(data);
            var algorithmsViewModel = new AlgorithmsViewModel(euclidAlgorithm, steinsAlgorithm);
            foreach (var algorithm in algorithmsViewModel.ToAlgorithmViewModels())
            {
                Algorithms.Add(algorithm);
            }
        }
        private bool IsRightDataWrited(object obj) => InputModel.IsValid;
    }
}
