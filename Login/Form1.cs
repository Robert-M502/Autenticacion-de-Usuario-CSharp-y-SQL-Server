using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Login
{
    public partial class frmLogin : Form
    {
        int id { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            ConexionDB conexion = new ConexionDB();
            string consulta = "SELECT * FROM usuarios WHERE correo='" + correo + "' AND contraseña='" + contrasena + "'";

            conexion.AbrirConexion();
            SqlDataReader resultado = conexion.EjecutarConsulta(consulta);
            
            if (resultado.HasRows) {
                while (resultado.Read()) {
                    id = resultado.GetInt32(0);
                    // ...
                }
                txtContraseña.Clear();
                   
                // Cerrar el formulario de inicio de sesión
                this.Hide();

                // Abrir el formulario de bienvenida
                frmBienvenido frmBienvenido = new frmBienvenido(id);
                frmBienvenido.ShowDialog();

                // Mostar nuevamente el formulario de inicio de sesión cuando se cierra el formulario de bienvenida
                this.Show();
            }
            else {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
            conexion.CerrarConexion();
        }
    }
}
