using Desafio_Compuletra.Entities;
using Desafio_Compuletra.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Desafio_Compuletra
{
    static class Program
    {
        public static ExchangeMachine ExchangeMachine { get; set; } //Máquina de moedas
        public static List<List<CoinSet>> Deposits { get; set; } //Lista de depósitos realizados
        public static List<List<CoinSet>> Changes { get; set; } //Lista de trocos gerados
        public static List<List<CoinSet>> Withdraws { get; set; } //Lista de saques realizados

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String pathDataFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//";

            if (File.Exists(pathDataFile + "Exchange Machine.xml"))
            {
                CreateLists();
                LoadExchangeMachineIntoXML();
                LoadCoinValidValuesIntoXML();

                if (File.Exists(pathDataFile + "Deposits.xml"))
                {
                    LoadDepositsIntoXML();
                }

                if (File.Exists(pathDataFile + "Withdraws.xml"))
                {
                    LoadWithdrawsIntoXML();
                }

                if (File.Exists(pathDataFile + "Changes.xml"))
                {
                    LoadChangesIntoXML();
                }

                Application.Run(new MainForm());
            }

            else
            {
                Application.Run(new FirstAccessForm());
            }

            
        }

        public static void CreateMachine(int maximumCapacity)
        {
            ExchangeMachine = new ExchangeMachine(maximumCapacity);
        }

        public static void CreateLists()
        {
            Deposits = new List<List<CoinSet>>();
            Changes = new List<List<CoinSet>>();
            Withdraws = new List<List<CoinSet>>();
        }

        public static void SaveExchangeMachineToXML()
        {
            XmlSerializer writer = new XmlSerializer(typeof(ExchangeMachine));
            //Salva o arquivo XML na pasta Documentos/Exchange Machine App
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Exchange Machine.xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, ExchangeMachine);
            file.Close();
        }

        public static void LoadExchangeMachineIntoXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(ExchangeMachine));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Exchange Machine.xml";
            StreamReader file = new StreamReader(path);
            ExchangeMachine = (ExchangeMachine)reader.Deserialize(file);
            file.Close();

        }

        public static void SaveCoinValidValuesToXML()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<decimal>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Coin Valid Values.xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, CoinValidator.ValidValues);
            file.Close();
        }

        public static void LoadCoinValidValuesIntoXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<decimal>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Coin Valid Values.xml";
            StreamReader file = new StreamReader(path);
            CoinValidator.ValidValues = (List<decimal>)reader.Deserialize(file);
            file.Close();
        }

        public static void SaveDepositsToXML()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<List<CoinSet>>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Deposits.xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, Deposits);
            file.Close();
        }

        public static void LoadDepositsIntoXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<List<CoinSet>>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Deposits.xml";
            StreamReader file = new StreamReader(path);
            Deposits = (List<List<CoinSet>>)reader.Deserialize(file);
            file.Close();
        }

        public static void SaveChangesToXML()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<List<CoinSet>>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Changes.xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, Changes);
            file.Close();
        }

        public static void LoadChangesIntoXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<List<CoinSet>>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Changes.xml";
            StreamReader file = new StreamReader(path);
            Changes = (List<List<CoinSet>>)reader.Deserialize(file);
            file.Close();
        }

        public static void SaveWithdrawsToXML()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<List<CoinSet>>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Withdraws.xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, Withdraws);
            file.Close();
        }

        public static void LoadWithdrawsIntoXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<List<CoinSet>>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//Withdraws.xml";
            StreamReader file = new StreamReader(path);
            Withdraws = (List<List<CoinSet>>)reader.Deserialize(file);
            file.Close();
        }
    }
}
