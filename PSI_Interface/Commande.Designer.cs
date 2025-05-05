namespace PSI_Interface
{
    partial class Commande
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
            bt_retour = new Button();
            lbl_titre = new Label();
            comboBoxPlats = new ComboBox();
            lbl_choix = new Label();
            bt_valider = new Button();
            SuspendLayout();
            // 
            // bt_retour
            // 
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
            bt_retour.Font = new Font("Segoe UI", 14F);
            bt_retour.Location = new Point(702, 12);
            bt_retour.Margin = new Padding(3, 4, 3, 4);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(199, 72);
            bt_retour.TabIndex = 42;
            bt_retour.Text = "Retour";
            bt_retour.UseVisualStyleBackColor = false;
            bt_retour.Click += bt_retour_Click;
            bt_retour.MouseEnter += bt_retour_MouseEnter;
            bt_retour.MouseLeave += bt_retour_MouseLeave;
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(14, 12);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(363, 81);
            lbl_titre.TabIndex = 41;
            lbl_titre.Text = "Commander";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxPlats
            // 
            comboBoxPlats.FormattingEnabled = true;
            comboBoxPlats.Location = new Point(14, 216);
            comboBoxPlats.Margin = new Padding(3, 4, 3, 4);
            comboBoxPlats.Name = "comboBoxPlats";
            comboBoxPlats.Size = new Size(170, 28);
            comboBoxPlats.TabIndex = 43;
            // 
            // lbl_choix
            // 
            lbl_choix.AutoSize = true;
            lbl_choix.BackColor = Color.FromArgb(250, 191, 80);
            lbl_choix.Font = new Font("Segoe UI", 12F);
            lbl_choix.Location = new Point(14, 163);
            lbl_choix.Name = "lbl_choix";
            lbl_choix.Size = new Size(238, 28);
            lbl_choix.TabIndex = 44;
            lbl_choix.Text = "Choisissez le plat souhaité";
            // 
            // bt_valider
            // 
            bt_valider.BackColor = Color.FromArgb(250, 191, 80);
            bt_valider.Font = new Font("Segoe UI", 14F);
            bt_valider.Location = new Point(702, 512);
            bt_valider.Margin = new Padding(3, 4, 3, 4);
            bt_valider.Name = "bt_valider";
            bt_valider.Size = new Size(199, 72);
            bt_valider.TabIndex = 45;
            bt_valider.Text = "Valider";
            bt_valider.UseVisualStyleBackColor = false;
            bt_valider.Click += bt_valider_Click;
            bt_valider.MouseEnter += bt_valider_MouseEnter;
            bt_valider.MouseLeave += bt_valider_MouseLeave;
            // 
            // Commande
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(914, 600);
            Controls.Add(bt_valider);
            Controls.Add(lbl_choix);
            Controls.Add(comboBoxPlats);
            Controls.Add(bt_retour);
            Controls.Add(lbl_titre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Commande";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Commande";
            Load += Commande_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bt_retour;
        private Label lbl_titre;
        private ComboBox comboBoxPlats;
        private Label lbl_choix;
        private Button bt_valider;
    }
}