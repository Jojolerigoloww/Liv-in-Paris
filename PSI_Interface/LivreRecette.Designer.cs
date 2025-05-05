namespace PSI_Interface
{
    partial class LivreRecette
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
            dataGridView = new DataGridView();
            bt_retour = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
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
            lbl_titre.Size = new Size(404, 65);
            lbl_titre.TabIndex = 15;
            lbl_titre.Text = "Livre des Recettes";
            lbl_titre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 94);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(776, 344);
            dataGridView.TabIndex = 16;
            // 
            // bt_retour
            // 
            bt_retour.BackColor = Color.FromArgb(250, 191, 80);
            bt_retour.Font = new Font("Segoe UI", 14F);
            bt_retour.Location = new Point(614, 9);
            bt_retour.Name = "bt_retour";
            bt_retour.Size = new Size(174, 54);
            bt_retour.TabIndex = 38;
            bt_retour.Text = "Retour";
            bt_retour.UseVisualStyleBackColor = false;
            bt_retour.Click += bt_retour_Click;
            bt_retour.MouseEnter += bt_retour_MouseEnter;
            bt_retour.MouseLeave += bt_retour_MouseLeave;
            // 
            // LivreRecette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(bt_retour);
            Controls.Add(dataGridView);
            Controls.Add(lbl_titre);
            Name = "LivreRecette";
            Text = "LivreRecette";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre;
        private DataGridView dataGridView;
        private Button bt_retour;
    }
}