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

namespace ProjetoLojaABC
{
        public partial class frmPesquisarFuncionarios : Form
    {
        public frmPesquisarFuncionarios()
        {
            InitializeComponent();
            desabilitarCampos();
        }

        // desabilitar campos
        public void desabilitarCampos()
        {
            btnPesquisar.Enabled = false;
            btnLimpar.Enabled = false;

            txtDesc.Enabled = false;
            rdbCod.Checked = false;
            rdbNome.Checked = false;
        }
        public void habilitarCampos()
        {
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = true;

            txtDesc.Enabled = true;
            txtDesc.Focus();
        }

        // limpar campos
        public void limparCampos()
        {
            txtDesc.Clear();
            rdbCod.Checked = false;
            rdbNome.Checked = false;
            txtDesc.Focus();

            //limpar a lista:
            ltbPesquisar.Items.Clear();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void rdbCod_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbCod.Checked)
            {
                pesquisaCodigo(Convert.ToInt32(txtDesc.Text));
            }

            if (rdbNome.Checked)
            {
                pesquisaNome(Convert.ToString(txtDesc.Text));
            }
        }

        // pesquisar por código
        public void pesquisaCodigo(int cod)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select * from tbFuncionarios where cod_func = @codFunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32).Value = cod;

            comm.Connection = Conexao.obterConexao();

            // carregando dados para objeto de tabela
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Clear();
            ltbPesquisar.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();
            
        }

        public void pesquisaNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select * from tbFuncionarios where nome like @nomeFunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nomeFunc", MySqlDbType.VarChar, 100).Value = "%" + nome + "%";

            comm.Connection = Conexao.obterConexao();

            // carregando dados para objeto de tabela
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            
            ltbPesquisar.Items.Clear();
            while (DR.Read())
            {
                ltbPesquisar.Items.Add(DR.GetString(1));
            }
                      
            Conexao.fecharConexao();

        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbPesquisar.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item válido!",
                                "Mensagem do Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
            else
            {
                string nome = ltbPesquisar.SelectedItem.ToString();
                frmFuncionarios abrir = new frmFuncionarios(nome);
                abrir.Show();
                this.Hide();
            }                        
        }
    }
}
