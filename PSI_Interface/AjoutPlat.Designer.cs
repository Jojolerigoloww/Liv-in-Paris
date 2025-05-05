namespace PSI_Interface
{
    partial class AjoutPlat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjoutPlat));
            lbl_titre = new Label();
            txt_prix = new TextBox();
            txt_nom = new TextBox();
            lbl_prix = new Label();
            lbl_date_peremption = new Label();
            lbl_date_creation = new Label();
            lbl_nom = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            lbl_recette = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            bt_plat = new Button();
            bt_retour = new Button();
            pictureBox1 = new PictureBox();
            bt_quitter = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(12, 9);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(344, 65);
            lbl_titre.TabIndex = 2;
            lbl_titre.Text = "Ajouter un plat";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_prix
            // 
            txt_prix.Location = new Point(243, 169);
            txt_prix.Name = "txt_prix";
            txt_prix.Size = new Size(176, 23);
            txt_prix.TabIndex = 28;
            // 
            // txt_nom
            // 
            txt_nom.Location = new Point(10, 169);
            txt_nom.Name = "txt_nom";
            txt_nom.Size = new Size(176, 23);
            txt_nom.TabIndex = 25;
            // 
            // lbl_prix
            // 
            lbl_prix.AutoSize = true;
            lbl_prix.BackColor = Color.FromArgb(250, 191, 80);
            lbl_prix.Font = new Font("Segoe UI", 12F);
            lbl_prix.Location = new Point(243, 127);
            lbl_prix.Name = "lbl_prix";
            lbl_prix.Size = new Size(36, 21);
            lbl_prix.TabIndex = 22;
            lbl_prix.Text = "Prix";
            // 
            // lbl_date_peremption
            // 
            lbl_date_peremption.AutoSize = true;
            lbl_date_peremption.BackColor = Color.FromArgb(250, 191, 80);
            lbl_date_peremption.Font = new Font("Segoe UI", 12F);
            lbl_date_peremption.Location = new Point(243, 226);
            lbl_date_peremption.Name = "lbl_date_peremption";
            lbl_date_peremption.Size = new Size(148, 21);
            lbl_date_peremption.TabIndex = 21;
            lbl_date_peremption.Text = "Date de péremption";
            // 
            // lbl_date_creation
            // 
            lbl_date_creation.AutoSize = true;
            lbl_date_creation.BackColor = Color.FromArgb(250, 191, 80);
            lbl_date_creation.Font = new Font("Segoe UI", 12F);
            lbl_date_creation.Location = new Point(12, 226);
            lbl_date_creation.Name = "lbl_date_creation";
            lbl_date_creation.Size = new Size(123, 21);
            lbl_date_creation.TabIndex = 20;
            lbl_date_creation.Text = "Date de création";
            // 
            // lbl_nom
            // 
            lbl_nom.AutoSize = true;
            lbl_nom.BackColor = Color.FromArgb(250, 191, 80);
            lbl_nom.Font = new Font("Segoe UI", 12F);
            lbl_nom.Location = new Point(12, 127);
            lbl_nom.Name = "lbl_nom";
            lbl_nom.Size = new Size(45, 21);
            lbl_nom.TabIndex = 19;
            lbl_nom.Text = "Nom";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 266);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(176, 23);
            dateTimePicker1.TabIndex = 29;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(243, 266);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(176, 23);
            dateTimePicker2.TabIndex = 30;
            // 
            // lbl_recette
            // 
            lbl_recette.AutoSize = true;
            lbl_recette.BackColor = Color.FromArgb(250, 191, 80);
            lbl_recette.Font = new Font("Segoe UI", 12F);
            lbl_recette.Location = new Point(10, 328);
            lbl_recette.Name = "lbl_recette";
            lbl_recette.Size = new Size(381, 21);
            lbl_recette.TabIndex = 31;
            lbl_recette.Text = "Voulez-vous rajouter votre plat à la liste des recettes ?";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.White;
            radioButton1.Location = new Point(10, 369);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(44, 19);
            radioButton1.TabIndex = 32;
            radioButton1.TabStop = true;
            radioButton1.Text = "Oui";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.White;
            radioButton2.Location = new Point(243, 369);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(48, 19);
            radioButton2.TabIndex = 33;
            radioButton2.TabStop = true;
            radioButton2.Text = "Non";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // bt_plat
            // 
            bt_plat.BackColor = Color.FromArgb(250, 191, 80);
            bt_plat.Font = new Font("Segoe UI", 14F);
            bt_plat.Location = new Point(614, 384);
            bt_plat.Name = "bt_plat";
            bt_plat.Size = new Size(174, 54);
            bt_plat.TabIndex = 34;
            bt_plat.Text = "Ajouter";
            bt_plat.UseVisualStyleBackColor = false;
            bt_plat.Click += bt_plat_Click;
            bt_plat.MouseEnter += bt_plat_MouseEnter;
            bt_plat.MouseLeave += bt_plat_MouseLeave;
            // 
            // bt_retour
            // 
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
            bt_retour.Font = new Font("Segoe UI", 14F);
            bt_retour.Location = new Point(614, 86);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(174, 54);
            bt_retour.TabIndex = 37;
            bt_retour.Text = "Retour";
            bt_retour.UseVisualStyleBackColor = false;
            bt_retour.Click += bt_retour_Click;
            bt_retour.MouseEnter += bt_retour_MouseEnter;
            bt_retour.MouseLeave += bt_retour_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(610, 180);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 169);
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(614, 12);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(174, 54);
            bt_quitter.TabIndex = 35;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            bt_quitter.MouseEnter += bt_quitter_MouseEnter;
            bt_quitter.MouseLeave += bt_quitter_MouseLeave;
            // 
            // AjoutPlat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(bt_retour);
            Controls.Add(pictureBox1);
            Controls.Add(bt_quitter);
            Controls.Add(bt_plat);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(lbl_recette);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(txt_prix);
            Controls.Add(txt_nom);
            Controls.Add(lbl_prix);
            Controls.Add(lbl_date_peremption);
            Controls.Add(lbl_date_creation);
            Controls.Add(lbl_nom);
            Controls.Add(lbl_titre);
            Name = "AjoutPlat";
            Text = "AjoutPlat";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre;
        private TextBox txt_prix;
        private TextBox txt_nom;
        private Label lbl_prix;
        private Label lbl_date_peremption;
        private Label lbl_date_creation;
        private Label lbl_nom;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label lbl_recette;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button bt_plat;
        private Button bt_retour;
        private PictureBox pictureBox1;
        private Button bt_quitter;
    }
}