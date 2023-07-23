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
    public partial class menu_generale : Form
    {
        public menu_generale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestion_medicament gm = new gestion_medicament();
            gm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gestion_stock gs = new gestion_stock();
            gs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestion_vente gv = new gestion_vente();
            gv.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Authentification au = new Authentification();
            au.Show();
            this.Hide();
        }
    }
}
