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
                ExchangeMachine = (ExchangeMachine)LoadDataFromXML(typeof(ExchangeMachine), "Exchange Machine.xml");
                CoinValidator.ValidValues = (List<decimal>)LoadDataFromXML(typeof(List<decimal>), "Coin Valid Values.xml");

                if (File.Exists(pathDataFile + "Deposits.xml"))
                {
                    Deposits = (List<List<CoinSet>>)LoadDataFromXML(typeof(List<List<CoinSet>>), "Deposits.xml");
                }

                if (File.Exists(pathDataFile + "Withdraws.xml"))
                {
                    Withdraws = (List<List<CoinSet>>)LoadDataFromXML(typeof(List<List<CoinSet>>), "Withdraws.xml");
                }

                if (File.Exists(pathDataFile + "Changes.xml"))
                {
                    Changes = (List<List<CoinSet>>)LoadDataFromXML(typeof(List<List<CoinSet>>), "Changes.xml");
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

        public static void SaveDataToXML(Type type, String fileName, Object obj)
        {
            XmlSerializer writer = new XmlSerializer(type);
            //Salva o arquivo XML na pasta Documentos/Exchange Machine App
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//" + fileName;
            FileStream file = File.Create(path);
            writer.Serialize(file, obj);
            file.Close();
        }

        public static Object LoadDataFromXML(Type type, String fileName)
        {
            XmlSerializer reader = new XmlSerializer(type);
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Exchange Machine App//" + fileName;
            StreamReader file = new StreamReader(path);
            Object obj = reader.Deserialize(file);
            file.Close();
            return obj;
        }
    }
}
