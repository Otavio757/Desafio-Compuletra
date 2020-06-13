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
        public static List<double> ValidValues { get; private set; }

        //Preenche a lista com o padrão brasileiro de moedas
        public static void BrazilianPattern()
        {
            ValidValues = new List<double> { 0.01, 0.05, 0.1, 0.25, 0.50, 1 };
        }

        //Cria um padrão em branco, isto é, sem valores inicializados
        public static void BlankPattern()
        {
            ValidValues = new List<double>();
        }

        //Adiciona um novo valor válido na lista, mantendo a ordem crescente. Se o valor já estiver na lista, nada acontece (nesse caso não faz sentido ter valores duplicados)
        public static void AddValue(double value)
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
        public static void RemoveValue(double value)
        {
            ValidValues.Remove(value);
        }

        //Verifica se o valor passado como parâmetro é válido
        public static bool IsValid(double value)
        {
            return ValidValues.Contains(value);
        }
    }
}
