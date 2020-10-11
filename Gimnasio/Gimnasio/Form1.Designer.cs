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
            this.tabControl_Tablas = new System.Windows.Forms.TabControl();
            this.tabPage_Empleado = new System.Windows.Forms.TabPage();
            this.tabPage_Cliente = new System.Windows.Forms.TabPage();
            this.tabPage_Suscripcion = new System.Windows.Forms.TabPage();
            this.tabPage_Clase = new System.Windows.Forms.TabPage();
            this.tabPage_Inscripcion = new System.Windows.Forms.TabPage();
            this.tabPage_Pago = new System.Windows.Forms.TabPage();
            this.tabPage_Horario = new System.Windows.Forms.TabPage();
            this.tabPageArticulo = new System.Windows.Forms.TabPage();
            this.btn_Eliminar_Articulo = new System.Windows.Forms.Button();
            this.btn_Modificar_Articulo = new System.Windows.Forms.Button();
            this.btn_Insertar_Articulo = new System.Windows.Forms.Button();
            this.dataGridView_Articulo = new System.Windows.Forms.DataGridView();
            this.tabPage_venta = new System.Windows.Forms.TabPage();
            this.tabPage_DetalleVenta = new System.Windows.Forms.TabPage();
            this.tabPage_Compra = new System.Windows.Forms.TabPage();
            this.tabPage_DetalleCompra = new System.Windows.Forms.TabPage();
            this.dataGridView_Horario = new System.Windows.Forms.DataGridView();
            this.btn_Insertar_Horario = new System.Windows.Forms.Button();
            this.btn_Modificar_Horario = new System.Windows.Forms.Button();
            this.btn_Eliminar_Horario = new System.Windows.Forms.Button();
            this.tabControl_Tablas.SuspendLayout();
            this.tabPage_Horario.SuspendLayout();
            this.tabPageArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Articulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Horario)).BeginInit();
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
            this.tabControl_Tablas.Location = new System.Drawing.Point(2, 3);
            this.tabControl_Tablas.Name = "tabControl_Tablas";
            this.tabControl_Tablas.SelectedIndex = 0;
            this.tabControl_Tablas.Size = new System.Drawing.Size(772, 498);
            this.tabControl_Tablas.TabIndex = 1;
            // 
            // tabPage_Empleado
            // 
            this.tabPage_Empleado.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Empleado.Name = "tabPage_Empleado";
            this.tabPage_Empleado.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Empleado.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Empleado.TabIndex = 0;
            this.tabPage_Empleado.Text = "Empleado";
            this.tabPage_Empleado.UseVisualStyleBackColor = true;
            // 
            // tabPage_Cliente
            // 
            this.tabPage_Cliente.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Cliente.Name = "tabPage_Cliente";
            this.tabPage_Cliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Cliente.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Cliente.TabIndex = 1;
            this.tabPage_Cliente.Text = "Cliente";
            this.tabPage_Cliente.UseVisualStyleBackColor = true;
            // 
            // tabPage_Suscripcion
            // 
            this.tabPage_Suscripcion.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Suscripcion.Name = "tabPage_Suscripcion";
            this.tabPage_Suscripcion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Suscripcion.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Suscripcion.TabIndex = 2;
            this.tabPage_Suscripcion.Text = "Suscripcion";
            this.tabPage_Suscripcion.UseVisualStyleBackColor = true;
            // 
            // tabPage_Clase
            // 
            this.tabPage_Clase.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Clase.Name = "tabPage_Clase";
            this.tabPage_Clase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Clase.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Clase.TabIndex = 3;
            this.tabPage_Clase.Text = "Clase";
            this.tabPage_Clase.UseVisualStyleBackColor = true;
            // 
            // tabPage_Inscripcion
            // 
            this.tabPage_Inscripcion.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Inscripcion.Name = "tabPage_Inscripcion";
            this.tabPage_Inscripcion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Inscripcion.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Inscripcion.TabIndex = 4;
            this.tabPage_Inscripcion.Text = "Inscripcion";
            this.tabPage_Inscripcion.UseVisualStyleBackColor = true;
            // 
            // tabPage_Pago
            // 
            this.tabPage_Pago.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Pago.Name = "tabPage_Pago";
            this.tabPage_Pago.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Pago.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Pago.TabIndex = 5;
            this.tabPage_Pago.Text = "Pago";
            this.tabPage_Pago.UseVisualStyleBackColor = true;
            // 
            // tabPage_Horario
            // 
            this.tabPage_Horario.Controls.Add(this.btn_Eliminar_Horario);
            this.tabPage_Horario.Controls.Add(this.btn_Modificar_Horario);
            this.tabPage_Horario.Controls.Add(this.btn_Insertar_Horario);
            this.tabPage_Horario.Controls.Add(this.dataGridView_Horario);
            this.tabPage_Horario.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Horario.Name = "tabPage_Horario";
            this.tabPage_Horario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Horario.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Horario.TabIndex = 6;
            this.tabPage_Horario.Text = "Horario";
            this.tabPage_Horario.UseVisualStyleBackColor = true;
            // 
            // tabPageArticulo
            // 
            this.tabPageArticulo.Controls.Add(this.btn_Eliminar_Articulo);
            this.tabPageArticulo.Controls.Add(this.btn_Modificar_Articulo);
            this.tabPageArticulo.Controls.Add(this.btn_Insertar_Articulo);
            this.tabPageArticulo.Controls.Add(this.dataGridView_Articulo);
            this.tabPageArticulo.Location = new System.Drawing.Point(4, 22);
            this.tabPageArticulo.Name = "tabPageArticulo";
            this.tabPageArticulo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArticulo.Size = new System.Drawing.Size(764, 472);
            this.tabPageArticulo.TabIndex = 7;
            this.tabPageArticulo.Text = "Articulo";
            this.tabPageArticulo.UseVisualStyleBackColor = true;
            // 
            // btn_Eliminar_Articulo
            // 
            this.btn_Eliminar_Articulo.Location = new System.Drawing.Point(656, 66);
            this.btn_Eliminar_Articulo.Name = "btn_Eliminar_Articulo";
            this.btn_Eliminar_Articulo.Size = new System.Drawing.Size(102, 23);
            this.btn_Eliminar_Articulo.TabIndex = 3;
            this.btn_Eliminar_Articulo.Text = "Eliminar";
            this.btn_Eliminar_Articulo.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Articulo.Click += new System.EventHandler(this.btn_Eliminar_Articulo_Click);
            // 
            // btn_Modificar_Articulo
            // 
            this.btn_Modificar_Articulo.Location = new System.Drawing.Point(656, 37);
            this.btn_Modificar_Articulo.Name = "btn_Modificar_Articulo";
            this.btn_Modificar_Articulo.Size = new System.Drawing.Size(102, 23);
            this.btn_Modificar_Articulo.TabIndex = 2;
            this.btn_Modificar_Articulo.Text = "Modificar";
            this.btn_Modificar_Articulo.UseVisualStyleBackColor = true;
            this.btn_Modificar_Articulo.Click += new System.EventHandler(this.btn_Modificar_Articulo_Click);
            // 
            // btn_Insertar_Articulo
            // 
            this.btn_Insertar_Articulo.Location = new System.Drawing.Point(656, 7);
            this.btn_Insertar_Articulo.Name = "btn_Insertar_Articulo";
            this.btn_Insertar_Articulo.Size = new System.Drawing.Size(102, 23);
            this.btn_Insertar_Articulo.TabIndex = 1;
            this.btn_Insertar_Articulo.Text = "Insertar";
            this.btn_Insertar_Articulo.UseVisualStyleBackColor = true;
            this.btn_Insertar_Articulo.Click += new System.EventHandler(this.btn_Insertar_Articulo_Click);
            // 
            // dataGridView_Articulo
            // 
            this.dataGridView_Articulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Articulo.Location = new System.Drawing.Point(7, 7);
            this.dataGridView_Articulo.Name = "dataGridView_Articulo";
            this.dataGridView_Articulo.Size = new System.Drawing.Size(642, 457);
            this.dataGridView_Articulo.TabIndex = 0;
            // 
            // tabPage_venta
            // 
            this.tabPage_venta.Location = new System.Drawing.Point(4, 22);
            this.tabPage_venta.Name = "tabPage_venta";
            this.tabPage_venta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_venta.Size = new System.Drawing.Size(764, 472);
            this.tabPage_venta.TabIndex = 8;
            this.tabPage_venta.Text = "Venta";
            this.tabPage_venta.UseVisualStyleBackColor = true;
            // 
            // tabPage_DetalleVenta
            // 
            this.tabPage_DetalleVenta.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DetalleVenta.Name = "tabPage_DetalleVenta";
            this.tabPage_DetalleVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DetalleVenta.Size = new System.Drawing.Size(764, 472);
            this.tabPage_DetalleVenta.TabIndex = 9;
            this.tabPage_DetalleVenta.Text = "DetalleVenta";
            this.tabPage_DetalleVenta.UseVisualStyleBackColor = true;
            // 
            // tabPage_Compra
            // 
            this.tabPage_Compra.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Compra.Name = "tabPage_Compra";
            this.tabPage_Compra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Compra.Size = new System.Drawing.Size(764, 472);
            this.tabPage_Compra.TabIndex = 10;
            this.tabPage_Compra.Text = "Compra";
            this.tabPage_Compra.UseVisualStyleBackColor = true;
            // 
            // tabPage_DetalleCompra
            // 
            this.tabPage_DetalleCompra.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DetalleCompra.Name = "tabPage_DetalleCompra";
            this.tabPage_DetalleCompra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DetalleCompra.Size = new System.Drawing.Size(764, 472);
            this.tabPage_DetalleCompra.TabIndex = 11;
            this.tabPage_DetalleCompra.Text = "DetalleCompra";
            this.tabPage_DetalleCompra.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Horario
            // 
            this.dataGridView_Horario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Horario.Location = new System.Drawing.Point(7, 7);
            this.dataGridView_Horario.Name = "dataGridView_Horario";
            this.dataGridView_Horario.Size = new System.Drawing.Size(642, 457);
            this.dataGridView_Horario.TabIndex = 0;
            // 
            // btn_Insertar_Horario
            // 
            this.btn_Insertar_Horario.Location = new System.Drawing.Point(656, 7);
            this.btn_Insertar_Horario.Name = "btn_Insertar_Horario";
            this.btn_Insertar_Horario.Size = new System.Drawing.Size(102, 23);
            this.btn_Insertar_Horario.TabIndex = 1;
            this.btn_Insertar_Horario.Text = "Insertar";
            this.btn_Insertar_Horario.UseVisualStyleBackColor = true;
            this.btn_Insertar_Horario.Click += new System.EventHandler(this.btn_Insertar_Horario_Click);
            // 
            // btn_Modificar_Horario
            // 
            this.btn_Modificar_Horario.Location = new System.Drawing.Point(656, 37);
            this.btn_Modificar_Horario.Name = "btn_Modificar_Horario";
            this.btn_Modificar_Horario.Size = new System.Drawing.Size(102, 23);
            this.btn_Modificar_Horario.TabIndex = 2;
            this.btn_Modificar_Horario.Text = "Modificar";
            this.btn_Modificar_Horario.UseVisualStyleBackColor = true;
            this.btn_Modificar_Horario.Click += new System.EventHandler(this.btn_Modificar_Horario_Click);
            // 
            // btn_Eliminar_Horario
            // 
            this.btn_Eliminar_Horario.Location = new System.Drawing.Point(656, 67);
            this.btn_Eliminar_Horario.Name = "btn_Eliminar_Horario";
            this.btn_Eliminar_Horario.Size = new System.Drawing.Size(102, 23);
            this.btn_Eliminar_Horario.TabIndex = 3;
            this.btn_Eliminar_Horario.Text = "Eliminar";
            this.btn_Eliminar_Horario.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Horario.Click += new System.EventHandler(this.btn_Eliminar_Horario_Click);
            // 
            // form_gimnasio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 501);
            this.Controls.Add(this.tabControl_Tablas);
            this.Name = "form_gimnasio";
            this.Text = "Formulario Gimnasio";
            this.Load += new System.EventHandler(this.form_gimnasio_Load);
            this.tabControl_Tablas.ResumeLayout(false);
            this.tabPage_Horario.ResumeLayout(false);
            this.tabPageArticulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Articulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Horario)).EndInit();
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
        private System.Windows.Forms.Button btn_Eliminar_Articulo;
        private System.Windows.Forms.Button btn_Modificar_Articulo;
        private System.Windows.Forms.Button btn_Insertar_Articulo;
        private System.Windows.Forms.DataGridView dataGridView_Articulo;
        private System.Windows.Forms.Button btn_Eliminar_Horario;
        private System.Windows.Forms.Button btn_Modificar_Horario;
        private System.Windows.Forms.Button btn_Insertar_Horario;
        private System.Windows.Forms.DataGridView dataGridView_Horario;
    }
}

