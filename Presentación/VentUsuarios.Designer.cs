namespace Presentación
{
    partial class VentUsuarios
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_usuarios = new System.Windows.Forms.DataGridView();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label_titulo = new System.Windows.Forms.Label();
            this.btn_seleccionar = new System.Windows.Forms.PictureBox();
            this.btn_cerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_seleccionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nombre";
            // 
            // dataGridView_usuarios
            // 
            this.dataGridView_usuarios.AllowUserToAddRows = false;
            this.dataGridView_usuarios.AllowUserToDeleteRows = false;
            this.dataGridView_usuarios.AllowUserToResizeColumns = false;
            this.dataGridView_usuarios.AllowUserToResizeRows = false;
            this.dataGridView_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Contraseña,
            this.Rol});
            this.dataGridView_usuarios.Location = new System.Drawing.Point(14, 198);
            this.dataGridView_usuarios.Name = "dataGridView_usuarios";
            this.dataGridView_usuarios.RowHeadersVisible = false;
            this.dataGridView_usuarios.RowHeadersWidth = 51;
            this.dataGridView_usuarios.RowTemplate.Height = 24;
            this.dataGridView_usuarios.Size = new System.Drawing.Size(520, 248);
            this.dataGridView_usuarios.TabIndex = 28;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(406, 142);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(110, 34);
            this.btn_buscar.TabIndex = 27;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(19, 145);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(363, 28);
            this.txt_nombre.TabIndex = 24;
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_titulo.Location = new System.Drawing.Point(110, 37);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(335, 38);
            this.label_titulo.TabIndex = 23;
            this.label_titulo.Text = "Ventana de busqueda";
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_seleccionar.Image = global::Presentación.Properties.Resources.accept_2550322;
            this.btn_seleccionar.Location = new System.Drawing.Point(474, 26);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(50, 49);
            this.btn_seleccionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_seleccionar.TabIndex = 33;
            this.btn_seleccionar.TabStop = false;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_cerrar.Image = global::Presentación.Properties.Resources.out_13705339;
            this.btn_cerrar.Location = new System.Drawing.Point(34, 26);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(50, 49);
            this.btn_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_cerrar.TabIndex = 32;
            this.btn_cerrar.TabStop = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(790, 101);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 125;
            // 
            // Contraseña
            // 
            this.Contraseña.HeaderText = "Contraseña";
            this.Contraseña.MinimumWidth = 6;
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Visible = false;
            this.Contraseña.Width = 125;
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.MinimumWidth = 6;
            this.Rol.Name = "Rol";
            this.Rol.Width = 125;
            // 
            // VentUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_usuarios);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "VentUsuarios";
            this.Text = "VentUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_seleccionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_seleccionar;
        private System.Windows.Forms.PictureBox btn_cerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_usuarios;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contraseña;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
    }
}