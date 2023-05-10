
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
            this.btnBuscAcept = new System.Windows.Forms.Button();
            this.btnBuscCanc = new System.Windows.Forms.Button();
            this.lblBuscCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBuscCliente
            // 
            this.dgvBuscCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscCliente.Location = new System.Drawing.Point(18, 89);
            this.dgvBuscCliente.Name = "dgvBuscCliente";
            this.dgvBuscCliente.RowHeadersWidth = 51;
            this.dgvBuscCliente.RowTemplate.Height = 24;
            this.dgvBuscCliente.Size = new System.Drawing.Size(684, 449);
            this.dgvBuscCliente.TabIndex = 0;
            // 
            // btnBuscAcept
            // 
            this.btnBuscAcept.Location = new System.Drawing.Point(710, 440);
            this.btnBuscAcept.Name = "btnBuscAcept";
            this.btnBuscAcept.Size = new System.Drawing.Size(177, 48);
            this.btnBuscAcept.TabIndex = 1;
            this.btnBuscAcept.Text = "Aceptar";
            this.btnBuscAcept.UseVisualStyleBackColor = true;
            this.btnBuscAcept.Click += new System.EventHandler(this.btnBuscAcept_Click);
            // 
            // btnBuscCanc
            // 
            this.btnBuscCanc.Location = new System.Drawing.Point(710, 495);
            this.btnBuscCanc.Name = "btnBuscCanc";
            this.btnBuscCanc.Size = new System.Drawing.Size(177, 43);
            this.btnBuscCanc.TabIndex = 2;
            this.btnBuscCanc.Text = "Cancelar";
            this.btnBuscCanc.UseVisualStyleBackColor = true;
            this.btnBuscCanc.Click += new System.EventHandler(this.btnBuscCanc_Click);
            // 
            // lblBuscCliente
            // 
            this.lblBuscCliente.AutoSize = true;
            this.lblBuscCliente.Location = new System.Drawing.Point(15, 34);
            this.lblBuscCliente.Name = "lblBuscCliente";
            this.lblBuscCliente.Size = new System.Drawing.Size(191, 20);
            this.lblBuscCliente.TabIndex = 3;
            this.lblBuscCliente.Text = "Seleccione un elemento:";
            // 
            // busquedaclientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 563);
            this.ControlBox = false;
            this.Controls.Add(this.lblBuscCliente);
            this.Controls.Add(this.btnBuscCanc);
            this.Controls.Add(this.btnBuscAcept);
            this.Controls.Add(this.dgvBuscCliente);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.Button btnBuscAcept;
        private System.Windows.Forms.Button btnBuscCanc;
        private System.Windows.Forms.Label lblBuscCliente;
    }
}