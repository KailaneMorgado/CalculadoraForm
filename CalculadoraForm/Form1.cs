using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForm
{
    public partial class FmTela : Form
    {
        //variaveis globais:
        bool operadorClicado = true;
        bool acabeiDeCalcular = false;

        public FmTela()
        {
            InitializeComponent();
        }



        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                // Supondo que txtDisplay.Text tem "5+4-8"....
                DataTable dt = new DataTable();
                var resultado = dt.Compute(txbTela.Text, null);
                double valor = Convert.ToDouble(resultado);

                // Verifica se é infinito (divisão por zero)
                if (double.IsInfinity(valor))
                {
                    MessageBox.Show("Divisão por zero não é permitida!", "Erro de Divisão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbTela.Text = ""; // Limpa a tela
                    operadorClicado = true;
                    return; // Sai da função
                }

                txbTela.Text = valor.ToString();
                acabeiDeCalcular = true;
            }
            catch
            {
                MessageBox.Show("Não há nenhuma operação a ser feita.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void numero_Click(object sender, EventArgs e)
        {
            //Obter um botão que está chamando esse evento:
            Button botaoClicado = (Button)sender;

            //limpar se eu já tiver calculado e clicar para calcular outra coisa.
            if (acabeiDeCalcular)
            {
                btnLimpar.PerformClick(); 
                acabeiDeCalcular = false;
            }

            //Adicionar o text do botão clicado no text box:
            txbTela.Text += botaoClicado.Text;

            operadorClicado = false;

        }

        private void operador_Click(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            if (operadorClicado == false)
            {
                // Adiciona o operador normalmente
                txbTela.Text += botaoClicado.Text;
                operadorClicado = true;
            }
            else if (txbTela.Text.Length > 0)
            {
                // Se já tem operador, substitui o último caractere
                char ultimoChar = txbTela.Text[txbTela.Text.Length - 1];

                if (ultimoChar == '+' || ultimoChar == '-' || ultimoChar == '*' || ultimoChar == '/')
                {
                    // Remove o último operador e coloca o novo
                    txbTela.Text = txbTela.Text.Substring(0, txbTela.Text.Length - 1) + botaoClicado.Text;
                }
                else
                {
                    // Se o último não é operador, adiciona normalmente
                    txbTela.Text += botaoClicado.Text;
                }
                operadorClicado = true;
            }

            acabeiDeCalcular = false;
        
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpar tela:
            txbTela.Text = "";
            //Voltar o operador clicado para true:
            operadorClicado = true;
        }

    }
}
