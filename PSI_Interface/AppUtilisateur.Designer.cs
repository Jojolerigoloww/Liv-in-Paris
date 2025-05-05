namespace PSI_Interface
{
    partial class AppUtilisateur
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
            bt_quitter = new Button();
            lbl_titre = new Label();
            bt_recette = new Button();
            bt_carte = new Button();
            bt_commande = new Button();
            SuspendLayout();
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(614, 384);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(174, 54);
            bt_quitter.TabIndex = 12;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            bt_quitter.MouseEnter += bt_quitter_MouseEnter;
            bt_quitter.MouseLeave += bt_quitter_MouseLeave;
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(12, 12);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(247, 65);
            lbl_titre.TabIndex = 13;
            lbl_titre.Text = "Bienvenue";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_recette
            // 
            bt_recette.BackColor = Color.FromArgb(250, 191, 80);
            bt_recette.Font = new Font("Segoe UI", 14F);
            bt_recette.Location = new Point(614, 12);
            bt_recette.Name = "bt_recette";
            bt_recette.Size = new Size(174, 54);
            bt_recette.TabIndex = 14;
            bt_recette.Text = "Livre des Recettes";
            bt_recette.UseVisualStyleBackColor = false;
            bt_recette.Click += bt_recette_Click;
            bt_recette.MouseEnter += bt_recette_MouseEnter;
            bt_recette.MouseLeave += bt_recette_MouseLeave;
            // 
            // bt_carte
            // 
            bt_carte.BackColor = Color.FromArgb(250, 191, 80);
            bt_carte.Font = new Font("Segoe UI", 14F);
            bt_carte.Location = new Point(614, 72);
            bt_carte.Name = "bt_carte";
            bt_carte.Size = new Size(174, 54);
            bt_carte.TabIndex = 15;
            bt_carte.Text = "Carte du métro";
            bt_carte.UseVisualStyleBackColor = false;
            bt_carte.Click += bt_carte_Click;
            bt_carte.MouseEnter += bt_carte_MouseEnter;
            bt_carte.MouseLeave += bt_carte_MouseLeave;
            // 
            // bt_commande
            // 
            bt_commande.BackColor = Color.FromArgb(250, 191, 80);
            bt_commande.Font = new Font("Segoe UI", 14F);
            bt_commande.Location = new Point(614, 132);
            bt_commande.Name = "bt_commande";
            bt_commande.Size = new Size(174, 54);
            bt_commande.TabIndex = 16;
            bt_commande.Text = "Commander";
            bt_commande.UseVisualStyleBackColor = false;
            bt_commande.Click += bt_commander_Click;
            bt_commande.MouseEnter += bt_commande_MouseEnter;
            bt_commande.MouseLeave += bt_commande_MouseLeave;
            // 
            // AppUtilisateur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(bt_commande);
            Controls.Add(bt_carte);
            Controls.Add(bt_recette);
            Controls.Add(lbl_titre);
            Controls.Add(bt_quitter);
            Name = "AppUtilisateur";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppPrincipale";
            Load += AppPrincipale_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button bt_quitter;
        private Label lbl_titre;
        private Button bt_recette;
        private Button bt_carte;
        private Button bt_commande;
    }
}