namespace BD_1
{
    partial class AddEditDoctorForm
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
            labelName = new Label();
            labelSignature = new Label();
            labelSeal = new Label();
            textBoxName = new TextBox();
            textBoxSeal = new TextBox();
            textBoxSignature = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(37, 15);
            labelName.TabIndex = 0;
            labelName.Text = "ФИО:";
            // 
            // labelSignature
            // 
            labelSignature.AutoSize = true;
            labelSignature.Location = new Point(12, 73);
            labelSignature.Name = "labelSignature";
            labelSignature.Size = new Size(58, 15);
            labelSignature.TabIndex = 1;
            labelSignature.Text = "Подпись:";
            // 
            // labelSeal
            // 
            labelSeal.AutoSize = true;
            labelSeal.Location = new Point(12, 44);
            labelSeal.Name = "labelSeal";
            labelSeal.Size = new Size(49, 15);
            labelSeal.TabIndex = 2;
            labelSeal.Text = "Печать:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(100, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(192, 23);
            textBoxName.TabIndex = 3;
            // 
            // textBoxSeal
            // 
            textBoxSeal.Location = new Point(100, 41);
            textBoxSeal.Name = "textBoxSeal";
            textBoxSeal.Size = new Size(192, 23);
            textBoxSeal.TabIndex = 4;
            // 
            // textBoxSignature
            // 
            textBoxSignature.Location = new Point(100, 70);
            textBoxSignature.Name = "textBoxSignature";
            textBoxSignature.Size = new Size(192, 23);
            textBoxSignature.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(136, 99);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(217, 99);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddEditDoctorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 126);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxSignature);
            Controls.Add(textBoxSeal);
            Controls.Add(textBoxName);
            Controls.Add(labelSeal);
            Controls.Add(labelSignature);
            Controls.Add(labelName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditDoctorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Доктор";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelSignature;
        private Label labelSeal;
        private TextBox textBoxName;
        private TextBox textBoxSeal;
        private TextBox textBoxSignature;
        private Button buttonSave;
        private Button buttonCancel;
    }
}