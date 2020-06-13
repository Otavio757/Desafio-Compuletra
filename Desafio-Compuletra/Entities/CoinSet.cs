using Desafio_Compuletra.Exceptions;
using Desafio_Compuletra.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Entities
{
    class CoinSet : IComparable
    {
        public double Value { get; private set; } //Valor das moedas do conjunto
        public int Quantity { get; private set; } //Quantidade de moedas do conjunto

        public CoinSet(double value, int quantity)
        {
            if (CoinValidator.IsValid(value))
            {
                throw new InvalidCoinValueException(value);
            }

            else if (quantity < 0)
            {
                throw new InvalidCoinQuantityException(quantity);
            }

            else
            {
                Value = value;
                Quantity = quantity;
            }
        }

        //Construtor que cria um conjunto de moedas vazio
        public CoinSet(double value) : this(value, 0)
        {
        }

        public void AddCoins(CoinSet coins)
        {
            if (coins.Value == Value)
            {
                Quantity += coins.Quantity;
            }

            else
            {
                throw new IncompatibleCoinValuesException(Value, coins.Value);
            }
        }

        public void AddCoins(int quantity)
        {
            Quantity += quantity;
        }

        public double RemoveCoin()
        {
            Quantity--;
            return Value;
        }

        public double RemoveCoins(int quantity)
        {
            Quantity -= quantity;
            return Value * quantity;
        }

        //Valor total do conjunto de moedas
        public double TotalValue()
        {
            return Value * Quantity;
        }

        public override String ToString()
        {
            String s = "$" + TotalValue() + " (" + Quantity + " moedas)";

            if (Quantity == 1)
            {
                s = s.Replace("moedas", "moeda");
            }

            return s;
        }

        public int CompareTo(object obj)
        {
            CoinSet cs = (CoinSet)obj;
            return Value.CompareTo(cs.Value);
        }
    }
}
