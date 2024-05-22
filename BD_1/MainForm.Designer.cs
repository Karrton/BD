namespace BD_1
{
    partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnManageOrders = new Button();
            comboBoxEntities = new ComboBox();
            label1 = new Label();
            buttonDelete = new Button();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonRepos = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(167, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(805, 392);
            dataGridView1.TabIndex = 2;
            // 
            // btnManageOrders
            // 
            btnManageOrders.Location = new Point(12, 146);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(149, 23);
            btnManageOrders.TabIndex = 3;
            btnManageOrders.Text = "Заказы";
            btnManageOrders.UseVisualStyleBackColor = true;
            btnManageOrders.Click += btnManageOrders_Click;
            // 
            // comboBoxEntities
            // 
            comboBoxEntities.FormattingEnabled = true;
            comboBoxEntities.Location = new Point(12, 30);
            comboBoxEntities.Name = "comboBoxEntities";
            comboBoxEntities.Size = new Size(149, 23);
            comboBoxEntities.TabIndex = 6;
            comboBoxEntities.SelectedIndexChanged += ComboBoxEntities_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(149, 15);
            label1.TabIndex = 7;
            label1.Text = "Данные для отображения";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(12, 59);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(149, 23);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 88);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(149, 23);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(12, 117);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(149, 23);
            buttonEdit.TabIndex = 10;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonRepos
            // 
            buttonRepos.Location = new Point(12, 175);
            buttonRepos.Name = "buttonRepos";
            buttonRepos.Size = new Size(149, 23);
            buttonRepos.TabIndex = 11;
            buttonRepos.Text = "Запросы";
            buttonRepos.UseVisualStyleBackColor = true;
            buttonRepos.Click += buttonRepos_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 416);
            Controls.Add(buttonRepos);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(buttonDelete);
            Controls.Add(btnManageOrders);
            Controls.Add(comboBoxEntities);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система аптеки";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private Button btnManageOrders;
        private ComboBox comboBoxEntities;
        private Label label1;
        private Button buttonDelete;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonRepos;
    }
}
