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
    public partial class frmAutenticacao : Form
    {
        public static int idLoggedEmployee = 0;

        public frmAutenticacao()
        {
            InitializeComponent();
        }


        //autenticar
        public void validateAuth()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select * from tbUsuario where usuario = @usuario and senha = @senha;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@usuario", MySqlDbType.VarChar, 20).Value = txtUsuario.Text;
            con.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            if (DR.HasRows)
            {
                idLoggedEmployee = Convert.ToInt32(DR.GetString("idGarcom"));
                frmMenuPrincipal open = new frmMenuPrincipal();
                open.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            Connection.closeConnection();

        }

        //ação click botão entrar
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            validateAuth();
        }

        //ação click enter
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validateAuth();
            }
        }
    }
}
