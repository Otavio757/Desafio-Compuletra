using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class MachineOverflowException : Exception
    {
        public int QuantityInserted { get; private set; }
        public int TotalQuantity { get; private set; }

        public MachineOverflowException(int quantityInserted, int totalQuantity)
        {
            QuantityInserted = quantityInserted;
            TotalQuantity = totalQuantity;
        }

        public override string ToString()
        {
            return "Só foi possível inserir " + QuantityInserted + " das " + TotalQuantity + " moedas do conjunto porque a máquina estava quase cheia";
        }
    }
}
