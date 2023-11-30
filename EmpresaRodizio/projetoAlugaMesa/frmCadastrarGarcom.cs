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
            txtEmail.Enabled = true;
            mtbCPF.Enabled = true;
            dtpDataEntrada.Enabled = true;

            gpbStatus.Enabled = true;
            rdbAtivo.Checked = true;

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        //habilitar campos botão pesquisar inativo
        public void enableFieldsResearchInactive()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;

            // habilitando campos
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            mtbCPF.Enabled = false;
            dtpDataEntrada.Enabled = false;

            gpbStatus.Enabled = true;
            rdbInativo.Checked = true;

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        //função sql cadastrar funcionários
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

        // função sql pesquisar funcionarios inativos
        public void researchInactiveEmployee()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idGarcom, nome, status from tbGarcom where status = 'INATIVO';";
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

        //função sql para pesquisar todos os dados do registro e imprimir na textbox
        public void researchTablesPrintData(int idGarcom)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select * from tbGarcom where idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = idGarcom;

            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            txtIdGarcom.Text = DR.GetValue(0).ToString();
            txtNome.Text = DR.GetValue(1).ToString();
            txtEmail.Text = DR.GetValue(2).ToString();
            mtbCPF.Text = DR.GetValue(3).ToString();
            dtpDataEntrada.Text = DR.GetValue(4).ToString();


            if (DR.GetValue(5).ToString().Equals("ATIVO"))
            {
                enableFieldsResearchActive();
            }
            else
            {
                enableFieldsResearchInactive();
            }

            Connection.closeConnection();
        }

        //função sql alterar funcionário
        public int changeEmployee(int idGarcom)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbGarcom set nome = @nome, email = @email, cpf = @cpf, dataEntrada = @dataEntrada, status = @status where idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;
            string status;

            if (rdbAtivo.Checked == true)
            {
                status = "ATIVO";
            }
            else
            {
                status = "INATIVO";
            }

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = txtNome.Text;
            con.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            con.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mtbCPF.Text;
            con.Parameters.Add("@dataEntrada", MySqlDbType.Date).Value = Convert.ToDateTime(dtpDataEntrada.Text);
            con.Parameters.Add("@status", MySqlDbType.VarChar, 15).Value = status;
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = idGarcom;

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        //função sql desativar funcionario
        public int disableEmployee()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbGarcom set status = 'INATIVO' where idGarcom = @idGarcom";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(txtIdGarcom.Text);

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
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
                //extraindo apenas o código do garçom a partir da listbox com split
                char[] between = { ' ' };
                string[] cod = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
                int waiter = Convert.ToInt32(cod[1]);
                txtNome.Focus();

                researchTablesPrintData(waiter);
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
                researchInactiveEmployee();
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

        //click botão alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //extraindo apenas o status (ativo ou inativo) para utilizar uma estrutura de condição
            char[] between = { ' ' };
            string[] str = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
            string status = str[str.Length - 1];

            if (status.Equals("ATIVO"))
            {
                if (rdbInativo.Checked == true)
                {
                    DialogResult resp = MessageBox.Show("Você está desativando um funcionário!\nDeseja realmente continuar?", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    if (resp == DialogResult.Yes)
                    {
                        if (changeEmployee(Convert.ToInt32(txtIdGarcom.Text)) == 1)
                        {
                            MessageBox.Show("Funcionário desativado e alterado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            clearFields();
                            disableFields();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao desativar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                else
                {
                    DialogResult resp = MessageBox.Show("Você está alterando um funcionário!\nDeseja realmente continuar?", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    if (resp == DialogResult.Yes)
                    {
                        if (changeEmployee(Convert.ToInt32(txtIdGarcom.Text)) == 1)
                        {
                            MessageBox.Show("Funcionário alterado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            clearFields();
                            disableFields();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            else
            {
                if (rdbAtivo.Checked == true)
                {
                    DialogResult resp = MessageBox.Show("Você está reativando um funcionário!\nDeseja realmente continuar?", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    if (resp == DialogResult.Yes)
                    {
                        if (changeEmployee(Convert.ToInt32(txtIdGarcom.Text)) == 1)
                        {
                            MessageBox.Show("Funcionário reativado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            clearFields();
                            disableFields();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao reativar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione \"Ativo\" para reativar o funcionário!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }

        //ação click botão desativar
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Você está desativando um funcionário!\nDeseja realmente continuar?", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (resp == DialogResult.Yes)
            {
                if (disableEmployee() == 1)
                {
                    MessageBox.Show("Funcionário desativado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    clearFields();
                    disableFields();
                }
                else
                {
                    MessageBox.Show("Erro ao desativar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            
        }
    }
}
