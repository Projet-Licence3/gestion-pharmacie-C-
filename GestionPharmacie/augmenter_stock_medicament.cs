using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionPharmacie
{
    public partial class augmenter_stock_medicament : Form
    {
        DBConnect db = new DBConnect();
        MySqlDataReader read;
        public augmenter_stock_medicament()
        {
            InitializeComponent();
            recupererMedicament();
        }

        private void recupererMedicament()
        {
            string req = "select * from medicament";
            comboBox1.DisplayMember = db.recuperer(req).Columns["nomMed"].ToString();
            comboBox1.DataSource = db.recuperer(req);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestion_stock gs = new gestion_stock();
            gs.Show();
            this.Hide();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("database=pharmacie2;server=localhost;user id=root;pwd=");
            try
            {
                con.Open();
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Veiller remplir le champ '" + label2.Text + "'");
                }
                else
                {
                    string req = "select * from medicament where nomMed='" + comboBox1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(req, con);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        textBox2.Text = read["qteMed"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Le medicament n'existe pas dans la BD");
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion echoué" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" )
                {
                    MessageBox.Show("Veillez remplir tous les champs");
                }
                else
                {
                    int prixUpdate = int.Parse(textBox2.Text) + int.Parse(textBox1.Text);
                    string requete = "update medicament set qteMed='" + prixUpdate + "' where nomMed='" + comboBox1.Text + "'"; 
                    db.Update(requete);
                    MessageBox.Show("Le medicament " + comboBox1.Text + " a desormais un prix egal a " + prixUpdate);

                    //comboBox1.Text = " ";
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                }
            }
            catch
            {
                MessageBox.Show("Connection echoué");
            }
        }
    }
}
