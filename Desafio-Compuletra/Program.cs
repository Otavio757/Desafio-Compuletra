using Desafio_Compuletra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Compuletra
{
    static class Program
    {
        public static ExchangeMachine ExchangeMachine { get; private set; }

        public static void CreateMachine(int maximumCapacity)
        {
            ExchangeMachine = new ExchangeMachine(maximumCapacity);
        }

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Colocar um if de só executar o formulário de primeiro acesso se não tiver dados salvos no sistema
            Application.Run(new FirstAccessForm());
        }
    }
}
