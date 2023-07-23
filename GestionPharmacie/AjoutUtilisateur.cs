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
    public partial class AjoutUtilisateur : Form
    {
        DBConnect db = new DBConnect();
        public AjoutUtilisateur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Veillez remplir tous les champs");
                }
                else
                {
                    string req = "insert into `utilisateur`(`username`, `password`, `telephone`, `email`) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                    db.Insert(req);
                    MessageBox.Show("Utilisateur '" + textBox1.Text + "' enregistrer avec succès");
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    textBox4.Text = " ";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connexion echoué " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authentification au = new Authentification();
            au.Show();
            this.Hide();
        }
    }
}
