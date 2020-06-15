using Desafio_Compuletra.Exceptions;
using Desafio_Compuletra.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Entities
{
    public class ExchangeMachine
    {
        public List<CoinSet> CoinsSet { get; set; } //Conjuntos de moedas
        public decimal TotalValue { get; set; } //Valor total armazenado na máquina
        public int NumCoins { get; set; } //Número de moedas inseridas na máquina
        public int MaximumCapacity { get; set; } //Número máximo de moedas que a máquina pode armazenar
        
        public ExchangeMachine(int maximumCapacity)
        {
            MaximumCapacity = maximumCapacity;
            TotalValue = 0;
            CoinsSet = new List<CoinSet>();
        }

        public ExchangeMachine()
        {
            MaximumCapacity = 1000; //Valor padrão
            TotalValue = 0;
            CoinsSet = new List<CoinSet>();
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
        public void AddCoins(List<CoinSet> coins)
        {
            foreach (CoinSet cs in coins)
            {
                int i = CoinsSet.BinarySearch(cs);

                if (i < 0)
                {
                    i = 0;

                    for (; i < CoinsSet.Count; i++)
                    {
                        if (cs.Value < CoinsSet[i].Value)
                        {
                            break;
                        }
                    }

                    CoinsSet.Insert(i, new CoinSet(cs.Value));
                }

                AddCoinsInTheSet(i, cs);
            }
        }

        //Método auxiliar que realmente insere um conjunto de moedas na máquina
        protected void AddCoinsInTheSet(int pos, CoinSet coins)
        {
            if (coins.Quantity <= FreeSpace())
            {
                CoinsSet[pos].AddCoins(coins);
                NumCoins += coins.Quantity;
                TotalValue += coins.TotalValue();
            }

            else
            {
                //Nesse caso insere somente as moedas que ainda cabem na máquina e lança uma exceção
                int freeSpace = FreeSpace();
                CoinsSet[pos].AddCoins(freeSpace);
                NumCoins = MaximumCapacity;
                TotalValue += freeSpace * coins.Value;

                throw new MachineOverflowException(freeSpace, coins.Quantity);
            }
        }

        //Saque de moedas
        public void Withdraw(List<CoinSet> coins)
        {
            List<CoinSet> temp = new List<CoinSet>();

            foreach (CoinSet cs in coins)
            {
                int pos = CoinsSet.BinarySearch(cs);

                try
                {
                    CoinsSet[pos].RemoveCoins(cs.Quantity);
                    NumCoins -= cs.Quantity;
                    TotalValue -= cs.TotalValue();
                    temp.Add(cs);
                }

                catch (Exception exception)
                {
                    AddCoins(temp); //Devolve para a máquina as moedas retiradas até agora

                    if (exception is InsufficientCoinsToWithdrawException)
                    {
                        throw new InsufficientCoinsToWithdrawException(CoinsSet[pos].Quantity, cs.Quantity, cs.Value);
                    }

                    else
                    {
                        //Nesse caso, a variável "pos" é negativa, pois não há um conjunto de moedas do valor solicitado
                        //Assim, a exceção capturada foi a ArgumentOutOfRangeException
                        throw new InsufficientCoinsToWithdrawException(0, cs.Quantity, cs.Value);
                    }
                }
            }
        }

        /*
         Estudei os Algoritmos Gulosos na minha graduação, que são utilizados para otimizar o desempenho e para funcionar em hardwares mais simples, 
         como o de uma máquina de moedas de verdade. Porém, existem situações específicas em que a seleção de moedas não é a melhor, como por exemplo 
         no seguinte caso: precisa-se de um troco de 30 centavos e só há moedas de 25, 10 e 1 centavo. O algoritmo guloso selecionará primeiro a 
         moeda maior (25) e depois mais 5 moedas de 1 centavo. Porém, a melhor opção seria 3 moedas de 10 centavos.
        */
        public List<CoinSet> GenerateChange(decimal value)
        {
            List<CoinSet> change = new List<CoinSet>();
            decimal pendingValue = value;

            for (int i = CoinsSet.Count - 1; i >= 0 && pendingValue > 0; i--)
            {
                if (CoinsSet[i].Value <= pendingValue && CoinsSet[i].Quantity > 0)
                {
                    change.Add(new CoinSet(CoinsSet[i].Value, 1));
                    pendingValue -= RemoveCoin(i);

                    while (CoinsSet[i].Value <= pendingValue && CoinsSet[i].Quantity > 0)
                    {
                        change.Last().AddCoin();
                        pendingValue -= RemoveCoin(i);
                    }
                }
            }

            if (pendingValue > 0)
            {     
                AddCoins(change); //Devolve para a máquina as moedas retiradas
                throw new InsufficientCoinsToChangeException(value, pendingValue);
            }

            return change;
        }

        //Método auxiliar para o cálculo do troco de moedas
        protected decimal RemoveCoin(int pos)
        {
            decimal value = CoinsSet[pos].RemoveCoin();
            NumCoins--;
            TotalValue -= value;
            return value;
        }

        public override string ToString()
        {
            return "Saldo: $" + TotalValue.ToString("F2") + "  " +
                    NumCoins + "/" + MaximumCapacity + " moedas";
        }

        public String Status()
        {
            if (CoinsSet.Count > 0)
            {
                String s = CoinsSet[0].ToString();

                for (int i = 1; i < CoinsSet.Count; i++)
                {
                    s += "\r\n" + CoinsSet[i].ToString();
                }

                return s;
            }

            else
            {
                return "A máquina está vazia";
            }
        }
    }
}
