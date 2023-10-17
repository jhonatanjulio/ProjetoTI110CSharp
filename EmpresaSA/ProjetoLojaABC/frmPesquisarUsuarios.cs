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
    public partial class frmPesquisarUsuarios : Form
    {
        public frmPesquisarUsuarios()
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
            rdbNomeUsu.Checked = false;
        }
        // habilitar campos
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
            rdbNomeUsu.Checked = false;
            txtDesc.Focus();

            //limpar a lista:
            ltbPesquisar.Items.Clear();
        }

        // pesquisar por nome de usuario
        public void pesquisaUsuario(string usuario)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select * from tbUsuarios where usuario like @usuario;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@usuario", MySqlDbType.VarChar, 100).Value = "%" + usuario + "%";

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

        // pesquisar por código
        public void pesquisaCodigo(int cod)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select * from tbUsuarios where cod_usu = @codUsu;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = cod;

            comm.Connection = Conexao.obterConexao();

            // carregando dados para objeto de tabela
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Clear();
            ltbPesquisar.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();

        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdbNomeUsu_CheckedChanged(object sender, EventArgs e)
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

            if (rdbNomeUsu.Checked)
            {
                pesquisaUsuario(Convert.ToString(txtDesc.Text));
            }
        }
    }
}
