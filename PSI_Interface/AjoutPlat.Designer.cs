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
            lbl_titre.Location = new Point(14, 12);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(431, 81);
            lbl_titre.TabIndex = 2;
            lbl_titre.Text = "Ajouter un plat";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_prix
            // 
            txt_prix.Location = new Point(278, 225);
            txt_prix.Margin = new Padding(3, 4, 3, 4);
            txt_prix.Name = "txt_prix";
            txt_prix.Size = new Size(201, 27);
            txt_prix.TabIndex = 28;
            // 
            // txt_nom
            // 
            txt_nom.Location = new Point(11, 225);
            txt_nom.Margin = new Padding(3, 4, 3, 4);
            txt_nom.Name = "txt_nom";
            txt_nom.Size = new Size(201, 27);
            txt_nom.TabIndex = 25;
            // 
            // lbl_prix
            // 
            lbl_prix.AutoSize = true;
            lbl_prix.BackColor = Color.FromArgb(250, 191, 80);
            lbl_prix.Font = new Font("Segoe UI", 12F);
            lbl_prix.Location = new Point(278, 169);
            lbl_prix.Name = "lbl_prix";
            lbl_prix.Size = new Size(44, 28);
            lbl_prix.TabIndex = 22;
            lbl_prix.Text = "Prix";
            // 
            // lbl_date_peremption
            // 
            lbl_date_peremption.AutoSize = true;
            lbl_date_peremption.BackColor = Color.FromArgb(250, 191, 80);
            lbl_date_peremption.Font = new Font("Segoe UI", 12F);
            lbl_date_peremption.Location = new Point(278, 301);
            lbl_date_peremption.Name = "lbl_date_peremption";
            lbl_date_peremption.Size = new Size(188, 28);
            lbl_date_peremption.TabIndex = 21;
            lbl_date_peremption.Text = "Date de péremption";
            // 
            // lbl_date_creation
            // 
            lbl_date_creation.AutoSize = true;
            lbl_date_creation.BackColor = Color.FromArgb(250, 191, 80);
            lbl_date_creation.Font = new Font("Segoe UI", 12F);
            lbl_date_creation.Location = new Point(14, 301);
            lbl_date_creation.Name = "lbl_date_creation";
            lbl_date_creation.Size = new Size(156, 28);
            lbl_date_creation.TabIndex = 20;
            lbl_date_creation.Text = "Date de création";
            // 
            // lbl_nom
            // 
            lbl_nom.AutoSize = true;
            lbl_nom.BackColor = Color.FromArgb(250, 191, 80);
            lbl_nom.Font = new Font("Segoe UI", 12F);
            lbl_nom.Location = new Point(14, 169);
            lbl_nom.Name = "lbl_nom";
            lbl_nom.Size = new Size(56, 28);
            lbl_nom.TabIndex = 19;
            lbl_nom.Text = "Nom";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(14, 355);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(201, 27);
            dateTimePicker1.TabIndex = 29;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(278, 355);
            dateTimePicker2.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(201, 27);
            dateTimePicker2.TabIndex = 30;
            // 
            // lbl_recette
            // 
            lbl_recette.AutoSize = true;
            lbl_recette.BackColor = Color.FromArgb(250, 191, 80);
            lbl_recette.Font = new Font("Segoe UI", 12F);
            lbl_recette.Location = new Point(11, 437);
            lbl_recette.Name = "lbl_recette";
            lbl_recette.Size = new Size(480, 28);
            lbl_recette.TabIndex = 31;
            lbl_recette.Text = "Voulez-vous rajouter votre plat à la liste des recettes ?";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.White;
            radioButton1.Location = new Point(11, 492);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(53, 24);
            radioButton1.TabIndex = 32;
            radioButton1.TabStop = true;
            radioButton1.Text = "Oui";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.White;
            radioButton2.Location = new Point(278, 492);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(58, 24);
            radioButton2.TabIndex = 33;
            radioButton2.TabStop = true;
            radioButton2.Text = "Non";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // bt_plat
            // 
            bt_plat.BackColor = Color.FromArgb(250, 191, 80);
            bt_plat.Font = new Font("Segoe UI", 14F);
            bt_plat.Location = new Point(702, 512);
            bt_plat.Margin = new Padding(3, 4, 3, 4);
            bt_plat.Name = "bt_plat";
            bt_plat.Size = new Size(199, 72);
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
            bt_retour.Location = new Point(702, 115);
            bt_retour.Margin = new Padding(3, 4, 3, 4);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(199, 72);
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
            pictureBox1.Location = new Point(697, 240);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 225);
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(702, 16);
            bt_quitter.Margin = new Padding(3, 4, 3, 4);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(199, 72);
            bt_quitter.TabIndex = 35;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            bt_quitter.MouseEnter += bt_quitter_MouseEnter;
            bt_quitter.MouseLeave += bt_quitter_MouseLeave;
            // 
            // AjoutPlat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(914, 600);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "AjoutPlat";
            StartPosition = FormStartPosition.CenterScreen;
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