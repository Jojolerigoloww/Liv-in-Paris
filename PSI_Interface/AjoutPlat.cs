using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class AjoutPlat : Form
    {
        private string nom;
        private string prenom;
        private string idUser;
        public AjoutPlat(string nom, string prenom, string idUser)
        {
            InitializeComponent();
            this.prenom = prenom;
            this.nom = nom;
            this.idUser = idUser;
        }


        private void bt_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_retour_Click(object sender, EventArgs e)
        {
            AppCuisinier cuisinier = new AppCuisinier(nom, prenom, idUser);
            cuisinier.Show();
            this.Hide();
        }

        private void bt_plat_MouseEnter(object sender, EventArgs e)
        {
            bt_plat.BackColor = Color.White;
        }

        private void bt_plat_MouseLeave(object sender, EventArgs e)
        {
            bt_plat.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_retour_MouseEnter(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.White;
        }

        private void bt_retour_MouseLeave(object sender, EventArgs e)
        {
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_quitter_MouseEnter(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.White;
        }

        private void bt_quitter_MouseLeave(object sender, EventArgs e)
        {
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
        }

        private void bt_plat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nom.Text) || string.IsNullOrWhiteSpace(txt_prix.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker2.Text) || (string.IsNullOrWhiteSpace(radioButton1.Text) && string.IsNullOrWhiteSpace(radioButton2.Text)))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Id_Plat = Guid.NewGuid().ToString("N");
                string Nom_Plat = txt_nom.Text;
                DateTime Date_Creation_Plat = dateTimePicker1.Value;
                DateTime Date_Peremption_Plat = dateTimePicker2.Value;
                string Prix = txt_prix.Text;
                string Id_Ligne = "L9";

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

                        string query = "INSERT INTO livin.plat (ID_Plat, Nom_Plat, Date_Création, Date_Péremption, Prix, Photo, ID_Cuisinier) VALUES (@Id, @Nom, @Date_Creation, @Date_Peremption, @Prix, NULL, @IdC)";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", Id_Plat);
                            cmd.Parameters.AddWithValue("@Nom", Nom_Plat);
                            cmd.Parameters.AddWithValue("@Date_Creation", Date_Creation_Plat);
                            cmd.Parameters.AddWithValue("@Date_Peremption", Date_Peremption_Plat);
                            cmd.Parameters.AddWithValue("@Prix", Prix);
                            cmd.Parameters.AddWithValue("@IdC", Id_Cuisinier);
                            cmd.Parameters.AddWithValue("@IdL", Id_Ligne);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Plat ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Effacer les champs après insertion
                                Id_Plat = "";
                                Nom_Plat = "";
                                Prix = "";

                                if (radioButton1.Checked) 
                                {
                                    AjoutRecette recette = new AjoutRecette(nom, prenom, idUser, Nom_Plat);
                                    recette.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    AppCuisinier cuisinier = new AppCuisinier(nom, prenom, idUser);
                                    cuisinier.Show();
                                    this.Hide();
                                }    
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
