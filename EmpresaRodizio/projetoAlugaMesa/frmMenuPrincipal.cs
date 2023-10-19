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
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        // acessa a janela de cadastro de mesas
        private void btnMesas_Click(object sender, EventArgs e)
        {
            frmCadastrarMesas open = new frmCadastrarMesas();
            open.Show();
            this.Hide();
        }

        // acessa a janela de alugar as mesas
        private void btnAlugarMesa_Click(object sender, EventArgs e)
        {
            frmAlugarMesa open = new frmAlugarMesa();
            open.Show();
            this.Hide();
        }
    }
}
