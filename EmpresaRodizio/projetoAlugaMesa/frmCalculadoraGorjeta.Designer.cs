
namespace projetoAlugaMesa
{
    partial class frmCalculadoraGorjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculadoraGorjeta));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblValorConta = new System.Windows.Forms.Label();
            this.lblAvaliacao = new System.Windows.Forms.Label();
            this.lblValorGorjeta = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorConta = new System.Windows.Forms.TextBox();
            this.txtValorGorjeta = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.cbbAvaliacao = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(178, 35);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(136, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Fechar Conta";
            // 
            // lblValorConta
            // 
            this.lblValorConta.AutoSize = true;
            this.lblValorConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorConta.Location = new System.Drawing.Point(20, 98);
            this.lblValorConta.Name = "lblValorConta";
            this.lblValorConta.Size = new System.Drawing.Size(120, 18);
            this.lblValorConta.TabIndex = 1;
            this.lblValorConta.Text = "Valor da Conta";
            // 
            // lblAvaliacao
            // 
            this.lblAvaliacao.AutoSize = true;
            this.lblAvaliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvaliacao.Location = new System.Drawing.Point(20, 155);
            this.lblAvaliacao.Name = "lblAvaliacao";
            this.lblAvaliacao.Size = new System.Drawing.Size(169, 18);
            this.lblAvaliacao.TabIndex = 2;
            this.lblAvaliacao.Text = "Qualidade do Serviço";
            // 
            // lblValorGorjeta
            // 
            this.lblValorGorjeta.AutoSize = true;
            this.lblValorGorjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorGorjeta.Location = new System.Drawing.Point(20, 317);
            this.lblValorGorjeta.Name = "lblValorGorjeta";
            this.lblValorGorjeta.Size = new System.Drawing.Size(131, 18);
            this.lblValorGorjeta.TabIndex = 3;
            this.lblValorGorjeta.Text = "Valor da Gorjeta";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(20, 373);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(90, 18);
            this.lblValorTotal.TabIndex = 4;
            this.lblValorTotal.Text = "Valor Total";
            // 
            // txtValorConta
            // 
            this.txtValorConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtValorConta.Location = new System.Drawing.Point(23, 119);
            this.txtValorConta.Name = "txtValorConta";
            this.txtValorConta.Size = new System.Drawing.Size(431, 24);
            this.txtValorConta.TabIndex = 5;
            // 
            // txtValorGorjeta
            // 
            this.txtValorGorjeta.Enabled = false;
            this.txtValorGorjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtValorGorjeta.Location = new System.Drawing.Point(23, 338);
            this.txtValorGorjeta.Name = "txtValorGorjeta";
            this.txtValorGorjeta.Size = new System.Drawing.Size(431, 24);
            this.txtValorGorjeta.TabIndex = 6;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtValorTotal.Location = new System.Drawing.Point(23, 394);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(431, 24);
            this.txtValorTotal.TabIndex = 7;
            // 
            // cbbAvaliacao
            // 
            this.cbbAvaliacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAvaliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cbbAvaliacao.FormattingEnabled = true;
            this.cbbAvaliacao.Items.AddRange(new object[] {
            "Excelente - 10%",
            "Ótimo - 8%",
            "Bom - 5%",
            "Ruim - 2%",
            "Sem gorjeta"});
            this.cbbAvaliacao.Location = new System.Drawing.Point(23, 176);
            this.cbbAvaliacao.Name = "cbbAvaliacao";
            this.cbbAvaliacao.Size = new System.Drawing.Size(431, 26);
            this.cbbAvaliacao.TabIndex = 8;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.Green;
            this.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcular.FlatAppearance.BorderSize = 0;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(23, 217);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(431, 35);
            this.btnCalcular.TabIndex = 9;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(23, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(431, 35);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Gray;
            this.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinuar.Enabled = false;
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.Location = new System.Drawing.Point(182, 441);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(128, 35);
            this.btnContinuar.TabIndex = 11;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // frmCalculadoraGorjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 509);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.cbbAvaliacao);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.txtValorGorjeta);
            this.Controls.Add(this.txtValorConta);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblValorGorjeta);
            this.Controls.Add(this.lblAvaliacao);
            this.Controls.Add(this.lblValorConta);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCalculadoraGorjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rodizio - Fechar Conta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblValorConta;
        private System.Windows.Forms.Label lblAvaliacao;
        private System.Windows.Forms.Label lblValorGorjeta;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtValorConta;
        private System.Windows.Forms.TextBox txtValorGorjeta;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.ComboBox cbbAvaliacao;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnContinuar;
    }
}