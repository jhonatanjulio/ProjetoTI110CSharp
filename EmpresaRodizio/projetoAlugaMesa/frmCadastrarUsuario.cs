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

            // habilitando botões padrões
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            lstPesquisar.Enabled = true;

            
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
    }
}
