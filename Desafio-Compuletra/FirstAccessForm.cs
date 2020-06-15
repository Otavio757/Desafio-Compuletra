﻿using Desafio_Compuletra.Validators;
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
    public partial class FirstAccessForm : Form
    {
        public FirstAccessForm()
        {
            InitializeComponent();
        }

        private void CustomPattern_Enter(object sender, EventArgs e)
        {
            if (CustomPattern.Text == "Digite os valores em centavos, separados por virgula")
            {
                CustomPattern.Text = "";
                CustomPattern.ForeColor = Color.Black;
            }
        }

        private void ButtonBrazilianPattern_CheckedChanged(object sender, EventArgs e)
        {
            CustomPattern.Visible = false;
        }

        private void ButtonCustomPattern_CheckedChanged(object sender, EventArgs e)
        {
            CustomPattern.Visible = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (MachineCapacity.Text != "" && (ButtonBrazilianPattern.Checked || (ButtonCustomPattern.Checked && CustomPattern.Text != "")))
            {
                try
                {
                    Program.CreateMachine(int.Parse(MachineCapacity.Text));

                    if (ButtonBrazilianPattern.Checked)
                    {
                        CoinValidator.BrazilianPattern();
                        OpenMainForm();
                    }

                    else
                    {
                        CoinValidator.BlankPattern();
                        String[] values = CustomPattern.Text.Split(',');

                        try
                        {
                            foreach (String s in values)
                            {
                                int cents = int.Parse(s);
                                double value = (double)cents / 100; //Converte o valor de centavos inteiro para decimal (exemplo: 50 centavos são 0.5);
                                CoinValidator.AddValue(value);
                            }

                            OpenMainForm();
                        }

                        catch
                        {
                            MessageBox.Show("Você não digitou corretamente o padrão de moedas personalizado. Digite os valores em centavos, separados por vírgula. " +
                                            "Por exemplo: 1,5,10,25,50,100", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }

                catch
                {
                    MessageBox.Show("Digite apenas números para definir a capacidade máxima da máquina", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("Preencha todos os campos antes de continuar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OpenMainForm()
        {
            this.Hide();
            var mainForm = new MainForm();
            mainForm.Closed += (s, args) => this.Close();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}