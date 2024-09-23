using Corte1.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corte1
{
    public partial class Form1 : Form
    {
        Regsistro registro = new Regsistro();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string ciudad = cbxCiudad.SelectedItem?.ToString() ?? "Sin ciudad seleccionada";

            Persona nuevaPersona = new Persona(nombres, apellidos, fechaNacimiento, ciudad);
            try
            {
                registro.AgregarPersona(nuevaPersona);
                lstPersonas.Items.Add($"{nombres} {apellidos}"); 
                MessageBox.Show("Persona agregada correctamente.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalcularEdad_Click(object sender, EventArgs e)
        {
            Operacion operacion = new Operacion();

            if (lstPersonas.SelectedIndex >= 0)
            {
                int indiceSeleccionado = lstPersonas.SelectedIndex;
                Persona personaSeleccionada = registro.MostrarPersonas()[indiceSeleccionado];

 
                int edad = operacion.CalcularEdad(personaSeleccionada);
                string resultado = operacion.EsMayorDeEdad(personaSeleccionada);

                MessageBox.Show($"Nombre: {personaSeleccionada.Nombres} {personaSeleccionada.Apellidos}\nEdad: {edad}\n{resultado}");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una persona de la lista.");
            }
        }
    }
}
