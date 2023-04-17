namespace Sherlock
{
    partial class SherlockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SherlockForm));
            this.qbfLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.countdownLabel = new System.Windows.Forms.Label();
            this.happyPictureBox = new System.Windows.Forms.PictureBox();
            this.sadPictureBox = new System.Windows.Forms.PictureBox();
            this.webGroupBox = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.exitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).BeginInit();
            this.webGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // qbfLabel
            // 
            this.qbfLabel.AutoSize = true;
            this.qbfLabel.Location = new System.Drawing.Point(12, 9);
            this.qbfLabel.Name = "qbfLabel";
            this.qbfLabel.Size = new System.Drawing.Size(24, 13);
            this.qbfLabel.TabIndex = 0;
            this.qbfLabel.Text = "text";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 20);
            this.textBox1.TabIndex = 1;
            // 
            // countdownLabel
            // 
            this.countdownLabel.AutoSize = true;
            this.countdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdownLabel.ForeColor = System.Drawing.Color.Red;
            this.countdownLabel.Location = new System.Drawing.Point(84, 68);
            this.countdownLabel.Name = "countdownLabel";
            this.countdownLabel.Size = new System.Drawing.Size(204, 73);
            this.countdownLabel.TabIndex = 2;
            this.countdownLabel.Text = "label1";
            // 
            // happyPictureBox
            // 
            this.happyPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("happyPictureBox.Image")));
            this.happyPictureBox.Location = new System.Drawing.Point(45, 156);
            this.happyPictureBox.Name = "happyPictureBox";
            this.happyPictureBox.Size = new System.Drawing.Size(260, 196);
            this.happyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.happyPictureBox.TabIndex = 3;
            this.happyPictureBox.TabStop = false;
            // 
            // sadPictureBox
            // 
            this.sadPictureBox.ImageLocation = "c:/temp/sad.jpg";
            this.sadPictureBox.Location = new System.Drawing.Point(45, 156);
            this.sadPictureBox.Name = "sadPictureBox";
            this.sadPictureBox.Size = new System.Drawing.Size(260, 196);
            this.sadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sadPictureBox.TabIndex = 4;
            this.sadPictureBox.TabStop = false;
            // 
            // webGroupBox
            // 
            this.webGroupBox.Controls.Add(this.webBrowser1);
            this.webGroupBox.Location = new System.Drawing.Point(418, 25);
            this.webGroupBox.Name = "webGroupBox";
            this.webGroupBox.Size = new System.Drawing.Size(356, 327);
            this.webGroupBox.TabIndex = 5;
            this.webGroupBox.TabStop = false;
            this.webGroupBox.Text = "https://people.rit.edu/dxsigm/sherlock.html";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(350, 308);
            this.webBrowser1.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(696, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // SherlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.webGroupBox);
            this.Controls.Add(this.sadPictureBox);
            this.Controls.Add(this.happyPictureBox);
            this.Controls.Add(this.countdownLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.qbfLabel);
            this.Name = "SherlockForm";
            this.Text = "Sherlock";
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).EndInit();
            this.webGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label qbfLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label countdownLabel;
        private System.Windows.Forms.PictureBox happyPictureBox;
        private System.Windows.Forms.PictureBox sadPictureBox;
        private System.Windows.Forms.GroupBox webGroupBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer timer1;
    }
}

