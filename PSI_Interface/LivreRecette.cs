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
    public partial class LivreRecette : Form
    {
        private string nom;
        private string prenom;
        private string idUser;
        private MySqlConnection codeSql;
        private MySqlDataAdapter adapter;
        public LivreRecette(string nom, string prenom, string idUser)
        {
            codeSql = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@");
            InitializeComponent();
            ChargerDonnees();
            this.nom = nom;
            this.prenom = prenom;
            this.idUser = idUser;
        }

        private void ChargerDonnees()
        {
            string requeteSQL = @"SELECT * FROM recette ORDER BY Portions";

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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_retour_Click(object sender, EventArgs e)
        {
            AppUtilisateur utilisateur = new AppUtilisateur(nom,prenom,idUser);
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
    }
}
