namespace PSI_Interface
{
    partial class AjoutRecette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjoutRecette));
            txt_type = new TextBox();
            txt_ingredient = new TextBox();
            lbl_type = new Label();
            lbl_portion = new Label();
            lbl_ingredient = new Label();
            lbl_titre = new Label();
            bt_retour = new Button();
            pictureBox1 = new PictureBox();
            bt_quitter = new Button();
            bt_plat = new Button();
            txt_nation = new TextBox();
            lbl_nationalité = new Label();
            txt_portion = new TextBox();
            lbl_regime = new Label();
            txt_regime = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txt_type
            // 
            txt_type.Location = new Point(243, 169);
            txt_type.Name = "txt_type";
            txt_type.Size = new Size(176, 23);
            txt_type.TabIndex = 37;
            // 
            // txt_ingredient
            // 
            txt_ingredient.Location = new Point(10, 169);
            txt_ingredient.Name = "txt_ingredient";
            txt_ingredient.Size = new Size(176, 23);
            txt_ingredient.TabIndex = 36;
            // 
            // lbl_type
            // 
            lbl_type.AutoSize = true;
            lbl_type.BackColor = Color.FromArgb(250, 191, 80);
            lbl_type.Font = new Font("Segoe UI", 12F);
            lbl_type.Location = new Point(243, 127);
            lbl_type.Name = "lbl_type";
            lbl_type.Size = new Size(93, 21);
            lbl_type.TabIndex = 35;
            lbl_type.Text = "Type de plat";
            // 
            // lbl_portion
            // 
            lbl_portion.AutoSize = true;
            lbl_portion.BackColor = Color.FromArgb(250, 191, 80);
            lbl_portion.Font = new Font("Segoe UI", 12F);
            lbl_portion.Location = new Point(243, 226);
            lbl_portion.Name = "lbl_portion";
            lbl_portion.Size = new Size(151, 21);
            lbl_portion.TabIndex = 34;
            lbl_portion.Text = "Nombre de portions";
            // 
            // lbl_ingredient
            // 
            lbl_ingredient.AutoSize = true;
            lbl_ingredient.BackColor = Color.FromArgb(250, 191, 80);
            lbl_ingredient.Font = new Font("Segoe UI", 12F);
            lbl_ingredient.Location = new Point(12, 127);
            lbl_ingredient.Name = "lbl_ingredient";
            lbl_ingredient.Size = new Size(88, 21);
            lbl_ingredient.TabIndex = 32;
            lbl_ingredient.Text = "Ingrédients";
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(12, 9);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(435, 65);
            lbl_titre.TabIndex = 31;
            lbl_titre.Text = "Ajouter une recette";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_retour
            // 
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
            bt_retour.Font = new Font("Segoe UI", 14F);
            bt_retour.Location = new Point(614, 83);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(174, 54);
            bt_retour.TabIndex = 43;
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
            pictureBox1.Location = new Point(610, 177);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 169);
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(614, 9);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(174, 54);
            bt_quitter.TabIndex = 41;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            bt_quitter.MouseEnter += bt_quitter_MouseEnter;
            bt_quitter.MouseLeave += bt_quitter_MouseLeave;
            // 
            // bt_plat
            // 
            bt_plat.BackColor = Color.FromArgb(250, 191, 80);
            bt_plat.Font = new Font("Segoe UI", 14F);
            bt_plat.Location = new Point(614, 381);
            bt_plat.Name = "bt_plat";
            bt_plat.Size = new Size(174, 54);
            bt_plat.TabIndex = 40;
            bt_plat.Text = "Ajouter";
            bt_plat.UseVisualStyleBackColor = false;
            bt_plat.Click += bt_plat_Click;
            bt_plat.MouseEnter += bt_plat_MouseEnter;
            bt_plat.MouseLeave += bt_plat_MouseLeave;
            // 
            // txt_nation
            // 
            txt_nation.Location = new Point(10, 266);
            txt_nation.Name = "txt_nation";
            txt_nation.Size = new Size(176, 23);
            txt_nation.TabIndex = 45;
            // 
            // lbl_nationalité
            // 
            lbl_nationalité.AutoSize = true;
            lbl_nationalité.BackColor = Color.FromArgb(250, 191, 80);
            lbl_nationalité.Font = new Font("Segoe UI", 12F);
            lbl_nationalité.Location = new Point(10, 226);
            lbl_nationalité.Name = "lbl_nationalité";
            lbl_nationalité.Size = new Size(86, 21);
            lbl_nationalité.TabIndex = 44;
            lbl_nationalité.Text = "Nationalité";
            // 
            // txt_portion
            // 
            txt_portion.Location = new Point(243, 266);
            txt_portion.Name = "txt_portion";
            txt_portion.Size = new Size(176, 23);
            txt_portion.TabIndex = 46;
            // 
            // lbl_regime
            // 
            lbl_regime.AutoSize = true;
            lbl_regime.BackColor = Color.FromArgb(250, 191, 80);
            lbl_regime.Font = new Font("Segoe UI", 12F);
            lbl_regime.Location = new Point(10, 325);
            lbl_regime.Name = "lbl_regime";
            lbl_regime.Size = new Size(145, 21);
            lbl_regime.TabIndex = 47;
            lbl_regime.Text = "Régime alimentaire";
            // 
            // txt_regime
            // 
            txt_regime.Location = new Point(10, 365);
            txt_regime.Name = "txt_regime";
            txt_regime.Size = new Size(176, 23);
            txt_regime.TabIndex = 48;
            // 
            // AjoutRecette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(txt_regime);
            Controls.Add(lbl_regime);
            Controls.Add(txt_portion);
            Controls.Add(txt_nation);
            Controls.Add(lbl_nationalité);
            Controls.Add(bt_retour);
            Controls.Add(pictureBox1);
            Controls.Add(bt_quitter);
            Controls.Add(bt_plat);
            Controls.Add(txt_type);
            Controls.Add(txt_ingredient);
            Controls.Add(lbl_type);
            Controls.Add(lbl_portion);
            Controls.Add(lbl_ingredient);
            Controls.Add(lbl_titre);
            Name = "AjoutRecette";
            Text = "AjoutRecette";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_type;
        private TextBox txt_ingredient;
        private Label lbl_type;
        private Label lbl_portion;
        private Label lbl_ingredient;
        private Label lbl_titre;
        private Button bt_retour;
        private PictureBox pictureBox1;
        private Button bt_quitter;
        private Button bt_plat;
        private TextBox txt_nation;
        private Label lbl_nationalité;
        private TextBox txt_portion;
        private Label lbl_regime;
        private TextBox txt_regime;
    }
}