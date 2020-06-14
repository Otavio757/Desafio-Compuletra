﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class InsufficientCoinsException : Exception
    {
        public int CoinsAvailable { get; private set; }
        public int IntendedWithdraw { get; private set; }
        public double CoinValue { get; private set; }

        public InsufficientCoinsException(int coinsAvailable, int intendedWithdraw, double coinValue)
        {
            CoinsAvailable = coinsAvailable;
            IntendedWithdraw = intendedWithdraw;
            CoinValue = coinValue;
        }

        public override string ToString()
        {
            return "Houve uma tentativa de saque de " + IntendedWithdraw + " moedas de $" + CoinValue + ", porém há somente " + CoinsAvailable + " moedas desse valor";
        }
    }
}
