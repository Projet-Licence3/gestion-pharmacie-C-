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
    public partial class supprimer_medicament : Form
    {
        DBConnect db = new DBConnect();
        MySqlDataReader read;
        public supprimer_medicament()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestion_medicament gm = new gestion_medicament();
            gm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("database=pharmacie2;server=localhost;user id=root;pwd=");
            try
            {
                con.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Veiller remplir tous les champs");
                }
                else
                {
                    string req = "select * from medicament where nomMed='" + textBox1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(req, con);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        con.Close();
                        con.Open();
                        string req2 = "delete from medicament where nomMed='" + textBox1.Text + "'";
                        MySqlCommand cmd2 = new MySqlCommand(req2, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Medicament supprimer avec succès");
                        textBox1.Text = " ";
                        
                    }
                    else
                    {
                        MessageBox.Show("Le medicament '" + textBox1.Text + "' n'existe pas dans la BD");
                        textBox1.Text = " ";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion echoué" + ex);
            }
        }
    }
}
