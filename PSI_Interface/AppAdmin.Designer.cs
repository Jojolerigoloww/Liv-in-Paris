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
            bt_exporter = new Button();
            comboBoxExport = new ComboBox();
            bt_exporttous = new Button();
            bt_import = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lbl_titre_2
            // 
            lbl_titre_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_titre_2.AutoSize = true;
            lbl_titre_2.BackColor = Color.FromArgb(250, 191, 80);
            lbl_titre_2.Font = new Font("Segoe UI", 36F);
            lbl_titre_2.Location = new Point(11, 9);
            lbl_titre_2.Name = "lbl_titre_2";
            lbl_titre_2.Size = new Size(308, 81);
            lbl_titre_2.TabIndex = 15;
            lbl_titre_2.Text = "Bienvenue";
            lbl_titre_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_quitter
            // 
            bt_quitter.BackColor = Color.FromArgb(250, 191, 80);
            bt_quitter.Font = new Font("Segoe UI", 14F);
            bt_quitter.Location = new Point(1179, 678);
            bt_quitter.Margin = new Padding(3, 4, 3, 4);
            bt_quitter.Name = "bt_quitter";
            bt_quitter.Size = new Size(199, 72);
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
            dataGridView.Location = new Point(11, 160);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1087, 507);
            dataGridView.TabIndex = 17;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Utilisateurs", "Cuisiniers", "Plats", "Clients", "Notes Moyennes" });
            comboBox1.Location = new Point(11, 111);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(159, 28);
            comboBox1.TabIndex = 18;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // bt_exporter
            // 
            bt_exporter.BackColor = Color.FromArgb(250, 191, 80);
            bt_exporter.Font = new Font("Segoe UI", 14F);
            bt_exporter.Location = new Point(1179, 18);
            bt_exporter.Margin = new Padding(3, 4, 3, 4);
            bt_exporter.Name = "bt_exporter";
            bt_exporter.Size = new Size(199, 72);
            bt_exporter.TabIndex = 22;
            bt_exporter.Text = "Exporter un";
            bt_exporter.UseVisualStyleBackColor = false;
            bt_exporter.Click += bt_exporter_Click;
            bt_exporter.MouseEnter += bt_exporter_MouseEnter;
            bt_exporter.MouseLeave += bt_exporter_MouseLeave;
            // 
            // comboBoxExport
            // 
            comboBoxExport.FormattingEnabled = true;
            comboBoxExport.Location = new Point(1202, 111);
            comboBoxExport.Name = "comboBoxExport";
            comboBoxExport.Size = new Size(159, 28);
            comboBoxExport.TabIndex = 23;
            // 
            // bt_exporttous
            // 
            bt_exporttous.BackColor = Color.FromArgb(250, 191, 80);
            bt_exporttous.Font = new Font("Segoe UI", 14F);
            bt_exporttous.Location = new Point(1179, 226);
            bt_exporttous.Margin = new Padding(3, 4, 3, 4);
            bt_exporttous.Name = "bt_exporttous";
            bt_exporttous.Size = new Size(199, 72);
            bt_exporttous.TabIndex = 24;
            bt_exporttous.Text = "Exporter tous";
            bt_exporttous.UseVisualStyleBackColor = false;
            bt_exporttous.Click += bt_exporttous_Click;
            bt_exporttous.MouseEnter += bt_exporttous_MouseEnter;
            bt_exporttous.MouseLeave += bt_exporttous_MouseLeave;
            // 
            // bt_import
            // 
            bt_import.BackColor = Color.FromArgb(250, 191, 80);
            bt_import.Font = new Font("Segoe UI", 14F);
            bt_import.Location = new Point(1179, 340);
            bt_import.Margin = new Padding(3, 4, 3, 4);
            bt_import.Name = "bt_import";
            bt_import.Size = new Size(199, 72);
            bt_import.TabIndex = 25;
            bt_import.Text = "Importer xml";
            bt_import.UseVisualStyleBackColor = false;
            bt_import.Click += bt_import_Click;
            bt_import.MouseEnter += bt_import_MouseEnter;
            bt_import.MouseLeave += bt_import_MouseLeave;
            // 
            // AppAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 77, 32);
            ClientSize = new Size(1390, 763);
            Controls.Add(bt_import);
            Controls.Add(bt_exporttous);
            Controls.Add(comboBoxExport);
            Controls.Add(bt_exporter);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView);
            Controls.Add(bt_quitter);
            Controls.Add(lbl_titre_2);
            Name = "AppAdmin";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button bt_exporter;
        private ComboBox comboBoxExport;
        private Button bt_exporttous;
        private Button bt_import;
    }
}