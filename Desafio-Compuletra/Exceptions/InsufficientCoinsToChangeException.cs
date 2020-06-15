using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class InsufficientCoinsToChangeException : Exception
    {
        public double TotalValue { get; private set; } //Valor total do troco
        public double MissingValue { get; private set; } //Valor que faltou

        public InsufficientCoinsToChangeException(double totalValue, double missingValue)
        {
            TotalValue = totalValue;
            MissingValue = missingValue;
        }

        public override string ToString()
        {
            return "Não há moedas suficientes para o troco de $" + TotalValue.ToString("F2") + ", faltam $" + MissingValue.ToString("F2");
        }
    }
}
