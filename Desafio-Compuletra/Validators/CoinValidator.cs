using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Validators
{
    static class CoinValidator
    {
        //Lista com os possíveis valores de moeda
        public static List<decimal> ValidValues { get; private set; }

        //Preenche a lista com o padrão brasileiro de moedas
        public static void BrazilianPattern()
        {
            ValidValues = new List<decimal> { (decimal)0.01, (decimal)0.05, (decimal)0.1, (decimal)0.25, (decimal)0.50, 1 };
        }

        //Cria um padrão em branco, isto é, sem valores inicializados
        public static void BlankPattern()
        {
            ValidValues = new List<decimal>();
        }

        //Adiciona um novo valor válido na lista, mantendo a ordem crescente. Se o valor já estiver na lista, nada acontece (nesse caso não faz sentido ter valores duplicados)
        public static void AddValue(decimal value)
        {
            if (!ValidValues.Contains(value))
            {
                int pos = 0;

                for (; pos < ValidValues.Count; pos++)
                {
                    if (value < ValidValues[pos])
                    {
                        break;
                    }
                }

                ValidValues.Insert(pos, value);
            }
        }

        //Remove um valor específico da lista. Se esse valor não estiver na lista, nada acontece
        public static void RemoveValue(decimal value)
        {
            ValidValues.Remove(value);
        }

        //Verifica se o valor passado como parâmetro é válido
        public static bool IsValid(decimal value)
        {
            return ValidValues.Contains(value);
        }
    }
}
