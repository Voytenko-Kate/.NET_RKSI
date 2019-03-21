/*
 * Lab6
 * Интерфейсы. События. Представители(делегаты).
 * 
 * Часть 1. Реализовать класс с интерфейсом ICalculator. Использовать инкапсуляцию.
 *   Продемонстрировать работу класса на разборе заданной строки.
 * 
 * Часть 2. Реализовать метод, последовательно считывающий числа из файла, 
 *  и выводящий накопленную сумму на консоль.
 */
using System;

namespace Lab6
{
    class Program
    {
        static void Parse(ICalculator calc, string expression)
        {
            string newExp = "";
            foreach (char c in expression)
                if (c != ' ')
                    newExp += c;
            expression = newExp;
            foreach(char c in expression)
            {
                if (Char.IsDigit(c))
                {
                    calc?.AddDigit(c - '0');
                }
                else if (c == '=')
                {
                    calc.Compute();
                    Console.WriteLine(calc.Result);
                    calc.Clear();
                }
                else
                {
                    object op = Enum.ToObject(typeof(CalculatorOperation), c);

                    if (Enum.IsDefined(typeof(CalculatorOperation), op))
                    {
                        calc.AddOperation((CalculatorOperation)op);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid character: " + c);
                    }
                }
            }
            calc.Clear();
        }

        static void Main(string[] args)
        {
            ICalculator calc = new Calculator();
            Logger logger = new Logger("logs.txt");
            calc.OnDidChangeLeft += logger.WriteLogs;
            calc.OnDidChangeRight += logger.WriteLogs;
            calc.OnDidChangeOperation += logger.WriteLogs;
            calc.OnUnableToCompute += logger.WriteLogs;
            calc.OnDidCompute += logger.WriteLogs;
            try
            {
                Parse(calc, "1*2*3*4=");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: \"{e.Message}\"");
            }
            Console.ReadKey();
        }
    }
}
