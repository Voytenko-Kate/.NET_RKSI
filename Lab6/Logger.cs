using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab6
{
    class Logger
    {
        static public string Path { private set; get; }
        public Logger(string path)
        {
            Path = path;
        }
        public void WriteLogs(ICalculator sender, CalculatorEventArgs e)
        {
            File.AppendAllText(Path, e.ToString() + Environment.NewLine);
        }
    }
}
