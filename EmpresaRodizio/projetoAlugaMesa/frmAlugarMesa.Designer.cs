
namespace projetoAlugaMesa
{
    partial class frmAlugarMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlugarMesa));
            this.gpbPesquisar = new System.Windows.Forms.GroupBox();
            this.lstPesquisar = new System.Windows.Forms.ListBox();
            this.rdbIndisponiveis = new System.Windows.Forms.RadioButton();
            this.rdbDisponiveis = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.btnAlugar = new System.Windows.Forms.Button();
            this.lblIdMesa = new System.Windows.Forms.Label();
            this.txtIdMesa = new System.Windows.Forms.TextBox();
            this.dtpDataAluguel = new System.Windows.Forms.DateTimePicker();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.lblValorConta = new System.Windows.Forms.Label();
            this.txtValorConta = new System.Windows.Forms.TextBox();
            this.lblGorjeta = new System.Windows.Forms.Label();
            this.txtGorjeta = new System.Windows.Forms.TextBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.btnFecharConta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gpbPesquisar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPesquisar
            // 
            this.gpbPesquisar.Controls.Add(this.btnHistorico);
            this.gpbPesquisar.Controls.Add(this.lstPesquisar);
            this.gpbPesquisar.Controls.Add(this.rdbIndisponiveis);
            this.gpbPesquisar.Controls.Add(this.rdbDisponiveis);
            this.gpbPesquisar.Controls.Add(this.btnPesquisar);
            this.gpbPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbPesquisar.Location = new System.Drawing.Point(323, 18);
            this.gpbPesquisar.Name = "gpbPesquisar";
            this.gpbPesquisar.Size = new System.Drawing.Size(414, 361);
            this.gpbPesquisar.TabIndex = 24;
            this.gpbPesquisar.TabStop = false;
            this.gpbPesquisar.Text = "Pesquisar Mesas:";
            // 
            // lstPesquisar
            // 
            this.lstPesquisar.FormattingEnabled = true;
            this.lstPesquisar.ItemHeight = 20;
            this.lstPesquisar.Location = new System.Drawing.Point(6, 80);
            this.lstPesquisar.Name = "lstPesquisar";
            this.lstPesquisar.Size = new System.Drawing.Size(402, 184);
            this.lstPesquisar.TabIndex = 18;
            this.lstPesquisar.SelectedIndexChanged += new System.EventHandler(this.lstPesquisar_SelectedIndexChanged);
            // 
            // rdbIndisponiveis
            // 
            this.rdbIndisponiveis.AutoSize = true;
            this.rdbIndisponiveis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbIndisponiveis.Location = new System.Drawing.Point(233, 41);
            this.rdbIndisponiveis.Name = "rdbIndisponiveis";
            this.rdbIndisponiveis.Size = new System.Drawing.Size(94, 24);
            this.rdbIndisponiveis.TabIndex = 1;
            this.rdbIndisponiveis.TabStop = true;
            this.rdbIndisponiveis.Text = "Alugadas";
            this.rdbIndisponiveis.UseVisualStyleBackColor = true;
            this.rdbIndisponiveis.CheckedChanged += new System.EventHandler(this.rdbIndisponiveis_CheckedChanged);
            // 
            // rdbDisponiveis
            // 
            this.rdbDisponiveis.AutoSize = true;
            this.rdbDisponiveis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbDisponiveis.Location = new System.Drawing.Point(64, 41);
            this.rdbDisponiveis.Name = "rdbDisponiveis";
            this.rdbDisponiveis.Size = new System.Drawing.Size(107, 24);
            this.rdbDisponiveis.TabIndex = 0;
            this.rdbDisponiveis.TabStop = true;
            this.rdbDisponiveis.Text = "Disponíveis";
            this.rdbDisponiveis.UseVisualStyleBackColor = true;
            this.rdbDisponiveis.CheckedChanged += new System.EventHandler(this.rdbDisponiveis_CheckedChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(48, 287);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(127, 50);
            this.btnPesquisar.TabIndex = 17;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(50, 122);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 20);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Status da Mesa:";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtStatus.Location = new System.Drawing.Point(54, 145);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(171, 26);
            this.txtStatus.TabIndex = 22;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(50, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(130, 20);
            this.lblCliente.TabIndex = 21;
            this.lblCliente.Text = "Nome do Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCliente.Location = new System.Drawing.Point(54, 41);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(236, 26);
            this.txtCliente.TabIndex = 20;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(465, 399);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(91, 50);
            this.btnVoltar.TabIndex = 19;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(348, 399);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 50);
            this.btnLimpar.TabIndex = 18;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLiberar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiberar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberar.Image = ((System.Drawing.Image)(resources.GetObject("btnLiberar.Image")));
            this.btnLiberar.Location = new System.Drawing.Point(229, 399);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(100, 50);
            this.btnLiberar.TabIndex = 15;
            this.btnLiberar.Text = "&Liberar";
            this.btnLiberar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLiberar.UseVisualStyleBackColor = false;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnAlugar
            // 
            this.btnAlugar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAlugar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlugar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlugar.Image")));
            this.btnAlugar.Location = new System.Drawing.Point(111, 399);
            this.btnAlugar.Name = "btnAlugar";
            this.btnAlugar.Size = new System.Drawing.Size(99, 50);
            this.btnAlugar.TabIndex = 14;
            this.btnAlugar.Text = "&Alugar";
            this.btnAlugar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlugar.UseVisualStyleBackColor = false;
            this.btnAlugar.Click += new System.EventHandler(this.btnAlugar_Click);
            // 
            // lblIdMesa
            // 
            this.lblIdMesa.AutoSize = true;
            this.lblIdMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdMesa.Location = new System.Drawing.Point(50, 70);
            this.lblIdMesa.Name = "lblIdMesa";
            this.lblIdMesa.Size = new System.Drawing.Size(169, 20);
            this.lblIdMesa.TabIndex = 26;
            this.lblIdMesa.Text = "Identificação da Mesa:";
            // 
            // txtIdMesa
            // 
            this.txtIdMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdMesa.Location = new System.Drawing.Point(54, 93);
            this.txtIdMesa.Name = "txtIdMesa";
            this.txtIdMesa.Size = new System.Drawing.Size(127, 26);
            this.txtIdMesa.TabIndex = 25;
            // 
            // dtpDataAluguel
            // 
            this.dtpDataAluguel.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataAluguel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpDataAluguel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAluguel.Location = new System.Drawing.Point(54, 197);
            this.dtpDataAluguel.Name = "dtpDataAluguel";
            this.dtpDataAluguel.Size = new System.Drawing.Size(121, 26);
            this.dtpDataAluguel.TabIndex = 49;
            // 
            // lblDataEntrada
            // 
            this.lblDataEntrada.AutoSize = true;
            this.lblDataEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEntrada.Location = new System.Drawing.Point(50, 174);
            this.lblDataEntrada.Name = "lblDataEntrada";
            this.lblDataEntrada.Size = new System.Drawing.Size(133, 20);
            this.lblDataEntrada.TabIndex = 48;
            this.lblDataEntrada.Text = "Data da Reserva:";
            // 
            // lblValorConta
            // 
            this.lblValorConta.AutoSize = true;
            this.lblValorConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorConta.Location = new System.Drawing.Point(50, 226);
            this.lblValorConta.Name = "lblValorConta";
            this.lblValorConta.Size = new System.Drawing.Size(119, 20);
            this.lblValorConta.TabIndex = 51;
            this.lblValorConta.Text = "Valor da Conta:";
            // 
            // txtValorConta
            // 
            this.txtValorConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtValorConta.Location = new System.Drawing.Point(54, 249);
            this.txtValorConta.Name = "txtValorConta";
            this.txtValorConta.Size = new System.Drawing.Size(171, 26);
            this.txtValorConta.TabIndex = 50;
            this.txtValorConta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblGorjeta
            // 
            this.lblGorjeta.AutoSize = true;
            this.lblGorjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGorjeta.Location = new System.Drawing.Point(50, 278);
            this.lblGorjeta.Name = "lblGorjeta";
            this.lblGorjeta.Size = new System.Drawing.Size(129, 20);
            this.lblGorjeta.TabIndex = 53;
            this.lblGorjeta.Text = "Valor da Gorjeta:";
            // 
            // txtGorjeta
            // 
            this.txtGorjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGorjeta.Location = new System.Drawing.Point(54, 301);
            this.txtGorjeta.Name = "txtGorjeta";
            this.txtGorjeta.Size = new System.Drawing.Size(171, 26);
            this.txtGorjeta.TabIndex = 52;
            this.txtGorjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(50, 330);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(89, 20);
            this.lblValorTotal.TabIndex = 55;
            this.lblValorTotal.Text = "Valor Total:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtValorTotal.Location = new System.Drawing.Point(54, 353);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(171, 26);
            this.txtValorTotal.TabIndex = 54;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHistorico
            // 
            this.btnHistorico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorico.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorico.Image")));
            this.btnHistorico.Location = new System.Drawing.Point(226, 287);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(140, 50);
            this.btnHistorico.TabIndex = 19;
            this.btnHistorico.Text = "&Histórico de Reservas";
            this.btnHistorico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistorico.UseVisualStyleBackColor = false;
            // 
            // btnFecharConta
            // 
            this.btnFecharConta.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFecharConta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharConta.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharConta.Image")));
            this.btnFecharConta.Location = new System.Drawing.Point(573, 399);
            this.btnFecharConta.Name = "btnFecharConta";
            this.btnFecharConta.Size = new System.Drawing.Size(100, 50);
            this.btnFecharConta.TabIndex = 56;
            this.btnFecharConta.Text = "&Fechar Conta";
            this.btnFecharConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFecharConta.UseVisualStyleBackColor = false;
            this.btnFecharConta.Click += new System.EventHandler(this.btnFecharConta_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAlugarMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFecharConta);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.lblGorjeta);
            this.Controls.Add(this.txtGorjeta);
            this.Controls.Add(this.lblValorConta);
            this.Controls.Add(this.txtValorConta);
            this.Controls.Add(this.dtpDataAluguel);
            this.Controls.Add(this.lblDataEntrada);
            this.Controls.Add(this.lblIdMesa);
            this.Controls.Add(this.txtIdMesa);
            this.Controls.Add(this.gpbPesquisar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnAlugar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAlugarMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rodízio - Alugar Mesas";
            this.gpbPesquisar.ResumeLayout(false);
            this.gpbPesquisar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPesquisar;
        private System.Windows.Forms.RadioButton rdbIndisponiveis;
        private System.Windows.Forms.RadioButton rdbDisponiveis;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnLiberar;
        private System.Windows.Forms.Button btnAlugar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblIdMesa;
        private System.Windows.Forms.TextBox txtIdMesa;
        private System.Windows.Forms.ListBox lstPesquisar;
        private System.Windows.Forms.DateTimePicker dtpDataAluguel;
        private System.Windows.Forms.Label lblDataEntrada;
        private System.Windows.Forms.Label lblValorConta;
        private System.Windows.Forms.TextBox txtValorConta;
        private System.Windows.Forms.Label lblGorjeta;
        private System.Windows.Forms.TextBox txtGorjeta;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.Button btnFecharConta;
        private System.Windows.Forms.Button button1;
    }
}