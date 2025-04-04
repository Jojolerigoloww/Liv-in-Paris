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
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_identifiant.Text) || string.IsNullOrWhiteSpace(txt_MotDePasse.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Connexion réussie !");
                AppPrincipale mainForm = new AppPrincipale();
                mainForm.Show();
                this.Hide();
            }
        }

        private void link_NoAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CréationCompte compte = new CréationCompte();
            compte.Show();
            this.Hide();
        }
    }
}
