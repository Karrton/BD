namespace BD_1
{
    public partial class AddEditPatientForm : Form
    {
        private void InitializeComponent()
        {
            textBoxName = new TextBox();
            textBoxPhone = new TextBox();
            textBoxAddress = new TextBox();
            labelName = new Label();
            labelPhone = new Label();
            labelAddress = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(100, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(192, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(100, 41);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(192, 23);
            textBoxPhone.TabIndex = 1;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(100, 70);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(192, 23);
            textBoxAddress.TabIndex = 2;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(37, 15);
            labelName.TabIndex = 3;
            labelName.Text = "ФИО:";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(12, 44);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(58, 15);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Телефон:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(12, 73);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(43, 15);
            labelAddress.TabIndex = 5;
            labelAddress.Text = "Адрес:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(136, 99);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(217, 99);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // AddEditPatientForm
            // 
            ClientSize = new Size(304, 126);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelAddress);
            Controls.Add(labelPhone);
            Controls.Add(labelName);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditPatientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пациент";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}