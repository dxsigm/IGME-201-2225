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

            this.pizzaRadioButton.CheckedChanged += new EventHandler(FoodRadioButton__CheckedChanged);
            this.sushiRadioButton.CheckedChanged += new EventHandler(FoodRadioButton__CheckedChanged);
            this.appleRadioButton.CheckedChanged += new EventHandler(FoodRadioButton__CheckedChanged);

            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);

            this.birthDateTimePicker.ValueChanged += new EventHandler(BirthDateTimePicker__ValueChanged);


            this.okButton.Click += new EventHandler(OkButton__Click);
            this.cancelButton.Click += new EventHandler(CancelButton__Click);

            ///////////////////////////////////////////////////////

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();

            this.photoPictureBox.ImageLocation = person.photoPath;

            this.homepageTextBox.Text = person.homePageURL;

            switch (person.favFood)
            {
                case "pizza":
                    this.pizzaRadioButton.Checked = true;
                    break;

                case "sushi":
                    this.sushiRadioButton.Checked = true;
                    break;

                case "apple":
                default:
                    this.appleRadioButton.Checked = true;
                    break;
            }

            if ( person.GetType() == typeof(Student))
            {
                this.typeComboBox.SelectedIndex = 0;

                Student student = (Student) person;
                this.gpaTextBox.Text = student.gpa.ToString();
                this.okRadioButton.Checked = true;
            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;

                Teacher teacher = (Teacher)person;
                this.specTextBox.Text = teacher.specialty;

                switch( teacher.rating)
                {
                    case "Ok":
                    default:
                        this.okRadioButton.Checked = true;
                        break;
                    case "Excellent":
                        this.excellentRadioButton.Checked = true;
                        break;
                    case "Poor":
                        this.poorRadioButton.Checked = true;
                        break;
                }
            }

            this.Show();
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


            }
        }


        private void Example_IMG__Click(object sender, EventArgs e)
        {
            this.homepageWebBrowser.Navigate("http://m.youtube.com/watch?v=oHg5SJYRHA0");
        }

        private void Example__MouseOver(object sender, HtmlElementEventArgs e )
        {
            HtmlElement htmlElement = (HtmlElement)sender;

            if( htmlElement.InnerText.ToLower().Contains("kitten"))
            {
                htmlElement.InnerText = "My Puppy Page";
            }
            else
            {
                htmlElement.InnerText = "My Kitten Page";
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


        private void FoodRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if( rb.Checked)
            {
                if (rb == this.pizzaRadioButton)
                {
                    this.orderLabel.Text = "Salvatores";
                }

                if( rb == this.sushiRadioButton)
                {
                    this.orderLabel.Text = "Wegmans";
                }

                if( rb == this.appleRadioButton)
                {
                    this.orderLabel.Text = "Orchard";
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

            if (this.pizzaRadioButton.Checked)
            {
                person.favFood = "pizza";
            }
            else if (this.sushiRadioButton.Checked)
            {
                person.favFood = "sushi";
            }
            else if (this.appleRadioButton.Checked)
            {
                person.favFood = "apple";
            }


            if ( person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text);
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;

                if (this.okRadioButton.Checked)
                {
                    teacher.rating = "Ok";
                }
                else if (this.excellentRadioButton.Checked)
                {
                    teacher.rating = "Excellent";
                }
                else if (this.poorRadioButton.Checked)
                {
                    teacher.rating = "Poor";
                }
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

                this.ratingGroupBox.Visible = false;
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);

                this.ratingGroupBox.Visible = true;
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
