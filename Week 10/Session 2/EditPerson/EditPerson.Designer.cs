﻿namespace EditPerson
{
    partial class EditPersonForm
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
            this.components = new System.ComponentModel.Container();
            this.typeVal = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.licLabel = new System.Windows.Forms.Label();
            this.licTextBox = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.specTextBox = new System.Windows.Forms.TextBox();
            this.gpaLabel = new System.Windows.Forms.Label();
            this.gpaTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.excellentRadioButton = new System.Windows.Forms.RadioButton();
            this.poorRadioButton = new System.Windows.Forms.RadioButton();
            this.okRadioButton = new System.Windows.Forms.RadioButton();
            this.pizzaRadioButton = new System.Windows.Forms.RadioButton();
            this.sushiRadioButton = new System.Windows.Forms.RadioButton();
            this.appleRadioButton = new System.Windows.Forms.RadioButton();
            this.ratingGroupBox = new System.Windows.Forms.GroupBox();
            this.foodGroupBox = new System.Windows.Forms.GroupBox();
            this.orderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.ratingGroupBox.SuspendLayout();
            this.foodGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeVal
            // 
            this.typeVal.Location = new System.Drawing.Point(9, 20);
            this.typeVal.Name = "typeVal";
            this.typeVal.Size = new System.Drawing.Size(70, 13);
            this.typeVal.TabIndex = 0;
            this.typeVal.Text = "Person type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(80, 18);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(119, 21);
            this.typeComboBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(9, 55);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(70, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(80, 53);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(207, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // emailLabel
            // 
            this.emailLabel.Location = new System.Drawing.Point(9, 92);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(70, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(80, 89);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(352, 20);
            this.emailTextBox.TabIndex = 2;
            // 
            // ageLabel
            // 
            this.ageLabel.Location = new System.Drawing.Point(9, 131);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(70, 13);
            this.ageLabel.TabIndex = 3;
            this.ageLabel.Text = "Age:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(80, 128);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(60, 20);
            this.ageTextBox.TabIndex = 3;
            // 
            // licLabel
            // 
            this.licLabel.Location = new System.Drawing.Point(9, 171);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(70, 13);
            this.licLabel.TabIndex = 4;
            this.licLabel.Text = "License Id:";
            // 
            // licTextBox
            // 
            this.licTextBox.Location = new System.Drawing.Point(80, 169);
            this.licTextBox.Name = "licTextBox";
            this.licTextBox.Size = new System.Drawing.Size(119, 20);
            this.licTextBox.TabIndex = 4;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.Location = new System.Drawing.Point(9, 210);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(70, 13);
            this.specialtyLabel.TabIndex = 5;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(80, 207);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(352, 20);
            this.specTextBox.TabIndex = 5;
            // 
            // gpaLabel
            // 
            this.gpaLabel.Location = new System.Drawing.Point(9, 210);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(60, 13);
            this.gpaLabel.TabIndex = 6;
            this.gpaLabel.Text = "GPA:";
            // 
            // gpaTextBox
            // 
            this.gpaTextBox.Location = new System.Drawing.Point(80, 207);
            this.gpaTextBox.Name = "gpaTextBox";
            this.gpaTextBox.Size = new System.Drawing.Size(60, 20);
            this.gpaTextBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(652, 337);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 24);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(734, 337);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 24);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // excellentRadioButton
            // 
            this.excellentRadioButton.AutoSize = true;
            this.excellentRadioButton.Location = new System.Drawing.Point(19, 21);
            this.excellentRadioButton.Name = "excellentRadioButton";
            this.excellentRadioButton.Size = new System.Drawing.Size(68, 17);
            this.excellentRadioButton.TabIndex = 6;
            this.excellentRadioButton.TabStop = true;
            this.excellentRadioButton.Text = "Excellent";
            this.excellentRadioButton.UseVisualStyleBackColor = true;
            // 
            // poorRadioButton
            // 
            this.poorRadioButton.AutoSize = true;
            this.poorRadioButton.Location = new System.Drawing.Point(19, 67);
            this.poorRadioButton.Name = "poorRadioButton";
            this.poorRadioButton.Size = new System.Drawing.Size(47, 17);
            this.poorRadioButton.TabIndex = 8;
            this.poorRadioButton.TabStop = true;
            this.poorRadioButton.Text = "Poor";
            this.poorRadioButton.UseVisualStyleBackColor = true;
            // 
            // okRadioButton
            // 
            this.okRadioButton.AutoSize = true;
            this.okRadioButton.Location = new System.Drawing.Point(19, 44);
            this.okRadioButton.Name = "okRadioButton";
            this.okRadioButton.Size = new System.Drawing.Size(39, 17);
            this.okRadioButton.TabIndex = 7;
            this.okRadioButton.TabStop = true;
            this.okRadioButton.Text = "Ok";
            this.okRadioButton.UseVisualStyleBackColor = true;
            // 
            // pizzaRadioButton
            // 
            this.pizzaRadioButton.AutoSize = true;
            this.pizzaRadioButton.Location = new System.Drawing.Point(15, 19);
            this.pizzaRadioButton.Name = "pizzaRadioButton";
            this.pizzaRadioButton.Size = new System.Drawing.Size(50, 17);
            this.pizzaRadioButton.TabIndex = 9;
            this.pizzaRadioButton.TabStop = true;
            this.pizzaRadioButton.Text = "Pizza";
            this.pizzaRadioButton.UseVisualStyleBackColor = true;
            // 
            // sushiRadioButton
            // 
            this.sushiRadioButton.AutoSize = true;
            this.sushiRadioButton.Location = new System.Drawing.Point(15, 42);
            this.sushiRadioButton.Name = "sushiRadioButton";
            this.sushiRadioButton.Size = new System.Drawing.Size(51, 17);
            this.sushiRadioButton.TabIndex = 10;
            this.sushiRadioButton.TabStop = true;
            this.sushiRadioButton.Text = "Sushi";
            this.sushiRadioButton.UseVisualStyleBackColor = true;
            // 
            // appleRadioButton
            // 
            this.appleRadioButton.AutoSize = true;
            this.appleRadioButton.Location = new System.Drawing.Point(15, 65);
            this.appleRadioButton.Name = "appleRadioButton";
            this.appleRadioButton.Size = new System.Drawing.Size(52, 17);
            this.appleRadioButton.TabIndex = 11;
            this.appleRadioButton.TabStop = true;
            this.appleRadioButton.Text = "Apple";
            this.appleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ratingGroupBox
            // 
            this.ratingGroupBox.Controls.Add(this.excellentRadioButton);
            this.ratingGroupBox.Controls.Add(this.poorRadioButton);
            this.ratingGroupBox.Controls.Add(this.okRadioButton);
            this.ratingGroupBox.Location = new System.Drawing.Point(525, 20);
            this.ratingGroupBox.Name = "ratingGroupBox";
            this.ratingGroupBox.Size = new System.Drawing.Size(104, 124);
            this.ratingGroupBox.TabIndex = 12;
            this.ratingGroupBox.TabStop = false;
            this.ratingGroupBox.Text = "Rating";
            // 
            // foodGroupBox
            // 
            this.foodGroupBox.Controls.Add(this.orderLabel);
            this.foodGroupBox.Controls.Add(this.pizzaRadioButton);
            this.foodGroupBox.Controls.Add(this.sushiRadioButton);
            this.foodGroupBox.Controls.Add(this.appleRadioButton);
            this.foodGroupBox.Location = new System.Drawing.Point(635, 20);
            this.foodGroupBox.Name = "foodGroupBox";
            this.foodGroupBox.Size = new System.Drawing.Size(113, 128);
            this.foodGroupBox.TabIndex = 13;
            this.foodGroupBox.TabStop = false;
            this.foodGroupBox.Text = "Fav Food";
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(38, 95);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(35, 13);
            this.orderLabel.TabIndex = 12;
            this.orderLabel.Text = "label1";
            // 
            // EditPersonForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(802, 373);
            this.Controls.Add(this.foodGroupBox);
            this.Controls.Add(this.ratingGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gpaTextBox);
            this.Controls.Add(this.gpaLabel);
            this.Controls.Add(this.specTextBox);
            this.Controls.Add(this.specialtyLabel);
            this.Controls.Add(this.licTextBox);
            this.Controls.Add(this.licLabel);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeVal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(812, 406);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(812, 406);
            this.Name = "EditPersonForm";
            this.ShowInTaskbar = false;
            this.Text = "Edit Person";
            this.Load += new System.EventHandler(this.EditPersonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ratingGroupBox.ResumeLayout(false);
            this.ratingGroupBox.PerformLayout();
            this.foodGroupBox.ResumeLayout(false);
            this.foodGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeVal;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label licLabel;
        private System.Windows.Forms.TextBox licTextBox;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox specTextBox;
        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.TextBox gpaTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton appleRadioButton;
        private System.Windows.Forms.RadioButton sushiRadioButton;
        private System.Windows.Forms.RadioButton pizzaRadioButton;
        private System.Windows.Forms.RadioButton okRadioButton;
        private System.Windows.Forms.RadioButton poorRadioButton;
        private System.Windows.Forms.RadioButton excellentRadioButton;
        private System.Windows.Forms.GroupBox foodGroupBox;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.GroupBox ratingGroupBox;
    }
}

