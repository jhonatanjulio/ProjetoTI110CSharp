using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLojaABC
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // declarando variável para receber o valor do botão selecionado
            DialogResult resp;
            resp = MessageBox.Show("Deseja sair?",
                "Mensagem do Sistema",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button3);

            if(resp == DialogResult.Yes) {
                Application.Exit();
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double num1, num2, result = 0;
            string resp = "";

            try
            {
                num1 = Convert.ToDouble(txtVariavel1.Text);
                num2 = Convert.ToDouble(txtVariavel2.Text);

                if (!(rdbAdicao.Checked || rdbSubtracao.Checked || rdbMultiplicacao.Checked || rdbDivisao.Checked))
                {
                    MessageBox.Show("Selecione uma operação.",
                        "Mensagem do Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    if (rdbAdicao.Checked)
                    {
                        result = num1 + num2;
                        resp = Convert.ToString(result);
                    }
                    if (rdbSubtracao.Checked)
                    {
                        result = num1 - num2;
                        resp = Convert.ToString(result);
                    }
                    if (rdbMultiplicacao.Checked)
                    {
                        result = num1 * num2;
                        resp = Convert.ToString(result);

                    }
                    if (rdbDivisao.Checked)
                    {
                        if (num2 == 0)
                        {
                            resp = "Impossível dividir por zero.";
                        }
                        else
                        {
                            result = num1 / num2;
                            resp = Convert.ToString(result);
                        }
                    }

                    limparCamposCalcular();
                    lblResultado.Text = resp;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insira apenas números.",
                        "Mensagem do Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                limparCampos();
            }
        }

        public void limparCampos()
        {
            txtVariavel1.Text = "";
            txtVariavel2.Clear();

            lblResultado.Text = "";

            rdbAdicao.Checked = false;
            rdbSubtracao.Checked = false;
            rdbMultiplicacao.Checked = false;
            rdbDivisao.Checked = false;

            txtVariavel1.Focus();
        }

        public void limparCamposCalcular()
        {
            txtVariavel1.Text = "";
            txtVariavel2.Clear();

            rdbAdicao.Checked = false;
            rdbSubtracao.Checked = false;
            rdbMultiplicacao.Checked = false;
            rdbDivisao.Checked = false;

            txtVariavel1.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}
