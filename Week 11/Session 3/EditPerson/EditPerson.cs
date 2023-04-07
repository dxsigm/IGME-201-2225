using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleLib;
using PeopleAppGlobals;
using CourseLib;

namespace EditPerson
{
    public partial class EditPersonForm : Form
    {
        public Person formPerson;

        public EditPersonForm(Person person, Form parentForm)
        {
            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // initialize field properties and associate all delegate method event handlers first

            this.Load += new EventHandler(EditPersonForm__Load);

            //foreach (Control control in this.Controls)
            foreach (Control control in this.detailsTabPage.Controls)
            {
                // use Tag property to indicate valid state
                control.Tag = false;
            }

            if( parentForm != null)
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;

            this.okButton.Enabled = false;

            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);

            // we could do this, but then we do not see the method signature for the delegate method
            //this.gpaTextBox.Validating += TxtBoxEmpty__Validating;

            this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);
            this.editPersonTabControl.SelectedIndexChanged += new EventHandler(EditPersonTabControl__SelectedIndexChanged);

            this.homepageWebBrowser.ScriptErrorsSuppressed = true;
            this.homepageWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(HomepageWebBrowser__DocumentCompleted);
            this.scheduleWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(ScheduleWebBrowser__DocumentCompleted);

            this.froshRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged);
            this.sophRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged);
            this.juniorRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged);
            this.seniorRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged);

            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);

            this.birthDateTimePicker.ValueChanged += new EventHandler(BirthDateTimePicker__ValueChanged);

            this.allCoursesListView.ItemActivate += new EventHandler(AllCoursesListView__ItemActivate);
            this.allCoursesListView.KeyDown += new KeyEventHandler(AllCoursesListView__KeyDown);

            this.courseSearchTextBox.TextChanged += new EventHandler(CourseSearchTextBox__TextChanged);


            this.okButton.Click += new EventHandler(OkButton__Click);
            this.cancelButton.Click += new EventHandler(CancelButton__Click);

            ///////////////////////////////////////////////////////

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();

            this.photoPictureBox.ImageLocation = person.photoPath;

            this.homepageTextBox.Text = person.homePageURL;

            // if a new person
            if (person.name == null)
            {
                // default to them
                this.themRadioButton.Checked = true;
            }
            else
            {
                switch (person.eGender)
                {
                    case genderPronoun.her:
                        this.herRadioButton.Checked = true;
                        break;

                    case genderPronoun.him:
                        this.himRadioButton.Checked = true;
                        break;

                    case genderPronoun.them:
                        this.themRadioButton.Checked = true;
                        break;
                }
            }

            if ( person.GetType() == typeof(Student))
            {
                this.typeComboBox.SelectedIndex = 0;

                Student student = (Student) person;
                this.gpaTextBox.Text = student.gpa.ToString();

                // if a new student
                if (student.name == null)
                {
                    // default class year to senior
                    this.seniorRadioButton.Checked = true;
                }
                else
                {
                    switch (student.eCollegeYear)
                    {
                        case collegeYear.freshman:
                            this.froshRadioButton.Checked = true;
                            break;

                        case collegeYear.sophomore:
                            this.sophRadioButton.Checked = true;
                            break;

                        case collegeYear.junior:
                            this.juniorRadioButton.Checked = true;
                            break;

                        case collegeYear.senior:
                        default:
                            this.seniorRadioButton.Checked = true;
                            break;
                    }
                }
            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;

                Teacher teacher = (Teacher)person;
                this.specTextBox.Text = teacher.specialty;

                this.seniorRadioButton.Checked = true;
            }

            this.Show();
        }

        private void ScheduleWebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            HtmlElement htmlElement = null;
            Course course = null;

            ICourseList iCourseList = (ICourseList)formPerson;

            string htmlId = null;

            foreach(string courseCode in iCourseList.CourseList)
            {
                course = Globals.courses[courseCode];

                foreach(DayOfWeek dayOfWeek in course.schedule.daysOfWeek)
                {
                    switch( dayOfWeek)
                    {
                        case DayOfWeek.Monday:
                        case DayOfWeek.Tuesday:
                        case DayOfWeek.Wednesday:
                        case DayOfWeek.Friday:
                        case DayOfWeek.Sunday:
                            htmlId = (dayOfWeek.ToString())[0].ToString();
                            break;

                        case DayOfWeek.Thursday:
                            htmlId = "R";
                            break;

                        case DayOfWeek.Saturday:
                            htmlId = "A";
                            break;
                    }
                }

                htmlId += $"{course.schedule.startTime:HH}";

                htmlElement = wb.Document.GetElementById(htmlId);

                if( htmlElement != null)
                {
                    htmlElement.InnerText = course.courseCode;
                    htmlElement.Style += "background-color: red;";

                    htmlElement.MouseOver += new HtmlElementEventHandler(HtmlElement__MouseOver);
                    htmlElement.MouseDown += new HtmlElementEventHandler(HtmlElement__MouseDown);
                }
            }


        }

        private void HtmlElement__MouseDown(object sender, HtmlElementEventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)sender;

            if( e.MouseButtonsPressed == MouseButtons.Left)
            {

            }
        }

        private void HtmlElement__MouseOver(object sender, HtmlElementEventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)sender;
            Course course = null;

            course = Globals.courses[htmlElement.InnerText];
            if( course != null)
            {
                this.schToolTip.Show($"Description: {course.description}\nReview: {course.review}", this.scheduleWebBrowser, e.MousePosition.X + 5, e.MousePosition.Y + 15, 1500);
            }
        }

        private void HomepageWebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;

            if(wb.Document.Title == "DOM-3")
            {
                HtmlElement htmlElement = null;
                HtmlElementCollection htmlElementCollection = null;

                htmlElement = wb.Document.Body;
                htmlElement.Style += "font-family: san-serif; color: #a000a0;";

                htmlElementCollection = wb.Document.GetElementsByTagName("h1");

                htmlElement = htmlElementCollection[0];
                htmlElement.InnerText = "My Kitten Page";

                htmlElement.MouseOver += new HtmlElementEventHandler(Example__MouseOver);

                htmlElementCollection = wb.Document.GetElementsByTagName("h2");

                htmlElementCollection[0].InnerText = "Meow";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>";
                htmlElementCollection[2].InnerText = "";

                
                HtmlElement imgElement = wb.Document.CreateElement("img");
                imgElement.SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");
                imgElement.SetAttribute("title", "awwwwwww");
                imgElement.Click += new HtmlElementEventHandler(Example_IMG__Click);


                htmlElement = wb.Document.GetElementById("lastParagraph");
                htmlElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, imgElement);

                htmlElement = wb.Document.CreateElement("footer");
                htmlElement.InnerHtml = "&copy;2023 <a href='http://www.nerdtherapy.org'>D. Schuh</a>";

                wb.Document.Body.AppendChild(htmlElement);
            }
        }


        private void Example_IMG__Click(object sender, EventArgs e)
        {
            this.homepageWebBrowser.Navigate("http://m.youtube.com/watch?v=oHg5SJYRHA0");
        }

        private void Example__MouseOver(object sender, HtmlElementEventArgs e )
        {
            HtmlElement htmlElement = (HtmlElement)sender;
            HtmlElementCollection htmlElementCollection = null;

            if( htmlElement.InnerText.ToLower().Contains("kitten"))
            {
                htmlElement.InnerText = "My Puppy Page";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Woof";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.puppies.com'>Puppies!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://www.allthingsdogs.com/wp-content/uploads/2019/05/Cute-Puppy-Names.jpg");

            }
            else
            {
                htmlElement.InnerText = "My Kitten Page";
                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Meow";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");

            }
        }

        private void EditPersonTabControl__SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;

            if( tc.SelectedTab == this.homePageTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;

                homepageWebBrowser.Navigate(this.homepageTextBox.Text);
            }
            else if(tc.SelectedTab == this.detailsTabPage)
            {
                this.AcceptButton = this.okButton;
                this.CancelButton = this.cancelButton;
            }
            else if(tc.SelectedTab == this.coursesTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;

                PaintListView(selectedCoursesListView);
                PaintListView(allCoursesListView);
            }
            else if (tc.SelectedTab == this.scheduleTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;

                this.scheduleWebBrowser.Navigate("https://people.rit.edu/dxsigm/schedule.html");
            }
        }

        private void AllCoursesListView__ItemActivate(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            Course course = null;
            string courseCode = "";

            courseCode = lv.SelectedItems[0].Tag.ToString();

            course = Globals.courses[courseCode];

            ICourseList iCourseList = (ICourseList)formPerson;

            if( course != null)
            {
                if( iCourseList.CourseList.Contains(course.courseCode))
                {
                    iCourseList.CourseList.Remove(course.courseCode);
                }
                else
                {
                    iCourseList.CourseList.Add(course.courseCode);
                }

                PaintListView(selectedCoursesListView);
            }
        }

        private void AllCoursesListView__KeyDown(object sender, KeyEventArgs e)
        {
            ListView lv = (ListView )sender;
            Course course = null;
            string courseCode = null;

            if( e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                try
                {
                    courseCode = lv.SelectedItems[0].Tag.ToString();

                    course = Globals.courses[courseCode];

                    if( courseCode != null )
                    {
                        ICourseList iCourseList = (ICourseList)formPerson;

                        if( iCourseList.CourseList.Contains(course.courseCode))
                        {
                            iCourseList.CourseList.Remove(course.courseCode);
                        }
                        else
                        {
                            iCourseList.CourseList.Add(course.courseCode);
                        }

                        PaintListView(selectedCoursesListView);
                    }
                }
                catch
                {

                }
            }
        }

        private void CourseSearchTextBox__TextChanged(object sender, EventArgs e)
        {
            PaintListView(allCoursesListView);
        }


        public void PaintListView(ListView lv)
        {
            // redraws the ListView based on the current contents of courses
            // and whether to start the current page of courses with firstCourseCode
            // passed in as a parameter
            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;


            // 12. clear the listview items
            lv.Items.Clear();

            // 13. lock the listview to begin updating it
            lv.BeginUpdate();

            int lviCntr = 0;

            // 14. loop through all courses in Globals.courses.sortedList and insert them in the ListView
            foreach (KeyValuePair<string, Course> keyValuePair in Globals.courses.sortedList)
            {
                Course thisCourse = null;

                // 15. set thisCourse to the Value in the current keyValuePair
                thisCourse = keyValuePair.Value;

                if (lv == selectedCoursesListView)
                {
                    ICourseList iCourseList = (ICourseList)formPerson;

                    if (!iCourseList.CourseList.Contains(thisCourse.courseCode))
                    {
                        continue;
                    }
                }
                else
                {
                    if (courseSearchTextBox.TextLength > 0)
                    {
                        if (!thisCourse.courseCode.Contains(courseSearchTextBox.Text) &&
                            !thisCourse.description.Contains(courseSearchTextBox.Text))
                        {
                            continue;
                        }
                    }
                }


                // 16. create a new ListViewItem named lvi
                lvi = new ListViewItem();

                // 17. set the first column of this row to show thisCourse.courseCode
                lvi.Text = thisCourse.courseCode;

                // 18. set the Tag property for this ListViewItem to the courseCode
                lvi.Tag = thisCourse.courseCode;

                // alternate row color
                if (lviCntr % 2 == 0)
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }


                // 19. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 20. set the column to show thisCourse.description
                lvsi.Text = thisCourse.description;

                // 21. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 22. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 23. set the column to show thisCourse.teacherEmail
                lvsi.Text = thisCourse.teacherEmail;

                // 24. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 25. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 26. set the column to show thisCourse.schedule.DaysOfWeek()
                // note that thisCourse.schedule.DaysOfWeek() returns the string that we want to display
                lvsi.Text = thisCourse.schedule.DaysOfWeek();

                // 27. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 28. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 29. set the column to show thisCourse.schedule.GetTimes()
                // note that thisCourse.schedule.GetTimes() returns the string that we want to display
                lvsi.Text = thisCourse.schedule.GetTimes();

                // 30. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);

                // 35. lvi is all filled in for all columns for this row so add it to courseListView.Items
                lv.Items.Add(lvi);

                // 36. increment our counter to alternate colors and check for nStartEl
                ++lviCntr;
            }


            // 37. unlock the ListView since we are done updating the contents
            lv.EndUpdate();

        }



        private void BirthDateTimePicker__ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if(dtp.Value == dtp.MinDate)
            {
                dtp.CustomFormat = " ";

            }
            else
            {
                dtp.CustomFormat = "MMM d, yyyy";
            }
        }

        private void PhotoPictureBox__Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            if( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                pb.ImageLocation = this.openFileDialog.FileName;
            }
        }


        private void ClassRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            // if the radio button is checked
            if (rb.Checked)
            {
                if (rb == this.froshRadioButton)
                {
                    classOfLabel.Text = "Class of 2026";
                }

                if (rb == this.sophRadioButton)
                {
                    classOfLabel.Text = "Class of 2025";
                }

                if (rb == this.juniorRadioButton)
                {
                    classOfLabel.Text = "Class of 2024";
                }

                if (rb == this.seniorRadioButton)
                {
                    classOfLabel.Text = "Class of 2023";
                }
            }
        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            if( this.Owner != null)
            {
                // enable the parent form
                this.Owner.Enabled = true;

                // and set it into focus to process mouse and keyboard events
                this.Owner.Focus();

                // repaint the parent form's ListView control with the edited person at the top of the screen
                IListView iListView = (IListView)this.Owner;
                iListView.PaintListView(formPerson.email);
            }

            this.Close();
            this.Dispose();
        }

        private void OkButton__Click(object sender, EventArgs e)
        {
            Student student = null;
            Teacher teacher = null;
            Person person = null;

            Globals.people.Remove(this.formPerson.email);

            if( this.typeComboBox.SelectedIndex == 0)
            {
                student = new Student();
                person = student;
            }
            else
            {
                teacher = new Teacher();
                person = teacher;
            }

            person.name = this.nameTextBox.Text;
            person.email = this.emailTextBox.Text;
            person.age = Convert.ToInt32(this.ageTextBox.Text);
            person.LicenseId = Convert.ToInt32(this.licTextBox.Text);

            person.photoPath = this.photoPictureBox.ImageLocation;

            person.homePageURL = this.homepageTextBox.Text;
            
            if ( person.dateOfBirth > this.birthDateTimePicker.MinDate )
            {
                this.birthDateTimePicker.Value = person.dateOfBirth;
            }
            else
            {
                this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate;
            }

            if (this.herRadioButton.Checked)
            {
                person.eGender = genderPronoun.her;
            }

            if (this.himRadioButton.Checked)
            {
                person.eGender = genderPronoun.him;
            }

            if (this.themRadioButton.Checked)
            {
                person.eGender = genderPronoun.them;
            }



            if ( person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text);

                if (this.froshRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.freshman;
                }

                if (this.sophRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.sophomore;
                }

                if (this.juniorRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.junior;
                }

                if (this.seniorRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.senior;
                }
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;
            }

            Globals.people[person.email] = person;

            if (this.Owner != null)
            {
                // enable the parent form
                this.Owner.Enabled = true;

                // and set it into focus to process mouse and keyboard events
                this.Owner.Focus();

                // repaint the parent form's ListView control with the edited person at the top of the screen
                IListView iListView = (IListView)this.Owner;
                iListView.PaintListView(formPerson.email);
            }

            this.Close();
            this.Dispose();
        }


        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if( cb.SelectedIndex == 0)
            {
                this.specialtyLabel.Visible = false;
                this.specTextBox.Visible = false;

                this.specTextBox.Tag = true;

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true;

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0);

                this.classGroupBox.Visible = true;
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);

                this.classGroupBox.Visible = false;
            }

            ValidateAll();
        }


        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                if( tb == this.gpaTextBox )
                {
                    if( e.KeyChar == '.' && !tb.Text.Contains("."))
                    {
                        e.Handled = false;
                    }
                }
            }

            ValidateAll();
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e )
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                tb.Tag = true;
            }

            ValidateAll();
        }


        private void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if( tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void ValidateAll()
        {
            this.okButton.Enabled =
                (bool)this.nameTextBox.Tag &&
                (bool)this.emailTextBox.Tag &&
                (bool)this.ageTextBox.Tag &&
                (bool)this.specTextBox.Tag &&
                (bool)this.gpaTextBox.Tag;
        }

        private void EditPersonForm__Load(object sender, EventArgs e)
        {

        }

        private void EditPersonForm_Load(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
