using System;
using System.Collections.Generic;
using System.Text;
using Lab6;
namespace Lab6
{
    class Calculator:ICalculator
    {
        bool isPoint = false;
        int countAfterPoint = 1;
        public double? LeftValue { get; private set; }

        public double? RightValue { get; private set; }

        public CalculatorOperation? Operation { get; private set; }

        public double? Result { get; private set; }
        public void AddDigit(int digit)
        {
            if (digit == -1)
            {
                if (isPoint)
                    return;
                isPoint = true;

            }
            else if (isPoint && digit!=-1)
            {
                RightValue += (double)digit *Math.Pow(10,-countAfterPoint);
                countAfterPoint++;
            }
            else
            {
                string rv = RightValue.ToString();
                rv += digit;
                RightValue = Double.Parse(rv);
            }
            OnDidChangeRight(this, new CalculatorEventArgs("Right change", LeftValue, RightValue, Operation));
        }

        public event CalculatorEvent OnDidChangeLeft;
        public event CalculatorEvent OnDidChangeRight;
        public event CalculatorEvent OnDidChangeOperation;
        public event CalculatorEvent OnDidCompute;
        public event CalculatorEvent OnUnableToCompute;

        public void AddOperation(CalculatorOperation op)
        {
            countAfterPoint = 1;
            isPoint = false;
            if (LeftValue == null)
                LeftValue = 0;
            if (Operation != null )
            {
                if( RightValue != 0)
                    Compute();
            }

            else
            {
                LeftValue = RightValue;
                OnDidChangeLeft?.Invoke(this, new CalculatorEventArgs("Left change", LeftValue, RightValue, Operation));
            }
            Operation = op;
            RightValue = null;
            OnDidChangeOperation?.Invoke(this, new CalculatorEventArgs("Change operation", LeftValue, RightValue, Operation));
            
        }

        public void Compute()
        {
            
            try
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
                        {
                            if (RightValue != 0)
                                LeftValue /= RightValue;
                            else throw new ArgumentException();
                        }
                        else
                            LeftValue = RightValue;
                        break;
                    default:
                        LeftValue = RightValue;
                        break;
                }
                RightValue = 0;
                isPoint = false;
                countAfterPoint = 1;
                OnDidChangeLeft?.Invoke(this, new CalculatorEventArgs("Left change", LeftValue, RightValue, Operation));
                //OnDidChangeRight?.Invoke(this, new CalculatorEventArgs("Right change", LeftValue, RightValue, Operation));
                Result = LeftValue;
                OnDidCompute?.Invoke(this, new ComputeEventArgs
                    (LeftValue, RightValue, Operation, Result));
            }
            catch
            {
                OnUnableToCompute?.Invoke(this, new CalculatorEventArgs("Error", LeftValue, RightValue, Operation));
                //throw new ArgumentException();
            }

        }

        public void Clear()
        {
            Operation = null;
            RightValue = null;
            LeftValue = null;
            Result = 0;            
        }
    }
}
