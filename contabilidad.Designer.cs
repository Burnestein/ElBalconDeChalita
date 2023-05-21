
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
            this.LblIngresosTotales = new System.Windows.Forms.Label();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.DgbIngresos = new System.Windows.Forms.DataGridView();
            this.idReservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblEgresosTotales = new System.Windows.Forms.Label();
            this.txtEgresos = new System.Windows.Forms.TextBox();
            this.DgbEgresos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compañia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limpieza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGanancias = new System.Windows.Forms.TextBox();
            this.LblGananciasTotales = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DgbIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgbEgresos)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblIngresosTotales
            // 
            this.LblIngresosTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblIngresosTotales.AutoSize = true;
            this.LblIngresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIngresosTotales.Location = new System.Drawing.Point(319, 0);
            this.LblIngresosTotales.Name = "LblIngresosTotales";
            this.LblIngresosTotales.Size = new System.Drawing.Size(106, 29);
            this.LblIngresosTotales.TabIndex = 2;
            this.LblIngresosTotales.Text = "Ingresos";
            this.LblIngresosTotales.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblIngresosTotales.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIngresos
            // 
            this.txtIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIngresos.Location = new System.Drawing.Point(0, 33);
            this.txtIngresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.ReadOnly = true;
            this.txtIngresos.Size = new System.Drawing.Size(425, 23);
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
            this.DgbIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgbIngresos.Location = new System.Drawing.Point(0, 0);
            this.DgbIngresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgbIngresos.Name = "DgbIngresos";
            this.DgbIngresos.RowHeadersWidth = 51;
            this.DgbIngresos.Size = new System.Drawing.Size(496, 155);
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
            // LblEgresosTotales
            // 
            this.LblEgresosTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEgresosTotales.AutoSize = true;
            this.LblEgresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEgresosTotales.Location = new System.Drawing.Point(322, 0);
            this.LblEgresosTotales.Name = "LblEgresosTotales";
            this.LblEgresosTotales.Size = new System.Drawing.Size(103, 29);
            this.LblEgresosTotales.TabIndex = 2;
            this.LblEgresosTotales.Text = "Egresos";
            this.LblEgresosTotales.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEgresos
            // 
            this.txtEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEgresos.Location = new System.Drawing.Point(0, 33);
            this.txtEgresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.ReadOnly = true;
            this.txtEgresos.Size = new System.Drawing.Size(428, 23);
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
            this.DgbEgresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgbEgresos.Location = new System.Drawing.Point(0, 0);
            this.DgbEgresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgbEgresos.Name = "DgbEgresos";
            this.DgbEgresos.RowHeadersWidth = 51;
            this.DgbEgresos.Size = new System.Drawing.Size(496, 155);
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
            // txtGanancias
            // 
            this.txtGanancias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGanancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGanancias.Location = new System.Drawing.Point(0, 43);
            this.txtGanancias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGanancias.Name = "txtGanancias";
            this.txtGanancias.ReadOnly = true;
            this.txtGanancias.Size = new System.Drawing.Size(425, 45);
            this.txtGanancias.TabIndex = 1;
            this.txtGanancias.TextChanged += new System.EventHandler(this.txtGanancias_TextChanged);
            // 
            // LblGananciasTotales
            // 
            this.LblGananciasTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblGananciasTotales.AutoSize = true;
            this.LblGananciasTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGananciasTotales.Location = new System.Drawing.Point(332, 0);
            this.LblGananciasTotales.Name = "LblGananciasTotales";
            this.LblGananciasTotales.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblGananciasTotales.Size = new System.Drawing.Size(93, 39);
            this.LblGananciasTotales.TabIndex = 0;
            this.LblGananciasTotales.Text = "Total";
            this.LblGananciasTotales.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "INGRESOS Y EGRESOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 431F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 484);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgbIngresos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 155);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DgbEgresos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(496, 155);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(496, 156);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.LblIngresosTotales);
            this.panel5.Controls.Add(this.txtIngresos);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(505, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(425, 155);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LblEgresosTotales);
            this.panel6.Controls.Add(this.txtEgresos);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(505, 164);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(425, 155);
            this.panel6.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtGanancias);
            this.panel7.Controls.Add(this.LblGananciasTotales);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(505, 325);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(425, 156);
            this.panel7.TabIndex = 5;
            // 
            // contabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "contabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.contabilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgbIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgbEgresos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
    }
}