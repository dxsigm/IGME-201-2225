﻿namespace PeopleList
{
    partial class PeopleListForm
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
            this.peopleListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // peopleListView
            // 
            this.peopleListView.HideSelection = false;
            this.peopleListView.Location = new System.Drawing.Point(35, 60);
            this.peopleListView.Name = "peopleListView";
            this.peopleListView.Size = new System.Drawing.Size(121, 97);
            this.peopleListView.TabIndex = 0;
            this.peopleListView.UseCompatibleStateImageBehavior = false;
            this.peopleListView.View = System.Windows.Forms.View.Details;
            // 
            // PeopleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 383);
            this.Controls.Add(this.peopleListView);
            this.Name = "PeopleListForm";
            this.Text = "PeopleList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView peopleListView;
    }
}