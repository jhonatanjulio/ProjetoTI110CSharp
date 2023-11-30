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
    public partial class frmHistoricoReservas : Form
    {
        public frmHistoricoReservas()
        {
            InitializeComponent();
            disableFields();
            researchAllEmployees();
        }

        //função desabilitar campos
        public void disableFields()
        {
            txtNome.Enabled = false;
            cbbGarcom.Enabled = false;
            dtpData.Enabled = false;
            dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.CustomFormat = " ";
        }

        //função limpar campos
        public void clearFields()
        {
            txtNome.Clear();
            cbbGarcom.Items.Clear();
            dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.CustomFormat = " ";

            chbNome.Checked = false;
            chbFuncionario.Checked = false;
            chbDataReserva.Checked = false;

            lstPesquisa.Items.Clear();
        }

        private void chbNome_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNome.Checked)
            {
                txtNome.Enabled = true;
                txtNome.Focus();
            }
            else
            {
                txtNome.Enabled = false;
            }
        }

        private void chbFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFuncionario.Checked)
            {
                cbbGarcom.Enabled = true;
                cbbGarcom.Focus();
            }
            else
            {
                cbbGarcom.Enabled = false;
            }
        }

        private void chbDataReserva_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDataReserva.Checked)
            {
                dtpData.Enabled = true;
                dtpData.Format = DateTimePickerFormat.Short;
                dtpData.Value = DateTime.Today;
                dtpData.Focus();
            }
            else
            {
                dtpData.Enabled = false;
                dtpData.Format = DateTimePickerFormat.Custom;
                dtpData.CustomFormat = " ";
            }
        }
        //função sql pesquisar todos os garçons para a combo box
        public void researchAllEmployees()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select nome from tbGarcom;";
            con.CommandType = CommandType.Text;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            cbbGarcom.Items.Clear();
            while (DR.Read())
            {
                cbbGarcom.Items.Add(DR.GetValue(0));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar código do garçom selecionado
        public void researchIdEmployee()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select idGarcom from tbGarcom where nome = @nome;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = cbbGarcom.SelectedItem.ToString();

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            DR.Read();
            lblIdGarcom.Text = DR.GetValue(0).ToString();

            Connection.closeConnection();
        }

        //função sql pesquisar com todos os três filtros (nome, data e garçom responsável)
        public void researchAllFilters()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.cliente like @nome AND alu.dataAluguel = @dataAluguel AND alu.idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = "%" + txtNome.Text + "%";
            con.Parameters.Add("@dataAluguel", MySqlDbType.Date).Value = Convert.ToDateTime(dtpData.Text);
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(lblIdGarcom.Text);

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {

                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$"+DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar dois filtros: nome + garçom
        public void researchFiltersNomeGarcom()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.cliente like @nome AND alu.idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = "%" + txtNome.Text + "%";
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(lblIdGarcom.Text);

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {

                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar dois filtros: garçom + data
        public void researchFiltersGarcomData()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.dataAluguel = @dataAluguel AND alu.idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@dataAluguel", MySqlDbType.Date).Value = Convert.ToDateTime(dtpData.Text);
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(lblIdGarcom.Text);

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {

                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar dois filtros: nome + data
        public void researchFiltersNomeData()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.cliente like @nome AND alu.dataAluguel = @dataAluguel";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = "%" + txtNome.Text + "%";
            con.Parameters.Add("@dataAluguel", MySqlDbType.Date).Value = Convert.ToDateTime(dtpData.Text);

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {

                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar filtro: nome
        public void researchFilterNome()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.cliente like @nome";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = "%" + txtNome.Text + "%";

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {

                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar filtro: garçom
        public void researchFilterGarcom()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.idGarcom = @idGarcom;";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@idGarcom", MySqlDbType.Int32).Value = Convert.ToInt32(lblIdGarcom.Text);

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {

                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar filtro: data
        public void researchFilterData()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom where alu.dataAluguel = @dataAluguel";
            con.CommandType = CommandType.Text;

            con.Parameters.Clear();
            con.Parameters.Add("@dataAluguel", MySqlDbType.Date).Value = Convert.ToDateTime(dtpData.Text);

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {
                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //função sql pesquisar todas reservas
        public void researchAll()
        {
            MySqlCommand con = new MySqlCommand();
            con.CommandText = "select alu.cliente, alu.dataAluguel, alu.valorConta, alu.gorjeta, alu.total, garc.nome, alu.status from tbAluguel as alu inner join tbGarcom as garc on alu.idGarcom = garc.idGarcom;";
            con.CommandType = CommandType.Text;

            con.Connection = Connection.getConnection();

            MySqlDataReader DR;
            DR = con.ExecuteReader();

            lstPesquisa.Items.Clear();
            while (DR.Read())
            {
                lstPesquisa.Items.Add(DR.GetString("cliente") + " | " + Convert.ToDateTime(DR.GetString("dataAluguel")).ToShortDateString() + " | " + "R$" + DR.GetString("valorConta") + " | " + "R$" + DR.GetString("gorjeta") + " | " + "R$" + DR.GetString("total") + " | " + DR.GetString("nome") + " | " + DR.GetString("status"));
            }

            Connection.closeConnection();
        }

        //ação click botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
            disableFields();
            researchAllEmployees();
        }

        //ação click botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (chbNome.Checked && chbFuncionario.Checked && chbDataReserva.Checked)
            {
                if (txtNome.Text.Equals("") || cbbGarcom.SelectedItem == null)
                {
                    MessageBox.Show("Preencha todos os campos antes de pesquisar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    researchAllFilters();
                }
            }
            else if (chbNome.Checked && chbFuncionario.Checked)
            {
                if (txtNome.Text.Equals("") || cbbGarcom.SelectedItem == null)
                {
                    MessageBox.Show("Preencha todos os campos antes de pesquisar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    researchFiltersNomeGarcom();
                }
            }
            else if (chbFuncionario.Checked && chbDataReserva.Checked)
            {
                if (cbbGarcom.SelectedItem == null)
                {
                    MessageBox.Show("Preencha todos os campos antes de pesquisar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else 
                {
                    researchFiltersGarcomData();
                }
            }
            else if (chbNome.Checked && chbDataReserva.Checked)
            {
                if (txtNome.Text.Equals(""))
                {
                    MessageBox.Show("Preencha todos os campos antes de pesquisar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    researchFiltersNomeData();
                }
            }
            else if (chbNome.Checked)
            {
                if (txtNome.Text.Equals(""))
                {
                    MessageBox.Show("Preencha todos os campos antes de pesquisar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    researchFilterNome();
                }
            }
            else if (chbFuncionario.Checked)
            {
                if (cbbGarcom.SelectedItem == null)
                {
                    MessageBox.Show("Preencha todos os campos antes de pesquisar!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    researchFilterGarcom();
                }
            }
            else if (chbDataReserva.Checked)
            {
                researchFilterData();
            }
            else
            {
                MessageBox.Show("Selecione pelo menos uma opção!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        //evento troca de texto
        private void cbbGarcom_TextChanged(object sender, EventArgs e)
        {
            researchIdEmployee();
        }

        //ação click botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmAlugarMesa open = new frmAlugarMesa();
            open.Show();
            this.Hide();
        }

        //ação click botão todas reservas
        private void btnTodas_Click(object sender, EventArgs e)
        {
            researchAll();
        }
    }
}
