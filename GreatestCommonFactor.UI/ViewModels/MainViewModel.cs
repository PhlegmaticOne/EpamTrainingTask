using GreatestCommonFactor.Lib;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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
            GCFAlgorithm euclidAlgorithm  = default;
            try { euclidAlgorithm = new EuclideanAlgorithm(InputModel.GetInputNumbers().ToArray()); }
            catch (Exception e) { MessageBox.Show(e.Message); return; }
            var algorithmsViewModel = new AlgorithmsViewModel(euclidAlgorithm);
            foreach (var algorithm in algorithmsViewModel.ToAlgorithmViewModels())
            {
                Algorithms.Add(algorithm);
            }
        }
        private void SetSteinTime(object obj)
        {
            Algorithms.Clear();
            GCFAlgorithm steinAlgorithm = default;
            try { steinAlgorithm = new SteinsAlgorithm(InputModel.GetInputNumbers().ToArray()); }
            catch(Exception e) { MessageBox.Show(e.Message); return; }
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
            GCFAlgorithm euclidAlgorithm = default, steinsAlgorithm = default;
            try
            {
                euclidAlgorithm = new EuclideanAlgorithm(data);
                steinsAlgorithm = new SteinsAlgorithm(data);
            }
            catch(Exception e) { MessageBox.Show(e.Message); return; }
            var algorithmsViewModel = new AlgorithmsViewModel(euclidAlgorithm, steinsAlgorithm);
            foreach (var algorithm in algorithmsViewModel.ToAlgorithmViewModels())
            {
                Algorithms.Add(algorithm);
            }
        }
        private bool IsRightDataWrited(object obj) => InputModel.IsValid;
    }
}
