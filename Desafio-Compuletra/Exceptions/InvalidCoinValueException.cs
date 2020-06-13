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
        public double InvalidValue { get; private set; }

        public InvalidCoinValueException(double invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public override string ToString()
        {
            return InvalidValue + " não é um valor válido para moedas. Confira ao lado os valores válidos: " + CoinValidator.ValidValues.ToString();
        }
    }
}
