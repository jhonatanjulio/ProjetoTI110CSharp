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
    public partial class frmCadastrarMesas : Form
    {
        public frmCadastrarMesas()
        {
            InitializeComponent();
            disableFields();
        }

        // desabilitar campos
        public void disableFields()
        {
            // desabilitando botões
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;

            // desabilitando campos e radio button
            txtIdMesa.Enabled = false;
            txtQtdeCadeiras.Enabled = false;

            rdbDisponivel.Enabled = false;
            rdbIndisponivel.Enabled = false;

            // habilitando botões padrões
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;
            lstPesquisar.Enabled = true;
        }

        // habilitar campos botão novo
        public void enableFieldsNew()
        {
            // habilitando botões
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e radio button
            txtQtdeCadeiras.Enabled = true;

            rdbDisponivel.Enabled = true;
            rdbIndisponivel.Enabled = true;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;
            rdbDisponiveis.Enabled = false;
            rdbIndisponiveis.Enabled = false;
            lstPesquisar.Enabled = false;

            btnCadastrar.Focus();
        }

        // habilitar campos botão pesquisar disponivel
        public void enableFieldsResearchAvailable()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e radio button
            txtQtdeCadeiras.Enabled = true;

            rdbDisponivel.Enabled = true;
            rdbIndisponivel.Enabled = true;
            rdbDisponivel.Checked = true;

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        // habilitar campos botão pesquisar indisponivel
        public void enableFieldsResearchUnavailable()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e radio button
            txtQtdeCadeiras.Enabled = false;

            rdbDisponivel.Enabled = false;
            rdbIndisponivel.Enabled = false;
            rdbIndisponivel.Checked = true;

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtIdMesa.Clear();
            txtQtdeCadeiras.Clear();

            rdbDisponivel.Checked = false;
            rdbIndisponivel.Checked = false;

            rdbDisponiveis.Checked = false;
            rdbIndisponiveis.Checked = false;

            lstPesquisar.Items.Clear();

            txtIdMesa.Focus();
        }

        // função sql cadastrar mesas
        public int registerTables(int qtdCad)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "insert into tbMesa(qtdCad, status) values (@qtdCad, @status);";
            con.CommandType = CommandType.Text;
            string status;

            if(rdbDisponivel.Checked == true)
            {
                status = "DISPONIVEL";
            }
            else if(rdbIndisponivel.Checked == true)
            {
                status = "INDISPONIVEL";
            }
            else
            {
                status = "DISPONIVEL";
            }

            con.Parameters.Clear();
            con.Parameters.Add("@qtdCad", MySqlDbType.Int32).Value = qtdCad;
            con.Parameters.Add("@status", MySqlDbType.VarChar, 15).Value = status;

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
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
            while(DR.Read())
            {
                lstPesquisar.Items.Add("Mesa: " + DR.GetValue(0).ToString() + " | " + DR.GetValue(1).ToString() + " cadeiras");
            }

            Connection.closeConnection();
        }

        //função sql pesquisa mesas indisponíveis
        public void researchUnavailableTables()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa, qtdCad from tbMesa where status = 'INDISPONIVEL';";
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

        //click botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal open = new frmMenuPrincipal();
            open.Show();
            this.Hide();
        }

        //click botão novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            enableFieldsNew();
            clearFields();
        }

        //click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        //click botão cadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (registerTables(Convert.ToInt32(txtQtdeCadeiras.Text)) == 1)
            {
                clearFields();
                disableFields();
                MessageBox.Show("Mesa cadastrada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }

        //click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            if (rdbDisponiveis.Checked == true)
            {
                clearFields();
                disableFields();
                enableFieldsResearchAvailable();
                researchAvailableTables();
            }
            else if (rdbIndisponiveis.Checked == true)
            {
                clearFields();
                disableFields();
                enableFieldsResearchUnavailable();
                researchUnavailableTables();
            }
            else
            {
                MessageBox.Show("Escolha pelo menos uma opção!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
            
        }

        //click botão alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        //click botão excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }
    }
}
