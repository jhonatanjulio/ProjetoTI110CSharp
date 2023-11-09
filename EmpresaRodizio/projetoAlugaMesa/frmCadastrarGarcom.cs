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
    public partial class frmCadastrarGarcom : Form
    {
        public frmCadastrarGarcom()
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
            txtIdGarcom.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            mtbCPF.Enabled = false;

            dtpDataEntrada.Enabled = false;
            dtpDataEntrada.Format = DateTimePickerFormat.Custom;
            dtpDataEntrada.CustomFormat = " ";

            gpbStatus.Enabled = false;

            // habilitando botões padrões
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            rdbAtivos.Enabled = true;
            rdbInativos.Enabled = true;
            lstPesquisar.Enabled = true;
        }

        // habilitar campos botão novo
        public void enableFieldsNew()
        {
            // habilitando botões
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e botando status padrao
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            mtbCPF.Enabled = true;
            gpbStatus.Enabled = true;
            rdbAtivo.Enabled = true;
            rdbAtivo.Checked = true;
            rdbInativo.Enabled = false;

            dtpDataEntrada.Enabled = true;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;
            dtpDataEntrada.Value = DateTime.Today;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;
            rdbAtivos.Enabled = false;
            rdbInativos.Enabled = false;
            lstPesquisar.Enabled = false;

            txtNome.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtIdGarcom.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            mtbCPF.Clear();

            rdbAtivo.Checked = false;
            rdbInativo.Checked = false;

            rdbAtivos.Checked = false;
            rdbInativos.Checked = false;

            lstPesquisar.Items.Clear();

            txtNome.Focus();
        }

        // habilitar campos botão pesquisar ativo
        public void enableFieldsResearchActive()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;

            // habilitando campos
            txtNome.Enabled = true;

            gpbStatus.Enabled = true;
            rdbAtivo.Checked = true;

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        //função sql cadastrar funcinários
        public int registerEmployee()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "insert into tbGarcom(nome, email, cpf, dataEntrada, status) values (@nome, @email, @cpf, @dataEntrada, @status);";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = txtNome.Text;
            con.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            con.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mtbCPF.Text;
            con.Parameters.Add("@dataEntrada", MySqlDbType.Date).Value = Convert.ToDateTime(dtpDataEntrada.Text);
            con.Parameters.Add("@status", MySqlDbType.VarChar, 15).Value = "ATIVO";

            con.Connection = Connection.getConnection();

            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        // função sql pesquisar funcionarios ativos
        public void researchActiveEmployee()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idGarcom, nome, status from tbGarcom where status = 'ATIVO';";
            con.CommandType = CommandType.Text;


            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            while (DR.Read())
            {
                lstPesquisar.Items.Add("ID: " + DR.GetValue(0).ToString() + " | " + "Nome: " + DR.GetValue(1).ToString() + " | " + "Status: " + DR.GetValue(2).ToString());
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
        }

        //click limpar campos
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        private void lstPesquisar_SelectedIndexChanged(object sender, EventArgs e)
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
                txtNome.Focus();

                //researchTablesPrintData(table);
            }
        }

        //click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbAtivos.Checked == true) //ativo
            {
                clearFields();
                rdbAtivo.Checked = true;
                disableFields();
                researchActiveEmployee();
            }
            else if (rdbInativos.Checked == true) //inativo
            {
                clearFields();
                rdbInativo.Checked = true;
                disableFields();
                //researchInactiveEmployee();
            }
            else //none
            {
                MessageBox.Show("Escolha pelo menos uma opção!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //click botão cadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!(txtNome.Text.Equals("") || txtEmail.Text.Equals("") || mtbCPF.Text.Equals("   .   .   -"))) 
            { 
                if (registerEmployee() == 1)
                {
                    clearFields();
                    disableFields();
                    MessageBox.Show("Garçom cadastrado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
