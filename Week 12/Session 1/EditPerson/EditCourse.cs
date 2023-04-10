using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseLib;
using PeopleAppGlobals;

namespace EditPerson
{
    public partial class EditCourseForm : Form
    {
        Course formCourse;
        public EditCourseForm(string courseCode)
        {
            InitializeComponent();

            formCourse = Globals.courses[courseCode];

            codeTextBox.Text = courseCode;
            descTextBox.Text = formCourse.description;
            revRichTextBox.Text = formCourse.review;

            updateButton.Click += new EventHandler(UpdateButton__Click);
            exitButton.Click += new EventHandler(ExitButton__Click);

            Show();
        }

        private void UpdateButton__Click(object sender, EventArgs e)
        {
            formCourse.description = descTextBox.Text;
            formCourse.review = revRichTextBox.Text;

            Globals.courses.Remove(formCourse.courseCode);
            Globals.courses[formCourse.courseCode] = formCourse;
            this.Close();
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }


}
