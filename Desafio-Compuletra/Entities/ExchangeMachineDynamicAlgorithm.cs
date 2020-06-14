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
            throw new NotImplementedException();
        }
    }
}
