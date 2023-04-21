
namespace El_Balcon_de_Chalita
{
    partial class busquedaclientes
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
            this.dgvBuscCliente = new System.Windows.Forms.DataGridView();
            this.btnbuscAcpt = new System.Windows.Forms.Button();
            this.btnBuscCanc = new System.Windows.Forms.Button();
            this.lblBuscSelec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBuscCliente
            // 
            this.dgvBuscCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscCliente.Location = new System.Drawing.Point(12, 69);
            this.dgvBuscCliente.Name = "dgvBuscCliente";
            this.dgvBuscCliente.RowHeadersWidth = 51;
            this.dgvBuscCliente.RowTemplate.Height = 24;
            this.dgvBuscCliente.Size = new System.Drawing.Size(596, 369);
            this.dgvBuscCliente.TabIndex = 0;
            // 
            // btnbuscAcpt
            // 
            this.btnbuscAcpt.Location = new System.Drawing.Point(628, 362);
            this.btnbuscAcpt.Name = "btnbuscAcpt";
            this.btnbuscAcpt.Size = new System.Drawing.Size(160, 36);
            this.btnbuscAcpt.TabIndex = 1;
            this.btnbuscAcpt.Text = "Aceptar";
            this.btnbuscAcpt.UseVisualStyleBackColor = true;
            // 
            // btnBuscCanc
            // 
            this.btnBuscCanc.Location = new System.Drawing.Point(628, 404);
            this.btnBuscCanc.Name = "btnBuscCanc";
            this.btnBuscCanc.Size = new System.Drawing.Size(160, 33);
            this.btnBuscCanc.TabIndex = 2;
            this.btnBuscCanc.Text = "Cancelar";
            this.btnBuscCanc.UseVisualStyleBackColor = true;
            this.btnBuscCanc.Click += new System.EventHandler(this.btnBuscCanc_Click);
            // 
            // lblBuscSelec
            // 
            this.lblBuscSelec.AutoSize = true;
            this.lblBuscSelec.Location = new System.Drawing.Point(12, 27);
            this.lblBuscSelec.Name = "lblBuscSelec";
            this.lblBuscSelec.Size = new System.Drawing.Size(163, 17);
            this.lblBuscSelec.TabIndex = 3;
            this.lblBuscSelec.Text = "Seleccione un elemento:";
            // 
            // busquedaclientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.lblBuscSelec);
            this.Controls.Add(this.btnBuscCanc);
            this.Controls.Add(this.btnbuscAcpt);
            this.Controls.Add(this.dgvBuscCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "busquedaclientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "busquedaclientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuscCliente;
        private System.Windows.Forms.Button btnbuscAcpt;
        private System.Windows.Forms.Button btnBuscCanc;
        private System.Windows.Forms.Label lblBuscSelec;
    }
}