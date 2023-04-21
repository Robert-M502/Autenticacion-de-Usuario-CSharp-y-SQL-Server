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


    public partial class frmEditar : Form
    {
        int idUser { get; set; }
        string nombreUser { get; set; }
        string correoUser { get; set; }
        string contraseñaUser { get; set; }

        public frmEditar(int id)
        {
            InitializeComponent();
            ConexionDB conexion = new ConexionDB();
            string consulta = "SELECT * FROM usuarios WHERE id = '"+ id +"'";
            conexion.AbrirConexion();
            SqlDataReader resultado = conexion.EjecutarConsulta(consulta);

            while (resultado.Read()) {
                idUser = Convert.ToInt32(resultado["id"]);
                nombreUser = resultado["nombre"].ToString();
                correoUser = resultado["correo"].ToString();
                contraseñaUser = resultado["contraseña"].ToString();
            }

            txtNombre.Text = nombreUser;
            txtCorreo.Text = correoUser;
            txtContraseña.Text = contraseñaUser;
            

            resultado.Close();
            conexion.CerrarConexion();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombreUser = txtNombre.Text.Trim();
            correoUser = txtCorreo.Text.Trim();
            contraseñaUser = txtContraseña.Text.Trim();
            ConexionDB conexion = new ConexionDB();
            string consulta = "UPDATE usuarios SET nombre='"+nombreUser +"', correo='"+correoUser +"', contraseña='"+contraseñaUser +"' WHERE id='"+idUser+"'";
            conexion.AbrirConexion();
            int filasAfectadas = conexion.EjecutarNonQuery(consulta);
            conexion.CerrarConexion();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("La datos fueron actualizados correctamente");
                this.Close();
            }
            else {
                MessageBox.Show("Hubo un error en actualizar los datos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            nombreUser = txtNombre.Text.Trim();
            correoUser = txtCorreo.Text.Trim();
            contraseñaUser = txtContraseña.Text.Trim();
            ConexionDB conexion = new ConexionDB();
            string consulta = "UPDATE usuarios SET nombre='" + nombreUser + "', correo='" + correoUser + "', contraseña='" + contraseñaUser + "' WHERE id='" + idUser + "'";
            conexion.AbrirConexion();
            int filasAfectadas = conexion.EjecutarNonQuery(consulta);
            conexion.CerrarConexion();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("La datos fueron actualizados correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error en actualizar los datos");
            }
        }
    }
}
