using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoAlugaMesa
{
    public partial class frmCalculadoraGorjeta : Form
    {
        public frmCalculadoraGorjeta()
        {
            InitializeComponent();
        }


        //calcular gorjeta
        public void calcularGorjeta(double porc)
        {
            double valorConta = Convert.ToDouble(txtValorConta.Text);
            double valorGorjeta = valorConta * (porc / 100);
            double valorTotal = valorConta + valorGorjeta;

            txtValorGorjeta.Text = valorGorjeta.ToString();
            txtValorTotal.Text = valorTotal.ToString();
        }

        //calcular gorjeta
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbbAvaliacao.Text)
                {
                    case "Excelente - 10%":
                        calcularGorjeta(10);
                        break;
                    case "Ótimo - 8%":
                        calcularGorjeta(8);
                        break;
                    case "Bom - 5%":
                        calcularGorjeta(5);
                        break;
                    case "Ruim - 2%":
                        calcularGorjeta(2);
                        break;
                    case "Sem gorjeta":
                        calcularGorjeta(0);
                        break;
                    default:
                        MessageBox.Show("Avalie o serviço antes de calcular a gorjeta!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        break;
                }

                btnContinuar.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha todos os campos antes de calcular a gorjeta!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            frmAlugarMesa open = new frmAlugarMesa(txtValorConta.Text, txtValorGorjeta.Text, txtValorTotal.Text);
            open.Show();
            this.Close();
        }
    }
}
