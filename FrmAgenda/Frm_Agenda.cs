namespace FrmAgenda
{
    public partial class Frm_Agenda : Form
    {
        public Frm_Agenda()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios (opcional pero recomendable)
            if (txtID.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Por favor complete los campos obligatorios: ID, Nombre y Teléfono.");
                return;
            }

            // Determinar el género seleccionado
            string genero = "";
            if (rdbMasculino.Checked)
                genero = "Masculino";
            else if (rdbFemenino.Checked)
                genero = "Femenino";

            // Agregar la fila al DataGridView
            dtgAgenda.Rows.Add(
                txtID.Text,
                txtNombre.Text,
                txtApellido.Text,
                txtTelefono.Text,
                txtCorreo.Text,
                txtDireccion.Text,
                genero
            );

            // Limpiar los campos después de agregar
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtObservaciones.Clear();
            rdbMasculino.Checked = false;
            rdbFemenino.Checked = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgAgenda.SelectedRows.Count > 0)
            {
                // Confirmar eliminación
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Elimina la fila seleccionada
                    dtgAgenda.Rows.RemoveAt(dtgAgenda.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro para eliminar.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtgAgenda.SelectedRows.Count > 0)
            {
                int fila = dtgAgenda.SelectedRows[0].Index;

                // Obtener género desde los RadioButtons
                string genero = rdbMasculino.Checked ? "Masculino" :
                                rdbFemenino.Checked ? "Femenino" : "";

                // Asignar valores a las celdas del DataGridView
                dtgAgenda.Rows[fila].Cells[0].Value = txtID.Text;
                dtgAgenda.Rows[fila].Cells[1].Value = txtNombre.Text;
                dtgAgenda.Rows[fila].Cells[2].Value = txtApellido.Text;
                dtgAgenda.Rows[fila].Cells[3].Value = txtTelefono.Text;
                dtgAgenda.Rows[fila].Cells[4].Value = txtCorreo.Text;
                dtgAgenda.Rows[fila].Cells[5].Value = txtDireccion.Text;
                dtgAgenda.Rows[fila].Cells[6].Value = genero;

                MessageBox.Show("Registro actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila para actualizar.");
            }
        }
    }
}
