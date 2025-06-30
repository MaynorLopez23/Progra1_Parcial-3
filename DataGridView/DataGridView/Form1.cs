using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Nombre";
            dataGridView1.Columns[1].Name = "Apellido";
            dataGridView1.Columns[2].Name = "Teléfono";
            dataGridView1.Columns[3].Name = "Correo";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            String telefono = txtTelefono.Text;
            String correo = txtCorreo.Text;
            if (String.IsNullOrWhiteSpace(nombre) ||
                String.IsNullOrWhiteSpace(apellido) ||
                String.IsNullOrWhiteSpace(telefono) ||
                String.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, llene todos los campos");
                return;
            }

            string[] row = new string[] { nombre, apellido, telefono, correo };
            dataGridView1.Rows.Add(row);

            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
    }
}
