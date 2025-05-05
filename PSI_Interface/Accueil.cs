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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            if (string.IsNullOrWhiteSpace(txt_email.Text) || string.IsNullOrWhiteSpace(txt_MotDePasse.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Email = txt_email.Text.Trim();
                string Mot_De_Passe = txt_MotDePasse.Text.Trim();
                string id_User = null;

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT ID_User,Nom_User,Prenom_User FROM Utilisateur WHERE Email = @email AND Mot_De_Passe = @mdp";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@email", Email);
                            cmd.Parameters.AddWithValue("@mdp", Mot_De_Passe);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nom = reader["Nom_User"].ToString();
                                    string prenom = reader["Prenom_User"].ToString();
                                    id_User = reader["ID_User"].ToString();
                                    
                                    MessageBox.Show($"Connexion réussie ! Bienvenue {prenom} {nom}", "Bienvenue", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    reader.Close();

                                    switch (comboBox_statut.SelectedIndex)
                                    {
                                        case 0: // Client
                                            using (MySqlCommand checkCmd = new MySqlCommand("SELECT ID_Client FROM Client WHERE ID_User = @ID", connection))
                                            {
                                                checkCmd.Parameters.AddWithValue("@ID", id_User);
                                                object result = checkCmd.ExecuteScalar();

                                                if (result == null)
                                                {
                                                    // Le client n'existe pas encore ? demander les préférences
                                                    string preferences = Microsoft.VisualBasic.Interaction.InputBox(
                                                        "Entrez vos préférences (régime, plats, allergies, etc.) :",
                                                        "Préférences Client",
                                                        "");
                                                    string idC = Guid.NewGuid().ToString("N");

                                                    if (!string.IsNullOrWhiteSpace(preferences))
                                                    {
                                                        using (MySqlCommand insertCmd = new MySqlCommand("INSERT INTO Client (ID_Client, Préférences, ID_User) VALUES (@idC, @pref, @id)", connection))
                                                        {
                                                            insertCmd.Parameters.AddWithValue("@idC", idC);
                                                            insertCmd.Parameters.AddWithValue("@pref", preferences);
                                                            insertCmd.Parameters.AddWithValue("@id", id_User);
                                                            insertCmd.ExecuteNonQuery();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Aucune préférence saisie. Compte client non créé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                            }

                                            AppUtilisateur Form_Utilisateur = new AppUtilisateur(nom, prenom, id_User);
                                            Form_Utilisateur.Show();
                                            break;

                                        case 1: // Cuisinier
                                            using (MySqlCommand checkCmd = new MySqlCommand("SELECT ID_Cuisinier FROM Cuisinier WHERE ID_User = @ID", connection))
                                            {
                                                checkCmd.Parameters.AddWithValue("@ID", id_User);
                                                object result = checkCmd.ExecuteScalar();

                                                if (result == null)
                                                {
                                                    string idC = Guid.NewGuid().ToString("N");
                                                    using (MySqlCommand insertCmd = new MySqlCommand("INSERT INTO Cuisinier (ID_Cuisinier,ID_User) VALUES (@idC,@id)", connection))
                                                    {
                                                        insertCmd.Parameters.AddWithValue("@idC", idC);
                                                        insertCmd.Parameters.AddWithValue("@id", id_User);
                                                        insertCmd.ExecuteNonQuery();
                                                    }
                                                }
                                            }

                                            AppCuisinier Form_Cuisinier = new AppCuisinier(nom, prenom, id_User);
                                            Form_Cuisinier.Show();
                                            break;

                                        case 2: // Admin
                                            AppAdmin Form_Admin = new AppAdmin(nom, prenom);
                                            Form_Admin.Show();
                                            break;
                                    }


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

        private void bt_valider_MouseEnter(object sender, EventArgs e)
        {
            bt_valider.BackColor = Color.White;
        }

        private void bt_valider_MouseLeave(object sender, EventArgs e)
        {
            bt_valider.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_quitter_MouseEnter(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.White;
        }

        private void bt_quitter_MouseLeave(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void link_NoAccount_MouseEnter(object sender, EventArgs e)
        {
            link_NoAccount.LinkColor = Color.White;
        }

        private void link_NoAccount_MouseLeave(object sender, EventArgs e)
        {
            link_NoAccount.LinkColor = Color.FromArgb(250, 191, 80);
        }
    }
}
