
namespace El_Balcon_de_Chalita
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usuario = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PbxCerrar = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCerrar)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(435, 191);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(269, 20);
            this.usuario.TabIndex = 0;
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(435, 277);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(269, 20);
            this.contraseña.TabIndex = 2;
            this.contraseña.TextChanged += new System.EventHandler(this.contraseña_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña :";
            // 
            // btnAcceder
            // 
            this.btnAcceder.BackColor = System.Drawing.Color.Chocolate;
            this.btnAcceder.FlatAppearance.BorderSize = 0;
            this.btnAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceder.ForeColor = System.Drawing.Color.White;
            this.btnAcceder.Location = new System.Drawing.Point(492, 336);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(137, 54);
            this.btnAcceder.TabIndex = 6;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.UseVisualStyleBackColor = false;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(252, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login de Contabilidad";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            // 
            // PbxCerrar
            // 
            this.PbxCerrar.Image = ((System.Drawing.Image)(resources.GetObject("PbxCerrar.Image")));
            this.PbxCerrar.Location = new System.Drawing.Point(733, 2);
            this.PbxCerrar.Name = "PbxCerrar";
            this.PbxCerrar.Size = new System.Drawing.Size(20, 20);
            this.PbxCerrar.TabIndex = 9;
            this.PbxCerrar.TabStop = false;
            this.PbxCerrar.Click += new System.EventHandler(this.PbxCerrar_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Chocolate;
            this.panelHeader.Controls.Add(this.PbxCerrar);
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(754, 66);
            this.panelHeader.TabIndex = 8;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 453);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 520);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxCerrar)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PbxCerrar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}