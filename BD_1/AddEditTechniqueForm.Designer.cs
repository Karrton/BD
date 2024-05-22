namespace BD_1
{
    partial class AddEditTechniqueForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">true, если управляемый ресурс должен быть удален; иначе false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            labelTechniqueName = new Label();
            textBoxTechniqueName = new TextBox();
            labelTechniqueDescription = new Label();
            textBoxTechniqueDescription = new TextBox();
            buttonSaveTechnique = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelTechniqueName
            // 
            labelTechniqueName.AutoSize = true;
            labelTechniqueName.Location = new Point(13, 15);
            labelTechniqueName.Margin = new Padding(4, 0, 4, 0);
            labelTechniqueName.Name = "labelTechniqueName";
            labelTechniqueName.Size = new Size(129, 15);
            labelTechniqueName.TabIndex = 0;
            labelTechniqueName.Text = "Название технологии:";
            // 
            // textBoxTechniqueName
            // 
            textBoxTechniqueName.Location = new Point(150, 12);
            textBoxTechniqueName.Margin = new Padding(4, 3, 4, 3);
            textBoxTechniqueName.Name = "textBoxTechniqueName";
            textBoxTechniqueName.Size = new Size(141, 23);
            textBoxTechniqueName.TabIndex = 1;
            // 
            // labelTechniqueDescription
            // 
            labelTechniqueDescription.AutoSize = true;
            labelTechniqueDescription.Location = new Point(13, 38);
            labelTechniqueDescription.Margin = new Padding(4, 0, 4, 0);
            labelTechniqueDescription.Name = "labelTechniqueDescription";
            labelTechniqueDescription.Size = new Size(132, 15);
            labelTechniqueDescription.TabIndex = 2;
            labelTechniqueDescription.Text = "Описание технологии:";
            // 
            // textBoxTechniqueDescription
            // 
            textBoxTechniqueDescription.Location = new Point(13, 56);
            textBoxTechniqueDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxTechniqueDescription.Multiline = true;
            textBoxTechniqueDescription.Name = "textBoxTechniqueDescription";
            textBoxTechniqueDescription.Size = new Size(278, 100);
            textBoxTechniqueDescription.TabIndex = 3;
            // 
            // buttonSaveTechnique
            // 
            buttonSaveTechnique.Location = new Point(133, 162);
            buttonSaveTechnique.Margin = new Padding(4, 3, 4, 3);
            buttonSaveTechnique.Name = "buttonSaveTechnique";
            buttonSaveTechnique.Size = new Size(75, 23);
            buttonSaveTechnique.TabIndex = 4;
            buttonSaveTechnique.Text = "Сохранить";
            buttonSaveTechnique.UseVisualStyleBackColor = true;
            buttonSaveTechnique.Click += buttonSaveTechnique_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(216, 162);
            buttonCancel.Margin = new Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddEditTechniqueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 191);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSaveTechnique);
            Controls.Add(textBoxTechniqueDescription);
            Controls.Add(labelTechniqueDescription);
            Controls.Add(textBoxTechniqueName);
            Controls.Add(labelTechniqueName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddEditTechniqueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Технология";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTechniqueName;
        private System.Windows.Forms.TextBox textBoxTechniqueName;
        private System.Windows.Forms.Label labelTechniqueDescription;
        private System.Windows.Forms.TextBox textBoxTechniqueDescription;
        private System.Windows.Forms.Button buttonSaveTechnique;
        private System.Windows.Forms.Button buttonCancel;
    }
}