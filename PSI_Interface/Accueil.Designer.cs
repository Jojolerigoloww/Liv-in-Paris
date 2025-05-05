namespace PSI_Interface
{
    partial class Accueil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
            lbl_email = new Label();
            txt_email = new TextBox();
            lbl_MotDePasse = new Label();
            txt_MotDePasse = new TextBox();
            link_NoAccount = new LinkLabel();
            bt_valider = new Button();
            bt_quitter = new Button();
            lbl_titre = new Label();
            pictureBox1 = new PictureBox();
            comboBox_statut = new ComboBox();
            lbl_statut = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.FromArgb(250, 191, 80);
            lbl_email.Font = new Font("Segoe UI", 14F);
            lbl_email.Location = new Point(24, 231);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(71, 32);
            lbl_email.TabIndex = 1;
            lbl_email.Text = "Email";
            // 
            // txt_email
            // 
            txt_email.Location = new Point(24, 291);
            txt_email.Margin = new Padding(3, 4, 3, 4);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(310, 27);
            txt_email.TabIndex = 2;
            // 
            // lbl_MotDePasse
            // 
            lbl_MotDePasse.AutoSize = true;
            lbl_MotDePasse.BackColor = Color.FromArgb(250, 191, 80);
            lbl_MotDePasse.Font = new Font("Segoe UI", 14F);
            lbl_MotDePasse.Location = new Point(24, 357);
            lbl_MotDePasse.Name = "lbl_MotDePasse";
            lbl_MotDePasse.Size = new Size(156, 32);
            lbl_MotDePasse.TabIndex = 3;
            lbl_MotDePasse.Text = "Mot de Passe";
            // 
            // txt_MotDePasse
            // 
            txt_MotDePasse.Location = new Point(24, 413);
            txt_MotDePasse.Margin = new Padding(3, 4, 3, 4);
            txt_MotDePasse.Name = "txt_MotDePasse";
            txt_MotDePasse.Size = new Size(310, 27);
            txt_MotDePasse.TabIndex = 4;
            // 
            // link_NoAccount
            // 
            link_NoAccount.ActiveLinkColor = Color.FromArgb(250, 191, 80);
            link_NoAccount.AutoSize = true;
            link_NoAccount.Font = new Font("Segoe UI", 10F);
            link_NoAccount.LinkColor = Color.FromArgb(250, 191, 80);
            link_NoAccount.Location = new Point(24, 581);
            link_NoAccount.Name = "link_NoAccount";
            link_NoAccount.Size = new Size(380, 23);
            link_NoAccount.TabIndex = 6;
            link_NoAccount.TabStop = true;
            link_NoAccount.Text = "Vous n'avez pas encore de compte ? En créer un";
            link_NoAccount.VisitedLinkColor = Color.FromArgb(250, 191, 80);
            link_NoAccount.LinkClicked += link_NoAccount_LinkClicked;
            link_NoAccount.MouseEnter += link_NoAccount_MouseEnter;
            link_NoAccount.MouseLeave += link_NoAccount_MouseLeave;
            // 
            // bt_valider
            // 
            bt_valider.BackColor = Color.FromArgb(250, 191, 80);
            bt_valider.Font = new Font("Segoe UI", 14F);
            bt_valider.Location = new Point(24, 648);
            bt_valider.Margin = new Padding(3, 4, 3, 4);
            bt_valider.Name = "bt_valider";
            bt_valider.Size = new Size(199, 72);
            bt_valider.TabIndex = 10;
            bt_valider.Text = "Valider";
            bt_valider.UseVisualStyleBackColor = false;
            bt_valider.Click += bt_valider_Click;
            bt_valider.MouseEnter += bt_valider_MouseEnter;
            bt_valider.MouseLeave += bt_valider_MouseLeave;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(640, 648);
            bt_quitter.Margin = new Padding(3, 4, 3, 4);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(199, 72);
            bt_quitter.TabIndex = 11;
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
            lbl_titre.Location = new Point(16, 77);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(346, 81);
            lbl_titre.TabIndex = 0;
            lbl_titre.Text = "LIVIN PARIS";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(518, 161);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(363, 404);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // comboBox_statut
            // 
            comboBox_statut.FormattingEnabled = true;
            comboBox_statut.Items.AddRange(new object[] { "Client", "Cuisinier", "Admin" });
            comboBox_statut.Location = new Point(24, 537);
            comboBox_statut.Name = "comboBox_statut";
            comboBox_statut.Size = new Size(310, 28);
            comboBox_statut.TabIndex = 21;
            // 
            // lbl_statut
            // 
            lbl_statut.AutoSize = true;
            lbl_statut.BackColor = Color.FromArgb(250, 191, 80);
            lbl_statut.Font = new Font("Segoe UI", 14F);
            lbl_statut.Location = new Point(24, 479);
            lbl_statut.Name = "lbl_statut";
            lbl_statut.Size = new Size(76, 32);
            lbl_statut.TabIndex = 22;
            lbl_statut.Text = "Statut";
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(954, 781);
            Controls.Add(lbl_statut);
            Controls.Add(comboBox_statut);
            Controls.Add(pictureBox1);
            Controls.Add(lbl_titre);
            Controls.Add(bt_quitter);
            Controls.Add(bt_valider);
            Controls.Add(link_NoAccount);
            Controls.Add(txt_MotDePasse);
            Controls.Add(lbl_MotDePasse);
            Controls.Add(txt_email);
            Controls.Add(lbl_email);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Accueil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_email;
        private TextBox txt_email;
        private Label lbl_MotDePasse;
        private TextBox txt_MotDePasse;
        private LinkLabel link_NoAccount;
        private Button bt_valider;
        private Button bt_quitter;
        private Label lbl_titre;
        private PictureBox pictureBox1;
        private ComboBox comboBox_statut;
        private Label lbl_statut;
    }
}
