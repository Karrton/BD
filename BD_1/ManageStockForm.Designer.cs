namespace BD_1
{
    public partial class ManageStockForm : Form
    {
        private void InitializeComponent()
        {
            dataGridViewStock = new DataGridView();
            buttonAddStock = new Button();
            buttonUpdateStock = new Button();
            buttonDeleteStock = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStock).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStock
            // 
            dataGridViewStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStock.Location = new Point(12, 12);
            dataGridViewStock.Name = "dataGridViewStock";
            dataGridViewStock.Size = new Size(710, 338);
            dataGridViewStock.TabIndex = 0;
            // 
            // buttonAddStock
            // 
            buttonAddStock.Location = new Point(12, 356);
            buttonAddStock.Name = "buttonAddStock";
            buttonAddStock.Size = new Size(75, 23);
            buttonAddStock.TabIndex = 1;
            buttonAddStock.Text = "Добавить";
            buttonAddStock.UseVisualStyleBackColor = true;
            buttonAddStock.Click += ButtonAddStock_Click;
            // 
            // buttonUpdateStock
            // 
            buttonUpdateStock.Location = new Point(93, 356);
            buttonUpdateStock.Name = "buttonUpdateStock";
            buttonUpdateStock.Size = new Size(75, 23);
            buttonUpdateStock.TabIndex = 2;
            buttonUpdateStock.Text = "Обновить";
            buttonUpdateStock.UseVisualStyleBackColor = true;
            buttonUpdateStock.Click += ButtonUpdateStock_Click;
            // 
            // buttonDeleteStock
            // 
            buttonDeleteStock.Location = new Point(174, 356);
            buttonDeleteStock.Name = "buttonDeleteStock";
            buttonDeleteStock.Size = new Size(75, 23);
            buttonDeleteStock.TabIndex = 3;
            buttonDeleteStock.Text = "Удалить";
            buttonDeleteStock.UseVisualStyleBackColor = true;
            buttonDeleteStock.Click += ButtonDeleteStock_Click;
            // 
            // ManageStockForm
            // 
            ClientSize = new Size(734, 391);
            Controls.Add(buttonDeleteStock);
            Controls.Add(buttonUpdateStock);
            Controls.Add(buttonAddStock);
            Controls.Add(dataGridViewStock);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ManageStockForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление запасами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStock).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.Button buttonAddStock;
        private System.Windows.Forms.Button buttonUpdateStock;
        private System.Windows.Forms.Button buttonDeleteStock;

        private void ButtonAddStock_Click(object sender, EventArgs e)
        {
            // Logic to add stock
        }

        private void ButtonUpdateStock_Click(object sender, EventArgs e)
        {
            // Logic to update stock
        }

        private void ButtonDeleteStock_Click(object sender, EventArgs e)
        {
            // Logic to delete stock
        }
    }

}