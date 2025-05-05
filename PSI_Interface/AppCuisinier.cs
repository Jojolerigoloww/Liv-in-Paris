using Microsoft.VisualBasic;
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
    public partial class AppCuisinier : Form
    {
        private string nom;
        private string prenom;
        private string idUser;
        public AppCuisinier(string nom, string prenom, string idUser)
        {
            InitializeComponent();
            this.prenom = prenom;
            this.nom = nom;
            this.idUser = idUser;
        }

        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AppCuisinier_Load(object sender, EventArgs e)
        {
            lbl_titre.Text = $"Bienvenue, {prenom} {nom} !";
        }

        private void bt_quitter_MouseEnter(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.White;
        }

        private void bt_quitter_MouseLeave(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_plat_Click(object sender, EventArgs e)
        {
            AjoutPlat ajout = new AjoutPlat(nom, prenom, idUser);
            ajout.Show();
            this.Hide();
        }

        private void bt_plat_MouseEnter(object sender, EventArgs e)
        {
            bt_plat.BackColor = Color.White;
        }

        private void bt_plat_MouseLeave(object sender, EventArgs e)
        {
            bt_plat.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_recette_Click(object sender, EventArgs e)
        {
            string nom_plat = Interaction.InputBox("Entrez le nom de votre recette :", "Saisie de nom");

            if (!string.IsNullOrWhiteSpace(nom_plat))
            {
                MessageBox.Show("Nom de recette validé");
                AjoutRecette recette = new AjoutRecette(nom, prenom, idUser, nom_plat);
                recette.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Aucune saisie effectuée.", "Information");
            }
        }

        private void bt_recette_MouseEnter(object sender, EventArgs e)
        {
            bt_recette.BackColor = Color.White;
        }

        private void bt_recette_MouseLeave(object sender, EventArgs e)
        {
            bt_recette.BackColor = Color.FromArgb(250, 191, 80);
        }
    }
}
