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
    public partial class enreg_medicament : Form
    {
        DBConnect db = new DBConnect();
        public enreg_medicament()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestion_medicament gm = new gestion_medicament();
            gm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Veillez remplir tous les champs");
                }
                else
                {
                    string req = "insert into `medicament`(`nomMed`, `qteMed`, `prixUnitaire`, `date_enreg`) values('" + textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+dateTimePicker1.Text+"')";
                    db.Insert(req);
                    MessageBox.Show("Medicament '" + textBox1.Text + "' enregistrer avec succès");
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connexion echoué" + ex);
            }
        }
    }
}
