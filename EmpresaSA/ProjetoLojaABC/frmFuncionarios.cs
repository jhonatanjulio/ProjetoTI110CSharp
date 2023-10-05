using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace ProjetoLojaABC
{
    public partial class frmFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmFuncionarios()
        {
            InitializeComponent();
            desabilitarCampos();
        }

        public frmFuncionarios(string nome)
        {
            InitializeComponent();
            habilitarCamposAlterar();
            carregaFuncionario(nome);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCamposNovo();
        }

        //criando o método limpar
        public void limparCampos()
        {
            txtCod.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();

            mskCEP.Clear();
            mskCPF.Clear();

            cbbEstado.Items.Clear();
            cbbEstado.Text = "";

            txtNome.Focus();
        }

        //desabilitar campos
        public void desabilitarCampos()
        {
            txtCod.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;

            mskCEP.Enabled = false;
            mskCPF.Enabled = false;

            cbbEstado.Enabled = false;
            dtpNasc.Enabled = false;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
        }

        //desabilitar campos novo
        public void desabilitarCamposNovo()
        {
            txtCod.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;

            mskCEP.Enabled = false;
            mskCPF.Enabled = false;

            cbbEstado.Enabled = false;
            dtpNasc.Enabled = false;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnNovo.Enabled = true;
            btnNovo.Focus();
        }

        public void habilitarCamposNovo()
        {
            txtCod.Enabled = false;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;

            mskCEP.Enabled = true;
            mskCPF.Enabled = true;

            cbbEstado.Enabled = true;
            dtpNasc.Enabled = true;

            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = true;
            btnNovo.Enabled = false;


            txtNome.Focus();
        }
        public void habilitarCamposAlterar()
        {
            txtCod.Enabled = false;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;

            mskCEP.Enabled = true;
            mskCPF.Enabled = true;

            cbbEstado.Enabled = true;
            dtpNasc.Enabled = true;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            btnNovo.Enabled = false;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            carregaCodigo();
            habilitarCamposNovo();
        }

        public int cadastraFuncionarios()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbFuncionarios(nome,email,cpf,d_nasc,endereco,cep,numero,bairro,estado,cidade)values(@nome,@email,@cpf,@d_nasc,@endereco,@cep,@numero,@bairro,@estado,@cidade);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCPF.Text;
            comm.Parameters.Add("@d_nasc", MySqlDbType.Date).Value = Convert.ToDateTime(dtpNasc.Text);
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCEP.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return res;
        }

        public void carregaCodigo()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select cod_func+1 from tbFuncionarios order by cod_func desc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCod.Text = Convert.ToString(DR.GetInt32(0));

            Conexao.fecharConexao();
        }

        //carregar funcionario
        public void carregaFuncionario(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome = @nomeFunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nomeFunc", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCod.Text = Convert.ToString(DR.GetInt32(0));
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            mskCPF.Text = DR.GetString(3);
            dtpNasc.Text = Convert.ToString(DR.GetDateTime(4));
            txtEndereco.Text = DR.GetString(5);
            mskCEP.Text = DR.GetString(6);
            txtNumero.Text = DR.GetString(7);
            txtBairro.Text = DR.GetString(8);
            cbbEstado.Text = DR.GetString(9);
            txtCidade.Text = DR.GetString(10);

            Conexao.fecharConexao();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("") || txtBairro.Text.Equals("") || txtCidade.Text.Equals("") ||
                txtNumero.Text.Equals("") || txtEmail.Text.Equals("") || txtEndereco.Text.Equals("") ||
                mskCPF.Text.Equals("   .   .   -") || mskCEP.Text.Equals("     -"))
            {
                MessageBox.Show("É necessário preencher todos os campos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cadastraFuncionarios() == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    desabilitarCamposNovo();
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar.", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarFuncionarios abrir = new frmPesquisarFuncionarios();
            abrir.Show();
            this.Hide();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alterado com sucesso!", 
                            "Mensagem do Sistema", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
            limparCampos();
            desabilitarCamposNovo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja realmente excluir?",
                                                "Mensagem do Sistema",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning,
                                                MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                limparCampos();
                desabilitarCamposNovo();
                MessageBox.Show("Excluído com sucesso!",
                            "Mensagem do Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
            }
        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WSCorreios.AtendeClienteClient ws = new WSCorreios.AtendeClienteClient();

                try
                {
                    WSCorreios.enderecoERP endereco = ws.consultaCEP(mskCEP.Text);
                    txtEndereco.Text = endereco.end;
                    txtBairro.Text = endereco.bairro;
                    txtCidade.Text = endereco.cidade;
                    cbbEstado.Text = endereco.uf;

                    txtNumero.Focus();
                }
                catch (Exception)
                {
                    if (mskCEP.Text.Equals("     -"))
                    {
                        txtNumero.Focus();
                    }
                    else
                    {
                        MessageBox.Show("CEP inválido!",
                            "Mensagem do Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                        mskCEP.Focus();
                        mskCEP.Clear();
                    }
                }
            }            
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            Conexao.obterConexao();
            MessageBox.Show("Banco de Dados conectado!");

            Conexao.fecharConexao();
            MessageBox.Show("Banco de Dados desconectado!");
        }
    }
}
