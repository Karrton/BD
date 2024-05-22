namespace BD_1
{
    public partial class ManageOrdersForm : Form
    {
        private void InitializeComponent()
        {
            dataGridViewOrders = new DataGridView();
            buttonUpdateStatus = new Button();
            buttonDeleteOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(12, 12);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.Size = new Size(710, 338);
            dataGridViewOrders.TabIndex = 0;
            // 
            // buttonUpdateStatus
            // 
            buttonUpdateStatus.Location = new Point(12, 356);
            buttonUpdateStatus.Name = "buttonUpdateStatus";
            buttonUpdateStatus.Size = new Size(120, 23);
            buttonUpdateStatus.TabIndex = 1;
            buttonUpdateStatus.Text = "Обновить статус";
            buttonUpdateStatus.UseVisualStyleBackColor = true;
            buttonUpdateStatus.Click += ButtonUpdateStatus_Click;
            // 
            // buttonDeleteOrder
            // 
            buttonDeleteOrder.Location = new Point(138, 356);
            buttonDeleteOrder.Name = "buttonDeleteOrder";
            buttonDeleteOrder.Size = new Size(120, 23);
            buttonDeleteOrder.TabIndex = 2;
            buttonDeleteOrder.Text = "Удалить заказ";
            buttonDeleteOrder.UseVisualStyleBackColor = true;
            buttonDeleteOrder.Click += ButtonDeleteOrder_Click;
            // 
            // ManageOrdersForm
            // 
            ClientSize = new Size(734, 391);
            Controls.Add(buttonDeleteOrder);
            Controls.Add(buttonUpdateStatus);
            Controls.Add(dataGridViewOrders);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ManageOrdersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление заказами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonUpdateStatus;
        private System.Windows.Forms.Button buttonDeleteOrder;
    }
}