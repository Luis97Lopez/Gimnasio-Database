using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class form_gimnasio : Form
    {
        public form_gimnasio()
        {
            InitializeComponent();
        }


        // -------------------------- EVENTOS Y FUNCIONES DEL FORM --------------------------

        private void form_gimnasio_Load(object sender, EventArgs e)
        {
            // Se actualizan todos los grids de golpe
            actualiza_grid(tabControl_Tablas.SelectedTab.Text);
        }

        private void tabControl_Tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualiza_grid(tabControl_Tablas.SelectedTab.Text);
        }

        public void actualiza_grid(string tabla) // Actualiza la tabla con ese nombre
        {
            // Se abre la conexion con la base de datos
            SqlConnection connection = Conexion.Conectar();

            // Se crea la consulta para obtener la tabla de profesor
            //string query = "SELECT * FROM gimnasio." + tabla + ";";
            string query = get_query_actualiza_grid(tabla);

            // Se crea el comando y se ejecuta
            SqlCommand command = new SqlCommand(query, connection);

            // Se obtiene la informacion de la tabla a partir del comando
            SqlDataAdapter data = new SqlDataAdapter(command);

            // Se rellena una tabla de datos con la informacion de la consulta y se pasa al datagrid
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            dataGridView.DataSource = dataTable;
        }

        private void btn_Insertar_Click(object sender, EventArgs e)
        {
            //Checa si se encuentra en la pestaña ¨DetalleVenta¨ o ¨DetalleCompra¨
            if ((tabControl_Tablas.SelectedTab.Text != "DetalleVenta" && 
                tabControl_Tablas.SelectedTab.Text != "DetalleCompra") || 
                MessageBox.Show("Después de insertar, este registro no se podrá modificar o eliminar." +
                "\n\n¿Desea continuar?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // Se crea una lista de strings para el metodo inserta
                List<string> lista = new List<string>();
                // Se crea el formulario para insertar un nuevo registro en la Tabla que esté seleccionada
                Formulario form_agregar = new Formulario(tabControl_Tablas.SelectedTab.Text);
                form_agregar.Text = "Insertar " + tabControl_Tablas.SelectedTab.Text;
                form_agregar.ShowDialog();

                if (form_agregar.band_aceptar) // Si ya se hizo click en aceptar en el formulario
                {
                    actualiza_lista_de_datos_insertar(lista, form_agregar);

                    inserta_en_DB(lista);
                    actualiza_grid(tabControl_Tablas.SelectedTab.Text); // Actualiza

                    // Limpia y cierra el formulario
                    form_agregar.Dispose();
                }
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (tabControl_Tablas.SelectedTab.Text != "DetalleVenta" && tabControl_Tablas.SelectedTab.Text != "DetalleCompra")
            {
                // Se crea una lista de strings para el metodo inserta
                List<string> lista = new List<string>();
                // Se crea el formulario para modificar una tupla
                Formulario form_modificar;

                // Primero checa que la fila entera esté seleccionada (en este caso selectedcells debe de ser 4 contando el id)
                if (dataGridView.SelectedRows.Count > 0)
                {
                    form_modificar = new Formulario(tabControl_Tablas.SelectedTab.Text);
                    form_modificar.Text = "Modificar " + tabControl_Tablas.SelectedTab.Text;

                    actualiza_formulario_antes_de_modificar(form_modificar);

                    form_modificar.ShowDialog();

                    if (form_modificar.band_aceptar) // Si ya se hizo click en aceptar en el formulario
                    {
                        actualiza_lista_de_datos_modificar(lista, form_modificar);

                        modifica_en_DB(lista);
                        actualiza_grid(tabControl_Tablas.SelectedTab.Text); // Actualiza

                        // Limpia y cierra el formulario
                        form_modificar.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("ERROR - Toda la fila debe de estar seleccionada.");
                }
            }
            else
            {
                MessageBox.Show("Los datos no se pueden modificar", "Notificación");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (tabControl_Tablas.SelectedTab.Text != "DetalleVenta" && tabControl_Tablas.SelectedTab.Text != "DetalleCompra")
            {
                // Primero checa que la fila entera esté seleccionada (en este caso selectedcells debe de ser 4 contando el id)
                if (dataGridView.SelectedRows.Count > 0)
                {
                    // Pide la confirmacion para eliminar al profesor
                    if (MessageBox.Show("Se va a eliminar " + dataGridView.SelectedCells[0].Value.ToString(),
                                        "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        elimina_en_DB(tabControl_Tablas.SelectedTab.Text);
                        actualiza_grid(tabControl_Tablas.SelectedTab.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Los datos no se pueden eliminar", "Notificación");
            }
        }

        // -------------------------- FUNCIONES CON LA DATABASE --------------------------

        public void inserta_en_DB(List<string> tabla)
        {
            // Se abre la conexion con la base de datos
            SqlConnection conexion = Conexion.Conectar();
            // Se crea la consulta en un string
            string valores = get_valores_tabla_insertar(tabla[0]);
            string consulta = "INSERT INTO gimnasio." + tabla[0] + " " + valores;

            // Se crea el comando con la conexion a la base de datos y la consulta
            SqlCommand comando = new SqlCommand(consulta, conexion);

            actualiza_comando_insertar(comando, tabla);

            // Se ejecuta la consulta
            comando.ExecuteNonQuery();
        }

        public void modifica_en_DB(List<string> tabla)
        {
            // Se abre la conexion con la base de datos
            SqlConnection conexion = Conexion.Conectar();
            // Se crea la consulta en un string
            string valores = get_valores_tabla_modificar(tabla[0]);
            string consulta = "UPDATE gimnasio." + tabla[0] + " " + valores;

            // Se crea el comando con la conexion a la base de datos y la consulta
            SqlCommand comando = new SqlCommand(consulta, conexion);

            actualiza_comando_modificar(comando, tabla);

            // Se ejecuta la consulta
            comando.ExecuteNonQuery();
        }

        public void elimina_en_DB(string tabla)
        {
            // Se abre la conexion con la base de datos
            SqlConnection conexion = Conexion.Conectar();
            // Se crea la consulta en un string
            string valores = get_valores_tabla_eliminar(tabla);
            string consulta = "DELETE from gimnasio." + tabla + " " + valores;

            // Se crea el comando con la conexion a la base de datos y la consulta
            SqlCommand comando = new SqlCommand(consulta, conexion);

            actualiza_comando_eliminar(comando, tabla);

            // Se ejecuta la consulta
            comando.ExecuteNonQuery();
        }


        // -------------------------- FUNCIONES DEL STRING DEL QUERY ESPECIFICO DE UNA TABLA --------------------------


        public string get_valores_tabla_insertar(string nombre_tabla)  // Saca el resto de la consulta a partir del nombre de la tabla
        {
            string v = "";

            switch (nombre_tabla)
            {
                case "Articulo":
                    v = "(Nombre, Precio, Existencia) VALUES(@Nombre, @Precio, @Existencia)";
                    break;
                case "Horario":
                    v = "(HoraInicio, HoraFin) VALUES(@HoraInicio, @HoraFin)";
                    break;
                case "Cliente":
                    v = "(Nombre, Direccion) VALUES(@Nombre, @Direccion)";
                    break;
                case "Clase":
                    v = "(IdEmpleado, IdHorario, Nombre, Cupo) VALUES(@Empleado, @Horario, @Nombre, @Cupo)";
                    break;
                case "Pago":
                    v = "(IdSuscripcion, IdCliente, Total, Fecha) VALUES(@Suscripcion, @Cliente, @Total, @Fecha)";
                    break;
                case "DetalleVenta":
                    v = "(IdVenta, IdArticulo, Cantidad) VALUES(@IdVenta, @IdArticulo, @Cantidad)";
                    break;
                case "DetalleCompra":
                    v = "(IdCompra, IdArticulo, Cantidad) VALUES(@IdCompra, @IdArticulo, @Cantidad)";
                    break;
                case "Empleado":
                    v = "(IdHorario, Nombre, Celular, Sueldo, Dias) VALUES (@IdHorario, @Nombre, @Celular, @Sueldo, @Dias)";
                    break;
                case "Suscripcion":
                    v = "(IdEmpleado, IdCliente, Precio, Duracion, Tipo, Fecha, Estado) VALUES (@IdEmpleado, @IdCliente, @Precio, @Duracion, @Tipo, @Fecha, @Estado)";
                    break;
                case "Inscripcion":
                    v = "(IdClase, IdCliente) VALUES (@IdClase, @IdCliente)";
                    break;
                case "Venta":
                    v = "(IdEmpleado, Fecha) VALUES (@IdEmpleado, @Fecha)";
                    break;
                case "Compra":
                    v = "(IdEmpleado, Fecha) VALUES (@IdEmpleado, @Fecha)";
                    break;
            }

            return v;
        }

        public string get_valores_tabla_modificar(string nombre_tabla)  // Saca el resto de la consulta a partir del nombre de la tabla
        {
            string v = "";

            switch (nombre_tabla)
            {
                case "Articulo":
                    v = "SET Nombre = @Nombre, Precio = @Precio, Existencia = @Existencia WHERE IdArticulo = @IdArticulo";
                     break;
                case "Horario":
                    v = "SET HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE IdHorario = @IdHorario";
                    break;
                case "Cliente":
                    v = "SET Nombre = @Nombre, Direccion = @Direccion WHERE IdCliente = @IdCliente";
                    break;
                case "Clase":
                    v = "SET IdEmpleado = @Empleado, IdHorario = @Horario, Nombre = @Nombre, Cupo = @Cupo WHERE IdClase = @IdClase";
                    break;
                case "Pago":
                    v = "SET IdSuscripcion = @Suscripcion, IdCliente = @Cliente, Total = @Total, Fecha = @Fecha WHERE IdPago = @IdPago";
                    break;

                case "DetalleVenta":
                    v = "SET IdArticulo = @Articulo, Cantidad = @Cantidad WHERE IdDetalleVenta = @IdDetalleVenta";
                    break;
                case "DetalleCompra":
                    v = "SET IdArticulo = @Articulo, Cantidad = @Cantidad WHERE IdDetalleCompra = @IdDetalleCompra";
                    break;

                case "Empleado":
                    v = "SET IdHorario = @IdHorario, Nombre = @Nombre, Celular = @Celular, Sueldo = @Sueldo, Dias = @Dias WHERE IdEmpleado = @IdEmpleado";
                    break;
                case "Suscripcion":
                    v = "SET IdEmpleado = @IdEmpleado, IdCLiente = @IdCliente, Precio = @Precio, Duracion=@Duracion, Tipo = @Tipo, Fecha = @Fecha, Estado = @Estado  WHERE IdSuscripcion = @IdSuscripcion";
                    break;
                case "Inscripcion":
                    v = "SET IdClase = @IdClase, IdCliente = @IdCLiente WHERE IdInscripcion = @IdInscripcion";
                    break;
                case "Venta":
                    v = "SET IdEmpleado = @IdEmpleado, Fecha = @Fecha  WHERE IdVenta = @IdVenta";
                    break;
                case "Compra":
                    v = "SET IdEmpleado = @IdEmpleado, Fecha = @Fecha  WHERE IdCompra = @IdCompra";
                    break;
            }

            return v;
        }

        public string get_valores_tabla_eliminar(string nombre_tabla) // Saca el resto de la consulta a partir del nombre de la tabla
        {
            string v = "";

            switch (nombre_tabla)
            {
                case "Articulo":
                    v = "WHERE IdArticulo = @IdArticulo";
                    break;
                case "Horario":
                    v = "WHERE IdHorario = @IdHorario";
                    break;
                case "Cliente":
                    v = "WHERE IdCliente = @IdCliente";
                    break;
                case "Clase":
                    v = "WHERE IdClase = @IdClase";
                    break;
                case "Pago":
                    v = "WHERE IdPago = @IdPago";
                    break;
                case "DetalleVenta":
                    v = "WHERE IdDetalleVenta = @IdDetalleVenta";
                    break;
                case "DetalleCompra":
                    v = "WHERE IdDetalleCompra = @IdDetalleCompra";
                    break;
                case "Empleado":
                    v = "WHERE IdEmpleado = @IdEmpleado";
                    break;
                case "Suscripcion":
                    v = "WHERE IdSuscripcion = @IdSuscripcion";
                    break;
                case "Inscripcion":
                    v = "WHERE IdInscripcion = @IdInscripcion";
                    break;
                case "Venta":
                    v = "WHERE IdVenta = @IdVenta";
                    break;
                case "Compra":
                    v = "WHERE IdCompra = @IdCompra";
                    break;
            }

            return v;
        }

        // -------------------------- FUNCIONES DE VALORES QUE TENDRÁ UN QUERY ESPECIFICO DE UNA TABLA --------------------------

        public void actualiza_lista_de_datos_insertar(List<string> lista, Formulario formulario)
        {
            // Añade el nombre de la lista
            lista.Add(tabControl_Tablas.SelectedTab.Text);

            // Añade a la lista los atributos dependiendo de la tabla
            switch (lista[0])
            {
                case "Articulo":
                    // Añade los atributos necesarios
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                case "Horario":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
                case "Cliente":
                    //lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                case "Clase":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    break;
                case "Pago":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    break;
                case "DetalleVenta":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                case "DetalleCompra":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;

                case "Empleado":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    lista.Add(formulario.Textbox5.Text);
                    break;
                case "Suscripcion":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    lista.Add(formulario.Textbox5.Text);
                    lista.Add(formulario.Textbox6.Text);
                    lista.Add(formulario.Textbox7.Text);
                    break;
                case "Inscripcion":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
                case "Venta":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
                case "Compra":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
            }
        }

        public void actualiza_formulario_antes_de_modificar(Formulario formulario)
        {
            // Es modificacion, asi que hay que poner los valores actuales de los atributos (selectedCells[0] es el id)
            switch (tabControl_Tablas.SelectedTab.Text)
            {
                case "Articulo":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[3].Value.ToString();
                    break;
                case "Horario":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    break;
                case "Cliente":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    break;
                case "Clase":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[3].Value.ToString();
                    formulario.Textbox4.Text = dataGridView.SelectedCells[4].Value.ToString();
                    break;
                case "Pago":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[3].Value.ToString();
                   // formulario.Textbox4.Text = dataGridView.SelectedCells[4].Value.ToString();

                    #region Quita el formato de fecha y lo convierte a cadena
                    string fecha4 = "";
                    string fechaAux4 = dataGridView.SelectedCells[4].Value.ToString();
                    fecha4 = fechaAux4.Substring(0, 10);
                    fechaAux4 = fecha4.Replace("/", "");

                    fecha4 = fechaAux4.Substring(4);
                    fecha4 += fechaAux4.Substring(2, 2);
                    fecha4 += fechaAux4.Substring(0, 2);
                    formulario.Textbox4.Text = fecha4;

                    #endregion
                    break;
                case "DetalleVenta":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[0].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[2].Value.ToString();
                    break;
                case "DetalleCompra":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[0].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[2].Value.ToString();
                    break;

                case "Empleado":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[3].Value.ToString();
                    formulario.Textbox4.Text = dataGridView.SelectedCells[4].Value.ToString();
                    formulario.Textbox5.Text = dataGridView.SelectedCells[5].Value.ToString();
                    break;
                case "Suscripcion":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[3].Value.ToString();
                    formulario.Textbox4.Text = dataGridView.SelectedCells[4].Value.ToString();
                    formulario.Textbox5.Text = dataGridView.SelectedCells[5].Value.ToString();

                    #region Quita el formato de fecha y lo convierte a cadena
                    string fecha = "";
                    string fechaAux = dataGridView.SelectedCells[6].Value.ToString();
                    fecha = fechaAux.Substring(0,10);
                    fechaAux = fecha.Replace("/", "");

                    fecha = fechaAux.Substring(4);
                    fecha += fechaAux.Substring(2,2);
                    fecha += fechaAux.Substring(0, 2);
                    #endregion

                    formulario.Textbox6.Text = fecha;
                    formulario.Textbox7.Text = dataGridView.SelectedCells[7].Value.ToString();
                    break;
                case "Inscripcion":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[1].Value.ToString();
                    break;
                case "Venta":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    #region Quita el formato de fecha y lo convierte a cadena
                    string fecha2 = "";
                    string fechaAux2 = dataGridView.SelectedCells[2].Value.ToString();
                    fecha2 = fechaAux2.Substring(0, 10);
                    fechaAux2 = fecha2.Replace("/", "");

                    fecha2 = fechaAux2.Substring(4) + "-";
                    fecha2 += fechaAux2.Substring(2, 2) + "-";
                    fecha2 += fechaAux2.Substring(0, 2);
                    #endregion
                    formulario.Textbox2.Text = fecha2;
                    break;
                case "Compra":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    #region Quita el formato de fecha y lo convierte a cadena
                    string fecha3 = "";
                    string fechaAux3 = dataGridView.SelectedCells[2].Value.ToString();
                    fecha3 = fechaAux3.Substring(0, 10);
                    fechaAux3 = fecha3.Replace("/", "");

                    fecha3 = fechaAux3.Substring(4) + "-";
                    fecha3 += fechaAux3.Substring(2, 2) + "-";
                    fecha3 += fechaAux3.Substring(0, 2);
                    #endregion
                    formulario.Textbox2.Text = fecha3;
                    break;


            }
        }

        public void actualiza_lista_de_datos_modificar(List<string> lista, Formulario formulario)
        {
            // Añade el nombre de la lista
            lista.Add(tabControl_Tablas.SelectedTab.Text);

            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (lista[0])
            {
                case "Articulo":
                    // Añade los atributos necesarios
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                case "Horario":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
                case "Cliente":
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                case "Clase":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    break;
                case "Pago":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    break;
                case "DetalleVenta":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                case "DetalleCompra":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    break;
                    
                case "Empleado":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    lista.Add(formulario.Textbox5.Text);
                    break;
                case "Suscripcion":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    lista.Add(formulario.Textbox3.Text);
                    lista.Add(formulario.Textbox4.Text);
                    lista.Add(formulario.Textbox5.Text);
                    lista.Add(formulario.Textbox6.Text);
                    lista.Add(formulario.Textbox7.Text);
                    break;
                case "Inscripcion":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
                case "Venta":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
                case "Compra":
                    lista.Add(formulario.Textbox1.Text);
                    lista.Add(formulario.Textbox2.Text);
                    break;
            }
        }


        // -------------------------- FUNCIONES DE ACTUALIZAR DATOS DE UN COMANDO --------------------------
        void actualiza_comando_insertar(SqlCommand comando, List<string> datos)
        {
            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (datos[0])
            {
                case "Articulo":
                    comando.Parameters.AddWithValue("@Nombre", datos[1]);
                    comando.Parameters.AddWithValue("@Precio", datos[2]);
                    comando.Parameters.AddWithValue("@Existencia", datos[3]);
                    break;
                case "Horario":
                    comando.Parameters.AddWithValue("@HoraInicio", datos[1]);
                    comando.Parameters.AddWithValue("@HoraFin", datos[2]);
                    break;
                case "Cliente":
                    comando.Parameters.AddWithValue("@Nombre", datos[1]);
                    comando.Parameters.AddWithValue("@Direccion", datos[2]);
                    break;
                case "Clase":
                    comando.Parameters.AddWithValue("@Empleado", datos[1]);
                    comando.Parameters.AddWithValue("@Horario", datos[2]);
                    comando.Parameters.AddWithValue("@Nombre", datos[3]);
                    comando.Parameters.AddWithValue("@Cupo", datos[4]);
                    break;
                case "Pago":
                    comando.Parameters.AddWithValue("@Suscripcion", datos[1]);
                    comando.Parameters.AddWithValue("@Cliente", datos[2]);
                    comando.Parameters.AddWithValue("@Total", datos[3]);
                    comando.Parameters.AddWithValue("@Fecha", datos[4]);
                    break;
                case "DetalleVenta":
                    comando.Parameters.AddWithValue("@IdVenta", datos[1]);
                    comando.Parameters.AddWithValue("@IdArticulo", datos[2]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[3]);
                    break;
                case "DetalleCompra":
                    comando.Parameters.AddWithValue("@IdCompra", datos[1]);
                    comando.Parameters.AddWithValue("@IdArticulo", datos[2]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[3]);
                    break;
                
                case "Empleado":
                    comando.Parameters.AddWithValue("@IdHorario", datos[1]);
                    comando.Parameters.AddWithValue("@Nombre", datos[2]);
                    comando.Parameters.AddWithValue("@Celular", datos[3]);
                    comando.Parameters.AddWithValue("@Sueldo", datos[4]);
                    comando.Parameters.AddWithValue("@Dias", datos[5]);
                    break;
                case "Suscripcion":
                    comando.Parameters.AddWithValue("@IdEmpleado", datos[1]);
                    comando.Parameters.AddWithValue("@IdCliente", datos[2]);
                    comando.Parameters.AddWithValue("@Precio", datos[3]);
                    comando.Parameters.AddWithValue("@Duracion", datos[4]);
                    comando.Parameters.AddWithValue("@Tipo", datos[5]);
                    comando.Parameters.AddWithValue("@Fecha", datos[6]);
                    comando.Parameters.AddWithValue("@Estado", datos[7]);
                    break;
                case "Inscripcion":
                    comando.Parameters.AddWithValue("@IdClase", datos[1]);
                    comando.Parameters.AddWithValue("@IdCliente", datos[2]);
                    break;
                case "Venta":
                    comando.Parameters.AddWithValue("@IdEmpleado", datos[1]);
                    comando.Parameters.AddWithValue("@Fecha", datos[2]);
                    break;
                case "Compra":
                    comando.Parameters.AddWithValue("@IdEmpleado", datos[1]);
                    comando.Parameters.AddWithValue("@Fecha", datos[2]);
                    break;

            }
        }

        void actualiza_comando_modificar(SqlCommand comando, List<string> datos)
        {
            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (datos[0])
            {
                case "Articulo":
                    comando.Parameters.AddWithValue("@Nombre", datos[1]);
                    comando.Parameters.AddWithValue("@Precio", datos[2]);
                    comando.Parameters.AddWithValue("@Existencia", datos[3]);
                    comando.Parameters.AddWithValue("@IdArticulo", dataGridView.SelectedCells[0].Value.ToString());
                 break;
                case "Horario":
                    comando.Parameters.AddWithValue("@HoraInicio", datos[1]);
                    comando.Parameters.AddWithValue("@HoraFin", datos[2]);
                    comando.Parameters.AddWithValue("@IdHorario", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Cliente":
                    comando.Parameters.AddWithValue("@Nombre", datos[1]);
                    comando.Parameters.AddWithValue("@Direccion", datos[2]);
                    comando.Parameters.AddWithValue("@IdCliente", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Clase":
                    comando.Parameters.AddWithValue("@Empleado", datos[1]);
                    comando.Parameters.AddWithValue("@Horario", datos[2]);
                    comando.Parameters.AddWithValue("@Nombre", datos[3]);
                    comando.Parameters.AddWithValue("@Cupo", datos[4]);
                    comando.Parameters.AddWithValue("@IdClase", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Pago":
                    comando.Parameters.AddWithValue("@Suscripcion", datos[1]);
                    comando.Parameters.AddWithValue("@Cliente", datos[2]);
                    comando.Parameters.AddWithValue("@Total", datos[3]);
                    comando.Parameters.AddWithValue("@Fecha", datos[4]);
                    comando.Parameters.AddWithValue("@IdPago", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "DetalleVenta":
                    comando.Parameters.AddWithValue("@IdVenta", datos[1]);
                    comando.Parameters.AddWithValue("@Articulo", datos[2]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[3]);
                    break;
                case "DetalleCompra":
                    comando.Parameters.AddWithValue("@IdCompra", datos[1]);
                    comando.Parameters.AddWithValue("@Articulo", datos[2]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[3]);
                    break;
                
                case "Empleado":
                    comando.Parameters.AddWithValue("@IdHorario", datos[1]);
                    comando.Parameters.AddWithValue("@Nombre", datos[2]);
                    comando.Parameters.AddWithValue("@Celular", datos[3]);
                    comando.Parameters.AddWithValue("@Sueldo", datos[4]);
                    comando.Parameters.AddWithValue("@Dias", datos[5]);
                    comando.Parameters.AddWithValue("@IdEmpleado", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Suscripcion":
                    comando.Parameters.AddWithValue("@IdEmpleado", datos[1]);
                    comando.Parameters.AddWithValue("@IdCliente", datos[2]);
                    comando.Parameters.AddWithValue("@Precio", datos[3]);
                    comando.Parameters.AddWithValue("@Duracion", datos[4]);
                    comando.Parameters.AddWithValue("@Tipo", datos[5]);
                    comando.Parameters.AddWithValue("@Fecha", datos[6]);
                    comando.Parameters.AddWithValue("@Estado", datos[7]);
                    comando.Parameters.AddWithValue("@IdSuscripcion", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Inscripcion":
                    comando.Parameters.AddWithValue("@IdClase", datos[1]);
                    comando.Parameters.AddWithValue("@IdCliente", datos[2]);
                    comando.Parameters.AddWithValue("@IdInscripcion", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Venta":
                    comando.Parameters.AddWithValue("@IdEmpleado", datos[1]);
                    comando.Parameters.AddWithValue("@Fecha", datos[2]);
                    comando.Parameters.AddWithValue("@IdVenta", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Compra":
                    comando.Parameters.AddWithValue("@IdEmpleado", datos[1]);
                    comando.Parameters.AddWithValue("@Fecha", datos[2]);
                    comando.Parameters.AddWithValue("@IdCompra", dataGridView.SelectedCells[0].Value.ToString());
                    break;

            }
        }

        void actualiza_comando_eliminar(SqlCommand comando, string tabla)
        {
            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (tabla)
            {
                case "Articulo":
                    comando.Parameters.AddWithValue("@IdArticulo", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Horario":
                    comando.Parameters.AddWithValue("@IdHorario", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Cliente":
                    comando.Parameters.AddWithValue("@IdCliente", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Clase":
                    comando.Parameters.AddWithValue("@IdClase", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Pago":
                    comando.Parameters.AddWithValue("@IdPago", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "DetalleVenta":
                    comando.Parameters.AddWithValue("@IdDetalleVenta", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "DetalleCompra":
                    comando.Parameters.AddWithValue("@IdDetalleCompra", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Empleado":
                    comando.Parameters.AddWithValue("@IdEmpleado", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Suscripcion":
                    comando.Parameters.AddWithValue("@IdSuscripcion", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Inscripcion":
                    comando.Parameters.AddWithValue("@IdInscripcion", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Venta":
                    comando.Parameters.AddWithValue("@IdVenta", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "Compra":
                    comando.Parameters.AddWithValue("@IdCompra", dataGridView.SelectedCells[0].Value.ToString());
                    break;
            }
        }

        string get_query_actualiza_grid(string tabla)
        {
            string query = "SELECT * FROM gimnasio." + tabla + ";";
            switch (tabla)
            {
                case "Inscripcion":
                    query = "SELECT i.IdInscripcion, (CAST(i.IdCliente AS VARCHAR(100)) " + "+ ' ' + c.Nombre) AS Cliente, " +
                        "(CAST(e.IdClase AS VARCHAR(100)) +  " +
                        "+ ' ' + e.Nombre + ' ' + CAST(h.HoraInicio AS VARCHAR(100))) AS Clase " +
                            "FROM gimnasio.Inscripcion i " +
                            "INNER JOIN gimnasio.Cliente c " +
                            "ON i.IdCliente = c.IdCliente " +
                            "INNER JOIN gimnasio.Clase e " +
                            "ON i.IdClase = e.IdClase " +
                            "INNER JOIN gimnasio.Horario h " +
                            "ON h.IdHorario = e.IdHorario";
                    
                    break;
                case "Venta":
                    query = "SELECT v.IdVenta, (CAST(e.IdEmpleado AS VARCHAR(100)) + ' ' + e.Nombre) AS Empleado, " +
                        "v.Fecha, v.Total " +
                        "FROM gimnasio.Venta v " +
                        "INNER JOIN gimnasio.Empleado e " +
                        "ON e.IdEmpleado = v.IdEmpleado";
                    break;
                case "Compra":
                    query = "SELECT v.IdCompra, (CAST(e.IdEmpleado AS VARCHAR(100)) + ' ' + e.Nombre) AS Empleado, " +
                        "v.Fecha, v.Total " +
                        "FROM gimnasio.Compra v " +
                        "INNER JOIN gimnasio.Empleado e " +
                        "ON e.IdEmpleado = v.IdEmpleado";
                    break;
                case "DetalleVenta":
                    query = "SELECT v.IdVenta, (CAST(a.IdArticulo AS VARCHAR(100)) + ' ' + a.Nombre) AS Articulo, " +
                        "v.Cantidad, v.Subtotal " +
                        "FROM gimnasio.DetalleVenta v " +
                        "INNER JOIN gimnasio.Articulo a " +
                        "ON v.IdArticulo = a.IdArticulo";
                    break;
                case "DetalleCompra":
                    query = "SELECT v.IdCompra, (CAST(a.IdArticulo AS VARCHAR(100)) + ' ' + a.Nombre) AS Articulo, " +
                        "v.Cantidad, v.Subtotal " +
                        "FROM gimnasio.DetalleCompra v " +
                        "INNER JOIN gimnasio.Articulo a " +
                        "ON v.IdArticulo = a.IdArticulo";
                    break;
            }

            return query;
        }
    }
}
