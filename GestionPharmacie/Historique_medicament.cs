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
    public partial class Historique_medicament : Form
    {
        DBConnect db = new DBConnect();
        public Historique_medicament()
        {
            InitializeComponent();
            afficher();
        }

        public void afficher()
        {
            string req = "select * from vente";
            db.select(req, dataGridView1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gestion_vente gv = new gestion_vente();
            gv.Show();
            this.Hide();
        }
    }
}
