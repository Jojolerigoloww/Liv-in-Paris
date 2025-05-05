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
    public partial class Commande : Form
    {

        private string nom;
        private string prenom;
        private string idUser;
        public Commande(string nom, string prenom, string idUser)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
            this.idUser = idUser;
        }

        private void bt_retour_Click(object sender, EventArgs e)
        {
            AppUtilisateur utilisateur = new AppUtilisateur(nom, prenom, idUser);
            utilisateur.Show();
            this.Hide();
        }

        private void bt_retour_MouseEnter(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.White;
        }

        private void bt_retour_MouseLeave(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_valider_MouseEnter(object sender, EventArgs e)
        {
            bt_valider.BackColor = Color.White;
        }

        private void bt_valider_MouseLeave(object sender, EventArgs e)
        {
            bt_valider.BackColor = Color.FromArgb(250, 191, 80);
        }

        private string GetClientIdFromUserId(string userId)
        {
            string clientId = null;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_Client FROM Client WHERE ID_User = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clientId = reader["ID_Client"].ToString();
                        }
                    }
                }
            }

            return clientId;
        }

        private void Commande_Load(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID_Plat, Nom_Plat , Prix FROM Plat";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    Dictionary<string, string> plats = new Dictionary<string, string>();

                    while (reader.Read())
                    {
                        string id = reader["ID_Plat"].ToString();
                        string nom = reader["Nom_Plat"].ToString();
                        plats.Add(id, nom);
                    }

                    comboBoxPlats.DataSource = new BindingSource(plats, null);
                    comboBoxPlats.DisplayMember = "Value"; // Ce que l’utilisateur voit (nom du plat)
                    comboBoxPlats.ValueMember = "Key";     // Ce que tu utilises dans le code (ID du plat)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
        
        private void bt_valider_Click(object sender, EventArgs e)
        {
            if (comboBoxPlats.SelectedItem != null)
            {
                string selectedPlatId = ((KeyValuePair<string, string>)comboBoxPlats.SelectedItem).Key;
                string selectedPlatNom = ((KeyValuePair<string, string>)comboBoxPlats.SelectedItem).Value;
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";

                string clientId = GetClientIdFromUserId(idUser);

                if (string.IsNullOrEmpty(clientId))
                {
                    MessageBox.Show("Impossible de trouver le client lié à cet utilisateur.", "Erreur");
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // 1. Enregistrement de la commande
                        string commandeId = Guid.NewGuid().ToString("N");
                        DateTime dateCommande = DateTime.Now;

                        string insertCommandeQuery = "INSERT INTO Commande (ID_Commande, Date_Commande, ID_Client) VALUES (@id, @date, @client)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertCommandeQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@id", commandeId);
                            insertCmd.Parameters.AddWithValue("@date", dateCommande);
                            insertCmd.Parameters.AddWithValue("@client", clientId);
                            insertCmd.ExecuteNonQuery();
                        }
                        Trajet trajet = new Trajet(nom, prenom, idUser, commandeId, selectedPlatId);
                        trajet.Show();
                        this.Hide();
                        // 2. Suppression du plat après enregistrement de la commande
                        /*string deleteQuery = "DELETE FROM Plat WHERE ID_Plat = @ID";
                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCmd.Parameters.AddWithValue("@ID", selectedPlatId);
                            int affectedRows = deleteCmd.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Commande enregistrée et plat supprimé.", "Succès");

                                var source = (BindingSource)comboBoxPlats.DataSource;
                                var originalDict = (Dictionary<string, string>)source.DataSource;

                                originalDict.Remove(selectedPlatId);

                                comboBoxPlats.DataSource = null;
                                comboBoxPlats.DataSource = new BindingSource(originalDict, null);
                                comboBoxPlats.DisplayMember = "Value";
                                comboBoxPlats.ValueMember = "Key";

                                
                            }
                            else
                            {
                                MessageBox.Show("Commande enregistrée mais aucun plat supprimé.", "Avertissement");
                            }
                        }*/
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un plat.");
            }
        }
    }
}
