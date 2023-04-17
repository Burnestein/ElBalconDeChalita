
namespace El_Balcon_de_Chalita
{
    partial class contabilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contabilidad));
            this.TbcContabilidad = new System.Windows.Forms.TabControl();
            this.TpgIngresos = new System.Windows.Forms.TabPage();
            this.LblIngresosTotales = new System.Windows.Forms.Label();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.DgbIngresos = new System.Windows.Forms.DataGridView();
            this.idReservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpgEgresos = new System.Windows.Forms.TabPage();
            this.LblEgresosTotales = new System.Windows.Forms.Label();
            this.txtEgresos = new System.Windows.Forms.TextBox();
            this.DgbEgresos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compañia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limpieza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpgGanancias = new System.Windows.Forms.TabPage();
            this.txtGanancias = new System.Windows.Forms.TextBox();
            this.LblGananciasTotales = new System.Windows.Forms.Label();
            this.TbcContabilidad.SuspendLayout();
            this.TpgIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgbIngresos)).BeginInit();
            this.TpgEgresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgbEgresos)).BeginInit();
            this.TpgGanancias.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcContabilidad
            // 
            this.TbcContabilidad.Controls.Add(this.TpgIngresos);
            this.TbcContabilidad.Controls.Add(this.TpgEgresos);
            this.TbcContabilidad.Controls.Add(this.TpgGanancias);
            this.TbcContabilidad.ItemSize = new System.Drawing.Size(100, 35);
            this.TbcContabilidad.Location = new System.Drawing.Point(12, 12);
            this.TbcContabilidad.Name = "TbcContabilidad";
            this.TbcContabilidad.SelectedIndex = 0;
            this.TbcContabilidad.Size = new System.Drawing.Size(782, 437);
            this.TbcContabilidad.TabIndex = 0;
            // 
            // TpgIngresos
            // 
            this.TpgIngresos.Controls.Add(this.LblIngresosTotales);
            this.TpgIngresos.Controls.Add(this.txtIngresos);
            this.TpgIngresos.Controls.Add(this.DgbIngresos);
            this.TpgIngresos.Location = new System.Drawing.Point(4, 39);
            this.TpgIngresos.Name = "TpgIngresos";
            this.TpgIngresos.Padding = new System.Windows.Forms.Padding(3);
            this.TpgIngresos.Size = new System.Drawing.Size(774, 394);
            this.TpgIngresos.TabIndex = 0;
            this.TpgIngresos.Text = "Ingresos";
            this.TpgIngresos.UseVisualStyleBackColor = true;
            this.TpgIngresos.Click += new System.EventHandler(this.Ingresos_Click);
            // 
            // LblIngresosTotales
            // 
            this.LblIngresosTotales.AutoSize = true;
            this.LblIngresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIngresosTotales.Location = new System.Drawing.Point(298, 104);
            this.LblIngresosTotales.Name = "LblIngresosTotales";
            this.LblIngresosTotales.Size = new System.Drawing.Size(148, 24);
            this.LblIngresosTotales.TabIndex = 2;
            this.LblIngresosTotales.Text = "Ingresos Totales";
            this.LblIngresosTotales.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIngresos
            // 
            this.txtIngresos.Location = new System.Drawing.Point(296, 145);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(226, 20);
            this.txtIngresos.TabIndex = 1;
            // 
            // DgbIngresos
            // 
            this.DgbIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgbIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReservacion,
            this.Ingreso});
            this.DgbIngresos.Location = new System.Drawing.Point(15, 44);
            this.DgbIngresos.Name = "DgbIngresos";
            this.DgbIngresos.Size = new System.Drawing.Size(244, 121);
            this.DgbIngresos.TabIndex = 0;
            this.DgbIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgbIngresos_CellContentClick);
            // 
            // idReservacion
            // 
            this.idReservacion.HeaderText = "IdReserva";
            this.idReservacion.Name = "idReservacion";
            // 
            // Ingreso
            // 
            this.Ingreso.HeaderText = "Ingreso de la Reserva";
            this.Ingreso.Name = "Ingreso";
            // 
            // TpgEgresos
            // 
            this.TpgEgresos.Controls.Add(this.LblEgresosTotales);
            this.TpgEgresos.Controls.Add(this.txtEgresos);
            this.TpgEgresos.Controls.Add(this.DgbEgresos);
            this.TpgEgresos.Location = new System.Drawing.Point(4, 39);
            this.TpgEgresos.Name = "TpgEgresos";
            this.TpgEgresos.Padding = new System.Windows.Forms.Padding(3);
            this.TpgEgresos.Size = new System.Drawing.Size(774, 394);
            this.TpgEgresos.TabIndex = 1;
            this.TpgEgresos.Text = "Egresos";
            this.TpgEgresos.UseVisualStyleBackColor = true;
            // 
            // LblEgresosTotales
            // 
            this.LblEgresosTotales.AutoSize = true;
            this.LblEgresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEgresosTotales.Location = new System.Drawing.Point(16, 242);
            this.LblEgresosTotales.Name = "LblEgresosTotales";
            this.LblEgresosTotales.Size = new System.Drawing.Size(146, 24);
            this.LblEgresosTotales.TabIndex = 2;
            this.LblEgresosTotales.Text = "Egresos Totales";
            // 
            // txtEgresos
            // 
            this.txtEgresos.Location = new System.Drawing.Point(20, 280);
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.Size = new System.Drawing.Size(142, 20);
            this.txtEgresos.TabIndex = 1;
            // 
            // DgbEgresos
            // 
            this.DgbEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgbEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.compañia,
            this.porcentaje,
            this.Gasto,
            this.limpieza});
            this.DgbEgresos.Location = new System.Drawing.Point(20, 20);
            this.DgbEgresos.Name = "DgbEgresos";
            this.DgbEgresos.Size = new System.Drawing.Size(544, 150);
            this.DgbEgresos.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id Reserva";
            this.id.Name = "id";
            // 
            // compañia
            // 
            this.compañia.HeaderText = "Compañia Afiliada";
            this.compañia.Name = "compañia";
            // 
            // porcentaje
            // 
            this.porcentaje.HeaderText = "Porcentaje de Ganancias de la Compañia";
            this.porcentaje.Name = "porcentaje";
            // 
            // Gasto
            // 
            this.Gasto.HeaderText = "Gasto";
            this.Gasto.Name = "Gasto";
            // 
            // limpieza
            // 
            this.limpieza.HeaderText = "Gastos de Limpieza";
            this.limpieza.Name = "limpieza";
            // 
            // TpgGanancias
            // 
            this.TpgGanancias.Controls.Add(this.txtGanancias);
            this.TpgGanancias.Controls.Add(this.LblGananciasTotales);
            this.TpgGanancias.Location = new System.Drawing.Point(4, 39);
            this.TpgGanancias.Name = "TpgGanancias";
            this.TpgGanancias.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGanancias.Size = new System.Drawing.Size(774, 394);
            this.TpgGanancias.TabIndex = 2;
            this.TpgGanancias.Text = "Ganancias";
            this.TpgGanancias.UseVisualStyleBackColor = true;
            // 
            // txtGanancias
            // 
            this.txtGanancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGanancias.Location = new System.Drawing.Point(228, 190);
            this.txtGanancias.Name = "txtGanancias";
            this.txtGanancias.Size = new System.Drawing.Size(224, 38);
            this.txtGanancias.TabIndex = 1;
            // 
            // LblGananciasTotales
            // 
            this.LblGananciasTotales.AutoSize = true;
            this.LblGananciasTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGananciasTotales.Location = new System.Drawing.Point(222, 145);
            this.LblGananciasTotales.Name = "LblGananciasTotales";
            this.LblGananciasTotales.Size = new System.Drawing.Size(241, 31);
            this.LblGananciasTotales.TabIndex = 0;
            this.LblGananciasTotales.Text = "Ganancias Totales";
            // 
            // contabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TbcContabilidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "contabilidad";
            this.Text = "contabilidad";
            this.Load += new System.EventHandler(this.contabilidad_Load);
            this.TbcContabilidad.ResumeLayout(false);
            this.TpgIngresos.ResumeLayout(false);
            this.TpgIngresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgbIngresos)).EndInit();
            this.TpgEgresos.ResumeLayout(false);
            this.TpgEgresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgbEgresos)).EndInit();
            this.TpgGanancias.ResumeLayout(false);
            this.TpgGanancias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcContabilidad;
        private System.Windows.Forms.TabPage TpgIngresos;
        private System.Windows.Forms.TabPage TpgEgresos;
        private System.Windows.Forms.TabPage TpgGanancias;
        private System.Windows.Forms.Label LblIngresosTotales;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.DataGridView DgbIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingreso;
        private System.Windows.Forms.Label LblEgresosTotales;
        private System.Windows.Forms.TextBox txtEgresos;
        private System.Windows.Forms.DataGridView DgbEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn compañia;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn limpieza;
        private System.Windows.Forms.TextBox txtGanancias;
        private System.Windows.Forms.Label LblGananciasTotales;
    }
}