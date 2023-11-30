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
    public partial class frmCadastrarUsuario : Form
    {
        public frmCadastrarUsuario()
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
            txtNome.Enabled = false;
            txtSenha.Enabled = false;
            cbbFuncionario.Enabled = false;

            // habilitando botões padrões
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            lstPesquisar.Enabled = true;
            txtNomeUser.Enabled = true;

            researchAllEmployees();
        }

        // habilitar campos botão novo
        public void enableFieldsNew()
        {
            // habilitando botões
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e botando status padrao
            txtNome.Enabled = true;
            txtSenha.Enabled = true;
            cbbFuncionario.Enabled = true;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;
            txtNomeUser.Enabled = false;
            lstPesquisar.Enabled = false;

            txtNome.Focus();
        }

        // habilitar campos botão pesquisar
        public void enableFieldsResearch()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos
            txtNome.Enabled = true;
            txtSenha.Enabled = true;

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtNome.Clear();
            txtSenha.Clear();
            cbbFuncionario.Text = "";
            cbbFuncionario.Items.Clear();

            lstPesquisar.Items.Clear();

            txtNome.Focus();
        }

        // pesquisar todos os funcionários que não possuem usuários e que estejam ativos
        public void researchAllEmployees()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select func.nome from tbGarcom as func left join tbUsuario as usu on usu.idGarcom = func.idGarcom where usu.idGarcom is null AND func.status = 'ATIVO';";
            con.CommandType = CommandType.Text;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            if (DR.HasRows)
            {
                cbbFuncionario.Items.Clear();
                while (DR.Read())
                {
                    cbbFuncionario.Items.Add(DR.GetValue(0).ToString());
                }
            }
            else
            {
                cbbFuncionario.Items.Clear();
                cbbFuncionario.Items.Add("Não existem funcionários disponíveis");
                cbbFuncionario.SelectedIndex = 0;
            }
            

            Connection.closeConnection();
        }

        // pesquisar todos os usuários registrados/cadastrados
        public void researchUsers()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select usuario from tbUsuario where usuario like @nome;";
            con.CommandType = CommandType.Text;

            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = "%" + txtNomeUser.Text + "%";

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();
            lstPesquisar.Items.Clear();
            
            while (DR.Read())
            {
                lstPesquisar.Items.Add(DR.GetValue(0).ToString());
                
            }

            Connection.closeConnection();
        }

        // pesquisar todos os registros do usuario especifico e mostrar os dados nas txt boxes
        public void researchUsersPrintData(string nome)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select * from tbUsuario where usuario = @nome;";
            con.CommandType = CommandType.Text;

            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = nome;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            txtNome.Text = DR.GetString("usuario");
            txtSenha.Text = DR.GetString("senha");
            lblIdFunc.Text = DR.GetString("idGarcom");

            Connection.closeConnection();

            researchEmployeeName(Convert.ToInt32(lblIdFunc.Text));
        }

        // pesquisar nome do funcionario pelo codigo
        public void researchEmployeeName(int id)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select nome from tbGarcom where idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = id;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();
            cbbFuncionario.Items.Clear();
            cbbFuncionario.Items.Add(DR.GetString(0).ToString());
            cbbFuncionario.SelectedIndex = 0;

            Connection.closeConnection();
        }

        // cadastrar novos usuários
        public int registerUser()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "insert into tbUsuario(usuario, senha, idGarcom) values (@usuario, @senha, @idGarcom);";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@usuario", MySqlDbType.VarChar, 20).Value = txtNome.Text;
            con.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(lblIdFunc.Text);

            con.Connection = Connection.getConnection();

            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        // alterar usuários
        public int changeUser()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbUsuario set usuario = @usuario, senha = @senha where idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Add("@usuario", MySqlDbType.VarChar, 20).Value = txtNome.Text;
            con.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(lblIdFunc.Text);

            con.Connection = Connection.getConnection();

            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        // excluir usuários
        public int deleteUser()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "delete from tbUsuario where usuario = @usuario;";
            con.CommandType = CommandType.Text;

            con.Parameters.Add("@usuario", MySqlDbType.VarChar, 20).Value = txtNome.Text;

            con.Connection = Connection.getConnection();

            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        // placeholder manual
        private void txtNomeUser_Enter(object sender, EventArgs e)
        {
            if (txtNomeUser.Text == "Digite o nome de usuário...")
            {
                txtNomeUser.Text = "";
                txtNomeUser.ForeColor = SystemColors.ControlText;
            }
        }
        private void txtNomeUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeUser.Text))
            {
                txtNomeUser.Text = "Digite o nome de usuário...";
                txtNomeUser.ForeColor = SystemColors.WindowFrame;
            }   
        }
        // -----

        //ação botão click voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal open = new frmMenuPrincipal();
            open.Show();
            this.Hide();
        }

        //ação botão click novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            enableFieldsNew();
        }

        // carregar codigo do funcionario para o cadastro
        private void cbbFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (btnCadastrar.Enabled == true)
            {
                if (!cbbFuncionario.Text.Equals("Não existem funcionários disponíveis"))
                {
                    MySqlCommand con = new MySqlCommand();
                    con.CommandText = "select idGarcom from tbGarcom where nome = @nome;";
                    con.CommandType = CommandType.Text;

                    con.Parameters.Clear();
                    con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = cbbFuncionario.Text;

                    con.Connection = Connection.getConnection();

                    MySqlDataReader DR;
                    DR = con.ExecuteReader();
                    DR.Read();
                    lblIdFunc.Text = DR.GetValue(0).ToString();

                    Connection.closeConnection();
                }
            }
        }

        // cadastrar usuario 
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!(txtNome.Text.Equals("") || txtSenha.Text.Equals("") || cbbFuncionario.Text.Equals("")))
            {
                try
                {
                    if (registerUser() == 1)
                    {
                        clearFields();
                        disableFields();
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch (FormatException)
                {
                    DialogResult resp;
                    resp = MessageBox.Show("Não existem funcionários disponíveis!\nDeseja cadastrar um novo funcionário?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                    if (resp == DialogResult.Yes)
                    {
                        frmCadastrarGarcom open = new frmCadastrarGarcom();
                        open.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //ação click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        //ação click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNomeUser.Text.Equals("") || txtNomeUser.Text.Equals("Digite o nome de usuário..."))
            {
                MessageBox.Show("Digite um nome de usuário!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            else
            {
                researchUsers();
            }
        }

        //ação click item lista de pesquisa
        private void lstPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPesquisar.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item válido!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                enableFieldsResearch();
                researchUsersPrintData(lstPesquisar.SelectedItem.ToString());
            }
        }

        //ação click botão alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!(txtNome.Text.Equals("") || txtSenha.Text.Equals("") || cbbFuncionario.Text.Equals("")))
            {
                if (changeUser() == 1)
                {
                    clearFields();
                    disableFields();
                    MessageBox.Show("Usuário alterado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Erro ao alterar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //ação click botão excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Você realmente deseja excluir este usuário?", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (resp == DialogResult.Yes)
            {
                if (deleteUser() == 1)
                {
                    MessageBox.Show("Usuário exclúida com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    clearFields();
                    disableFields();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
