namespace BD_1
{
    partial class AddEditMedicationForm
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
            label1 = new Label();
            textBoxName = new TextBox();
            comboBoxType = new ComboBox();
            comboBoxPreparationMethod = new ComboBox();
            numericUpDownPrice = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonSave = new Button();
            buttonClancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(77, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(215, 23);
            textBoxName.TabIndex = 1;
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(77, 41);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(215, 23);
            comboBoxType.TabIndex = 2;
            // 
            // comboBoxPreparationMethod
            // 
            comboBoxPreparationMethod.FormattingEnabled = true;
            comboBoxPreparationMethod.Location = new Point(77, 70);
            comboBoxPreparationMethod.Name = "comboBoxPreparationMethod";
            comboBoxPreparationMethod.Size = new Size(215, 23);
            comboBoxPreparationMethod.TabIndex = 3;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Location = new Point(77, 99);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(215, 23);
            numericUpDownPrice.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 5;
            label2.Text = "Тип";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 6;
            label3.Text = "Метод";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 101);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 7;
            label4.Text = "Цена";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(136, 128);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonClancel
            // 
            buttonClancel.Location = new Point(217, 128);
            buttonClancel.Name = "buttonClancel";
            buttonClancel.Size = new Size(75, 23);
            buttonClancel.TabIndex = 9;
            buttonClancel.Text = "Отмена";
            buttonClancel.UseVisualStyleBackColor = true;
            buttonClancel.Click += buttonClancel_Click;
            // 
            // AddEditMedicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 156);
            Controls.Add(buttonClancel);
            Controls.Add(buttonSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDownPrice);
            Controls.Add(comboBoxPreparationMethod);
            Controls.Add(comboBoxType);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditMedicationForm";
            Text = "Лекарство";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private ComboBox comboBoxType;
        private ComboBox comboBoxPreparationMethod;
        private NumericUpDown numericUpDownPrice;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonSave;
        private Button buttonClancel;
    }
}