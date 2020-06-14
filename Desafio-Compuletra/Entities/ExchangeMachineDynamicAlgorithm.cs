using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Entities
{
    class ExchangeMachineDynamicAlgorithm : ExchangeMachine
    {
        public ExchangeMachineDynamicAlgorithm(int maximumCapacity) : base(maximumCapacity)
        {
        }

        /*
         Este algoritmo segue o princípio da Programação Dinâmica que estudei na graduação. Ele garante a melhor seleção de moedas, 
         porém é mais pesado do que o algoritmo guloso e pode não funcionar em hardwares mais simples. 
        */
        public override List<CoinSet> GenerateChange(double value)
        {
            int sizeCounter = (int)(value * 100);
            int[] counter1 = new int[sizeCounter];
            int counter2 = 0;

            for (int i = 0; i < counter1.Length; i++)
            {

            }
            return null;
        }

        //Método auxiliar que analisa as combinações de moedas e retorna a melhor
        private List<CoinSet> BestCoinCombination(List<double> coinsCombinations, double changeValue)
        {
            return null;
        }
    }
}
