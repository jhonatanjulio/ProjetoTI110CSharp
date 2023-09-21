// biblioteca do csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLojaABC
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //frmMenuPrincipal abrir = new frmMenuPrincipal();
            //abrir.Show();
            //this.Hide();

            //declaração de variáveis
            string userName, userPass;

            //inicializar as variáveis
            userName = txtUsuario.Text;
            userPass = txtSenha.Text;

            if (userName.Equals("senac") && userPass.Equals("senac"))
            {
                frmMenuPrincipal abrir = new frmMenuPrincipal();
                abrir.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Usuário ou senha inválidos!", 
                                "Mensagem do Sistema", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error, 
                                MessageBoxDefaultButton.Button1);
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.Focus();
            }
        }
    }
}
