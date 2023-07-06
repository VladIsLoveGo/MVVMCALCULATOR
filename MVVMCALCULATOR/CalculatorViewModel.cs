using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Windows.Input;

namespace MVVMCalculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _firstOperand;
        private string _secondOperand;
        private string _result;
        public string SelectedOperand { get; set; }


        public string FirstOperand
        {
            get => _firstOperand;
            set
            {
                _firstOperand = value;
                OnPropertyChanged();
            }
        }

        public string SecondOperand
        {
            get => _secondOperand;
            set
            {
                _secondOperand = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand PowerCommand { get; }
        public ICommand SquareRootCommand { get; }
        public ICommand PercentCommand { get; }
        public ICommand DigitCommand { get; }
        public ICommand ClearCommand { get; }

        public CalculatorViewModel()
        {
            AddCommand = new RelayCommand(Add);
            SubtractCommand = new RelayCommand(Subtract);
            MultiplyCommand = new RelayCommand(Multiply);
            DivideCommand = new RelayCommand(Divide);
            PowerCommand = new RelayCommand(Power);
            SquareRootCommand = new RelayCommand(SquareRoot);
            PercentCommand = new RelayCommand(Percent);
            DigitCommand = new RelayCommand(Digit);
            ClearCommand = new RelayCommand(Clear);
        }

        private void Add(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first) && decimal.TryParse(SecondOperand, out decimal second))
            {
                Result = (first + second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }
        private void Clear(object parameter)
        {
            FirstOperand = "";
            SecondOperand = "";
            Result = "";
        }

        private void Subtract(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first) && decimal.TryParse(SecondOperand, out decimal second))
            {
                Result = (first - second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Multiply(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first) && decimal.TryParse(SecondOperand, out decimal second))
            {
                Result = (first * second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Divide(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first) && decimal.TryParse(SecondOperand, out decimal second))
            {
                if (second != 0)
                {
                    Result = (first / second).ToString();
                }
                else
                {
                    Result = "Cannot divide by zero";
                }
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Power(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first) && decimal.TryParse(SecondOperand, out decimal second))
            {
                Result = Math.Pow((double)first, (double)second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void SquareRoot(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first))
            {
                if (first >= 0)
                {
                    Result = Math.Sqrt((double)first).ToString();
                }
                else
                {
                    Result = "Invalid input";
                }
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Percent(object parameter)
        {
            if (decimal.TryParse(FirstOperand, out decimal first) && decimal.TryParse(SecondOperand, out decimal second))
            {
                Result = ((first * second) / 100).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Digit(object parameter)
        {
            if (parameter is string digit)
            {
                if (SelectedOperand == null)
                {
                    FirstOperand += digit;
                }
                else
                {
                    SecondOperand += digit;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
