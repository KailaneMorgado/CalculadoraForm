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
        public FmTela()
        {
            InitializeComponent();
        }



        private void btnIgual_Click(object sender, EventArgs e)
        {
            //Implementar depois
        }

        private void numero_Click(object sender, EventArgs e)
        {
            //Obter um botão que está chamando esse evento:
            Button botaoClicado = (Button)sender;

            //Adicionar o text do botão clicado no text box:

        }
    }
}
