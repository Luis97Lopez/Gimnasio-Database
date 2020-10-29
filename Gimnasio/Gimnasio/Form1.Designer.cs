namespace Gimnasio
{
    partial class form_gimnasio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_gimnasio));
            this.tabControl_Tablas = new System.Windows.Forms.TabControl();
            this.tabPage_Empleado = new System.Windows.Forms.TabPage();
            this.tabPage_Cliente = new System.Windows.Forms.TabPage();
            this.tabPage_Suscripcion = new System.Windows.Forms.TabPage();
            this.tabPage_Clase = new System.Windows.Forms.TabPage();
            this.tabPage_Inscripcion = new System.Windows.Forms.TabPage();
            this.tabPage_Pago = new System.Windows.Forms.TabPage();
            this.tabPage_Horario = new System.Windows.Forms.TabPage();
            this.tabPageArticulo = new System.Windows.Forms.TabPage();
            this.label_articulo_disponible = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_articulo_precio = new System.Windows.Forms.Label();
            this.label_articulo_nombre = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage_venta = new System.Windows.Forms.TabPage();
            this.tabPage_DetalleVenta = new System.Windows.Forms.TabPage();
            this.tabPage_Compra = new System.Windows.Forms.TabPage();
            this.tabPage_DetalleCompra = new System.Windows.Forms.TabPage();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Insertar = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl_Tablas.SuspendLayout();
            this.tabPageArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Tablas
            // 
            this.tabControl_Tablas.Controls.Add(this.tabPage_Empleado);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Cliente);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Suscripcion);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Clase);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Inscripcion);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Pago);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Horario);
            this.tabControl_Tablas.Controls.Add(this.tabPageArticulo);
            this.tabControl_Tablas.Controls.Add(this.tabPage_venta);
            this.tabControl_Tablas.Controls.Add(this.tabPage_DetalleVenta);
            this.tabControl_Tablas.Controls.Add(this.tabPage_Compra);
            this.tabControl_Tablas.Controls.Add(this.tabPage_DetalleCompra);
            this.tabControl_Tablas.Location = new System.Drawing.Point(29, 12);
            this.tabControl_Tablas.Name = "tabControl_Tablas";
            this.tabControl_Tablas.SelectedIndex = 0;
            this.tabControl_Tablas.Size = new System.Drawing.Size(791, 24);
            this.tabControl_Tablas.TabIndex = 1;
            this.tabControl_Tablas.SelectedIndexChanged += new System.EventHandler(this.tabControl_Tablas_SelectedIndexChanged);
            // 
            // tabPage_Empleado
            // 
            this.tabPage_Empleado.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Empleado.Name = "tabPage_Empleado";
            this.tabPage_Empleado.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Empleado.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Empleado.TabIndex = 0;
            this.tabPage_Empleado.Text = "Empleado";
            this.tabPage_Empleado.UseVisualStyleBackColor = true;
            // 
            // tabPage_Cliente
            // 
            this.tabPage_Cliente.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Cliente.Name = "tabPage_Cliente";
            this.tabPage_Cliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Cliente.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Cliente.TabIndex = 1;
            this.tabPage_Cliente.Text = "Cliente";
            this.tabPage_Cliente.UseVisualStyleBackColor = true;
            // 
            // tabPage_Suscripcion
            // 
            this.tabPage_Suscripcion.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Suscripcion.Name = "tabPage_Suscripcion";
            this.tabPage_Suscripcion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Suscripcion.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Suscripcion.TabIndex = 2;
            this.tabPage_Suscripcion.Text = "Suscripcion";
            this.tabPage_Suscripcion.UseVisualStyleBackColor = true;
            // 
            // tabPage_Clase
            // 
            this.tabPage_Clase.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Clase.Name = "tabPage_Clase";
            this.tabPage_Clase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Clase.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Clase.TabIndex = 3;
            this.tabPage_Clase.Text = "Clase";
            this.tabPage_Clase.UseVisualStyleBackColor = true;
            // 
            // tabPage_Inscripcion
            // 
            this.tabPage_Inscripcion.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Inscripcion.Name = "tabPage_Inscripcion";
            this.tabPage_Inscripcion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Inscripcion.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Inscripcion.TabIndex = 4;
            this.tabPage_Inscripcion.Text = "Inscripcion";
            this.tabPage_Inscripcion.UseVisualStyleBackColor = true;
            // 
            // tabPage_Pago
            // 
            this.tabPage_Pago.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Pago.Name = "tabPage_Pago";
            this.tabPage_Pago.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Pago.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Pago.TabIndex = 5;
            this.tabPage_Pago.Text = "Pago";
            this.tabPage_Pago.UseVisualStyleBackColor = true;
            // 
            // tabPage_Horario
            // 
            this.tabPage_Horario.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Horario.Name = "tabPage_Horario";
            this.tabPage_Horario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Horario.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Horario.TabIndex = 6;
            this.tabPage_Horario.Text = "Horario";
            this.tabPage_Horario.UseVisualStyleBackColor = true;
            // 
            // tabPageArticulo
            // 
            this.tabPageArticulo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPageArticulo.Controls.Add(this.label_articulo_disponible);
            this.tabPageArticulo.Controls.Add(this.comboBox1);
            this.tabPageArticulo.Controls.Add(this.label_articulo_precio);
            this.tabPageArticulo.Controls.Add(this.label_articulo_nombre);
            this.tabPageArticulo.Controls.Add(this.textBox2);
            this.tabPageArticulo.Controls.Add(this.textBox1);
            this.tabPageArticulo.Location = new System.Drawing.Point(4, 22);
            this.tabPageArticulo.Name = "tabPageArticulo";
            this.tabPageArticulo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArticulo.Size = new System.Drawing.Size(783, 0);
            this.tabPageArticulo.TabIndex = 7;
            this.tabPageArticulo.Text = "Articulo";
            // 
            // label_articulo_disponible
            // 
            this.label_articulo_disponible.AutoSize = true;
            this.label_articulo_disponible.Location = new System.Drawing.Point(28, 101);
            this.label_articulo_disponible.Name = "label_articulo_disponible";
            this.label_articulo_disponible.Size = new System.Drawing.Size(59, 13);
            this.label_articulo_disponible.TabIndex = 5;
            this.label_articulo_disponible.Text = "Disponible:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sí",
            "No"});
            this.comboBox1.Location = new System.Drawing.Point(93, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label_articulo_precio
            // 
            this.label_articulo_precio.AutoSize = true;
            this.label_articulo_precio.Location = new System.Drawing.Point(47, 66);
            this.label_articulo_precio.Name = "label_articulo_precio";
            this.label_articulo_precio.Size = new System.Drawing.Size(40, 13);
            this.label_articulo_precio.TabIndex = 3;
            this.label_articulo_precio.Text = "Precio:";
            // 
            // label_articulo_nombre
            // 
            this.label_articulo_nombre.AutoSize = true;
            this.label_articulo_nombre.Location = new System.Drawing.Point(40, 35);
            this.label_articulo_nombre.Name = "label_articulo_nombre";
            this.label_articulo_nombre.Size = new System.Drawing.Size(47, 13);
            this.label_articulo_nombre.TabIndex = 2;
            this.label_articulo_nombre.Text = "Nombre:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage_venta
            // 
            this.tabPage_venta.Location = new System.Drawing.Point(4, 22);
            this.tabPage_venta.Name = "tabPage_venta";
            this.tabPage_venta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_venta.Size = new System.Drawing.Size(783, 0);
            this.tabPage_venta.TabIndex = 8;
            this.tabPage_venta.Text = "Venta";
            this.tabPage_venta.UseVisualStyleBackColor = true;
            // 
            // tabPage_DetalleVenta
            // 
            this.tabPage_DetalleVenta.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DetalleVenta.Name = "tabPage_DetalleVenta";
            this.tabPage_DetalleVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DetalleVenta.Size = new System.Drawing.Size(783, 0);
            this.tabPage_DetalleVenta.TabIndex = 9;
            this.tabPage_DetalleVenta.Text = "DetalleVenta";
            this.tabPage_DetalleVenta.UseVisualStyleBackColor = true;
            // 
            // tabPage_Compra
            // 
            this.tabPage_Compra.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Compra.Name = "tabPage_Compra";
            this.tabPage_Compra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Compra.Size = new System.Drawing.Size(783, 0);
            this.tabPage_Compra.TabIndex = 10;
            this.tabPage_Compra.Text = "Compra";
            this.tabPage_Compra.UseVisualStyleBackColor = true;
            // 
            // tabPage_DetalleCompra
            // 
            this.tabPage_DetalleCompra.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DetalleCompra.Name = "tabPage_DetalleCompra";
            this.tabPage_DetalleCompra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DetalleCompra.Size = new System.Drawing.Size(783, 0);
            this.tabPage_DetalleCompra.TabIndex = 11;
            this.tabPage_DetalleCompra.Text = "DetalleCompra";
            this.tabPage_DetalleCompra.UseVisualStyleBackColor = true;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(621, 55);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(158, 23);
            this.btn_Eliminar.TabIndex = 3;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(356, 55);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(158, 23);
            this.btn_Modificar.TabIndex = 2;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Insertar
            // 
            this.btn_Insertar.Location = new System.Drawing.Point(71, 55);
            this.btn_Insertar.Name = "btn_Insertar";
            this.btn_Insertar.Size = new System.Drawing.Size(158, 23);
            this.btn_Insertar.TabIndex = 1;
            this.btn_Insertar.Text = "Insertar";
            this.btn_Insertar.UseVisualStyleBackColor = true;
            this.btn_Insertar.Click += new System.EventHandler(this.btn_Insertar_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(33, 108);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(787, 333);
            this.dataGridView.TabIndex = 2;
            // 
            // form_gimnasio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 475);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Insertar);
            this.Controls.Add(this.tabControl_Tablas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_gimnasio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario Gimnasio";
            this.Load += new System.EventHandler(this.form_gimnasio_Load);
            this.tabControl_Tablas.ResumeLayout(false);
            this.tabPageArticulo.ResumeLayout(false);
            this.tabPageArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl_Tablas;
        private System.Windows.Forms.TabPage tabPage_Empleado;
        private System.Windows.Forms.TabPage tabPage_Cliente;
        private System.Windows.Forms.TabPage tabPage_Suscripcion;
        private System.Windows.Forms.TabPage tabPage_Clase;
        private System.Windows.Forms.TabPage tabPage_Inscripcion;
        private System.Windows.Forms.TabPage tabPage_Pago;
        private System.Windows.Forms.TabPage tabPage_Horario;
        private System.Windows.Forms.TabPage tabPageArticulo;
        private System.Windows.Forms.TabPage tabPage_venta;
        private System.Windows.Forms.TabPage tabPage_DetalleVenta;
        private System.Windows.Forms.TabPage tabPage_Compra;
        private System.Windows.Forms.TabPage tabPage_DetalleCompra;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Insertar;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label_articulo_disponible;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_articulo_precio;
        private System.Windows.Forms.Label label_articulo_nombre;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

