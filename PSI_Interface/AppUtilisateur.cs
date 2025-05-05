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
    public partial class AppUtilisateur : Form
    {
        private string nom;
        private string prenom;
        private string idUser;
        public AppUtilisateur(string nom, string prenom, string idUser)
        {
            InitializeComponent();
            this.prenom = prenom;
            this.nom = nom;
            this.idUser = idUser;
        }

        private void AppPrincipale_Load(object sender, EventArgs e)
        {
            lbl_titre.Text = $"Bienvenue, {prenom} {nom} !";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_quitter_MouseEnter(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.White;
        }

        private void bt_quitter_MouseLeave(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_recette_Click(object sender, EventArgs e)
        {
            LivreRecette livre = new LivreRecette(nom, prenom, idUser);
            livre.Show();
            this.Hide();
        }

        private void bt_recette_MouseEnter(object sender, EventArgs e)
        {
            bt_recette.BackColor = Color.White;
        }

        private void bt_recette_MouseLeave(object sender, EventArgs e)
        {
            bt_recette.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_carte_MouseEnter(object sender, EventArgs e)
        {
            bt_carte.BackColor = Color.White;
        }

        private void bt_carte_MouseLeave(object sender, EventArgs e)
        {
            bt_carte.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_carte_Click(object sender, EventArgs e)
        {
            Carte carte = new Carte(nom, prenom, idUser);
            carte.Show();
            this.Hide();
        }

        private void bt_commander_Click(object sender, EventArgs e)
        {
            Commande commande = new Commande(nom,prenom,idUser);
            commande.Show();
            this.Hide();
        }

        private void bt_commande_MouseEnter(object sender, EventArgs e)
        {
            bt_commande.BackColor = Color.White;
        }

        private void bt_commande_MouseLeave(object sender, EventArgs e)
        {
            bt_commande.BackColor = Color.FromArgb(250, 191, 80);
        }
    }
}
