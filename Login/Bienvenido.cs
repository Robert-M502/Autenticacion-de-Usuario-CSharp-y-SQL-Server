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
    public partial class frmBienvenido : Form
    {
        public int idUser { set; get; }
        string correoUser { get; set; }
        public string nombreUser { get; set; }

        public frmBienvenido(int id)
        {
            InitializeComponent();
            selectUsuario(id);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            frmEditar frmEditar = new frmEditar(idUser);
            frmEditar.ShowDialog();

            selectUsuario(idUser);

            this.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void selectUsuario(int id) {
            ConexionDB conexion = new ConexionDB();
            string consulta = "SELECT * FROM usuarios WHERE id='" + id + "'";
            conexion.AbrirConexion();
            SqlDataReader resultado = conexion.EjecutarConsulta(consulta);

            if (resultado.Read())
            {   
                idUser = resultado.GetInt32(0);
                nombreUser = resultado.GetString(1);
                correoUser = resultado.GetString(2);
                string contraseña = resultado.GetString(3);

                lblId.Text = "ID: " + idUser;
                lblNombre.Text = "Nombre del usuario: " + nombreUser;
                lblCorreo.Text = "Correo: " + correoUser;
            }

            resultado.Close();
            conexion.CerrarConexion();
        }

        private void frmBienvenido_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
