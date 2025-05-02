namespace PSI_Interface
{
    partial class CréationCompte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CréationCompte));
            dataGridViewUtilisateurs = new DataGridView();
            lbl_titre = new Label();
            lbl_nom = new Label();
            lbl_prenom = new Label();
            lbl_email = new Label();
            lbl_adresse = new Label();
            lbl_metro = new Label();
            lbl_mdp = new Label();
            bt_quitter = new Button();
            txt_nom = new TextBox();
            txt_prenom = new TextBox();
            txt_adresse = new TextBox();
            txt_email = new TextBox();
            txt_mdp = new TextBox();
            txt_metro = new TextBox();
            pictureBox1 = new PictureBox();
            bt_valider = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUtilisateurs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUtilisateurs
            // 
            dataGridViewUtilisateurs.ColumnHeadersHeight = 29;
            dataGridViewUtilisateurs.Location = new Point(22, 84);
            dataGridViewUtilisateurs.Margin = new Padding(3, 4, 3, 4);
            dataGridViewUtilisateurs.Name = "dataGridViewUtilisateurs";
            dataGridViewUtilisateurs.RowHeadersWidth = 51;
            dataGridViewUtilisateurs.Size = new Size(571, 400);
            dataGridViewUtilisateurs.TabIndex = 0;
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(32, 29);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(561, 81);
            lbl_titre.TabIndex = 1;
            lbl_titre.Text = "Création du compte";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_nom
            // 
            lbl_nom.AutoSize = true;
            lbl_nom.BackColor = Color.FromArgb(250, 191, 80);
            lbl_nom.Font = new Font("Segoe UI", 12F);
            lbl_nom.Location = new Point(32, 161);
            lbl_nom.Name = "lbl_nom";
            lbl_nom.Size = new Size(56, 28);
            lbl_nom.TabIndex = 2;
            lbl_nom.Text = "Nom";
            // 
            // lbl_prenom
            // 
            lbl_prenom.AutoSize = true;
            lbl_prenom.BackColor = Color.FromArgb(250, 191, 80);
            lbl_prenom.Font = new Font("Segoe UI", 12F);
            lbl_prenom.Location = new Point(32, 293);
            lbl_prenom.Name = "lbl_prenom";
            lbl_prenom.Size = new Size(80, 28);
            lbl_prenom.TabIndex = 3;
            lbl_prenom.Text = "Prénom";
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.FromArgb(250, 191, 80);
            lbl_email.Font = new Font("Segoe UI", 12F);
            lbl_email.Location = new Point(296, 161);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(59, 28);
            lbl_email.TabIndex = 5;
            lbl_email.Text = "Email";
            // 
            // lbl_adresse
            // 
            lbl_adresse.AutoSize = true;
            lbl_adresse.BackColor = Color.FromArgb(250, 191, 80);
            lbl_adresse.Font = new Font("Segoe UI", 12F);
            lbl_adresse.Location = new Point(32, 428);
            lbl_adresse.Name = "lbl_adresse";
            lbl_adresse.Size = new Size(80, 28);
            lbl_adresse.TabIndex = 4;
            lbl_adresse.Text = "Adresse";
            // 
            // lbl_metro
            // 
            lbl_metro.AutoSize = true;
            lbl_metro.BackColor = Color.FromArgb(250, 191, 80);
            lbl_metro.Font = new Font("Segoe UI", 12F);
            lbl_metro.Location = new Point(296, 428);
            lbl_metro.Name = "lbl_metro";
            lbl_metro.Size = new Size(269, 28);
            lbl_metro.TabIndex = 7;
            lbl_metro.Text = "Arrêt de Métro le plus proche";
            // 
            // lbl_mdp
            // 
            lbl_mdp.AutoSize = true;
            lbl_mdp.BackColor = Color.FromArgb(250, 191, 80);
            lbl_mdp.Font = new Font("Segoe UI", 12F);
            lbl_mdp.Location = new Point(296, 293);
            lbl_mdp.Name = "lbl_mdp";
            lbl_mdp.Size = new Size(127, 28);
            lbl_mdp.TabIndex = 6;
            lbl_mdp.Text = "Mot de Passe";
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(665, 40);
            bt_quitter.Margin = new Padding(3, 4, 3, 4);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(199, 72);
            bt_quitter.TabIndex = 12;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            // 
            // txt_nom
            // 
            txt_nom.Location = new Point(30, 217);
            txt_nom.Margin = new Padding(3, 4, 3, 4);
            txt_nom.Name = "txt_nom";
            txt_nom.Size = new Size(201, 27);
            txt_nom.TabIndex = 13;
            // 
            // txt_prenom
            // 
            txt_prenom.Location = new Point(30, 347);
            txt_prenom.Margin = new Padding(3, 4, 3, 4);
            txt_prenom.Name = "txt_prenom";
            txt_prenom.Size = new Size(201, 27);
            txt_prenom.TabIndex = 14;
            // 
            // txt_adresse
            // 
            txt_adresse.Location = new Point(30, 492);
            txt_adresse.Margin = new Padding(3, 4, 3, 4);
            txt_adresse.Name = "txt_adresse";
            txt_adresse.Size = new Size(201, 27);
            txt_adresse.TabIndex = 15;
            // 
            // txt_email
            // 
            txt_email.Location = new Point(296, 217);
            txt_email.Margin = new Padding(3, 4, 3, 4);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(201, 27);
            txt_email.TabIndex = 16;
            // 
            // txt_mdp
            // 
            txt_mdp.Location = new Point(296, 347);
            txt_mdp.Margin = new Padding(3, 4, 3, 4);
            txt_mdp.Name = "txt_mdp";
            txt_mdp.Size = new Size(201, 27);
            txt_mdp.TabIndex = 17;
            // 
            // txt_metro
            // 
            txt_metro.Location = new Point(296, 492);
            txt_metro.Margin = new Padding(3, 4, 3, 4);
            txt_metro.Name = "txt_metro";
            txt_metro.Size = new Size(201, 27);
            txt_metro.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(656, 161);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 256);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // bt_valider
            // 
            bt_valider.BackColor = Color.FromArgb(250, 191, 80);
            bt_valider.Font = new Font("Segoe UI", 14F);
            bt_valider.Location = new Point(665, 465);
            bt_valider.Margin = new Padding(3, 4, 3, 4);
            bt_valider.Name = "bt_valider";
            bt_valider.Size = new Size(199, 72);
            bt_valider.TabIndex = 20;
            bt_valider.Text = "Valider";
            bt_valider.UseVisualStyleBackColor = false;
            bt_valider.Click += bt_valider_Click;
            // 
            // CréationCompte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(914, 600);
            //Controls.Add(dataGridViewUtilisateurs); //(Ligne a passer en commentaire pour supprimer la liste des utilisateurs)
            Controls.Add(bt_valider);
            Controls.Add(pictureBox1);
            Controls.Add(txt_metro);
            Controls.Add(txt_mdp);
            Controls.Add(txt_email);
            Controls.Add(txt_adresse);
            Controls.Add(txt_prenom);
            Controls.Add(txt_nom);
            Controls.Add(bt_quitter);
            Controls.Add(lbl_metro);
            Controls.Add(lbl_mdp);
            Controls.Add(lbl_email);
            Controls.Add(lbl_adresse);
            Controls.Add(lbl_prenom);
            Controls.Add(lbl_nom);
            Controls.Add(lbl_titre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CréationCompte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CréationCompte";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUtilisateurs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre;
        private Label lbl_nom;
        private Label lbl_prenom;
        private Label lbl_email;
        private Label lbl_adresse;
        private Label lbl_metro;
        private Label lbl_mdp;
        private Button bt_quitter;
        private TextBox txt_nom;
        private TextBox txt_prenom;
        private TextBox txt_adresse;
        private TextBox txt_email;
        private TextBox txt_mdp;
        private TextBox txt_metro;
        private PictureBox pictureBox1;
        private Button bt_valider;
    }
}