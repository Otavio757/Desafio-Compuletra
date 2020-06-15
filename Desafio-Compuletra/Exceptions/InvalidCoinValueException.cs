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
            String s = (int)(InvalidValue * 100) + " não é um valor válido para moedas. Confira ao lado os valores válidos: " + (int)(CoinValidator.ValidValues[0] * 100);

            for (int i = 1; i < CoinValidator.ValidValues.Count; i++)
            {
                s += ", " + (int)(CoinValidator.ValidValues[i] * 100);
            }

            return s;
        }
    }
}
