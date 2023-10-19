
namespace projetoAlugaMesa
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.btnMesas = new System.Windows.Forms.Button();
            this.btnAlugarMesa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMesas
            // 
            this.btnMesas.BackColor = System.Drawing.Color.AliceBlue;
            this.btnMesas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMesas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesas.Image = ((System.Drawing.Image)(resources.GetObject("btnMesas.Image")));
            this.btnMesas.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMesas.Location = new System.Drawing.Point(128, 96);
            this.btnMesas.Name = "btnMesas";
            this.btnMesas.Size = new System.Drawing.Size(243, 271);
            this.btnMesas.TabIndex = 0;
            this.btnMesas.Text = "Cadastrar Mesas";
            this.btnMesas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMesas.UseVisualStyleBackColor = false;
            this.btnMesas.Click += new System.EventHandler(this.btnMesas_Click);
            // 
            // btnAlugarMesa
            // 
            this.btnAlugarMesa.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAlugarMesa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlugarMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlugarMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlugarMesa.Image = ((System.Drawing.Image)(resources.GetObject("btnAlugarMesa.Image")));
            this.btnAlugarMesa.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlugarMesa.Location = new System.Drawing.Point(406, 96);
            this.btnAlugarMesa.Name = "btnAlugarMesa";
            this.btnAlugarMesa.Size = new System.Drawing.Size(243, 271);
            this.btnAlugarMesa.TabIndex = 1;
            this.btnAlugarMesa.Text = "Alugar Mesas";
            this.btnAlugarMesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAlugarMesa.UseVisualStyleBackColor = false;
            this.btnAlugarMesa.Click += new System.EventHandler(this.btnAlugarMesa_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnAlugarMesa);
            this.Controls.Add(this.btnMesas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rodízio - Menu Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMesas;
        private System.Windows.Forms.Button btnAlugarMesa;
    }
}

