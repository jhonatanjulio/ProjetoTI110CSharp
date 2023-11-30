
namespace projetoAlugaMesa
{
    partial class frmHistoricoReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoricoReservas));
            this.gpbPesquisar = new System.Windows.Forms.GroupBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblIdGarcom = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lstPesquisa = new System.Windows.Forms.ListBox();
            this.cbbGarcom = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.chbFuncionario = new System.Windows.Forms.CheckBox();
            this.chbDataReserva = new System.Windows.Forms.CheckBox();
            this.chbNome = new System.Windows.Forms.CheckBox();
            this.btnTodas = new System.Windows.Forms.Button();
            this.gpbPesquisar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPesquisar
            // 
            this.gpbPesquisar.Controls.Add(this.btnTodas);
            this.gpbPesquisar.Controls.Add(this.btnVoltar);
            this.gpbPesquisar.Controls.Add(this.lblIdGarcom);
            this.gpbPesquisar.Controls.Add(this.btnLimpar);
            this.gpbPesquisar.Controls.Add(this.btnPesquisar);
            this.gpbPesquisar.Controls.Add(this.lstPesquisa);
            this.gpbPesquisar.Controls.Add(this.cbbGarcom);
            this.gpbPesquisar.Controls.Add(this.dtpData);
            this.gpbPesquisar.Controls.Add(this.txtNome);
            this.gpbPesquisar.Controls.Add(this.chbFuncionario);
            this.gpbPesquisar.Controls.Add(this.chbDataReserva);
            this.gpbPesquisar.Controls.Add(this.chbNome);
            this.gpbPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbPesquisar.Location = new System.Drawing.Point(3, 2);
            this.gpbPesquisar.Name = "gpbPesquisar";
            this.gpbPesquisar.Size = new System.Drawing.Size(779, 456);
            this.gpbPesquisar.TabIndex = 0;
            this.gpbPesquisar.TabStop = false;
            this.gpbPesquisar.Text = "Pesquisar reservas por:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(460, 397);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(127, 50);
            this.btnVoltar.TabIndex = 20;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblIdGarcom
            // 
            this.lblIdGarcom.AutoSize = true;
            this.lblIdGarcom.Location = new System.Drawing.Point(386, 65);
            this.lblIdGarcom.Name = "lblIdGarcom";
            this.lblIdGarcom.Size = new System.Drawing.Size(0, 18);
            this.lblIdGarcom.TabIndex = 20;
            this.lblIdGarcom.Visible = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(327, 397);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(127, 50);
            this.btnLimpar.TabIndex = 19;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(194, 397);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(127, 50);
            this.btnPesquisar.TabIndex = 18;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lstPesquisa
            // 
            this.lstPesquisa.FormattingEnabled = true;
            this.lstPesquisa.ItemHeight = 18;
            this.lstPesquisa.Location = new System.Drawing.Point(33, 150);
            this.lstPesquisa.Name = "lstPesquisa";
            this.lstPesquisa.Size = new System.Drawing.Size(693, 238);
            this.lstPesquisa.TabIndex = 9;
            // 
            // cbbGarcom
            // 
            this.cbbGarcom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGarcom.FormattingEnabled = true;
            this.cbbGarcom.Location = new System.Drawing.Point(211, 62);
            this.cbbGarcom.Name = "cbbGarcom";
            this.cbbGarcom.Size = new System.Drawing.Size(154, 26);
            this.cbbGarcom.TabIndex = 8;
            this.cbbGarcom.TextChanged += new System.EventHandler(this.cbbGarcom_TextChanged);
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(181, 92);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(111, 24);
            this.dtpData.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(181, 34);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(184, 24);
            this.txtNome.TabIndex = 4;
            // 
            // chbFuncionario
            // 
            this.chbFuncionario.AutoSize = true;
            this.chbFuncionario.Location = new System.Drawing.Point(33, 64);
            this.chbFuncionario.Name = "chbFuncionario";
            this.chbFuncionario.Size = new System.Drawing.Size(176, 22);
            this.chbFuncionario.TabIndex = 2;
            this.chbFuncionario.Text = "Garçom Responsável:";
            this.chbFuncionario.UseVisualStyleBackColor = true;
            this.chbFuncionario.CheckedChanged += new System.EventHandler(this.chbFuncionario_CheckedChanged);
            // 
            // chbDataReserva
            // 
            this.chbDataReserva.AutoSize = true;
            this.chbDataReserva.Location = new System.Drawing.Point(33, 94);
            this.chbDataReserva.Name = "chbDataReserva";
            this.chbDataReserva.Size = new System.Drawing.Size(141, 22);
            this.chbDataReserva.TabIndex = 1;
            this.chbDataReserva.Text = "Data da Reserva:";
            this.chbDataReserva.UseVisualStyleBackColor = true;
            this.chbDataReserva.CheckedChanged += new System.EventHandler(this.chbDataReserva_CheckedChanged);
            // 
            // chbNome
            // 
            this.chbNome.AutoSize = true;
            this.chbNome.Location = new System.Drawing.Point(33, 36);
            this.chbNome.Name = "chbNome";
            this.chbNome.Size = new System.Drawing.Size(142, 22);
            this.chbNome.TabIndex = 0;
            this.chbNome.Text = "Nome do Cliente:";
            this.chbNome.UseVisualStyleBackColor = true;
            this.chbNome.CheckedChanged += new System.EventHandler(this.chbNome_CheckedChanged);
            // 
            // btnTodas
            // 
            this.btnTodas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTodas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodas.Image = ((System.Drawing.Image)(resources.GetObject("btnTodas.Image")));
            this.btnTodas.Location = new System.Drawing.Point(599, 39);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(127, 77);
            this.btnTodas.TabIndex = 21;
            this.btnTodas.Text = "&Visualizar Todas Reservas";
            this.btnTodas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTodas.UseVisualStyleBackColor = false;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // frmHistoricoReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.gpbPesquisar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHistoricoReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rodízio - Histórico de Reservas";
            this.gpbPesquisar.ResumeLayout(false);
            this.gpbPesquisar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPesquisar;
        private System.Windows.Forms.CheckBox chbFuncionario;
        private System.Windows.Forms.CheckBox chbDataReserva;
        private System.Windows.Forms.CheckBox chbNome;
        private System.Windows.Forms.ComboBox cbbGarcom;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ListBox lstPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblIdGarcom;
        private System.Windows.Forms.Button btnVoltar;
        public System.Windows.Forms.Button btnTodas;
    }
}