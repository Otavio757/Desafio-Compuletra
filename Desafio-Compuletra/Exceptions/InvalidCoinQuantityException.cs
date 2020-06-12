using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class InvalidCoinQuantityException : Exception
    {
        public double InvalidQuantity { get; private set; }

        public InvalidCoinQuantityException(double invalidQuantity)
        {
            InvalidQuantity = invalidQuantity;
        }

        public override string ToString()
        {
            return InvalidQuantity + " não é um valor válido para a quantidade de moedas. Informe um valor não negativo";
        }
    }
}
