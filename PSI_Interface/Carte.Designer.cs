namespace PSI_Interface
{
    partial class Carte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carte));
            bt_retour = new Button();
            lbl_titre = new Label();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
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
            bt_retour.TabIndex = 40;
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
            lbl_titre.Size = new Size(435, 81);
            lbl_titre.TabIndex = 39;
            lbl_titre.Text = "Carte du métro";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(14, 157);
            pictureBox.Margin = new Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(887, 651);
            pictureBox.TabIndex = 41;
            pictureBox.TabStop = false;
            // 
            // Carte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(914, 824);
            Controls.Add(pictureBox);
            Controls.Add(bt_retour);
            Controls.Add(lbl_titre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Carte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carte";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bt_retour;
        private Label lbl_titre;
        private PictureBox pictureBox;
    }
}