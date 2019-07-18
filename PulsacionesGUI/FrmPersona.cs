using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
using System.Net;
using System.Net.Mail;
namespace PulsacionesGUI
{
    public partial class FrmPersona : Form , IRecibe
    {
        PersonaService personaService = new PersonaService();
        GenerarPDF generarPDF = new GenerarPDF();
        EnviarCorreoService enviarCorreo = new EnviarCorreoService();
     
        public FrmPersona()
        {
            InitializeComponent();
        }
      
        public void Recibir(Persona persona)
        {
            if (persona != null)
            {
                txtIdentificacion.Text = persona.Identificacion;
                txtNombre.Text = persona.Nombre;
                txtEdad.Text = Convert.ToString(persona.Edad);
                txtSexo.Text = persona.Sexo;
                txtCorreo.Text = persona.Correo.ToString();
                persona.CalcularPulsaciones();
                txtPulsaciones.Text = persona.Pulsaciones.ToString();

            }
        }
        
        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    Persona persona = new Persona();
                    txtIdentificacion.Enabled = true;
                    persona.Identificacion = txtIdentificacion.Text;
                    persona.Nombre = txtNombre.Text;
                    persona.Edad = int.Parse(txtEdad.Text);
                    persona.Sexo = txtSexo.Text;
                    persona.Correo = new MailAddress(txtCorreo.Text);
                    persona.CalcularPulsaciones();
                    //string mensajes = enviarCorreo.EnviarCorreo(persona);
                    enviarCorreo.EnviarCorreo(persona);
                    string mensaje = personaService.Guardar(persona);
                    
                    MessageBox.Show(mensaje);
                }
                catch (Exception)
                {

                    MessageBox.Show("Error!!,Ingrese TODA La informacion Debidamente", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                  Limpiar();
            }
        }
        public void Limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtSexo.Text = "";
            txtPulsaciones.Text = "";
        }
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
        
            var identificacion = txtIdentificacion.Text;
            if (identificacion != "")
            {
                Persona persona = personaService.Buscar(identificacion);
                if (persona != null)
                {
                    txtIdentificacion.Enabled = false;
                    txtIdentificacion.Text = persona.Identificacion;
                    txtNombre.Text = persona.Nombre;
                    txtEdad.Text = Convert.ToString(persona.Edad);
                    txtSexo.Text = persona.Sexo;
                    txtCorreo.Text = persona.Correo.ToString();
                    persona.CalcularPulsaciones();
                    txtPulsaciones.Text = persona.Pulsaciones.ToString();
                }
                else
                {
                    MessageBox.Show($"No se encontro la persona con identificacion{ identificacion}");
                }
            }
            else
            {
                MessageBox.Show($"Porfavor dijite una identificacion");
            }
            
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Persona persona;
            var identificacion = txtIdentificacion.Text;
            if (identificacion != "")
            {
                Persona personabuscada = personaService.Buscar(identificacion);
                if (personabuscada != null)
                {
                   personaService.Eliminar(personaService.Buscar(txtIdentificacion.Text));
                    try
                    {
                        persona = new Persona();
                        txtIdentificacion.Enabled = true;
                        persona.Identificacion = txtIdentificacion.Text;
                        persona.Nombre = txtNombre.Text;
                        persona.Edad = int.Parse(txtEdad.Text);
                        persona.Sexo = txtSexo.Text;
                        persona.Correo = new MailAddress (txtCorreo.Text);
                        personaService.Modificar(persona);
                        MessageBox.Show("Informacion actualizada", "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error!!,Ingrese TODA La informacion Debidamente", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona Registrada Con esta identificacion", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Dijite Una Identificacion A Modificar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
             DialogResult opcion;
            opcion = MessageBox.Show("Realmente desea Eliminar", "Salir del Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
              var identificacion = txtIdentificacion.Text;
            if (identificacion != "")
            {
                Persona personabuscada = personaService.Buscar(identificacion);
                if (personabuscada != null)
                {
                        txtIdentificacion.Enabled = true;
                        var Mensaje = personaService.Eliminar(personabuscada);
                    MessageBox.Show(Mensaje, "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Dijite Una Identificacion A Buscar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();  
            }
           
        }

        private void BtnPDF_Click(object sender, EventArgs e)
        {
            generarPDF.GenerarPdf();
        }

        private void BtnBuscarGrid_Click(object sender, EventArgs e)
        {
            FrmConsultarPersonas frmConsultar = new FrmConsultarPersonas(this);
            frmConsultar.Show();
        }
    }
}
