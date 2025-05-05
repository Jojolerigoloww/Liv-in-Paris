using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI_Rendu1;

namespace PSI_Interface
{
    public partial class Trajet : Form
    {
        private string nom;
        private string prenom;
        private string idUser;
        private string idCommande;
        private string idPlat;

        public Trajet(string nom, string prenom, string idUser, string idCommande, string idPlat)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.idUser = idUser;
            InitializeComponent();
            this.idCommande = idCommande;
            this.idPlat = idPlat;
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

        private void Trajet_Load(object sender, EventArgs e)
        {
            string stationClient = "", stationCuisinier = "";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 1. Récupérer ID_Cuisinier via Plat
                string idCuisinier = "";
                using (MySqlCommand cmdPlat = new MySqlCommand("SELECT ID_Cuisinier FROM Plat WHERE ID_Plat = @id_Plat", connection))
                {
                    cmdPlat.Parameters.AddWithValue("@id_Plat", idPlat);
                    object result = cmdPlat.ExecuteScalar();
                    if (result != null)
                        idCuisinier = result.ToString();
                    else
                    {
                        MessageBox.Show("Plat introuvable.");
                        return;
                    }
                }

                // 2. Récupérer ID_User du cuisinier
                string idUserCuisinier = "";
                using (MySqlCommand cmdCuisinier = new MySqlCommand("SELECT ID_User FROM Cuisinier WHERE ID_Cuisinier = @idCuisinier", connection))
                {
                    cmdCuisinier.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                    object result = cmdCuisinier.ExecuteScalar();
                    if (result != null)
                        idUserCuisinier = result.ToString();
                    else
                    {
                        MessageBox.Show("Cuisinier introuvable.");
                        return;
                    }
                }

                // 3. Récupérer Station du client
                using (MySqlCommand cmdStationClient = new MySqlCommand("SELECT Metro FROM Utilisateur WHERE ID_User = @idUser", connection))
                {
                    cmdStationClient.Parameters.AddWithValue("@idUser", idUser);
                    object result = cmdStationClient.ExecuteScalar();
                    if (result != null)
                        stationClient = result.ToString();
                    else
                    {
                        MessageBox.Show("Station du client introuvable.");
                        return;
                    }
                }

                // 4. Récupérer Station du cuisinier
                using (MySqlCommand cmdStationCuisinier = new MySqlCommand("SELECT Metro FROM Utilisateur WHERE ID_User = @idUser", connection))
                {
                    cmdStationCuisinier.Parameters.AddWithValue("@idUser", idUserCuisinier);
                    object result = cmdStationCuisinier.ExecuteScalar();
                    if (result != null)
                        stationCuisinier = result.ToString();
                    else
                    {
                        MessageBox.Show("Station du cuisinier introuvable.");
                        return;
                    }
                }
            }

            try
            {
                Graphe graphe = new Graphe();
                graphe.VisualiserChemin(stationCuisinier, stationClient, "chemin.png");

                string imagePath = @"C:\Users\basti\Documents\GitHub\Liv-in-Paris\PSI_Rendu1_2.0\PSI_Rendu1_2.0\bin\Debug\net8.0\chemin.png";
                if (File.Exists(imagePath))
                {
                    using (var bmpTemp = new Bitmap(imagePath))
                    {
                        pictureBox.Image = new Bitmap(bmpTemp);
                    }
                }
                else
                {
                    MessageBox.Show("L'image du trajet n'a pas été trouvée.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'exécution du programme : " + ex.Message);
            }
        }
    }
}
