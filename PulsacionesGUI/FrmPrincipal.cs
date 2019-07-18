using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PulsacionesGUI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void PersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersona frmPersona = new FrmPersona();
            frmPersona.Show();
        }

        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PersonaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultarPersonas frmPersona = new FrmConsultarPersonas();
            frmPersona.Show();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GraficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrafica frmGrafica = new FrmGrafica();
            frmGrafica.Show();
        }
    }
}
