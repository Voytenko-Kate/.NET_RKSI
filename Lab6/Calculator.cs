using System;
using System.Collections.Generic;
using System.Text;
using Lab6;
namespace Lab6
{
    class Calculator:ICalculator
    {
        public double? LeftValue { get; private set; }

        public double? RightValue { get; private set; }

        public CalculatorOperation? Operation { get; private set; }

        public double? Result { get; private set; }
        public void AddDigit(int digit)
        {
            //if (RightValue != null)
             string rv = RightValue.ToString();
            rv += digit;
            RightValue = Double.Parse(rv);
        }

        public event CalculatorEvent OnDidChangeLeft;
        public event CalculatorEvent OnDidChangeRight;
        public void AddOperation(CalculatorOperation op)
        {
            if (LeftValue == null)
                LeftValue = 0;
            Compute();
            Operation = op;
            RightValue = null;
        }

        public event CalculatorEvent OnDidChangeOperation;
        public void Compute()
        {
            switch (Operation)
            {
                case CalculatorOperation.Add:
                    LeftValue += RightValue;
                    break;
                case CalculatorOperation.Mul:
                    if (LeftValue != 0)
                        LeftValue *= RightValue;
                    else
                        LeftValue = RightValue;
                    break;
                case CalculatorOperation.Sub:
                    if (LeftValue != 0)
                        LeftValue -= RightValue;
                    else
                        LeftValue = RightValue;
                    break;
                case CalculatorOperation.Div:
                    if (LeftValue != 0)
                        LeftValue /= RightValue;
                    else
                        LeftValue = RightValue;
                    break;
                default:
                    LeftValue = RightValue;
                    break;
            }
            Result = LeftValue;
        }

        public event CalculatorEvent OnDidCompute;
        public event CalculatorEvent OnUnableToCompute;
        public void Clear()
        {
            RightValue = null;
            LeftValue = null;
            Result = 0;
        }
    }
}
