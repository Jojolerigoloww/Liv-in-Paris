using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PSI_Interface
{
    public partial class CréationCompte : Form
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable utilisateursTable;
        public CréationCompte()
        {
            InitializeComponent();
            connection = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@");
            LoadUtilisateurs();
        }
        private System.Windows.Forms.DataGridView dataGridViewUtilisateurs;

        private void LoadUtilisateurs()
        {
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM Utilisateur", connection);
                utilisateursTable = new DataTable();
                adapter.Fill(utilisateursTable);
                ///dataGridViewUtilisateurs.DataSource = utilisateursTable; ///(Utile pour vérifier que le compte a bien été créé
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
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
                string Id_User = Guid.NewGuid().ToString("N");
                string Nom_User = txt_nom.Text;
                string Prenom_User = txt_prenom.Text;
                string Adresse = txt_adresse.Text;
                string Email = txt_email.Text;
                string Mot_De_Passe = txt_mdp.Text;
                string Metro = txt_metro.Text;

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO Utilisateur (Id_User, Nom_User, Prenom_User, Adresse, Email, Mot_De_Passe, Metro) VALUES (@Id, @Nom, @Prenom, @Adresse, @Email, @Mdp, @Metro)";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", Id_User);
                            cmd.Parameters.AddWithValue("@Nom", Nom_User);
                            cmd.Parameters.AddWithValue("@Prenom", Prenom_User);
                            cmd.Parameters.AddWithValue("@Adresse", Adresse);
                            cmd.Parameters.AddWithValue("@Email", Email);
                            cmd.Parameters.AddWithValue("@Mdp", Mot_De_Passe);
                            cmd.Parameters.AddWithValue("@Metro", Metro);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Utilisateur ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Effacer les champs après insertion
                                Id_User = "";
                                Nom_User = "";
                                Prenom_User = "";
                                Adresse = "";
                                Email = "";
                                Mot_De_Passe = "";
                                Metro = "";
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de l'ajout.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
