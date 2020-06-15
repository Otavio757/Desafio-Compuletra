using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class IncompatibleCoinValuesException : Exception
    {
        public decimal Value1 { get; private set; }
        public decimal Value2 { get; private set; }

        public IncompatibleCoinValuesException(decimal value1, decimal value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public override string ToString()
        {
            return "As moedas devem possuir o mesmo valor (você informou os valores " + Value1.ToString("F2") + " e " + Value2.ToString("F2") + ")";
        }
    }
}
