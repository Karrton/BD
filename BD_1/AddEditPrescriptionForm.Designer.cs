namespace BD_1
{
    partial class AddEditPrescriptionForm
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
            comboBoxPatient = new ComboBox();
            comboBoxDoctor = new ComboBox();
            comboBoxDiagnosis = new ComboBox();
            comboBoxMedicine = new ComboBox();
            comboBoxInstruction = new ComboBox();
            labelPatient = new Label();
            labelDoctor = new Label();
            labelDiagnosis = new Label();
            labelMedicine = new Label();
            labelInstruction = new Label();
            labelValMedicine = new Label();
            numericUpDownValMedicine = new NumericUpDown();
            buttonCancel = new Button();
            buttonSave = new Button();
            label1 = new Label();
            comboBoxStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownValMedicine).BeginInit();
            SuspendLayout();
            // 
            // comboBoxPatient
            // 
            comboBoxPatient.FormattingEnabled = true;
            comboBoxPatient.Location = new Point(91, 12);
            comboBoxPatient.Name = "comboBoxPatient";
            comboBoxPatient.Size = new Size(201, 23);
            comboBoxPatient.TabIndex = 0;
            // 
            // comboBoxDoctor
            // 
            comboBoxDoctor.FormattingEnabled = true;
            comboBoxDoctor.Location = new Point(91, 41);
            comboBoxDoctor.Name = "comboBoxDoctor";
            comboBoxDoctor.Size = new Size(201, 23);
            comboBoxDoctor.TabIndex = 1;
            // 
            // comboBoxDiagnosis
            // 
            comboBoxDiagnosis.FormattingEnabled = true;
            comboBoxDiagnosis.Location = new Point(91, 70);
            comboBoxDiagnosis.Name = "comboBoxDiagnosis";
            comboBoxDiagnosis.Size = new Size(201, 23);
            comboBoxDiagnosis.TabIndex = 2;
            // 
            // comboBoxMedicine
            // 
            comboBoxMedicine.FormattingEnabled = true;
            comboBoxMedicine.Location = new Point(91, 99);
            comboBoxMedicine.Name = "comboBoxMedicine";
            comboBoxMedicine.Size = new Size(201, 23);
            comboBoxMedicine.TabIndex = 3;
            // 
            // comboBoxInstruction
            // 
            comboBoxInstruction.FormattingEnabled = true;
            comboBoxInstruction.Location = new Point(91, 128);
            comboBoxInstruction.Name = "comboBoxInstruction";
            comboBoxInstruction.Size = new Size(201, 23);
            comboBoxInstruction.TabIndex = 4;
            // 
            // labelPatient
            // 
            labelPatient.AutoSize = true;
            labelPatient.Location = new Point(12, 15);
            labelPatient.Name = "labelPatient";
            labelPatient.Size = new Size(54, 15);
            labelPatient.TabIndex = 5;
            labelPatient.Text = "Пациент";
            // 
            // labelDoctor
            // 
            labelDoctor.AutoSize = true;
            labelDoctor.Location = new Point(12, 44);
            labelDoctor.Name = "labelDoctor";
            labelDoctor.Size = new Size(34, 15);
            labelDoctor.TabIndex = 6;
            labelDoctor.Text = "Врач";
            // 
            // labelDiagnosis
            // 
            labelDiagnosis.AutoSize = true;
            labelDiagnosis.Location = new Point(12, 73);
            labelDiagnosis.Name = "labelDiagnosis";
            labelDiagnosis.Size = new Size(52, 15);
            labelDiagnosis.TabIndex = 7;
            labelDiagnosis.Text = "Диагноз";
            // 
            // labelMedicine
            // 
            labelMedicine.AutoSize = true;
            labelMedicine.Location = new Point(12, 102);
            labelMedicine.Name = "labelMedicine";
            labelMedicine.Size = new Size(64, 15);
            labelMedicine.TabIndex = 8;
            labelMedicine.Text = "Лекарство";
            // 
            // labelInstruction
            // 
            labelInstruction.AutoSize = true;
            labelInstruction.Location = new Point(12, 131);
            labelInstruction.Name = "labelInstruction";
            labelInstruction.Size = new Size(73, 15);
            labelInstruction.TabIndex = 9;
            labelInstruction.Text = "Инструкция";
            // 
            // labelValMedicine
            // 
            labelValMedicine.AutoSize = true;
            labelValMedicine.Location = new Point(12, 188);
            labelValMedicine.Name = "labelValMedicine";
            labelValMedicine.Size = new Size(130, 15);
            labelValMedicine.TabIndex = 10;
            labelValMedicine.Text = "Количество лекарства";
            // 
            // numericUpDownValMedicine
            // 
            numericUpDownValMedicine.Location = new Point(148, 186);
            numericUpDownValMedicine.Name = "numericUpDownValMedicine";
            numericUpDownValMedicine.Size = new Size(144, 23);
            numericUpDownValMedicine.TabIndex = 11;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(217, 215);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(136, 215);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 160);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 14;
            label1.Text = "Статус";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(91, 157);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(201, 23);
            comboBoxStatus.TabIndex = 15;
            // 
            // AddEditPrescriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 241);
            Controls.Add(comboBoxStatus);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(numericUpDownValMedicine);
            Controls.Add(labelValMedicine);
            Controls.Add(labelInstruction);
            Controls.Add(labelMedicine);
            Controls.Add(labelDiagnosis);
            Controls.Add(labelDoctor);
            Controls.Add(labelPatient);
            Controls.Add(comboBoxInstruction);
            Controls.Add(comboBoxMedicine);
            Controls.Add(comboBoxDiagnosis);
            Controls.Add(comboBoxDoctor);
            Controls.Add(comboBoxPatient);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditPrescriptionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Рецепт";
            ((System.ComponentModel.ISupportInitialize)numericUpDownValMedicine).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxPatient;
        private ComboBox comboBoxDoctor;
        private ComboBox comboBoxDiagnosis;
        private ComboBox comboBoxMedicine;
        private ComboBox comboBoxInstruction;
        private Label labelPatient;
        private Label labelDoctor;
        private Label labelDiagnosis;
        private Label labelMedicine;
        private Label labelInstruction;
        private Label labelValMedicine;
        private NumericUpDown numericUpDownValMedicine;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label1;
        private ComboBox comboBoxStatus;
    }
}