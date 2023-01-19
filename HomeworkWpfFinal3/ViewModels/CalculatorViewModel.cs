using HomeworkWpfFinal3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeworkWpfFinal3.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculatorModel;
        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            AddCommand = new RelayCommand(Add, CanAdd);
            SubtractCommand = new RelayCommand(Subtract, CanSubtract);
            MultiplyCommand = new RelayCommand(Multiply, CanMultiply);
            DivideCommand = new RelayCommand(Divide, CanDivide);
        }

        private double _firstNumber;
        public double FirstNumber
        {
            get { return _firstNumber; }
            set
            {
                _firstNumber = value;
                OnPropertyChanged("FirstNumber");
            }
        }

        private double _secondNumber;
        public double SecondNumber
        {
            get { return _secondNumber; }
            set
            {
                _secondNumber = value;
                OnPropertyChanged("SecondNumber");
            }
        }

        private double _result;
        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand SubtractCommand { get; set; }
        public ICommand MultiplyCommand { get; set; }
        public ICommand DivideCommand { get; set; }

        private void Add()
        {
            Result = _calculatorModel.Add(FirstNumber, SecondNumber);
        }

        private bool CanAdd()
        {
            return !(double.IsNaN(FirstNumber) || double.IsNaN(SecondNumber));
        }

        private void Subtract()
        {
            Result = _calculatorModel.Subtract(FirstNumber, SecondNumber);
        }

        private bool CanSubtract()
        {
            return !(double.IsNaN(FirstNumber) || double.IsNaN(SecondNumber));
        }

        private void Multiply()
        {
            Result = _calculatorModel.Multiply(FirstNumber, SecondNumber);
        }

        private bool CanMultiply()
        {
            return !(double.IsNaN(FirstNumber) || double.IsNaN(SecondNumber));
        }

        private void Divide()
        {
            Result = _calculatorModel.Divide(FirstNumber, SecondNumber);
        }

        private bool CanDivide()
        {
            return !(double.IsNaN(FirstNumber) || double.IsNaN(SecondNumber) || SecondNumber == 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
