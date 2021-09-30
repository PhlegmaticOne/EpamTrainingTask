using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace GreatestCommonFactor.UI
{
    public class InputModel : BaseViewModel, IDataErrorInfo
    {
        public string InputData { get; set; }
        private readonly Regex _regex = new Regex(@"\d+( \d+)*$");
        public event EventHandler DataChanged;
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                if (columnName == "InputData")
                {
                    if (string.IsNullOrEmpty(InputData) || !_regex.IsMatch(InputData))
                    {
                        IsValid = false;
                        error = "Invalid data";
                    }
                    else
                    {
                        IsValid = true;
                    }
                }
                DataChanged?.Invoke(this, EventArgs.Empty);
                return error;
            }
        }
        public string Error => string.Empty;
        public bool IsValid { get; private set; }
        public IEnumerable<int> GetInputNumbers()
        {
            var result = new List<int>();
            foreach (var numStr in InputData.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(int.Parse(numStr));
            }
            return result;
        }
    }
}
