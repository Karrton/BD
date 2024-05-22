namespace BD_1
{
    public partial class ManagePreparationTechniquesForm : Form
    {
        private void InitializeComponent()
        {
            dataGridViewTechniques = new DataGridView();
            buttonAddTechnique = new Button();
            buttonUpdateTechnique = new Button();
            buttonDeleteTechnique = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTechniques).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTechniques
            // 
            dataGridViewTechniques.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTechniques.Location = new Point(12, 12);
            dataGridViewTechniques.Name = "dataGridViewTechniques";
            dataGridViewTechniques.Size = new Size(710, 345);
            dataGridViewTechniques.TabIndex = 0;
            // 
            // buttonAddTechnique
            // 
            buttonAddTechnique.Location = new Point(12, 363);
            buttonAddTechnique.Name = "buttonAddTechnique";
            buttonAddTechnique.Size = new Size(75, 23);
            buttonAddTechnique.TabIndex = 1;
            buttonAddTechnique.Text = "Добавить";
            buttonAddTechnique.UseVisualStyleBackColor = true;
            buttonAddTechnique.Click += ButtonAddTechnique_Click;
            // 
            // buttonUpdateTechnique
            // 
            buttonUpdateTechnique.Location = new Point(93, 363);
            buttonUpdateTechnique.Name = "buttonUpdateTechnique";
            buttonUpdateTechnique.Size = new Size(75, 23);
            buttonUpdateTechnique.TabIndex = 2;
            buttonUpdateTechnique.Text = "Обновить";
            buttonUpdateTechnique.UseVisualStyleBackColor = true;
            buttonUpdateTechnique.Click += ButtonUpdateTechnique_Click;
            // 
            // buttonDeleteTechnique
            // 
            buttonDeleteTechnique.Location = new Point(174, 363);
            buttonDeleteTechnique.Name = "buttonDeleteTechnique";
            buttonDeleteTechnique.Size = new Size(75, 23);
            buttonDeleteTechnique.TabIndex = 3;
            buttonDeleteTechnique.Text = "Удалить";
            buttonDeleteTechnique.UseVisualStyleBackColor = true;
            buttonDeleteTechnique.Click += ButtonDeleteTechnique_Click;
            // 
            // ManagePreparationTechniquesForm
            // 
            ClientSize = new Size(734, 391);
            Controls.Add(buttonDeleteTechnique);
            Controls.Add(buttonUpdateTechnique);
            Controls.Add(buttonAddTechnique);
            Controls.Add(dataGridViewTechniques);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ManagePreparationTechniquesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление методами подготовки";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTechniques).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewTechniques;
        private System.Windows.Forms.Button buttonAddTechnique;
        private System.Windows.Forms.Button buttonUpdateTechnique;
        private System.Windows.Forms.Button buttonDeleteTechnique;
    }

}