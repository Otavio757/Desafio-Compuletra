using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class InvalidCoinQuantityException : Exception
    {
        public decimal InvalidQuantity { get; private set; }

        public InvalidCoinQuantityException(decimal invalidQuantity)
        {
            InvalidQuantity = invalidQuantity;
        }

        public override string ToString()
        {
            return InvalidQuantity + " não é um valor válido para a quantidade de moedas. Informe um valor não negativo";
        }
    }
}
