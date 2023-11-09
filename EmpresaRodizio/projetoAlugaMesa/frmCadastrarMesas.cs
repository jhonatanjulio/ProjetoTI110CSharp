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
            dtpDataEntrada.Enabled = false;
            dtpDataEntrada.Format = DateTimePickerFormat.Custom;
            dtpDataEntrada.CustomFormat = " ";
            txtStatus.Enabled = false;

            // habilitando botões padrões
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;
            lstPesquisar.Enabled = true;
        }

        // habilitar campos botão novo
        public void enableFieldsNew()
        {
            // habilitando botões
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos e botando status padrao
            txtQtdeCadeiras.Enabled = true;
            txtStatus.Text = "DISPONIVEL";
            dtpDataEntrada.Enabled = true;

            dtpDataEntrada.Format = DateTimePickerFormat.Short;
            dtpDataEntrada.Value = DateTime.Today;

            // desabilitando o botão de pesquisar
            btnPesquisar.Enabled = false;
            rdbDisponiveis.Enabled = false;
            rdbIndisponiveis.Enabled = false;
            lstPesquisar.Enabled = false;

            txtQtdeCadeiras.Focus();
        }

        // habilitar campos botão pesquisar disponivel
        public void enableFieldsResearchAvailable()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;

            // habilitando campos
            txtQtdeCadeiras.Enabled = true;

            txtStatus.Text = "DISPONIVEL";

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        // habilitar campos botão pesquisar indisponivel
        public void enableFieldsResearchUnavailable()
        {
            // habilitando botões
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;

            // habilitando campos
            txtQtdeCadeiras.Enabled = false;

            txtStatus.Text = "INDISPONIVEL";

            // desabilitando o botão novo
            btnNovo.Enabled = false;

            btnAlterar.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtIdMesa.Clear();
            txtQtdeCadeiras.Clear();

            txtStatus.Clear();

            rdbDisponiveis.Checked = false;
            rdbIndisponiveis.Checked = false;

            lstPesquisar.Items.Clear();

            txtIdMesa.Focus();
        }

        // função sql cadastrar mesas
        public int registerTables(int qtdCad)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "insert into tbMesa(qtdCad, status, dataEntrada) values (@qtdCad, @status, @dataEntrada);";
            con.CommandType = CommandType.Text;
            string status = "DISPONIVEL";

            con.Parameters.Clear();
            con.Parameters.Add("@qtdCad", MySqlDbType.Int32).Value = qtdCad;
            con.Parameters.Add("@status", MySqlDbType.VarChar, 15).Value = status;
            con.Parameters.Add("@dataEntrada", MySqlDbType.Date).Value = Convert.ToDateTime(dtpDataEntrada.Text);

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        //função sql pesquisar mesas disponíveis
        public void researchAvailableTables()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa, qtdCad from tbMesa where status = 'DISPONIVEL';";
            con.CommandType = CommandType.Text;


            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            while (DR.Read())
            {
                lstPesquisar.Items.Add("Mesa: " + DR.GetValue(0).ToString() + " | " + DR.GetValue(1).ToString() + " cadeiras");
            }

            Connection.closeConnection();
        }

        //função sql pesquisa mesas indisponíveis
        public void researchUnavailableTables()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa, qtdCad from tbMesa where status = 'INDISPONIVEL';";
            con.CommandType = CommandType.Text;


            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            while (DR.Read())
            {
                lstPesquisar.Items.Add("Mesa: " + DR.GetValue(0).ToString() + " | " + DR.GetValue(1).ToString() + " cadeiras");
            }

            Connection.closeConnection();
        }

        //função sql para pesquisar todos os dados do registro e imprimir na textbox
        public void researchTablesPrintData(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select * from tbMesa where idMesa = @idMesa;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            txtIdMesa.Text = DR.GetValue(0).ToString();
            txtQtdeCadeiras.Text = DR.GetValue(1).ToString();
            dtpDataEntrada.Text = DR.GetValue(2).ToString();

            if (DR.GetValue(2).ToString().Equals("DISPONIVEL"))
            {
                txtStatus.Text = "DISPONIVEL";
                enableFieldsResearchAvailable();
            }
            else
            {
                enableFieldsResearchUnavailable();
                txtStatus.Text = "INDISPONIVEL";
            }

            Connection.closeConnection();
        }

        //função sql para retornar o próximo código disponível no auto_increment da tabela
        public void nextTableId()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa+1 from tbMesa order by idMesa desc;";
            con.CommandType = CommandType.Text;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            try
            {
                txtIdMesa.Text = DR.GetValue(0).ToString();
            }
            catch (Exception)
            {
                txtIdMesa.Text = "1";
            }
            

            Connection.closeConnection();
        }

        //função sql alterar mesa
        public int changeTable(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbMesa set qtdCad = @qtdCad where idMesa = @idMesa;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@qtdCad", MySqlDbType.Int32).Value = Convert.ToInt32(txtQtdeCadeiras.Text);
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
        }

        //função sql deletar mesa
        public int deleteTable(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "delete from tbMesa where idMesa = @idMesa;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            return resp;
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
            clearFields();
            enableFieldsNew();
            nextTableId();
        }

        //click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
        }

        //click botão cadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (registerTables(Convert.ToInt32(txtQtdeCadeiras.Text)) == 1)
                {
                    clearFields();
                    disableFields();
                    MessageBox.Show("Mesa cadastrada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Preencha todos os campos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbDisponiveis.Checked == true)
            {
                clearFields();
                rdbDisponiveis.Checked = true;
                disableFields();
                researchAvailableTables();
            }
            else if (rdbIndisponiveis.Checked == true)
            {
                clearFields();
                rdbIndisponiveis.Checked = true;
                disableFields();
                researchUnavailableTables();
            }
            else
            {
                MessageBox.Show("Escolha pelo menos uma opção!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //click botão alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatus.Text.Equals("INDISPONIVEL"))
                {
                    MessageBox.Show("Não é possível alterar uma mesa indisponível!\nLibere-a antes na janela de aluguel!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DialogResult resp = MessageBox.Show("Você realmente deseja alterar esta mesa? (Não é possível voltar atrás com esta operação).", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    if (resp == DialogResult.Yes)
                    {
                        if (changeTable(Convert.ToInt32(txtIdMesa.Text)) == 1)
                        {
                            MessageBox.Show("Mesa alterada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            clearFields();
                            disableFields();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insira a quantidade de cadeiras!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //click botão excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text.Equals("INDISPONIVEL"))
            {
                MessageBox.Show("Não é possível excluir uma mesa indisponível!\nLibere-a antes na janela de aluguel!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DialogResult resp = MessageBox.Show("Você realmente deseja excluir esta mesa? (Não é possível voltar atrás com esta operação).", "Mensagem do Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                if (resp == DialogResult.Yes)
                {
                    if (deleteTable(Convert.ToInt32(txtIdMesa.Text)) == 1)
                    {
                        MessageBox.Show("Mesa exclúida com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        clearFields();
                        disableFields();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        // ação de click na listbox (seja em item ou fora)
        private void lstPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPesquisar.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item válido!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                //extraindo apenas o código da mesa a partir da listbox com split
                char[] between = { ' ' };
                string[] cod = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
                int table = Convert.ToInt32(cod[1]);
                txtQtdeCadeiras.Focus();

                researchTablesPrintData(table);
            }
        }

        //ação click no radio button disponíveis (para caso troque a opção, a lista seja limpa para uma nova pesquisa)
        private void rdbDisponiveis_CheckedChanged(object sender, EventArgs e)
        {
            lstPesquisar.Items.Clear();
        }

        //ação click no radio button indisponíveis (para caso troque a opção, a lista seja limpa para uma nova pesquisa)
        private void rdbIndisponiveis_CheckedChanged(object sender, EventArgs e)
        {
            lstPesquisar.Items.Clear();
        }
    }
}
