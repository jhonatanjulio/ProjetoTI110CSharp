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
    public partial class frmCadastrarMesas : Form
    {
        public frmCadastrarMesas()
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
            txtIdMesa.Enabled = false;
            txtQtdeCadeiras.Enabled = false;

            rdbDisponivel.Enabled = false;
            rdbIndisponivel.Enabled = false;

            // habilitando botões padrões
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
        }

        // habilitar campos botão novo
        public void enableFieldsNew()
        {
            // habilitando botões
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e radio button
            txtIdMesa.Enabled = true;
            txtQtdeCadeiras.Enabled = true;

            rdbDisponivel.Enabled = true;
            rdbIndisponivel.Enabled = true;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;

            btnCadastrar.Focus();
        }

        // habilitar campos botão pesquisar (FICOU DE ALTERAR)
        public void enableFieldsResearch()
        {
            // habilitando botões
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e radio button
            txtIdMesa.Enabled = true;
            txtQtdeCadeiras.Enabled = true;

            rdbDisponivel.Enabled = true;
            rdbIndisponivel.Enabled = true;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;

            btnCadastrar.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtIdMesa.Clear();
            txtQtdeCadeiras.Clear();

            rdbDisponivel.Checked = false;
            rdbIndisponivel.Checked = false;

            txtIdMesa.Focus();
        }

        //click botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal open = new frmMenuPrincipal();
            open.Show();
            this.Hide();
        }

        //click botão novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            enableFieldsNew();
        }

        //click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }
    }
}
