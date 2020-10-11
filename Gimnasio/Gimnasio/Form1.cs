using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void form_gimnasio_Load(object sender, EventArgs e)
        {
            // Se actualizan todos los grids de golpe
            actualiza_grid("Articulo");
        }

        public void actualiza_grid(string tabla) // Actualiza la tabla con ese nombre
        {
            // Se abre la conexion con la base de datos
            SqlConnection connection = Conexion.Conectar();

            // Se crea la consulta para obtener la tabla de profesor
            string query = "SELECT * FROM gimnasio."+tabla+";";

            // Se crea el comando y se ejecuta
            SqlCommand command = new SqlCommand(query, connection);

            // Se obtiene la informacion de la tabla a partir del comando
            SqlDataAdapter data = new SqlDataAdapter(command);

            // Se rellena una tabla de datos con la informacion de la consulta y se pasa al datagrid
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);

            switch (tabla) // Selecciona el grid de la pestaña especifica
            {
                case "Articulo":
                    dataGridView_Articulo.DataSource = dataTable;
                    break;
            }
            
        }

        public string get_valores_tabla_insertar(string nombre_tabla)  // Saca el resto de la consulta a partir del nombre de la tabla
        {
            string v = "";

            switch (nombre_tabla)
            {
                case "Articulo":
                    v = "(Nombre, Precio, Existencia) VALUES(@Nombre, @Precio, @Existencia)";
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
            }

            return v;
        }

        public void inserta(List<string> tabla)
        {
            // Se abre la conexion con la base de datos
            SqlConnection conexion = Conexion.Conectar();
            // Se crea la consulta en un string
            string valores = get_valores_tabla_insertar(tabla[0]);
            string consulta = "INSERT INTO gimnasio."+ tabla[0] + " " +valores;

            // Se crea el comando con la conexion a la base de datos y la consulta
            SqlCommand comando = new SqlCommand(consulta, conexion);

            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (tabla[0])
            {
                case "Articulo":
                    comando.Parameters.AddWithValue("@Nombre", tabla[1]);
                    comando.Parameters.AddWithValue("@Precio", tabla[2]);
                    comando.Parameters.AddWithValue("@Existencia", tabla[3]);
                    break;
            }

            // Se ejecuta la consulta
            comando.ExecuteNonQuery();
        }

        public void modifica(List<string> tabla)
        {
            // Se abre la conexion con la base de datos
            SqlConnection conexion = Conexion.Conectar();
            // Se crea la consulta en un string
            string valores = get_valores_tabla_modificar(tabla[0]);
            string consulta = "UPDATE gimnasio." + tabla[0] + " " + valores;

            // Se crea el comando con la conexion a la base de datos y la consulta
            SqlCommand comando = new SqlCommand(consulta, conexion);

            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (tabla[0])
            {
                case "Articulo":
                    comando.Parameters.AddWithValue("@Nombre", tabla[1]);
                    comando.Parameters.AddWithValue("@Precio", tabla[2]);
                    comando.Parameters.AddWithValue("@Existencia", tabla[3]);
                    comando.Parameters.AddWithValue("@IdArticulo", dataGridView_Articulo.SelectedCells[0].Value.ToString());
                    break;
            }

            // Se ejecuta la consulta
            comando.ExecuteNonQuery();
        }

        public void elimina(string tabla)
        {
            // Se abre la conexion con la base de datos
            SqlConnection conexion = Conexion.Conectar();
            // Se crea la consulta en un string
            string valores = get_valores_tabla_eliminar(tabla);
            string consulta = "DELETE gimnasio." + tabla + " " + valores;

            // Se crea el comando con la conexion a la base de datos y la consulta
            SqlCommand comando = new SqlCommand(consulta, conexion);

            // Se asignan los valores de los "VALUES" de la consulta con los datos de los textbox
            switch (tabla)
            {
                case "Articulo":
                    comando.Parameters.AddWithValue("@IdArticulo", dataGridView_Articulo.SelectedCells[0].Value.ToString());
                    break;
            }

            // Se ejecuta la consulta
            comando.ExecuteNonQuery();
        }

        // ->->->->->->->->->->->->->->->->->-> ARTICULO <-<-<-<-<-<-<-<-<-<-<-<-<-<-<- //
        private void btn_Insertar_Articulo_Click(object sender, EventArgs e)
        {
            // Se crea una lista de strings para el metodo inserta
            List<string> lista = new List<string>();
            // Se crea el formulario para insertar un nuevo profesor
            Formulario form_agregar = new Formulario(tabPageArticulo.Text);
            form_agregar.Text = "Insertar " + tabPageArticulo.Text;
            form_agregar.ShowDialog();

            if (form_agregar.band_aceptar) // Si ya se hizo click en aceptar en el formulario
            {
                // Añade el nombre de la lista
                lista.Add(tabPageArticulo.Text);
                // Añade los atributos necesarios
                lista.Add(form_agregar.Textbox1.Text);
                lista.Add(form_agregar.Textbox2.Text);
                lista.Add(form_agregar.Textbox3.Text);

                inserta(lista);
                actualiza_grid(tabPageArticulo.Text); // Actualiza

                // Limpia y cierra el formulario
                form_agregar.Dispose();
            }
        }

        private void btn_Modificar_Articulo_Click(object sender, EventArgs e)
        {
            // Se crea una lista de strings para el metodo inserta
            List<string> lista = new List<string>();
            // Se crea el formulario para insertar un nuevo profesor
            Formulario form_modificar;

            // Primero checa que la fila entera esté seleccionada (en este caso selectedcells debe de ser 4 contando el id)
            if(dataGridView_Articulo.SelectedCells.Count == 4)
            {
                form_modificar = new Formulario(tabPageArticulo.Text);
                form_modificar.Text = "Modificar " + tabPageArticulo.Text;
                // Es modificacion, asi que hay que poner los valores actuales de los atributos (selectedCells[0] es el id)
                form_modificar.Textbox1.Text = dataGridView_Articulo.SelectedCells[1].Value.ToString();
                form_modificar.Textbox2.Text = dataGridView_Articulo.SelectedCells[2].Value.ToString();
                form_modificar.Textbox3.Text = dataGridView_Articulo.SelectedCells[3].Value.ToString();
                form_modificar.ShowDialog();

                if (form_modificar.band_aceptar) // Si ya se hizo click en aceptar en el formulario
                {
                    // Añade el nombre de la lista
                    lista.Add(tabPageArticulo.Text);
                    // Añade los atributos necesarios
                    lista.Add(form_modificar.Textbox1.Text);
                    lista.Add(form_modificar.Textbox2.Text);
                    lista.Add(form_modificar.Textbox3.Text);

                    modifica(lista);
                    actualiza_grid(tabPageArticulo.Text); // Actualiza

                    // Limpia y cierra el formulario
                    form_modificar.Dispose();
                }
            }
            else
            {
                MessageBox.Show("ERROR - Toda la fila debe de estar seleccionada.");
            }
            
        }

        private void btn_Eliminar_Articulo_Click(object sender, EventArgs e)
        {
            // Primero checa que la fila entera esté seleccionada (en este caso selectedcells debe de ser 4 contando el id)
            if (dataGridView_Articulo.SelectedCells.Count == 4)
            {
                // Pide la confirmacion para eliminar al profesor
                if (MessageBox.Show("Se va a eliminar " + dataGridView_Articulo.SelectedCells[1].Value.ToString(),
                                    "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    elimina(tabPageArticulo.Text);
                    actualiza_grid(tabPageArticulo.Text);
                }
            }
        }
    }
}
