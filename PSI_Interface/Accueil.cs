using MySql.Data.MySqlClient;
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
                string Id_User = txt_identifiant.Text.Trim();
                string Mot_De_Passe = txt_MotDePasse.Text.Trim();

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT Nom_User,Prenom_User FROM Utilisateur WHERE Id_User = @id AND Mot_De_Passe = @mdp";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", Id_User);
                            cmd.Parameters.AddWithValue("@mdp", Mot_De_Passe);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nom = reader["Nom_User"].ToString();
                                    string prenom = reader["Prenom_User"].ToString();

                                    MessageBox.Show($"Connexion réussie ! Bienvenue {prenom} {nom}", "Bienvenue", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    reader.Close();

                                    AppPrincipale mainForm = new AppPrincipale(nom,prenom);
                                    mainForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("ID ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
