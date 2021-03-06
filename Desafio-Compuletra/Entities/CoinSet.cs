﻿using Desafio_Compuletra.Exceptions;
using Desafio_Compuletra.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Entities
{
    public class CoinSet : IComparable
    {
        public decimal Value { get; set; } //Valor das moedas do conjunto
        public int Quantity { get; set; } //Quantidade de moedas do conjunto

        public CoinSet(decimal value, int quantity)
        {
            if (!CoinValidator.IsValid(value))
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
        public CoinSet(decimal value) : this(value, 0)
        {
        }

        public CoinSet()
        {
            Value = 1;
            Quantity = 0;
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

        public void AddCoin()
        {
            Quantity++;
        }

        public decimal RemoveCoins(int quantity)
        {
            if (quantity <= Quantity)
            {
                Quantity -= quantity;
                return Value * quantity;
            }

            else
            {
                throw new InsufficientCoinsToWithdrawException(Quantity, quantity, Value);
            }
        }

        public decimal RemoveCoin()
        {
            return RemoveCoins(1);
        }

        //Valor total do conjunto de moedas
        public decimal TotalValue()
        {
            return Value * Quantity;
        }

        public override String ToString()
        {
            String s = Quantity + " moedas de $" + Value.ToString("F2") + " (total $" + TotalValue().ToString("F2") + ")";

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
