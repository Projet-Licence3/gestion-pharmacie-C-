using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPharmacie
{
    public partial class gestion_medicament : Form
    {
        public gestion_medicament()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu_generale mg = new menu_generale();
            mg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enreg_medicament em = new enreg_medicament();
            em.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            supprimer_medicament sm = new supprimer_medicament();
            sm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rechercher_medicament rm = new rechercher_medicament();
            rm.Show();
            this.Hide();
        }
    }
}
