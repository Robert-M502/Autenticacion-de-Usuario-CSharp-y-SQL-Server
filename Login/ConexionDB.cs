using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login
{
     class ConexionDB
    {
        private SqlConnection conexion;
        public ConexionDB() {
                string cadenaConexion = "server=DESKTOP-BP5JRVE\\SQLEXPRESS; database=Login; User ID=sa; Password=admin;";
                conexion = new SqlConnection(cadenaConexion);
        }
        public SqlConnection AbrirConexion() {
            if (conexion.State == System.Data.ConnectionState.Closed) {
                conexion.Open();
            }
            return conexion;
        }
        public SqlConnection CerrarConexion() {
            if (conexion.State == System.Data.ConnectionState.Open) {
                conexion.Close();
            }   
            return conexion;
        }
        public SqlDataReader EjecutarConsulta(string consulta) { 
            SqlCommand comando = new SqlCommand(consulta, conexion);
            return comando.ExecuteReader();
        }
        public int EjecutarNonQuery(string consulta) {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
    }
}
