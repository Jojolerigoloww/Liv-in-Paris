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
using System.Xml.Serialization;
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
            ChargerUtilisateurs();
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
            string requeteSQL = ObtenirRequeteSQL(selection);

            try
            {
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(requeteSQL, codeSql))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView.DataSource = dataTable;

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
            switch (selection)
            {
                case "Utilisateurs":
                    return @"SELECT * FROM Utilisateur";

                case "Cuisiniers":
                    return @"SELECT * FROM Cuisinier";

                case "Plats":
                    return @"SELECT * FROM Plat";

                case "Clients":
                    return @"SELECT * FROM Client";

                case "Notes Moyennes":
                    return @"SELECT Utilisateur.Nom_User AS Nom_Cuisinier,
                            Utilisateur.Prenom_User AS Prenom_Cuisinier,
                            COALESCE(AVG(Note.Note), 0) AS Note_Moyenne
                            FROM Cuisinier
                            JOIN Utilisateur ON Cuisinier.ID_User = Utilisateur.ID_User
                            LEFT JOIN Note ON Cuisinier.ID_Cuisinier = Note.ID_Cuisinier
                            GROUP BY Cuisinier.ID_Cuisinier, Utilisateur.Nom_User, Utilisateur.Prenom_User
                            ORDER BY Note_Moyenne DESC;";

                default:
                    return @"SELECT *
                            FROM utilisateur
                            ORDER BY Nom_User,Prenom_User";
            }
        }

        private void ConfigurerDataGridView()
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;

        }

        private void bt_exporter_Click(object sender, EventArgs e)
        {
            if (comboBoxExport.SelectedItem is Utilisateur utilisateur)
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Fichier XML (*.xml)|*.xml",
                    Title = "Enregistrer l'utilisateur en XML",
                    FileName = $"{utilisateur.Prenom}_{utilisateur.Nom}.xml"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Utilisateur));
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        serializer.Serialize(writer, utilisateur);
                    }

                    MessageBox.Show("Utilisateur exporté avec succès !");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.");
            }
        }

        private void bt_exporter_MouseEnter(object sender, EventArgs e)
        {
            bt_exporter.BackColor = Color.White;
        }

        private void bt_exporter_MouseLeave(object sender, EventArgs e)
        {
            bt_exporter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void ChargerUtilisateurs()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_User, Nom_User, Prenom_User, Email, Mot_De_Passe, Adresse, Metro FROM Utilisateur";
                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new Utilisateur
                        {
                            ID_User = reader["ID_User"].ToString(),
                            Nom = reader["Nom_User"].ToString(),
                            Prenom = reader["Prenom_User"].ToString(),
                            Email = reader["Email"].ToString(),
                            MotDePasse = reader["Mot_De_Passe"].ToString(),
                            Adresse = reader["Adresse"].ToString(),
                            Metro = reader["Metro"].ToString()
                        };

                        comboBoxExport.Items.Add(user);
                    }
                }
            }
        }

        private void bt_exporttous_MouseEnter(object sender, EventArgs e)
        {
            bt_exporttous.BackColor = Color.White;
        }

        private void bt_exporttous_MouseLeave(object sender, EventArgs e)
        {
            bt_exporttous.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_exporttous_Click(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_User, Nom_User, Prenom_User, Email, Mot_De_Passe, Adresse, Metro FROM Utilisateur";
                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new Utilisateur
                        {
                            ID_User = reader["ID_User"].ToString(),
                            Nom = reader["Nom_User"].ToString(),
                            Prenom = reader["Prenom_User"].ToString(),
                            Email = reader["Email"].ToString(),
                            MotDePasse = reader["Mot_De_Passe"].ToString(),
                            Adresse = reader["Adresse"].ToString(),
                            Metro = reader["Metro"].ToString()
                        };
                        utilisateurs.Add(user);
                    }
                }
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Fichier XML (*.xml)|*.xml",
                Title = "Exporter tous les utilisateurs",
                FileName = "Tous_Utilisateurs.xml"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                var liste = new ListeUtilisateurs { Utilisateurs = utilisateurs };
                XmlSerializer serializer = new XmlSerializer(typeof(ListeUtilisateurs));

                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                {
                    serializer.Serialize(writer, liste);
                }

                MessageBox.Show("Tous les utilisateurs ont été exportés avec succès !");
            }
        }

        private void bt_import_MouseEnter(object sender, EventArgs e)
        {
            bt_import.BackColor = Color.White;
        }

        private void bt_import_MouseLeave(object sender, EventArgs e)
        {
            bt_import.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Fichier XML (*.xml)|*.xml",
                Title = "Importer des utilisateurs"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string cheminComplet = openFileDialog.FileName;

                    XmlSerializer serializer = new XmlSerializer(typeof(ListeUtilisateurs));
                    ListeUtilisateurs listeImportee;

                    using (StreamReader reader = new StreamReader(cheminComplet))
                    {
                        listeImportee = (ListeUtilisateurs)serializer.Deserialize(reader);
                    }

                    string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        foreach (var utilisateur in listeImportee.Utilisateurs)
                        {
                            MessageBox.Show(utilisateur.ID_User);
                            string checkQuery = "SELECT COUNT(*) FROM Utilisateur WHERE Email = @Email";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@Email", utilisateur.Email);
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (count == 0)
                                {
                                    string insertQuery = @"INSERT INTO Utilisateur (ID_User, Nom_User, Prenom_User, Email, Mot_De_Passe, Adresse, Metro) 
                                                   VALUES (@Id, @Nom, @Prenom, @Email, @Mdp, @Adresse, @Metro)";

                                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                                    {
                                        if (string.IsNullOrEmpty(utilisateur.ID_User))
                                        {
                                            utilisateur.ID_User = Guid.NewGuid().ToString("N");
                                        }
                                        insertCmd.Parameters.AddWithValue("@Id", utilisateur.ID_User);
                                        insertCmd.Parameters.AddWithValue("@Nom", utilisateur.Nom);
                                        insertCmd.Parameters.AddWithValue("@Prenom", utilisateur.Prenom);
                                        insertCmd.Parameters.AddWithValue("@Email", utilisateur.Email);
                                        insertCmd.Parameters.AddWithValue("@Mdp", utilisateur.MotDePasse);
                                        insertCmd.Parameters.AddWithValue("@Adresse", utilisateur.Adresse);
                                        insertCmd.Parameters.AddWithValue("@Metro", utilisateur.Metro);

                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Importation terminée. Les nouveaux utilisateurs ont été ajoutés.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'import : " + ex.Message);
                }
            }
        }
    }
}
