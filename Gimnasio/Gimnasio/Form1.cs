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
            string query = "SELECT * FROM gimnasio." + tabla + ";";

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

        private void btn_Modificar_Click(object sender, EventArgs e)
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            // Primero checa que la fila entera esté seleccionada (en este caso selectedcells debe de ser 4 contando el id)
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Pide la confirmacion para eliminar al profesor
                if (MessageBox.Show("Se va a eliminar " + dataGridView.SelectedCells[1].Value.ToString(),
                                    "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    elimina_en_DB(tabControl_Tablas.SelectedTab.Text);
                    actualiza_grid(tabControl_Tablas.SelectedTab.Text);
                }
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
            string consulta = "DELETE gimnasio." + tabla + " " + valores;

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
                    v = "(Empleado, Horario, Nombre) VALUES(@Empleado, @Horario, @Nombre)";
                    break;
                case "Pago":
                    v = "(Suscripcion, Cliente, Total) VALUES(@Suscripcion, @Cliente, @Total)";
                    break;
                case "DetalleVenta":
                    v = "(Articulo, Cantidad) VALUES(@Articulo, @Cantidad)";
                    break;
                case "DetalleCompra":
                    v = "(Articulo, Cantidad) VALUES(@Articulo, @Cantidad)";
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
                    v = "SET Nombre = @Nombre, Direccion = @Direccion, WHERE IdCliente = @IdCliente";
                    break;
                case "Clase":
                    v = "SET Empleado = @Empleado, Horario = @Horario, Nombre, @Nombre WHERE IdClase = @IdClase";
                    break;
                case "Pago":
                    v = "SET Suscripcion = @Suscripcion, Cliente = @Cliente, Total = @Total WHERE IdPago = @IdPago";
                    break;
                case "DetalleVenta":
                    v = "SET Articulo = @Articulo, Cantidad = @Cantidad WHERE IdDetalleVenta = @IdDetalleVenta";
                    break;
                case "DetalleCompra":
                    v = "SET Articulo = @Articulo, Cantidad = @Cantidad WHERE IdDetalleCompra = @IdDetalleCompra";
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
                    break;
                case "DetalleCompra":
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
                    break;
                case "Pago":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    formulario.Textbox3.Text = dataGridView.SelectedCells[3].Value.ToString();
                    formulario.Textbox4.Text = dataGridView.SelectedCells[4].Value.ToString();
                    break;
                case "DetalleVenta":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
                    break;
                case "DetalleCompra":
                    formulario.Textbox1.Text = dataGridView.SelectedCells[1].Value.ToString();
                    formulario.Textbox2.Text = dataGridView.SelectedCells[2].Value.ToString();
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
                    break;
                case "DetalleCompra":
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
                    break;
                case "Pago":
                    comando.Parameters.AddWithValue("@Suscripcion", datos[1]);
                    comando.Parameters.AddWithValue("@Cliente", datos[2]);
                    comando.Parameters.AddWithValue("@Total", datos[3]);
                    comando.Parameters.AddWithValue("@Fecha", datos[4]);
                    break;
                case "DetalleVenta":
                    comando.Parameters.AddWithValue("@Articulo", datos[1]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[2]);
                    break;
                case "DetalleCompra":
                    comando.Parameters.AddWithValue("@Articulo", datos[1]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[2]);
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
                    comando.Parameters.AddWithValue("@Articulo", datos[1]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[2]);
                    comando.Parameters.AddWithValue("@IdDetalleVenta", dataGridView.SelectedCells[0].Value.ToString());
                    break;
                case "DetalleCompra":
                    comando.Parameters.AddWithValue("@Articulo", datos[1]);
                    comando.Parameters.AddWithValue("@Cantidad", datos[2]);
                    comando.Parameters.AddWithValue("@IdDetalleCompra", dataGridView.SelectedCells[0].Value.ToString());
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
            }
        }
    }
}
