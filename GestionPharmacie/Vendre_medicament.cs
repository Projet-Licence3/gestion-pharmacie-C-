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
    public partial class Vendre_medicament : Form
    {
        DBConnect db = new DBConnect();
        MySqlDataReader read;
        MySqlConnection con = new MySqlConnection("database=pharmacie2;server=localhost;user id=root;pwd=");
        public Vendre_medicament()
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
            gestion_vente gv = new gestion_vente();
            gv.Show();
            this.Hide();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                
                
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
            catch (Exception ex)
            {
                MessageBox.Show("Connexion echoué" + ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string req = "select * from medicament where nomMed='" + comboBox1.Text + "'";
               
                MySqlCommand cmd = new MySqlCommand(req, con);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    string prixUnitaire = read["prixUnitaire"].ToString();
                    int qteMed = int.Parse(read["qteMed"].ToString());
                    int qteSaisie = int.Parse(textBox1.Text);
                    if(qteSaisie > qteMed)
                    {
                        MessageBox.Show("ERREUR La quantité maximum a vendre est " + qteMed);
                    }

                    int qte = Convert.ToInt32(textBox1.Text);
                    int prix = Convert.ToInt32(prixUnitaire);
                    int sommePaye = qte * prix;
                    textBox3.Text = sommePaye.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Le medicament n'existe pas dans la BD");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion echoué" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySqlConnection con = new MySqlConnection("database=pharmacie2;server=localhost;user id=root;pwd=");
            try
            {
                con.Open();
                if (comboBox1.Text=="" || textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="" || dateTimePicker1.Text == "")
                {
                    MessageBox.Show("Veiller remplir tous les champs");
                }
                else
                {
                    string reqSelect = "select * from medicament where nomMed='" + comboBox1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(reqSelect, con);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        int quantiteMed = int.Parse(read["qteMed"].ToString());
                        int qteDiminuer = quantiteMed - (int.Parse(textBox1.Text));

                        string reqInserte = "insert into `vente`(`nomMed`, `qteVente`, `sommePayer`, `date_vente`) values('" + comboBox1.Text + "', '" + textBox1.Text + "', '" + textBox3.Text + "', '" + dateTimePicker1.Text + "')";
                        db.Insert(reqInserte);

                        string requete = "update medicament set qteMed='" + qteDiminuer + "' where nomMed='" + comboBox1.Text + "'";
                        db.Update(requete);

                        MessageBox.Show("Medicament '" + comboBox1.Text + "' vendu avec succès");
                    }
                    else
                    {
                        MessageBox.Show("Le medicament '" + comboBox1.Text + "' n'existe pas dans la BD");
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion echoué" + ex);
            }

        }
    }
}

