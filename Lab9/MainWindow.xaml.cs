using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab6;
namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICalculator calc = new Calculator();
        public MainWindow(ICalculator calc)
        {
            InitializeComponent();
            calc = new Calculator();
            //calc.OnDidChangeLeft += Calc_OnDidChangeLeft;
            //calc.OnDidChangeOperation += Calc_OnDidChangeOperation;
            //calc.OnDidChangeRight += Calc_OnDidChangeRight;
            //calc.OnDidCompute += Calc_OnDidCompute;
            //calc.OnUnableToCompute += Calc_OnUnableToCompute;
        }

        private void Calc_OnUnableToCompute(ICalculator sender, CalculatorEventArgs eventArgs)
        {
            MessageBox.Show("Деление на ноль!", "Error!", MessageBoxButton.OK,MessageBoxImage.Error);
            calc.Clear();
            output.Text = "";
        }

        private void Calc_OnDidCompute(ICalculator sender, CalculatorEventArgs eventArgs)
        {
            output.Text = eventArgs.LeftValue.ToString();
        }

        private void Calc_OnDidChangeRight(ICalculator sender, CalculatorEventArgs eventArgs)
        {
            char op;
            string rv = eventArgs.RightValue.ToString();
            string lv = eventArgs.LeftValue.ToString();
            op = eventArgs.Operation.HasValue ? (char)eventArgs.Operation.Value : ' ';
            output.Text = eventArgs.LeftValue.ToString()
                + op + eventArgs.RightValue.ToString();
        }

        private void Calc_OnDidChangeOperation(ICalculator sender, CalculatorEventArgs eventArgs)
        {
            char op;
            op = eventArgs.Operation.HasValue ? (char)eventArgs.Operation.Value : ' ';
            output.Text = eventArgs.LeftValue.ToString()
                 + op + eventArgs.RightValue.ToString();
        }

        private void Calc_OnDidChangeLeft(ICalculator sender, CalculatorEventArgs eventArgs)
        {
            char op;
            op = eventArgs.Operation.HasValue ? (char)eventArgs.Operation.Value : ' ';
            output.Text = eventArgs.LeftValue.ToString()
                + op + eventArgs.RightValue.ToString();
        }

        public void Button_Click(object sender, RoutedEventArgs args)
        {
            string but = (sender as Button).Content.ToString();
            //output.AppendText(but);
            switch (but)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case ",":
                    if (but == ",")
                        calc.AddDigit(-1);
                    else
                        calc.AddDigit(int.Parse(but));
                    break;
                case "+":
                case "-":
                case "/":
                case "*":
                    object op = Enum.ToObject(typeof(CalculatorOperation), but[0]);
                    if (Enum.IsDefined(typeof(CalculatorOperation), op))
                    {
                        calc.AddOperation((CalculatorOperation)op);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid character: " + but);
                    }
                    break;
                case "=":
                    calc.Compute();
                    //output.Text = calc.Result.ToString();
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены что хотите закрыть приложение?", "Закрытие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calc.OnDidChangeLeft += Calc_OnDidChangeLeft;
            calc.OnDidChangeOperation += Calc_OnDidChangeOperation;
            calc.OnDidChangeRight += Calc_OnDidChangeRight;
            calc.OnDidCompute += Calc_OnDidCompute;
            calc.OnUnableToCompute += Calc_OnUnableToCompute;
        }
    }
}
