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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}