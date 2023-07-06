using System.Windows;

namespace MVVMCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel();
        }
    }
}