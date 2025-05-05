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

    public partial class Note : Form
    {
        private string nom;
        private string prenom;
        private string idUser;
        public Note(string nom, string prenom, string idUser)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
            this.idUser = idUser;
        }

        private void bt_retour_MouseEnter(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.White;
        }

        private void bt_retour_MouseLeave(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_retour_Click(object sender, EventArgs e)
        {
            AppUtilisateur utilisateur = new AppUtilisateur(nom, prenom, idUser);
            utilisateur.Show();
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

        private void bt_valider_Click(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
            string idClient = null;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID_Client FROM Client WHERE ID_User = @ID_User";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_User", idUser);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                        idClient = result.ToString();
                    else
                    {
                        MessageBox.Show("Ce client n'existe pas dans la table Client.");
                        return;
                    }
                }
            }
            string idCuisinier = comboBox.SelectedValue.ToString();
            string commentaire = txt_commentaire.Text.Trim();
            DateTime dateNote = DateTime.Now;

            if (!decimal.TryParse(txt_note.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal note))
            {
                MessageBox.Show("Note invalide. Entrez un nombre décimal (ex : 8.5).");
                return;
            }
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string insertQuery = @"INSERT INTO Note (ID_Client, ID_Cuisinier, Date_Note, Note, Commentaire)
                               VALUES (@ID_Client, @ID_Cuisinier, @Date_Note, @Note, @Commentaire)"
                ;

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Client", idClient);
                    cmd.Parameters.AddWithValue("@ID_Cuisinier", idCuisinier);
                    cmd.Parameters.AddWithValue("@Date_Note", dateNote);
                    cmd.Parameters.AddWithValue("@Note", note);
                    cmd.Parameters.AddWithValue("@Commentaire", commentaire);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Note enregistrée avec succès !");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de l'insertion : " + ex.Message);
                    }
                }
            }
        }

        private void Note_Load(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT Cuisinier.ID_Cuisinier, Utilisateur.Nom_User
            FROM Cuisinier
            INNER JOIN Utilisateur ON Cuisinier.ID_User = Utilisateur.ID_User";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = "Nom_User";
                comboBox.ValueMember = "ID_Cuisinier";
            }
        }
    }
}
