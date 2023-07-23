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
    public partial class AppGeneral : Form
    {
        public AppGeneral()
        {
            InitializeComponent();
        }

        private void AppGeneral_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int pdd = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            pdd += 1;
            progressBar1.Value = pdd;
            pourcentage.Text = pdd + "%";
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Authentification au = new Authentification();
                au.Show();
                this.Hide();
            }
        }

        
    }
}
