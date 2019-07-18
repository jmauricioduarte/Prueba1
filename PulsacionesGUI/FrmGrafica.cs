using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PulsacionesGUI
{
    public partial class FrmGrafica : Form
    { PersonaService servic = new PersonaService();
        public FrmGrafica()
        {
            InitializeComponent();
        }

        private void BtnGrafica_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            List<Persona> reportes = new List<Persona>();
            reportes = servic.Consultar();
            
            foreach (var item in reportes)
            {
                Series serie = chart1.Series.Add(item.Nombre);

                serie.Label = item.Pulsaciones.ToString();
                serie.Points.Add(Double.Parse(item.Pulsaciones.ToString()));
            }


        }
    }
}
/*List<Reporte> reportes = new List<Reporte>();
            Reporte reporte1 = new Reporte();
            reporte1.Nombre = "Carlos";
            reporte1.Pulsaciones = "32";
            Reporte reporte2 = new Reporte();
            reporte2.Nombre = "Andrea";
            reporte2.Pulsaciones = "56";
            Reporte reporte3 = new Reporte();
            reporte3.Nombre = "Pedro";
            reporte3.Pulsaciones = "75";
            Reporte reporte4 = new Reporte();
            reporte4.Nombre = "Carolina";
            reporte4.Pulsaciones = "12";
            reportes.Add(reporte1);
            reportes.Add(reporte2);
            reportes.Add(reporte3);
            reportes.Add(reporte4);*/