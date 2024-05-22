namespace BD_1
{
    public partial class ReportsForm : Form
    {
        private void InitializeComponent()
        {
            comboBoxReportType = new ComboBox();
            buttonGenerateReport = new Button();
            dataGridViewReport = new DataGridView();
            label1 = new Label();
            comboBoxType = new ComboBox();
            label2 = new Label();
            comboBoxStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // comboBoxReportType
            // 
            comboBoxReportType.FormattingEnabled = true;
            comboBoxReportType.Location = new Point(12, 12);
            comboBoxReportType.Name = "comboBoxReportType";
            comboBoxReportType.Size = new Size(150, 23);
            comboBoxReportType.TabIndex = 0;
            // 
            // buttonGenerateReport
            // 
            buttonGenerateReport.Location = new Point(168, 12);
            buttonGenerateReport.Name = "buttonGenerateReport";
            buttonGenerateReport.Size = new Size(150, 23);
            buttonGenerateReport.TabIndex = 1;
            buttonGenerateReport.Text = "Сгенерировать отчет";
            buttonGenerateReport.UseVisualStyleBackColor = true;
            buttonGenerateReport.Click += ButtonGenerateReport_Click;
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Location = new Point(12, 41);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.Size = new Size(776, 397);
            dataGridViewReport.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(324, 16);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 3;
            label1.Text = "Тип";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(357, 12);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(100, 23);
            comboBoxType.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(463, 16);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 5;
            label2.Text = "Статус";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(512, 12);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(100, 23);
            comboBoxStatus.TabIndex = 6;
            // 
            // ReportsForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxStatus);
            Controls.Add(label2);
            Controls.Add(comboBoxType);
            Controls.Add(label1);
            Controls.Add(dataGridViewReport);
            Controls.Add(buttonGenerateReport);
            Controls.Add(comboBoxReportType);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчеты и статистика";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.DataGridView dataGridViewReport;
        private Label label1;
        private ComboBox comboBoxType;
        private Label label2;
        private ComboBox comboBoxStatus;
    }
}