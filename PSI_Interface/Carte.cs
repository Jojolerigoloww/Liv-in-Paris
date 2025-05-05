using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI_Interface
{
    public partial class Carte : Form
    {

        private string nom;
        private string prenom;
        private string idUser;
        public Carte(string nom, string prenom, string idUser)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
            this.idUser = idUser;
        }

        private void bt_retour_MouseEnter(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.White;
        }

        private void bt_retour_MouseLeave(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_retour_Click(object sender, EventArgs e)
        {
            AppUtilisateur utilisateur = new AppUtilisateur(nom, prenom, idUser);
            utilisateur.Show();
            this.Hide();
        }
    }
}
