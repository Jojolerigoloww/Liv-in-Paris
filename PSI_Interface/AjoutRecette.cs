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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PSI_Interface
{
    public partial class AjoutRecette : Form
    {

        private string nom;
        private string prenom;
        private string idUser;
        private string nom_Plat;

        public AjoutRecette(string nom, string prenom, string idUser, string nom_Plat)
        {
            InitializeComponent();
            this.prenom = prenom;
            this.nom = nom;
            this.idUser = idUser;
            this.nom_Plat = nom_Plat;
        }

        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_retour_Click(object sender, EventArgs e)
        {
            AjoutPlat plat = new AjoutPlat(nom, prenom, idUser);
            plat.Show();
            this.Hide();
        }

        private void bt_plat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ingredient.Text) || string.IsNullOrWhiteSpace(txt_type.Text) || string.IsNullOrWhiteSpace(txt_nation.Text) ||
                string.IsNullOrWhiteSpace(txt_portion.Text) || string.IsNullOrWhiteSpace(txt_regime.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Id_Recette = Guid.NewGuid().ToString("N");
                string Ingredients = txt_ingredient.Text;
                string Nom_Recette = nom_Plat;
                string Type = txt_type.Text;
                string Nationalite = txt_nation.Text;
                string Portions = txt_portion.Text;
                string Regime = txt_regime.Text;

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=Bastien2109@";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string getIdCuisinierQuery = "SELECT ID_Cuisinier FROM Cuisinier WHERE ID_User = @ID_User";
                        MySqlCommand getIdCmd = new MySqlCommand(getIdCuisinierQuery, connection);
                        getIdCmd.Parameters.AddWithValue("@ID_User", idUser);

                        object result = getIdCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Cuisinier introuvable pour cet utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string Id_Cuisinier = result.ToString();

                        string query = "INSERT INTO livin.recette (ID_Recette, Nom_Recette, Ingrédients, Type_Plat, Nationalité, Portions, Régime_Alimentaire, ID_Cuisinier) VALUES (@Id, @Nom, @ingredients, @type, @nation, @portions, @regime, @IdC)";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", Id_Recette);
                            cmd.Parameters.AddWithValue("@Nom", Nom_Recette);
                            cmd.Parameters.AddWithValue("@ingredients", Ingredients);
                            cmd.Parameters.AddWithValue("@type", Type);
                            cmd.Parameters.AddWithValue("@nation", Nationalite);
                            cmd.Parameters.AddWithValue("@IdC", Id_Cuisinier);
                            cmd.Parameters.AddWithValue("@portions", Portions);
                            cmd.Parameters.AddWithValue("@regime", Regime);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Recette ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Effacer les champs après insertion
                                Id_Recette = "";
                                Nom_Recette = "";
                                Ingredients = "";
                                Type = "";
                                Portions = "";
                                Nationalite = "";
                                Portions = "";

                                AppCuisinier cuisinier = new AppCuisinier(nom, prenom, idUser);
                                cuisinier.Show();
                                this.Hide();
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

        private void bt_quitter_MouseEnter(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.White;
        }

        private void bt_quitter_MouseLeave(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_retour_MouseEnter(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.White;
        }

        private void bt_retour_MouseLeave(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_plat_MouseEnter(object sender, EventArgs e)
        {
            bt_plat.BackColor = Color.White;
        }

        private void bt_plat_MouseLeave(object sender, EventArgs e)
        {
            bt_plat.BackColor = Color.FromArgb(250, 191, 80);
        }
    }
}
