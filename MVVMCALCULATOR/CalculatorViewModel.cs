using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVMCalculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _firstNumber;
        private string _secondNumber;
        private string _result;

        public string FirstNumber
        {
            get => _firstNumber;
            set
            {
                _firstNumber = value;
                OnPropertyChanged();
            }
        }

        public string SecondNumber
        {
            get => _secondNumber;
            set
            {
                _secondNumber = value;
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

        public CalculatorViewModel()
        {
            AddCommand = new RelayCommand(Add);
            SubtractCommand = new RelayCommand(Subtract);
            MultiplyCommand = new RelayCommand(Multiply);
            DivideCommand = new RelayCommand(Divide);
            PowerCommand = new RelayCommand(Power);
            SquareRootCommand = new RelayCommand(SquareRoot);
        }

        private void Add()
        {
            if (decimal.TryParse(FirstNumber, out decimal first) && decimal.TryParse(SecondNumber, out decimal second))
            {
                Result = (first + second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Subtract()
        {
            if (decimal.TryParse(FirstNumber, out decimal first) && decimal.TryParse(SecondNumber, out decimal second))
            {
                Result = (first - second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Multiply()
        {
            if (decimal.TryParse(FirstNumber, out decimal first) && decimal.TryParse(SecondNumber, out decimal second))
            {
                Result = (first * second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void Divide()
        {
            if (decimal.TryParse(FirstNumber, out decimal first) && decimal.TryParse(SecondNumber, out decimal second))
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

        private void Power()
        {
            if (decimal.TryParse(FirstNumber, out decimal first) && decimal.TryParse(SecondNumber, out decimal second))
            {
                Result = Math.Pow((double)first, (double)second).ToString();
            }
            else
            {
                Result = "Invalid input";
            }
        }

        private void SquareRoot()
        {
            if (decimal.TryParse(FirstNumber, out decimal first))
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}
