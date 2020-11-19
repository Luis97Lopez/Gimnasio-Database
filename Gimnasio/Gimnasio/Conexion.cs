using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gimnasio
{
    class Conexion
    { /*
        
           //Conexion de Mauricio:
        private const string ConnectionString = "SERVER=MR-ICIO\\SQLEXPRESS;" +
                                     "integrated security=true;";
        +/
         /*  
           Conexion de Luis:
        private const string ConnectionString = "SERVER=DESKTOP-GP08O95\\SQLEXPRESS;" +
                                    "DATABASE=Gimnasio;" +
                                    "integrated security=true;";

            Conexion de Alfredo:
        private const string ConnectionString = "SERVER=DESKTOP-DVAR0RA\\SQLEXPRESS;" +
                                                "DATABASE=Gimnasio;" +
                                                "integrated security=true;";

        */

        // Se crea la cadena con la que se va a conectar a la base de datos.
        //private const string ConnectionString = "SERVER=MR-ICIO\\SQLEXPRESS;" +
       
        private const string ConnectionString = "SERVER=DESKTOP-IHCDKCC\\SQLEXPRESS;" +
                                                "DATABASE=Gimnasio;" +
                                                "integrated security=true;";
        

        public static SqlConnection Conectar()
        {
            // Se crea la conexion a partir de la cadena 
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Se abre la conexion para poder trabajar
            conexion.Open();

            return conexion;
        }
    }
}
