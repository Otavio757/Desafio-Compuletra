using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class IncompatibleCoinValuesException : Exception
    {
        public double Value1 { get; private set; }
        public double Value2 { get; private set; }

        public IncompatibleCoinValuesException(double value1, double value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public override string ToString()
        {
            return "As moedas devem possuir o mesmo valor (você informou os valores " + Value1 + " e " + Value2 + ")";
        }
    }
}
