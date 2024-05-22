namespace BD_1
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbMedicationID;
        private ComboBox cmbIngredientID;
        private TextBox txtQuantity;
        private Button btnSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbMedicationID = new ComboBox();
            cmbIngredientID = new ComboBox();
            txtQuantity = new TextBox();
            btnSubmit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonClancel = new Button();
            label4 = new Label();
            textBoxCriticaLevel = new TextBox();
            SuspendLayout();
            // 
            // cmbMedicationID
            // 
            cmbMedicationID.FormattingEnabled = true;
            cmbMedicationID.Location = new Point(11, 27);
            cmbMedicationID.Name = "cmbMedicationID";
            cmbMedicationID.Size = new Size(200, 23);
            cmbMedicationID.TabIndex = 0;
            // 
            // cmbIngredientID
            // 
            cmbIngredientID.FormattingEnabled = true;
            cmbIngredientID.Location = new Point(11, 71);
            cmbIngredientID.Name = "cmbIngredientID";
            cmbIngredientID.Size = new Size(200, 23);
            cmbIngredientID.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(11, 115);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 23);
            txtQuantity.TabIndex = 2;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(56, 188);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Сохранить";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 4;
            label1.Text = "Лекарство";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 53);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 5;
            label2.Text = "Ингридиент";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Количество";
            // 
            // buttonClancel
            // 
            buttonClancel.Location = new Point(137, 188);
            buttonClancel.Name = "buttonClancel";
            buttonClancel.Size = new Size(75, 23);
            buttonClancel.TabIndex = 7;
            buttonClancel.Text = "Отмена";
            buttonClancel.UseVisualStyleBackColor = true;
            buttonClancel.Click += buttonClancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 141);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 8;
            label4.Text = "Критическая норма";
            // 
            // textBoxCriticaLevel
            // 
            textBoxCriticaLevel.Location = new Point(11, 159);
            textBoxCriticaLevel.Name = "textBoxCriticaLevel";
            textBoxCriticaLevel.Size = new Size(200, 23);
            textBoxCriticaLevel.TabIndex = 9;
            // 
            // ReservationForm
            // 
            ClientSize = new Size(224, 216);
            Controls.Add(textBoxCriticaLevel);
            Controls.Add(label4);
            Controls.Add(buttonClancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbMedicationID);
            Controls.Add(cmbIngredientID);
            Controls.Add(txtQuantity);
            Controls.Add(btnSubmit);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReservationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Состав лекарства";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonClancel;
        private Label label4;
        private TextBox textBoxCriticaLevel;
    }
}