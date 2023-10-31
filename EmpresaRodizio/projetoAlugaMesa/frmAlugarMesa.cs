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
    public partial class frmAlugarMesa : Form
    {
        public frmAlugarMesa()
        {
            InitializeComponent();
            disableFields();
        }

        // desabilitar campos
        public void disableFields()
        {
            // desabilitando botões
            btnAlugar.Enabled = false;
            btnLiberar.Enabled = false;
            btnLimpar.Enabled = false;

            // desabilitando campos
            txtCliente.Enabled = false;
            txtIdMesa.Enabled = false;
            txtStatus.Enabled = false;
            dtpDataEntrada.Enabled = false;
            dtpDataEntrada.Format = DateTimePickerFormat.Custom;
            dtpDataEntrada.CustomFormat = " ";

            // habilitando botões padrões
            btnPesquisar.Enabled = true;
            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;
            lstPesquisar.Enabled = true;
        }

        // habilitar campos botão pesquisar quando mesa estiver disponivel
        public void enableFieldsResearchAvailabe()
        {
            // habilitando botões
            btnAlugar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos
            txtCliente.Enabled = true;
            txtIdMesa.Enabled = false;
            txtStatus.Enabled = false;
            dtpDataEntrada.Enabled = true;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;

            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;

            txtCliente.Focus();
        }

        // habilitar campos botão pesquisar quando mesa estiver indisponivel
        public void enableFieldsResearchUnavailabe()
        {
            // habilitando botões
            btnLiberar.Enabled = true;
            btnLimpar.Enabled = true;

            // habilitando campos
            txtCliente.Enabled = false;
            txtIdMesa.Enabled = false;
            txtStatus.Enabled = false;
            dtpDataEntrada.Format = DateTimePickerFormat.Short;

            rdbDisponiveis.Enabled = true;
            rdbIndisponiveis.Enabled = true;

            btnLiberar.Focus();
        }

        //limpar campos
        public void clearFields()
        {
            txtCliente.Clear();
            txtIdMesa.Clear();
            txtStatus.Clear();

            txtCliente.Focus();

            lstPesquisar.Items.Clear();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal open = new frmMenuPrincipal();
            open.Show();
            this.Hide();
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

        //função sql pesquisar mesas alugadas
        public void researchRentedTables()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa, cliente, status, idAlug from tbAluguel where status = 'EM ANDAMENTO';";
            con.CommandType = CommandType.Text;


            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            while (DR.Read())
            {
                lstPesquisar.Items.Add("Mesa: " + DR.GetValue(0).ToString() + " | " + "Cliente: " + DR.GetValue(1).ToString() + " | " + "Status: " + DR.GetValue(2) + ": " + DR.GetValue(3));
            }

            Connection.closeConnection();
        }

        //função sql alugar mesas
        public int registerRentedTable(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "insert into tbAluguel(cliente, idMesa) values (@cliente, @idMesa);";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@cliente", MySqlDbType.VarChar, 20).Value = txtCliente.Text;
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();

            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            if (changeStatusTable(idMesa) != 1)
            {
                MessageBox.Show("Erro ao atualizar o status da mesa!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            return resp;
        }

        //função sql alterar o status da mesa alugada
        public int changeStatusTable(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbMesa set status = @status where idMesa = @idMesa;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = "INDISPONIVEL";
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();

            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();
            return resp;
        }

        //função sql para pesquisar todos os dados do registro e imprimir na textbox mesas disponiveis
        public void researchAvailableTablesPrintData(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idMesa, status from tbMesa where idMesa = @idMesa;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            txtIdMesa.Text = DR.GetValue(0).ToString();
            txtStatus.Text = DR.GetValue(1).ToString();
            txtStatus.Text = "DISPONIVEL";
            enableFieldsResearchAvailabe();

            Connection.closeConnection();
        }

        //função sql para pesquisar todos os dados do registro e imprimir na textbox mesas alugadas
        public void researchUnavailableTablesPrintData(int idAlug)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.idMesa, mesa.status, alu.dataAluguel from tbAluguel as alu inner join tbMesa as mesa on alu.idMesa = mesa.idMesa where alu.idAlug = @idAlug;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idAlug", MySqlDbType.Int32).Value = idAlug;

            con.Connection = Connection.getConnection();
            MySqlDataReader DR;
            DR = con.ExecuteReader();
            DR.Read();

            txtCliente.Text = DR.GetValue(0).ToString();
            txtIdMesa.Text = DR.GetValue(1).ToString();
            txtStatus.Text = DR.GetValue(2).ToString();
            enableFieldsResearchUnavailabe();
            dtpDataEntrada.Format = DateTimePickerFormat.Short;
            dtpDataEntrada.Text = DR.GetValue(3).ToString();
            

            Connection.closeConnection();
        }

        //função sql liberar alugueis
        public int toFreeRentedTables(int idMesa, int idAlug)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbAluguel set status = 'CONCLUIDO' where idAlug = @id;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@id", MySqlDbType.Int32).Value = idAlug;

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();

            if (toFreeTables(idMesa) != 1)
            {
                MessageBox.Show("Erro ao alterar o status da mesa!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            return resp;
        }

        //função sql liberar mesas alugadas
        public int toFreeTables(int idMesa)
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "update tbMesa set status = 'DISPONIVEL' where idMesa = @idMesa;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idMesa", MySqlDbType.Int32).Value = idMesa;

            con.Connection = Connection.getConnection();
            int resp = con.ExecuteNonQuery();

            Connection.closeConnection();
            return resp;
        }

        //click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbDisponiveis.Checked == true)
            {
                clearFields();
                disableFields();
                researchAvailableTables();
            }
            else if (rdbIndisponiveis.Checked == true)
            {
                clearFields();
                disableFields();
                researchRentedTables();
                txtStatus.Text = "INDISPONIVEL";
            }
            else
            {
                MessageBox.Show("Escolha pelo menos uma opção!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
            rdbDisponiveis.Checked = false;
            rdbIndisponiveis.Checked = false;
        }

        //click botão alugar
        private void btnAlugar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Equals(""))
            {
                MessageBox.Show("Insira o nome do cliente!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            else
            {
                if (registerRentedTable(Convert.ToInt32(txtIdMesa.Text)) == 1)
                {
                    clearFields();
                    disableFields();
                    MessageBox.Show("Mesa alugada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Erro ao alugar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        //click botão liberar
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            char[] between = { ' ' };
            string[] cod = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
            int rentedTable = Convert.ToInt32(cod[cod.Length - 1]);

            if (toFreeRentedTables(Convert.ToInt32(txtIdMesa.Text), rentedTable) == 1)
            {
                clearFields();
                disableFields();
                MessageBox.Show("Mesa liberada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Erro ao liberar a mesa!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void lstPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPesquisar.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item válido!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (rdbDisponiveis.Checked == true)
                {
                    //extraindo apenas o código da mesa a partir da listbox com split
                    char[] between = { ' ' };
                    string[] cod = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
                    int table = Convert.ToInt32(cod[1]);
                    researchAvailableTablesPrintData(table);
                }
                if (rdbIndisponiveis.Checked == true)
                {
                    //extraindo apenas o código da mesa a partir da listbox com split
                    char[] between = { ' ' };
                    string[] cod = lstPesquisar.SelectedItem.ToString().Split(between, StringSplitOptions.None);
                    int rentedTable = Convert.ToInt32(cod[cod.Length - 1]);
                    researchUnavailableTablesPrintData(rentedTable);
                }
            }
        }

        //ação click no radio button disponíveis (para caso troque a opção, a lista seja limpa para uma nova pesquisa)
        private void rdbDisponiveis_CheckedChanged(object sender, EventArgs e)
        {
            lstPesquisar.Items.Clear();
        }

        //ação click no radio button alugadas/indisponiveis (para caso troque a opção, a lista seja limpa para uma nova pesquisa)
        private void rdbIndisponiveis_CheckedChanged(object sender, EventArgs e)
        {
            lstPesquisar.Items.Clear();
        }
    }
}