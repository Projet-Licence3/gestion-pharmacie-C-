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
    public partial class gestion_vente : Form
    {
        public gestion_vente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu_generale mg = new menu_generale();
            mg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vendre_medicament vm = new Vendre_medicament();
            vm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Historique_medicament hv = new Historique_medicament();
            hv.Show();
            this.Hide();
        }
    }
}
