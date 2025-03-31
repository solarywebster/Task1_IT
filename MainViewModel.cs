using ReactiveUI;
using System;

namespace Task1
{
    public class MainViewModel : ReactiveObject
    {
        private string _num1 = "0";
        private string _num2 = "0";
        private string _result = "";

        public string Num1
        {
            get => _num1;
            set => this.RaiseAndSetIfChanged(ref _num1, value);
        }

        public string Num2
        {
            get => _num2;
            set => this.RaiseAndSetIfChanged(ref _num2, value);
        }

        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        private RealNumber ParseNumber(string input)
        {
            if (double.TryParse(input, out double value))
                return new RealNumber(value);
            throw new ArgumentException("Некорректное число!");
        }

        public void Add() => ExecuteOperation((a, b) => (a + b).ToString());
        public void Subtract() => ExecuteOperation((a, b) => (a - b).ToString());
        public void Multiply() => ExecuteOperation((a, b) => (a * b).ToString());
        public void Divide() => ExecuteOperation((a, b) => (a / b).ToString());
        public void Compare() => ExecuteComparison();
        public void ToScientific() => ExecuteScientificNotation();

        private void ExecuteOperation(Func<RealNumber, RealNumber, string> operation)
        {
            try
            {
                RealNumber a = ParseNumber(Num1);
                RealNumber b = ParseNumber(Num2);
                Result = operation(a, b);
            }
            catch (Exception ex)
            {
                Result = $"Ошибка: {ex.Message}";
            }
        }

        private void ExecuteComparison()
        {
            try
            {
                RealNumber a = ParseNumber(Num1);
                RealNumber b = ParseNumber(Num2);
                Result = a.Compare(b);
            }
            catch (Exception ex)
            {
                Result = $"Ошибка: {ex.Message}";
            }
        }

        private void ExecuteScientificNotation()
        {
            try
            {
                RealNumber a = ParseNumber(Num1);
                Result = a.ToScientificString();
            }
            catch (Exception ex)
            {
                Result = $"Ошибка: {ex.Message}";
            }
        }
    }
}
