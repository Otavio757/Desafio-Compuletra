using Desafio_Compuletra.Entities;
using Desafio_Compuletra.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Compuletra
{
    public partial class MainForm : Form
    {
        private String currentHelpMessage;
        private EventHandler currentButton = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Summary.Text = Program.ExchangeMachine.ToString();
        }

        private void ClearInputAndShowButtons()
        {
            Input.Visible = true;
            Input.Text = "";
            Input.ReadOnly = false;
            ButtonSubmit.Visible = true;
            ButtonHelp.Visible = true;

        }

        private void ButtonDeposit_Click(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                ButtonSubmit.Click -= currentButton;
            }
  
            ButtonSubmit.Visible = true;
            ButtonSubmit.Text = "Efetuar Depósito";
            currentButton = new EventHandler(SubmitDeposit);
            ButtonSubmit.Click += currentButton;

            currentHelpMessage = "Digite os valores das moedas e as suas respectivas quantidades que deseja depositar, separando-as por quebras de linha. " +
                                 "Utilize o seguinte formato:\r\n" +
                                 "[Valor em centavos] : [Quantidade]\r\n" +
                                 "Por exemplo, para depositar 4 moedas de 1 real e 2 moedas de 10 centavos, digite:\r\n" +
                                 "100:4\r\n" +
                                 "10:2";
           
            ClearInputAndShowButtons();
            Input.AppendText(currentHelpMessage);
        }

        private void SubmitDeposit(object sender, EventArgs eventArgs)
        {
            String[] values = Input.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            List<CoinSet> coins = new List<CoinSet>();

            foreach (String s in values)
            {
                String[] split = s.Split(':');

                try
                {
                    int cents = int.Parse(split[0]);
                    double value = (double)cents / 100; //Converte o valor de centavos inteiro para decimal (exemplo: 50 centavos são 0.5);
                    int quantity = int.Parse(split[1]);
                    coins.Add(new CoinSet(value, quantity));           
                }

                catch (Exception e)
                {
                    if (e is InvalidCoinValueException || e is InvalidCoinQuantityException)
                    {
                        MessageBox.Show(e.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {
                        MessageBox.Show("Você não digitou corretamente as moedas do depósito. " + currentHelpMessage, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    return;
                }
            }

            try
            {
                Program.ExchangeMachine.AddCoins(coins);
                MessageBox.Show("Depósito efetuado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (MachineOverflowException e)
            {
                MessageBox.Show(e.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Summary.Text = Program.ExchangeMachine.ToString();
            Input.Text = "";
        }

        private void ButtonWithdraw_Click(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                ButtonSubmit.Click -= currentButton;
            }

            ButtonSubmit.Visible = true;
            ButtonSubmit.Text = "Efetuar Saque";
            currentButton = new EventHandler(SubmitWithdraw);
            ButtonSubmit.Click += currentButton;

            currentHelpMessage = "Digite os valores das moedas e as suas respectivas quantidades que deseja sacar, separando-as por quebras de linha. " +
                                 "Utilize o seguinte formato:\r\n" +
                                 "[Valor em centavos] : [Quantidade]\r\n" +
                                 "Por exemplo, para sacar 4 moedas de 1 real e 2 moedas de 10 centavos, digite:\r\n" +
                                 "100:4\r\n" +
                                 "10:2";

            ClearInputAndShowButtons();
            Input.AppendText(currentHelpMessage);
        }

        private void SubmitWithdraw(object sender, EventArgs eventArgs)
        {
            String[] values = Input.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            List<CoinSet> coins = new List<CoinSet>();

            foreach (String s in values)
            {
                String[] split = s.Split(':');

                try
                {
                    int cents = int.Parse(split[0]);
                    double value = (double)cents / 100; //Converte o valor de centavos inteiro para decimal (exemplo: 50 centavos são 0.5);
                    int quantity = int.Parse(split[1]);
                    coins.Add(new CoinSet(value, quantity));
                }

                catch
                {
                    MessageBox.Show("Você não digitou corretamente as moedas do saque. " + currentHelpMessage, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            try
            {
                Program.ExchangeMachine.Withdraw(coins);
                Summary.Text = Program.ExchangeMachine.ToString();
                MessageBox.Show("Saque efetuado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InsufficientCoinsToWithdrawException e)
            {
                MessageBox.Show(e.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Input.Text = "";
        }

        private void ButtonStatus_Click(object sender, EventArgs e)
        {
            ClearInputAndShowButtons();
            Input.ReadOnly = true;
            Input.AppendText(Program.ExchangeMachine.Status());
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                ButtonSubmit.Click -= currentButton;
            }

            ButtonSubmit.Visible = true;
            ButtonSubmit.Text = "Gerar Troco";
            currentButton = new EventHandler(SubmitChange);
            ButtonSubmit.Click += currentButton;

            ClearInputAndShowButtons();
            currentHelpMessage = "Digite o valor do troco";
            Input.AppendText(currentHelpMessage);
        }

        private void SubmitChange(object sender, EventArgs eventArgs)
        {
            try
            {
                double value = double.Parse(Input.Text);

                try
                {
                    List<CoinSet> change = Program.ExchangeMachine.GenerateChange(value);
                    String changeDetails = "Confira abaixo o seu troco:\r\n" + change[0].ToString();

                    for (int i = 1; i < change.Count; i++)
                    {
                        changeDetails += "\r\n" + change[i].ToString();
                    }

                    Summary.Text = Program.ExchangeMachine.ToString();
                    MessageBox.Show(changeDetails, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (InsufficientCoinsToChangeException e)
                {
                    MessageBox.Show(e.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            catch
            {
                MessageBox.Show("Você não digitou corretamente o valor do troco. Digite apenas números e uma vírgula para separar os " +
                                "centavos (por exemplo: 0,25)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Input.Text = "";
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(currentHelpMessage, "Ajuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Input_Enter(object sender, EventArgs e)
        {
            if (Input.Text == currentHelpMessage)
            {
                Input.Text = "";
            }
        }
    }
}
