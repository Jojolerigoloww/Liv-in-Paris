using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace PSI_Interface
{
    public partial class AppAdmin : Form
    {
        private string nom;
        private string prenom;
        private MySqlConnection codeSql;
        private MySqlDataAdapter adapter;
        private DataTable utilisateursTable;

        public AppAdmin(string nom, string prenom)
        {
            InitializeComponent();
            codeSql = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@");
            this.prenom = prenom;
            this.nom = nom;
        }
        private System.Windows.Forms.DataGridView dataGridView1;

        private void bt_quitter_MouseEnter(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.White;
        }

        private void bt_quitter_MouseLeave(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void AppAdmin_Load(object sender, EventArgs e)
        {
            lbl_titre_2.Text = $"Bonjour, administrateur {prenom} {nom}";
        }

        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = comboBox1.SelectedItem?.ToString();

            ChargerDonnees(selection);
        }

        private void ChargerDonnees(string selection)
        {
            // Obtenir la requête SQL appropriée selon la sélection
            string requeteSQL = ObtenirRequeteSQL(selection);

            try
            {
                {
                    // Créer un adaptateur de données avec la requête
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(requeteSQL, codeSql))
                    {
                        // Créer et remplir un DataTable
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Lier le DataTable au DataGridView
                        dataGridView.DataSource = dataTable;

                        // Optionnel: Ajuster l'apparence du DataGridView
                        ConfigurerDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenirRequeteSQL(string selection)
        {
            // *** INSÉREZ VOS REQUÊTES SQL ICI ***
            switch (selection)
            {
                case "Utilisateurs":
                    // Requête pour les utilisateurs
                    return @"SELECT * FROM Utilisateur";

                case "Cuisiniers":
                    // Requête pour les cuisiniers
                    return @"SELECT * FROM Cuisinier";

                case "Plats":
                    // Requête pour les plats
                    return @"SELECT * FROM Plat";

                case "Clients":
                    // Requête pour les notes
                    return @"SELECT * FROM Client";

                case "Notes Moyennes":
                    // Requête pour les commandes
                    return @"SELECT Utilisateur.Nom_User AS Nom_Cuisinier,
                            Utilisateur.Prenom_User AS Prenom_Cuisinier,
                            COALESCE(AVG(Note.Note), 0) AS Note_Moyenne
                            FROM Cuisinier
                            JOIN Utilisateur ON Cuisinier.ID_User = Utilisateur.ID_User
                            LEFT JOIN Note ON Cuisinier.ID_Cuisinier = Note.ID_Cuisinier
                            GROUP BY Cuisinier.ID_Cuisinier, Utilisateur.Nom_User, Utilisateur.Prenom_User
                            ORDER BY Note_Moyenne DESC;";

                default:
                    // Requête par défaut au cas où
                    return @"SELECT *
                            FROM utilisateur
                            ORDER BY Nom_User,Prenom_User";
            }
        }

        private void ConfigurerDataGridView()
        {
            // Personnaliser l'apparence et le comportement du DataGridView
            dataGridView.AllowUserToAddRows = false;       // Empêcher l'ajout de lignes par l'utilisateur
            dataGridView.AllowUserToDeleteRows = false;    // Empêcher la suppression de lignes
            dataGridView.ReadOnly = true;                  // Rendre le DataGridView en lecture seule
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajuster les colonnes
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue; // Alternance des couleurs

            // Vous pouvez ajouter d'autres personnalisations ici selon vos besoins
        }
    }
}
