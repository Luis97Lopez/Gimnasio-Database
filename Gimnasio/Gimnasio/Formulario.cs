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
    public partial class Formulario : Form
    {
        // Variable global para saber de que tabla
        string tabla = "";
        // Variable para saber cuando se hizo clic en aceptar
        public bool band_aceptar = false;

        public List<string> listaHorarios = new List<string>(); //Lista que almacena los horarios existentes en formato string.

        public Formulario(string tbl)
        {
            InitializeComponent();
            tabla = tbl;

            

            // Esconde todo
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            /*
             * Medidas:
             * x += 120
             * y += 20
            */

            switch (tabla) // Muestra solo los controles necesarios para los atributos de la tabla y redimensiona
            {
                case "Empleado":
                    label1.Text = "Horario";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Nombre (50)";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Celular (15)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    label4.Text = "Sueldo ($)";
                    label4.Location = new Point(370, 10);
                    label4.Show();
                    textBox4.Location = new Point(370, 30);
                    textBox4.Show();

                    label5.Text = "Días (7)";
                    label5.Location = new Point(490, 10);
                    label5.Show();
                    textBox5.Location = new Point(490, 30);
                    textBox5.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(490 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 620;
                    this.Height = 130;

                    break;

                case "Cliente":
                    /*label1.Text = "Empleado";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();*/

                    label2.Text = "Nombre (50)";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Dirección (70)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(250 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 380;
                    this.Height = 130;

                    break;

                case "Suscripcion":
                    label1.Text = "Empleado";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Cliente";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Precio ($)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    label4.Text = "Duración (20)";
                    label4.Location = new Point(370, 10);
                    label4.Show();
                    textBox4.Location = new Point(370, 30);
                    textBox4.Show();

                    label5.Text = "Tipo (20)";
                    label5.Location = new Point(490, 10);
                    label5.Show();
                    textBox5.Location = new Point(490, 30);
                    textBox5.Show();

                    label6.Text = "Fecha (Año-Mes-Día)";
                    label6.Location = new Point(610, 10);
                    label6.Show();
                    textBox6.Location = new Point(610, 30);
                    textBox6.Show();

                    label7.Text = "Estado (20)";
                    label7.Location = new Point(730, 10);
                    label7.Show();
                    textBox7.Location = new Point(730, 30);
                    textBox7.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(730 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 860;
                    this.Height = 130;

                    break;

                case "Clase":

                    llenaComboHorarios(); //Lena el Combobox de Horarios con los horarios existentes en la tabla

                    if(textBox2.Text != string.Empty) //Si es modificación selecciona el item adecuado del combobox.
                        SeleccionaHorarioModif();

                    label1.Text = "Empleado";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Horario";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    comboBox1.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Nombre (50)";
                    label3.Location = new Point(280, 10);
                    label3.Show();
                    textBox3.Location = new Point(280, 30);
                    textBox3.Show();

                    label4.Text = "Cupo";
                    label4.Location = new Point(400, 10);
                    label4.Show();
                    textBox4.Location = new Point(400, 30);
                    textBox4.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(370 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 530;
                    this.Height = 130;

                    break;

                case "Inscripcion":
                    label1.Text = "Clase";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Cliente";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(130 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 260;
                    this.Height = 130;

                    break;

                case "Pago":
                    label1.Text = "Suscripción";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Cliente";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Total ($)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    label4.Text = "Fecha (Año-Mes-Día)";
                    label4.Location = new Point(370, 10);
                    label4.Show();
                    textBox4.Location = new Point(370, 30);
                    textBox4.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(370 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 500;
                    this.Height = 130;

                    break;

                case "Horario":
                    label1.Text = "Hora inicio (HH:MM:SS)";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Hora fin (HH:MM:SS)";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(130 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 270;
                    this.Height = 130;

                    break;

                case "Articulo":
                    label1.Text = "Nombre (40)";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Precio ($)";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Existencia";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(250 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 380;
                    this.Height = 130;

                    break;

                case "Venta":
                    label1.Text = "Empleado";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "DetalleVenta";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Fecha (Año-Mes-Día)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(250 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 380;
                    this.Height = 130;

                    break;

                case "DetalleVenta":
                    label1.Text = "Articulo";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Cantidad";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    /*label3.Text = "Total ($)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();*/

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(250 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 380;
                    this.Height = 130;

                    break;

                case "Compra":
                    label1.Text = "Empleado";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "DetalleCompra";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    label3.Text = "Fecha (Año-Mes-Día)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(250 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 380;
                    this.Height = 130;

                    break;

                case "DetalleCompra":
                    label1.Text = "Articulo";
                    label1.Location = new Point(10, 10);
                    label1.Show();
                    textBox1.Location = new Point(10, 30);
                    textBox1.Show();

                    label2.Text = "Cantidad";
                    label2.Location = new Point(130, 10);
                    label2.Show();
                    textBox2.Location = new Point(130, 30);
                    textBox2.Show();

                    /*label3.Text = "Total ($)";
                    label3.Location = new Point(250, 10);
                    label3.Show();
                    textBox3.Location = new Point(250, 30);
                    textBox3.Show();*/

                    // Posiciona los botones en las orillas de la ventana, a la izquierda aceptar y a la derecha cancelar
                    button_Aceptar.Location = new Point(10, 50 + 10);
                    button_Cancelar.Location = new Point(250 + 20, 50 + 10);

                    // Redimensiona toda la ventana
                    this.Width = 380;
                    this.Height = 130;

                    break;

            }
        }


        private void SeleccionaHorarioModif()
        {
            foreach(string cad in listaHorarios)
            {
                string Id = cad.Substring(0, 1);
                if (textBox2.Text == Id)
                    ComboBox1.SelectedIndex = listaHorarios.IndexOf(cad);
            }
        }

        private void button_Aceptar_Click(object sender, EventArgs e) // Completa la accion
        {
            switch (tabla)
            {
                case "Articulo": 
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if(textBox1.Text != "" && textBox2.Text != "" && textBox2.Text != "")
                    {
                        // Solo se checa el textbox1 porque es la unica cadena que hay
                        if(textBox1.Text.Length <= 40)
                        {
                            // Se alza la bandera para confirmar la acción y se cierra
                            band_aceptar = true;
                            this.Close();
                        }
                        else // La cadena de texto sobrepasa la longitud permitida en la base de datos
                        {
                            MessageBox.Show("ERROR - Las cadenas no pueden medir más de lo permitido.");
                        }
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
                case "Horario":
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        band_aceptar = true;
                        this.Close();
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
                case "Clase":
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        // Solo se checa el textbox1 porque es la unica cadena que hay
                        if (textBox3.Text.Length <= 50)
                        {
                            // Se alza la bandera para confirmar la acción y se cierra
                            band_aceptar = true;
                            this.Close();
                        }
                        else // La cadena de texto sobrepasa la longitud permitida en la base de datos
                        {
                            MessageBox.Show("ERROR - Las cadenas no pueden medir más de lo permitido.");
                        }
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
                case "Cliente":
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if (textBox2.Text != "" && textBox3.Text != "")
                    {
                        // Solo se checa el textbox1 porque es la unica cadena que hay
                        if (textBox2.Text.Length <= 50 && textBox2.Text.Length <= 70)
                        {
                            // Se alza la bandera para confirmar la acción y se cierra
                            band_aceptar = true;
                            this.Close();
                        }
                        else // La cadena de texto sobrepasa la longitud permitida en la base de datos
                        {
                            MessageBox.Show("ERROR - Las cadenas no pueden medir más de lo permitido.");
                        }
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
                case "Pago":
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        band_aceptar = true;
                        this.Close();
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
                case "DetalleVenta":
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        band_aceptar = true;
                        this.Close();
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
                case "DetalleCompra":
                    // Checa que los controles no estén vacios ni que las cadenas sobrepasen la longitud correspondiente
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        band_aceptar = true;
                        this.Close();
                    }
                    else // Al menos un textbox está vacio
                    {
                        MessageBox.Show("ERROR - Los campos no pueden quedar vacios.");
                    }
                    break;
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e) // Aborta la accion y cierra todo
        {
            this.Close();
        }

        private void llenaComboHorarios()
        {
            
            // Se abre la conexion con la base de datos
            SqlConnection connection = Conexion.Conectar();

            // Se crea la consulta para obtener la tabla de profesor
            string query = "SELECT * FROM gimnasio.Horario ORDER BY HoraInicio ASC";

            // Se crea el comando y se ejecuta
            SqlCommand command = new SqlCommand(query, connection);

            // Se obtiene la informacion de la tabla a partir del comando
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            for (int i=0; i<dataGridView1.Rows.Count;i++)
            {
                string horario = dataGridView1.Rows[i].Cells[0].Value.ToString() + " - " + dataGridView1.Rows[i].Cells[1].Value.ToString() + " - " + dataGridView1.Rows[i].Cells[2].Value.ToString();
                comboBox1.Items.Add(horario);
                listaHorarios.Add(horario);
            }
            
        }

        // Gets de todos los textbox 
        // Esto es para poder acceder a los textbox desde el form1 sin tener que asignar los textos a variables globales
        public TextBox Textbox1
        {
            get
            {
                return textBox1;
            }
        }
        public TextBox Textbox2
        {
            get
            {
                return textBox2;
            }
        }
        public TextBox Textbox3
        {
            get
            {
                return textBox3;
            }
        }
        public TextBox Textbox4
        {
            get
            {
                return textBox4;
            }
        }
        public TextBox Textbox5
        {
            get
            {
                return textBox5;
            }
        }
        public TextBox Textbox6
        {
            get
            {
                return textBox6;
            }
        }
        public TextBox Textbox7
        {
            get
            {
                return textBox7;
            }
        }

        public ComboBox ComboBox1
        {
            get
            {
                return comboBox1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdHorario = comboBox1.SelectedItem.ToString();
            Textbox2.Text = IdHorario.Substring(0, 1);
        }
    }
}
