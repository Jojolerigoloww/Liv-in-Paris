namespace PSI_Interface
{
    partial class AppCuisinier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppCuisinier));
            lbl_titre = new Label();
            bt_quitter = new Button();
            bt_plat = new Button();
            bt_recette = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(11, 9);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(308, 81);
            lbl_titre.TabIndex = 14;
            lbl_titre.Text = "Bienvenue";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(633, 403);
            bt_quitter.Margin = new Padding(3, 4, 3, 4);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(199, 72);
            bt_quitter.TabIndex = 15;
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
            bt_plat.Location = new Point(631, 293);
            bt_plat.Margin = new Padding(3, 4, 3, 4);
            bt_plat.Name = "bt_plat";
            bt_plat.Size = new Size(199, 72);
            bt_plat.TabIndex = 16;
            bt_plat.Text = "Nouveau Plat";
            bt_plat.UseVisualStyleBackColor = false;
            bt_plat.Click += bt_plat_Click;
            bt_plat.MouseEnter += bt_plat_MouseEnter;
            bt_plat.MouseLeave += bt_plat_MouseLeave;
            // 
            // bt_recette
            // 
            bt_recette.BackColor = Color.FromArgb(250, 191, 80);
            bt_recette.Font = new Font("Segoe UI", 14F);
            bt_recette.Location = new Point(631, 184);
            bt_recette.Margin = new Padding(3, 4, 3, 4);
            bt_recette.Name = "bt_recette";
            bt_recette.Size = new Size(199, 72);
            bt_recette.TabIndex = 17;
            bt_recette.Text = "Nouvelle Recette";
            bt_recette.UseVisualStyleBackColor = false;
            bt_recette.Click += bt_recette_Click;
            bt_recette.MouseEnter += bt_recette_MouseEnter;
            bt_recette.MouseLeave += bt_recette_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(14, 149);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 321);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // AppCuisinier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(843, 487);
            Controls.Add(pictureBox1);
            Controls.Add(bt_recette);
            Controls.Add(bt_plat);
            Controls.Add(bt_quitter);
            Controls.Add(lbl_titre);
            Name = "AppCuisinier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppCuisinier";
            Load += AppCuisinier_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre;
        private Button bt_quitter;
        private Button bt_plat;
        private Button bt_recette;
        private PictureBox pictureBox1;
    }
}