using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projetoAlugaMesa
{
    public partial class frmAlugarMesa : Form
    {
        public frmAlugarMesa()
        {
            InitializeComponent();
            disableFields();
        }

        // desabilitar campos
        public void disableFields()
        {
            // desabilitando botões
            btnAlugar.Enabled = false;
            btnLiberar.Enabled = false;
            btnLimpar.Enabled = false;

            // desabilitando campos
            txtCliente.Enabled = false;
            txtIdMesa.Enabled = false;
            txtStatus.Enabled = false;

            // habilitando botões padrões
            btnPesquisar.Enabled = true;
            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;
            lstPesquisar.Enabled = true;
        }

        // habilitar campos botão novo
        public void enableFieldsNew()
        {
            // habilitando botões
            btnAlugar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos
            txtCliente.Enabled = true;
            txtIdMesa.Enabled = true;
            txtStatus.Enabled = true;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;
            rdbDisponiveis.Enabled = false;
            rdbIndisponiveis.Enabled = false;
            lstPesquisar.Enabled = false;

            btnAlugar.Focus();
        }

        // habilitar campos botão pesquisar quando mesa estiver disponivel
        public void enableFieldsResearchAvailabe()
        {
            // habilitando botões
            btnAlugar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos
            txtCliente.Enabled = true;
            txtIdMesa.Enabled = false;
            txtStatus.Enabled = false;

            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;

            btnAlugar.Focus();
        }

        // habilitar campos botão pesquisar quando mesa estiver indisponivel
        public void enableFieldsResearchUnavailabe()
        {
            // habilitando botões
            btnLiberar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos
            txtCliente.Enabled = true;
            txtIdMesa.Enabled = true;
            txtStatus.Enabled = false;

            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;

            btnLiberar.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtCliente.Clear();
            txtIdMesa.Clear();
            txtStatus.Clear();

            txtCliente.Focus();

            lstPesquisar.Items.Clear();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal open = new frmMenuPrincipal();
            open.Show();
            this.Hide();
        }

        //função sql pesquisar mesas disponíveis
        public void researchAvailableTables()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa, qtdCad from tbMesa where status = 'DISPONIVEL';";
            con.CommandType = CommandType.Text;


            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            while (DR.Read())
            {
                lstPesquisar.Items.Add("Mesa: " + DR.GetValue(0).ToString() + " | " + DR.GetValue(1).ToString() + " cadeiras");
            }

            Connection.closeConnection();
        }

        //função sql pesquisar mesas alugadas (para fazer)
        public void researchRentedTables()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select cliente, idMesa, status from tbAluguel;";
            con.CommandType = CommandType.Text;


            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            while (DR.Read())
            {
                lstPesquisar.Items.Add("Mesa: " + DR.GetValue(0).ToString() + " | " + "Cliente: " + DR.GetValue(1).ToString() + " | " + "Status: " + DR.GetValue(2));
            }

            Connection.closeConnection();
        }

        //função sql alugar mesas


        //click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbDisponiveis.Checked == true)
            {
                clearFields();
                disableFields();
                researchAvailableTables();
            }
            else if (rdbIndisponiveis.Checked == true)
            {
                clearFields();
                disableFields();
                enableFieldsResearchUnavailabe();
                txtStatus.Text = "INDISPONIVEL";
            }
            else
            {
                MessageBox.Show("Escolha pelo menos uma opção!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
            rdbDisponiveis.Checked = false;
            rdbIndisponiveis.Checked = false;
        }

        //click botão alugar
        private void btnAlugar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        //click botão liberar
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        private void lstPesquisar_SelectedIndexChanged(object sender, EventArgs e) // incompleto
        {
            if (lstPesquisar.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item válido!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                //extraindo apenas o código da mesa a partir da listbox com split
                char[] between = { ' ' };
                string[] cod = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
                int table = Convert.ToInt32(cod[1]);

                enableFieldsResearchAvailabe();
            }
        }

        //ação click no radio button disponíveis (para caso troque a opção, a lista seja limpa para uma nova pesquisa)
        private void rdbDisponiveis_CheckedChanged(object sender, EventArgs e)
        {
            lstPesquisar.Items.Clear();
        }

        //ação click no radio button alugadas/indisponiveis (para caso troque a opção, a lista seja limpa para uma nova pesquisa)
        private void rdbIndisponiveis_CheckedChanged(object sender, EventArgs e)
        {
            lstPesquisar.Items.Clear();
        }
    }
}
