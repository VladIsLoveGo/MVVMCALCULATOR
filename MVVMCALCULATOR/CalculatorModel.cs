using System.ComponentModel;

namespace MVVMCALCULATOR
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        private double _operand1;
        private double _operand2;
        private double _result;

        public double Operand1
        {
            get { return _operand1; }
            set
            {
                _operand1 = value;
                OnPropertyChanged("Operand1");
            }
        }

        public double Operand2
        {
            get { return _operand2; }
            set
            {
                _operand2 = value;
                OnPropertyChanged("Operand2");
            }
        }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}