namespace PSI_Interface
{
    partial class Note
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
            lbl_titre = new Label();
            bt_retour = new Button();
            comboBox = new ComboBox();
            txt_commentaire = new TextBox();
            txt_note = new TextBox();
            bt_valider = new Button();
            lbl_nom = new Label();
            label1 = new Label();
            label2 = new Label();
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
            lbl_titre.Size = new Size(421, 81);
            lbl_titre.TabIndex = 14;
            lbl_titre.Text = "Noter cuisinier";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_retour
            // 
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
            bt_retour.Font = new Font("Segoe UI", 14F);
            bt_retour.Location = new Point(589, 18);
            bt_retour.Margin = new Padding(3, 4, 3, 4);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(199, 72);
            bt_retour.TabIndex = 22;
            bt_retour.Text = "Retour";
            bt_retour.UseVisualStyleBackColor = false;
            bt_retour.Click += bt_retour_Click;
            bt_retour.MouseEnter += bt_retour_MouseEnter;
            bt_retour.MouseLeave += bt_retour_MouseLeave;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(12, 196);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(172, 28);
            comboBox.TabIndex = 23;
            // 
            // txt_commentaire
            // 
            txt_commentaire.Location = new Point(12, 313);
            txt_commentaire.Name = "txt_commentaire";
            txt_commentaire.Size = new Size(172, 27);
            txt_commentaire.TabIndex = 24;
            // 
            // txt_note
            // 
            txt_note.Location = new Point(267, 195);
            txt_note.Name = "txt_note";
            txt_note.Size = new Size(172, 27);
            txt_note.TabIndex = 25;
            // 
            // bt_valider
            // 
            bt_valider.BackColor = Color.FromArgb(250, 191, 80);
            bt_valider.Font = new Font("Segoe UI", 14F);
            bt_valider.Location = new Point(589, 365);
            bt_valider.Margin = new Padding(3, 4, 3, 4);
            bt_valider.Name = "bt_valider";
            bt_valider.Size = new Size(199, 72);
            bt_valider.TabIndex = 26;
            bt_valider.Text = "Valider";
            bt_valider.UseVisualStyleBackColor = false;
            bt_valider.Click += bt_valider_Click;
            bt_valider.MouseEnter += bt_valider_MouseEnter;
            bt_valider.MouseLeave += bt_valider_MouseLeave;
            // 
            // lbl_nom
            // 
            lbl_nom.AutoSize = true;
            lbl_nom.BackColor = Color.FromArgb(250, 191, 80);
            lbl_nom.Font = new Font("Segoe UI", 12F);
            lbl_nom.Location = new Point(12, 155);
            lbl_nom.Name = "lbl_nom";
            lbl_nom.Size = new Size(165, 28);
            lbl_nom.TabIndex = 27;
            lbl_nom.Text = "Choix du cuisinier";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(250, 191, 80);
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 269);
            label1.Name = "label1";
            label1.Size = new Size(130, 28);
            label1.TabIndex = 28;
            label1.Text = "Commentaire";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(250, 191, 80);
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(267, 155);
            label2.Name = "label2";
            label2.Size = new Size(56, 28);
            label2.TabIndex = 29;
            label2.Text = "Note";
            // 
            // Note
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbl_nom);
            Controls.Add(bt_valider);
            Controls.Add(txt_note);
            Controls.Add(txt_commentaire);
            Controls.Add(comboBox);
            Controls.Add(bt_retour);
            Controls.Add(lbl_titre);
            Name = "Note";
            Text = "Note";
            Load += Note_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre;
        private Button bt_retour;
        private ComboBox comboBox;
        private TextBox txt_commentaire;
        private TextBox txt_note;
        private Button bt_valider;
        private Label lbl_nom;
        private Label label1;
        private Label label2;
    }
}