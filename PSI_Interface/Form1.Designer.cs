namespace PSI_Interface
{
    partial class InterfaceLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfaceLogin));
            lbl_titre = new Label();
            bt_quitter = new Button();
            menuStrip1 = new MenuStrip();
            identificationToolStripMenuItem = new ToolStripMenuItem();
            identifiantToolStripMenuItem = new ToolStripMenuItem();
            motDePasseToolStripMenuItem = new ToolStripMenuItem();
            lbl_Identifiant = new Label();
            txt_identifiant = new TextBox();
            lbl_MotDePasse = new Label();
            txt_MotDePasse = new TextBox();
            link_NoAccount = new LinkLabel();
            grp_identification = new GroupBox();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            grp_identification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_titre
            // 
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(216, 50);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(279, 65);
            lbl_titre.TabIndex = 0;
            lbl_titre.Text = "LIVIN PARIS";
            lbl_titre.Click += label1_Click;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(255, 128, 128);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(517, 482);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(191, 50);
            bt_quitter.TabIndex = 5;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { identificationToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(765, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // identificationToolStripMenuItem
            // 
            identificationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { identifiantToolStripMenuItem, motDePasseToolStripMenuItem });
            identificationToolStripMenuItem.Name = "identificationToolStripMenuItem";
            identificationToolStripMenuItem.Size = new Size(89, 20);
            identificationToolStripMenuItem.Text = "Identification";
            // 
            // identifiantToolStripMenuItem
            // 
            identifiantToolStripMenuItem.Name = "identifiantToolStripMenuItem";
            identifiantToolStripMenuItem.Size = new Size(180, 22);
            identifiantToolStripMenuItem.Text = "Identifiant";
            // 
            // motDePasseToolStripMenuItem
            // 
            motDePasseToolStripMenuItem.Name = "motDePasseToolStripMenuItem";
            motDePasseToolStripMenuItem.Size = new Size(180, 22);
            motDePasseToolStripMenuItem.Text = "Mot de Passe";
            // 
            // lbl_Identifiant
            // 
            lbl_Identifiant.AutoSize = true;
            lbl_Identifiant.BackColor = Color.FromArgb(250, 191, 80);
            lbl_Identifiant.Font = new Font("Segoe UI", 14F);
            lbl_Identifiant.Location = new Point(19, 23);
            lbl_Identifiant.Name = "lbl_Identifiant";
            lbl_Identifiant.Size = new Size(98, 25);
            lbl_Identifiant.TabIndex = 1;
            lbl_Identifiant.Text = "Identifiant";
            // 
            // txt_identifiant
            // 
            txt_identifiant.Location = new Point(19, 69);
            txt_identifiant.Name = "txt_identifiant";
            txt_identifiant.Size = new Size(271, 27);
            txt_identifiant.TabIndex = 2;
            // 
            // lbl_MotDePasse
            // 
            lbl_MotDePasse.AutoSize = true;
            lbl_MotDePasse.BackColor = Color.FromArgb(250, 191, 80);
            lbl_MotDePasse.Font = new Font("Segoe UI", 14F);
            lbl_MotDePasse.Location = new Point(19, 113);
            lbl_MotDePasse.Name = "lbl_MotDePasse";
            lbl_MotDePasse.Size = new Size(123, 25);
            lbl_MotDePasse.TabIndex = 3;
            lbl_MotDePasse.Text = "Mot de Passe";
            // 
            // txt_MotDePasse
            // 
            txt_MotDePasse.Location = new Point(21, 160);
            txt_MotDePasse.Name = "txt_MotDePasse";
            txt_MotDePasse.Size = new Size(272, 27);
            txt_MotDePasse.TabIndex = 4;
            // 
            // link_NoAccount
            // 
            link_NoAccount.AutoSize = true;
            link_NoAccount.Location = new Point(21, 211);
            link_NoAccount.Name = "link_NoAccount";
            link_NoAccount.Size = new Size(325, 20);
            link_NoAccount.TabIndex = 6;
            link_NoAccount.TabStop = true;
            link_NoAccount.Text = "Vous n'avez pas encore de compte ? En créer un";
            // 
            // grp_identification
            // 
            grp_identification.BackColor = Color.FromArgb(250, 191, 80);
            grp_identification.Controls.Add(link_NoAccount);
            grp_identification.Controls.Add(txt_MotDePasse);
            grp_identification.Controls.Add(lbl_MotDePasse);
            grp_identification.Controls.Add(txt_identifiant);
            grp_identification.Controls.Add(lbl_Identifiant);
            grp_identification.FlatStyle = FlatStyle.Flat;
            grp_identification.Font = new Font("Segoe UI", 11F);
            grp_identification.Location = new Point(21, 178);
            grp_identification.Margin = new Padding(5, 5, 5, 4);
            grp_identification.Name = "grp_identification";
            grp_identification.Size = new Size(389, 282);
            grp_identification.TabIndex = 8;
            grp_identification.TabStop = false;
            grp_identification.Text = "Bienvenue";
            grp_identification.Enter += groupBox1_Enter;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleRole = AccessibleRole.None;
            pictureBox1.Enabled = false;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(459, 178);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(275, 282);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // InterfaceLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(765, 578);
            Controls.Add(pictureBox1);
            Controls.Add(grp_identification);
            Controls.Add(bt_quitter);
            Controls.Add(lbl_titre);
            Controls.Add(menuStrip1);
            Enabled = false;
            MainMenuStrip = menuStrip1;
            Name = "InterfaceLogin";
            Text = "Liv'in Paris";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grp_identification.ResumeLayout(false);
            grp_identification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre;
        private Button bt_quitter;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem identificationToolStripMenuItem;
        private ToolStripMenuItem identifiantToolStripMenuItem;
        private ToolStripMenuItem motDePasseToolStripMenuItem;
        private Label lbl_Identifiant;
        private TextBox txt_identifiant;
        private Label lbl_MotDePasse;
        private TextBox txt_MotDePasse;
        private LinkLabel link_NoAccount;
        private GroupBox grp_identification;
        private PictureBox pictureBox1;
    }
}
