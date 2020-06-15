using Desafio_Compuletra.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class InvalidCoinValueException : Exception
    {
        public decimal InvalidValue { get; private set; }

        public InvalidCoinValueException(decimal invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public override string ToString()
        {
            String s = InvalidValue + " não é um valor válido para moedas. Confira ao lado os valores válidos: " + CoinValidator.ValidValues[0].ToString("F2");

            for (int i = 1; i < CoinValidator.ValidValues.Count; i++)
            {
                s += ", " + CoinValidator.ValidValues[i].ToString("F2");
            }

            return s;
        }
    }
}
