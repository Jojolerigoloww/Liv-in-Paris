namespace PSI_Interface
{
    partial class AppAdmin
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
            lbl_titre_2 = new Label();
            bt_quitter = new Button();
            dataGridView = new DataGridView();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lbl_titre_2
            // 
            lbl_titre_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre_2.AutoSize = true;
            lbl_titre_2.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre_2.Font = new Font("Segoe UI", 36F);
            lbl_titre_2.Location = new Point(10, 7);
            lbl_titre_2.Name = "lbl_titre_2";
            lbl_titre_2.Size = new Size(247, 65);
            lbl_titre_2.TabIndex = 15;
            lbl_titre_2.Text = "Bienvenue";
            lbl_titre_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(787, 506);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(174, 54);
            bt_quitter.TabIndex = 16;
            bt_quitter.Text = "Quitter";
            bt_quitter.UseVisualStyleBackColor = false;
            bt_quitter.Click += bt_quitter_Click;
            bt_quitter.MouseEnter += bt_quitter_MouseEnter;
            bt_quitter.MouseLeave += bt_quitter_MouseLeave;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 120);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(951, 380);
            dataGridView.TabIndex = 17;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Utilisateurs", "Cuisiniers", "Plats", "Notes", "Notes Moyennes" });
            comboBox1.Location = new Point(10, 83);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(140, 23);
            comboBox1.TabIndex = 18;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // AppAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(973, 572);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView);
            Controls.Add(bt_quitter);
            Controls.Add(lbl_titre_2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AppAdmin";
            Text = "AppAdmin";
            Load += AppAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titre_2;
        private Button bt_quitter;
        private DataGridView dataGridView;
        private ComboBox comboBox1;
    }
}