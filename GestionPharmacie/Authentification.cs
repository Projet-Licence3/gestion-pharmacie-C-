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
    public partial class Authentification : Form
    {
        MySqlDataReader read;
        public Authentification()
        {
            InitializeComponent();
        }

        string username = "VisionTech";
        string mdp = "2023";
        

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("database=pharmacie2;server=localhost;user id=root;pwd=");
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Veillez remplir tous les champs d'abord");
                }
                else
                {
                    con.Open();
                    string req = "select * from utilisateur where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(req, con);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        menu_generale mg = new menu_generale();
                        mg.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ERREUR DE CONNEXION");
                        textBox1.Text = " ";
                        textBox2.Text = " ";
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection echoué " + ex);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            LoginAdmin la = new LoginAdmin();
            la.Show();
            this.Hide();
                
        }
    }
}
