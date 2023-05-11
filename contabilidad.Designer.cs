
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TbcContabilidad.SuspendLayout();
            this.TpgIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgbIngresos)).BeginInit();
            this.TpgEgresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgbEgresos)).BeginInit();
            this.TpgGanancias.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcContabilidad
            // 
            this.TbcContabilidad.Controls.Add(this.TpgIngresos);
            this.TbcContabilidad.Controls.Add(this.TpgEgresos);
            this.TbcContabilidad.Controls.Add(this.TpgGanancias);
            this.TbcContabilidad.ItemSize = new System.Drawing.Size(100, 35);
            this.TbcContabilidad.Location = new System.Drawing.Point(14, 77);
            this.TbcContabilidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbcContabilidad.Name = "TbcContabilidad";
            this.TbcContabilidad.SelectedIndex = 0;
            this.TbcContabilidad.Size = new System.Drawing.Size(912, 476);
            this.TbcContabilidad.TabIndex = 0;
            // 
            // TpgIngresos
            // 
            this.TpgIngresos.BackColor = System.Drawing.Color.White;
            this.TpgIngresos.Controls.Add(this.LblIngresosTotales);
            this.TpgIngresos.Controls.Add(this.txtIngresos);
            this.TpgIngresos.Controls.Add(this.DgbIngresos);
            this.TpgIngresos.Location = new System.Drawing.Point(4, 39);
            this.TpgIngresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TpgIngresos.Name = "TpgIngresos";
            this.TpgIngresos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TpgIngresos.Size = new System.Drawing.Size(904, 433);
            this.TpgIngresos.TabIndex = 0;
            this.TpgIngresos.Text = "Ingresos";
            this.TpgIngresos.Click += new System.EventHandler(this.Ingresos_Click);
            // 
            // LblIngresosTotales
            // 
            this.LblIngresosTotales.AutoSize = true;
            this.LblIngresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIngresosTotales.Location = new System.Drawing.Point(357, 37);
            this.LblIngresosTotales.Name = "LblIngresosTotales";
            this.LblIngresosTotales.Size = new System.Drawing.Size(193, 29);
            this.LblIngresosTotales.TabIndex = 2;
            this.LblIngresosTotales.Text = "Ingresos Totales";
            this.LblIngresosTotales.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIngresos
            // 
            this.txtIngresos.Location = new System.Drawing.Point(304, 82);
            this.txtIngresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(263, 23);
            this.txtIngresos.TabIndex = 1;
            // 
            // DgbIngresos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgbIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgbIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgbIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReservacion,
            this.Ingreso});
            this.DgbIngresos.Location = new System.Drawing.Point(293, 138);
            this.DgbIngresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgbIngresos.Name = "DgbIngresos";
            this.DgbIngresos.RowHeadersWidth = 51;
            this.DgbIngresos.Size = new System.Drawing.Size(301, 149);
            this.DgbIngresos.TabIndex = 0;
            this.DgbIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgbIngresos_CellContentClick);
            // 
            // idReservacion
            // 
            this.idReservacion.HeaderText = "IdReserva";
            this.idReservacion.MinimumWidth = 6;
            this.idReservacion.Name = "idReservacion";
            this.idReservacion.Width = 125;
            // 
            // Ingreso
            // 
            this.Ingreso.HeaderText = "Ingreso de la Reserva";
            this.Ingreso.MinimumWidth = 6;
            this.Ingreso.Name = "Ingreso";
            this.Ingreso.Width = 125;
            // 
            // TpgEgresos
            // 
            this.TpgEgresos.BackColor = System.Drawing.Color.White;
            this.TpgEgresos.Controls.Add(this.LblEgresosTotales);
            this.TpgEgresos.Controls.Add(this.txtEgresos);
            this.TpgEgresos.Controls.Add(this.DgbEgresos);
            this.TpgEgresos.Location = new System.Drawing.Point(4, 39);
            this.TpgEgresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TpgEgresos.Name = "TpgEgresos";
            this.TpgEgresos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TpgEgresos.Size = new System.Drawing.Size(904, 433);
            this.TpgEgresos.TabIndex = 1;
            this.TpgEgresos.Text = "Egresos";
            // 
            // LblEgresosTotales
            // 
            this.LblEgresosTotales.AutoSize = true;
            this.LblEgresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEgresosTotales.Location = new System.Drawing.Point(380, 26);
            this.LblEgresosTotales.Name = "LblEgresosTotales";
            this.LblEgresosTotales.Size = new System.Drawing.Size(190, 29);
            this.LblEgresosTotales.TabIndex = 2;
            this.LblEgresosTotales.Text = "Egresos Totales";
            // 
            // txtEgresos
            // 
            this.txtEgresos.Location = new System.Drawing.Point(361, 74);
            this.txtEgresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.Size = new System.Drawing.Size(165, 23);
            this.txtEgresos.TabIndex = 1;
            // 
            // DgbEgresos
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgbEgresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgbEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgbEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.compañia,
            this.porcentaje,
            this.Gasto,
            this.limpieza});
            this.DgbEgresos.Location = new System.Drawing.Point(122, 119);
            this.DgbEgresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgbEgresos.Name = "DgbEgresos";
            this.DgbEgresos.RowHeadersWidth = 51;
            this.DgbEgresos.Size = new System.Drawing.Size(681, 185);
            this.DgbEgresos.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id Reserva";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // compañia
            // 
            this.compañia.HeaderText = "Compañia Afiliada";
            this.compañia.MinimumWidth = 6;
            this.compañia.Name = "compañia";
            this.compañia.Width = 125;
            // 
            // porcentaje
            // 
            this.porcentaje.HeaderText = "% de Ganancias de la Compañia";
            this.porcentaje.MinimumWidth = 6;
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Width = 125;
            // 
            // Gasto
            // 
            this.Gasto.HeaderText = "Gasto";
            this.Gasto.MinimumWidth = 6;
            this.Gasto.Name = "Gasto";
            this.Gasto.Width = 125;
            // 
            // limpieza
            // 
            this.limpieza.HeaderText = "Gastos de Limpieza";
            this.limpieza.MinimumWidth = 6;
            this.limpieza.Name = "limpieza";
            this.limpieza.Width = 125;
            // 
            // TpgGanancias
            // 
            this.TpgGanancias.BackColor = System.Drawing.Color.White;
            this.TpgGanancias.Controls.Add(this.txtGanancias);
            this.TpgGanancias.Controls.Add(this.LblGananciasTotales);
            this.TpgGanancias.Location = new System.Drawing.Point(4, 39);
            this.TpgGanancias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TpgGanancias.Name = "TpgGanancias";
            this.TpgGanancias.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TpgGanancias.Size = new System.Drawing.Size(904, 433);
            this.TpgGanancias.TabIndex = 2;
            this.TpgGanancias.Text = "Ganancias";
            // 
            // txtGanancias
            // 
            this.txtGanancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGanancias.Location = new System.Drawing.Point(314, 183);
            this.txtGanancias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGanancias.Name = "txtGanancias";
            this.txtGanancias.Size = new System.Drawing.Size(261, 45);
            this.txtGanancias.TabIndex = 1;
            // 
            // LblGananciasTotales
            // 
            this.LblGananciasTotales.AutoSize = true;
            this.LblGananciasTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGananciasTotales.Location = new System.Drawing.Point(319, 114);
            this.LblGananciasTotales.Name = "LblGananciasTotales";
            this.LblGananciasTotales.Size = new System.Drawing.Size(301, 39);
            this.LblGananciasTotales.TabIndex = 0;
            this.LblGananciasTotales.Text = "Ganancias Totales";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chocolate;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 70);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(383, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONTABILIDAD";
            // 
            // contabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TbcContabilidad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "contabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtGanancias;
        private System.Windows.Forms.Label LblGananciasTotales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn compañia;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn limpieza;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}