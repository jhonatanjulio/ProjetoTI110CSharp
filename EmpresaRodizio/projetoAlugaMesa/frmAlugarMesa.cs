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
    public partial class frmAlugarMesa : Form
    {
        public frmAlugarMesa()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal open = new frmMenuPrincipal();
            open.Show();
            this.Hide();
        }
    }
}
