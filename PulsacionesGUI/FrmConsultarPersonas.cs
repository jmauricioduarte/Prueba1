using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PulsacionesGUI
{
    public partial class FrmConsultarPersonas : Form
    {
        public IRecibe FrmRecibe;
        PersonaService service = new PersonaService();
        GenerarPDF generarPDF = new GenerarPDF();

        public FrmConsultarPersonas()
            
            
        {
            InitializeComponent();
        }
        public FrmConsultarPersonas(IRecibe frmRecibe)
        {
            InitializeComponent();
            FrmRecibe = frmRecibe;


        }

        private void FrmConsultarPersonas_Load(object sender, EventArgs e)
        {

        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            List<Persona> Personas = new List<Persona>();
            Personas = service.Consultar();
            tablaPersona.DataSource = null;
            tablaPersona.DataSource = Personas;
            tablaPersona.Refresh();

        }

        private void TablaPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            generarPDF.GenerarPdf();
        }

        private void TablaPersona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Persona persona = new Persona();
            persona = (Persona)tablaPersona.CurrentRow.DataBoundItem;
            FrmRecibe.Recibir(persona);
            this.Dispose();
        }
    }
}
