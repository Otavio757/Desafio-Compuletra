using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Compuletra.Exceptions
{
    class InsufficientCoinsToWithdrawException : Exception
    {
        public int CoinsAvailable { get; private set; }
        public int IntendedWithdraw { get; private set; }
        public decimal CoinValue { get; private set; }

        public InsufficientCoinsToWithdrawException(int coinsAvailable, int intendedWithdraw, decimal coinValue)
        {
            CoinsAvailable = coinsAvailable;
            IntendedWithdraw = intendedWithdraw;
            CoinValue = coinValue;
        }

        public override string ToString()
        {
            return "Houve uma tentativa de saque de " + IntendedWithdraw + " moedas de $" + CoinValue.ToString("F2") + ", porém há somente " + CoinsAvailable + " moedas desse valor";
        }
    }
}
