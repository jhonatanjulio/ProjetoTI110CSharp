
namespace WebCam
{
    partial class Form1
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
            this.pctCapturaImagem = new System.Windows.Forms.PictureBox();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.cbbDispositivo = new System.Windows.Forms.ComboBox();
            this.sfdSalvaImagem = new System.Windows.Forms.SaveFileDialog();
            this.ofdAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.btnAbrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctCapturaImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // pctCapturaImagem
            // 
            this.pctCapturaImagem.Location = new System.Drawing.Point(77, 50);
            this.pctCapturaImagem.Name = "pctCapturaImagem";
            this.pctCapturaImagem.Size = new System.Drawing.Size(391, 275);
            this.pctCapturaImagem.TabIndex = 0;
            this.pctCapturaImagem.TabStop = false;
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.AutoSize = true;
            this.lblDispositivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDispositivo.Location = new System.Drawing.Point(74, 362);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(81, 18);
            this.lblDispositivo.TabIndex = 2;
            this.lblDispositivo.Text = "Dispositivo";
            // 
            // btnCapturar
            // 
            this.btnCapturar.Location = new System.Drawing.Point(502, 50);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(213, 69);
            this.btnCapturar.TabIndex = 3;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(502, 125);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(213, 69);
            this.btnLimpar.TabIndex = 4;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // cbbDispositivo
            // 
            this.cbbDispositivo.FormattingEnabled = true;
            this.cbbDispositivo.Location = new System.Drawing.Point(77, 383);
            this.cbbDispositivo.Name = "cbbDispositivo";
            this.cbbDispositivo.Size = new System.Drawing.Size(286, 21);
            this.cbbDispositivo.TabIndex = 1;
            // 
            // ofdAbrirArquivo
            // 
            this.ofdAbrirArquivo.FileName = "openFileDialog1";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(548, 224);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(119, 34);
            this.btnAbrir.TabIndex = 5;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.cbbDispositivo);
            this.Controls.Add(this.pctCapturaImagem);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctCapturaImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctCapturaImagem;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ComboBox cbbDispositivo;
        private System.Windows.Forms.SaveFileDialog sfdSalvaImagem;
        private System.Windows.Forms.OpenFileDialog ofdAbrirArquivo;
        private System.Windows.Forms.Button btnAbrir;
    }
}

