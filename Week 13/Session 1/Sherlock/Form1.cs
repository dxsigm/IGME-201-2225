using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sherlock
{
    public partial class SherlockForm : Form
    {
        public SherlockForm()
        {
            InitializeComponent();

            // exit button disabled
            this.exitButton.Enabled = false;

            // set label text
            this.qbfLabel.Text = "The quick brown fox jumped over the lazy dog.";

            // hide the countdown label
            this.countdownLabel.Visible= false;

            // initialize countdown label to "20"
            this.countdownLabel.Text = "20";

            // hide picture boxes
            this.happyPictureBox.Visible= false;
            this.sadPictureBox.Visible= false;

            // set the timer interval to 1 second
            this.timer1.Interval = 1000;

            // need a textbox keypress event handler - wrong characters show the sad face, vice versa, 
            // if the sentence correct sentence then the exit button is enabled
            this.textBox1.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            // navigate the webbrowser to the url
            this.webBrowser1.Navigate(this.webGroupBox.Text);

            // catch when the web browser completes so we can set up the html dom manipulation
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);

            // timer tick event handler to countdown the label, and to clears the textbox if out of time
            this.timer1.Tick += new EventHandler(Timer__Tick);

            // event handler to exit app on exit button click
            this.exitButton.Click += new EventHandler(ExitButton__Click);
        }

        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            // if countdown label is 20
            if( countdownLabel.Text == "20")
            {
                // start the timer
                timer1.Start();

                // make countdown label visible
                countdownLabel.Visible = true;
            }

            // if they typed the correct character
            if(qbfLabel.Text[textBox1.TextLength] == e.KeyChar)
            {
                // let .NET handle the keypress
                e.Handled = false;

                // show the happy face
                happyPictureBox.Visible = true;


                // hide the sad
                sadPictureBox.Visible = false;

                // if they typed the full sentence
                if( textBox1.Text + e.KeyChar == qbfLabel.Text)
                {
                    // enable the exit button
                    exitButton.Enabled = true;

                    // disable the keypress event handler
                    textBox1.KeyPress -= TextBox__KeyPress;
                }
            }
            // else they typed the wrong character
            else
            {
                // do not show the character in the textbox
                e.Handled = true;

                // show the sad face
                sadPictureBox.Visible = true;

                // hide the happy face
                happyPictureBox.Visible = false;
            }
        }

        private void Timer__Tick(object sender, EventArgs e)
        {
            // if the countdown label is 1
            if( countdownLabel.Text == "1")
            {
                // stop the timer
                timer1.Stop();

                // clear the textbox
                textBox1.Text = "";

                // reset the countdown label to 20
                countdownLabel.Text=  "20";

                // hide the pictureboxes
                sadPictureBox.Visible = false;
                happyPictureBox.Visible = false;

                // hide the countdown label
                countdownLabel.Visible = false;
            }
            else
            {
                // decrement the countdown label
                countdownLabel.Text = (Int32.Parse(countdownLabel.Text) - 1).ToString();
            }
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // get a ref to the web browser control
            WebBrowser wb = (WebBrowser) sender;;

            // get the anchor tag elements
            HtmlElementCollection htmlElementCollection = wb.Document.GetElementsByTagName("a");


            // for each anchor tag
            foreach(HtmlElement htmlElement in htmlElementCollection)
            {
                // associate a Click event handler
                htmlElement.Click += new HtmlElementEventHandler(Link__Click);
            }

            // remove the delegate method from the web browser control
            wb.DocumentCompleted -= WebBrowser__DocumentCompleted;
        }

        private void Link__Click(object sender, HtmlElementEventArgs e)
        {
            // fetch the element that was clicked
            HtmlElement htmlElement = (HtmlElement)sender;

            // if the current text contains "again"
            if (htmlElement.InnerText.Contains("again"))
            {
                // change the text and style to last phrase
                htmlElement.InnerText = "I asked you to stop it.";
                htmlElement.Style = "color: purple; font-size: 2.5rem;";

                // remove the click event handler from this element
                htmlElement.Click -= Link__Click;
            }
            else if (htmlElement.InnerText.Contains("clicked"))
            {
                // change the text and style to the second phrase
                htmlElement.InnerText = "You clicked me again.  Now stop it.";
                htmlElement.Style = "color: red; font-size: 2rem;";
            }
            else
            {
                // chane the text and style to the first phrase
                htmlElement.InnerText = "You clicked me!";
                htmlElement.Style = "color: blue; font-size: 1.5rem;";
            }
        }


    }
}
