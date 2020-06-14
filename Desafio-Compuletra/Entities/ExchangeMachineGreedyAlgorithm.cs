using Desafio_Compuletra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Entities
{
    class ExchangeMachineGreedyAlgorithm : ExchangeMachine
    {
        public ExchangeMachineGreedyAlgorithm(int maximumCapacity) : base(maximumCapacity)
        {
        }

        /*
         Estudei os Algoritmos Gulosos na minha graduação, que são utilizados para otimizar o desempenho e para funcionar em hardwares mais simples, 
         como o de uma máquina de moedas de verdade. Porém, existem situações específicas em que a seleção de moedas não é a melhor, como por exemplo 
         no seguinte caso: precisa-se de um troco de 30 centavos e só há moedas de 25, 10 e 1 centavo. O algoritmo guloso selecionará primeiro a 
         moeda maior (25) e depois mais 5 moedas de 1 centavo. Porém, a melhor opção seria 3 moedas de 10 centavos.
        */
        public override List<CoinSet> GenerateChange(double value)
        {
            List<CoinSet> change = new List<CoinSet>();
            double pendingValue = value;

            for (int i = coinsSet.Count - 1; i >= 0 && pendingValue > 0; i--)
            {
                if (coinsSet[i].Value <= pendingValue && coinsSet[i].Quantity > 0)
                {
                    change.Add(new CoinSet(coinsSet[i].Value, 1));
                    pendingValue -= RemoveCoin(i);

                    while (coinsSet[i].Value <= pendingValue && coinsSet[i].Quantity > 0)
                    {
                        change.Last().AddCoin();
                        pendingValue -= RemoveCoin(i);
                    }
                }
            }

            if (pendingValue > 0)
            {
                //Devolve para a máquina as moedas retiradas
                change.ForEach(delegate (CoinSet cs)
                {
                    AddCoins(cs);
                });

                throw new InsufficientCoinsToChangeException(value, pendingValue);
            }

            return change;
        }
    }
}
