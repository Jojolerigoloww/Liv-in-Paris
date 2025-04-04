namespace PSI_Interface
{
    partial class AppPrincipale
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
            SuspendLayout();
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(591, 363);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(174, 54);
            bt_quitter.TabIndex = 12;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            // 
            // lbl_titre
            // 
            lbl_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre.AutoSize = true;
            lbl_titre.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre.Font = new Font("Segoe UI", 36F);
            lbl_titre.Location = new Point(26, 26);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(247, 65);
            lbl_titre.TabIndex = 13;
            lbl_titre.Text = "Bienvenue";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AppPrincipale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_titre);
            Controls.Add(bt_quitter);
            Name = "AppPrincipale";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppPrincipale";
            Load += AppPrincipale_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button bt_quitter;
        private Label lbl_titre;
    }
}