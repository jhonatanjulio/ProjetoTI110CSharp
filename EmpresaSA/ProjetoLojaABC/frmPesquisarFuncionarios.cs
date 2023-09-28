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
            ltbPesquisar.Items.Add(txtDesc.Text);
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
