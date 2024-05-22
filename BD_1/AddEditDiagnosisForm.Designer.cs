namespace BD_1
{
    public partial class AddEditDiagnosisForm : Form
    {
        private void InitializeComponent()
        {
            labelName = new Label();
            textBoxName = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(114, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название диагноза:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(132, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(218, 23);
            textBoxName.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(194, 41);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(275, 41);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // AddEditDiagnosisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 67);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditDiagnosisForm";
            Text = "Диагноз";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}