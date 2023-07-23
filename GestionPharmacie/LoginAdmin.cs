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
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Authentification au = new Authentification();
            au.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Veillez remplir le champs d'abord");
            }
            else if(textBox1.Text == "2023")
            {
                AjoutUtilisateur au = new AjoutUtilisateur();
                au.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect");
            }
        }
    }
}
