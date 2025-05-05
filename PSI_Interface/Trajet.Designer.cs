namespace PSI_Interface
{
    partial class Trajet
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
            pictureBox = new PictureBox();
            bt_retour = new Button();
            lbl_titre = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 122);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1243, 488);
            pictureBox.TabIndex = 44;
            pictureBox.TabStop = false;
            // 
            // bt_retour
            // 
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
            bt_retour.Font = new Font("Segoe UI", 14F);
            bt_retour.Location = new Point(1085, 12);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(174, 54);
            bt_retour.TabIndex = 43;
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
            lbl_titre.Location = new Point(12, 13);
            lbl_titre.Name = "lbl_titre";
            lbl_titre.Size = new Size(479, 65);
            lbl_titre.TabIndex = 42;
            lbl_titre.Text = "Trajet Cuisinier-Client";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Trajet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(1271, 622);
            Controls.Add(pictureBox);
            Controls.Add(bt_retour);
            Controls.Add(lbl_titre);
            Name = "Trajet";
            Text = "Trajet";
            Load += Trajet_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button bt_retour;
        private Label lbl_titre;
    }
}