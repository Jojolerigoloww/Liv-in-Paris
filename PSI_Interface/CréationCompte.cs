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
    public partial class CréationCompte : Form
    {
        public CréationCompte()
        {
            InitializeComponent();
        }

        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nom.Text) || string.IsNullOrWhiteSpace(txt_prenom.Text) || string.IsNullOrWhiteSpace(txt_adresse.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) || string.IsNullOrWhiteSpace(txt_mdp.Text) || string.IsNullOrWhiteSpace(txt_metro.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string fullName = txt_prenom.Text + " " + txt_nom.Text;
                MessageBox.Show($"Bienvenue, {fullName} ! Votre compte a été créé avec succès !", "Bienvenue");
                AppPrincipale mainForm = new AppPrincipale();
                mainForm.Show();
                this.Hide();
            }
        }
    }
}
