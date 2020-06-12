using Desafio_Compuletra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Entities
{
    class ExchangeMachine
    {
        private List<CoinSet> coinsSet;
        public double TotalValue { get; private set; } //Valor total armazenado na máquina
        public int NumCoins { get; private set; } //Número de moedas inseridas na máquina
        public int MaximumCapacity { get; private set; } //Número máximo de moedas que a máquina pode armazenar
        
        public ExchangeMachine(int maximumCapacity)
        {
            MaximumCapacity = maximumCapacity;
            TotalValue = 0;
            coinsSet = new List<CoinSet>();
        }

        public bool IsEmpty()
        {
            return NumCoins == 0;
        }

        public bool IsFull()
        {
            return NumCoins == MaximumCapacity;
        }

        //Retorna o espaço livre na máquina, isto é, quantas moedas ainda podem ser inseridas
        public int FreeSpace()
        {
            return MaximumCapacity - NumCoins;
        }

        //As moedas são inseridas em ordem crescente de valor
        public void InsertCoins(CoinSet coins)
        {
            int pos = coinsSet.BinarySearch(coins);

            if (pos < 0)
            {
                pos = 0;

                for (; pos < coinsSet.Count; pos++)
                {
                    if (coins.Value < coinsSet[pos].Value)
                    {
                        break;
                    }
                }

                coinsSet.Insert(pos, new CoinSet(coins.Value));
            }

            InsertCoinsInTheSet(pos, coins);
        }

        //Método auxiliar que realmente insere as moedas em um conjunto da máquina
        private void InsertCoinsInTheSet(int pos, CoinSet coins)
        {
            if (coins.Quantity <= FreeSpace())
            {
                coinsSet[pos].AddCoins(coins);
                NumCoins += coins.Quantity;
                TotalValue += coins.TotalValue();
            }

            else
            {
                //Nesse caso insere somente as moedas que ainda cabem na máquina e lança uma exceção
                int freeSpace = FreeSpace();
                coinsSet[pos].AddCoins(freeSpace);
                NumCoins = MaximumCapacity;
                TotalValue += freeSpace * coins.Value;

                throw new MachineOverflowException(freeSpace, coins.Quantity);
            }
        }

        public override string ToString()
        {
            return "$" + TotalValue + " (" + NumCoins + "/" + MaximumCapacity + " moedas)";
        }
    }
}
