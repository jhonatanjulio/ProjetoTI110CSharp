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
        private int index = 0;
        private List<string> resultado = new List<string>();

        public frmCalculadoraGorjeta()
        {
            InitializeComponent();
        }

        public frmCalculadoraGorjeta(int selectedIndex, List<string> result)
        {
            InitializeComponent();
            index = selectedIndex;
            resultado = result;
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
            
            //repreenche a lista de pesquisa
            foreach (string linha in resultado)
            {
                open.lstPesquisar.Items.Add(linha);
            }

            //reselecionando o item que estava selecionado anteriormente
            open.lstPesquisar.SelectedIndex = index;

            //extraindo apenas o código da reserva a partir da listbox com split
            char[] between = { ' ' };
            string[] cod = open.lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
            int rentedTable = Convert.ToInt32(cod[cod.Length - 1]);

            open.researchUnavailableTablesPrintData(rentedTable);

            //repreenche a lista de pesquisa (novamente)
            foreach (string linha in resultado)
            {
                open.lstPesquisar.Items.Add(linha);
            }

            //reselecionando o item que estava selecionado anteriormente
            open.lstPesquisar.SelectedIndex = index;

            //retornando o valor da flag original para a função clearFieldsValues retornar sua função normal
            open.flagClearFields = false;
            open.btnFecharConta.Enabled = false;

            open.Show();

            this.Close();
        }
    }
}
