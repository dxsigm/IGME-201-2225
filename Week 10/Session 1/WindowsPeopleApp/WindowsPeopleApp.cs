using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals;
using PeopleWinApp;

namespace WindowsPeopleApp
{
    internal static class WindowsPeopleApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Globals.AddPeopleSampleData();
            Globals.AddCoursesSampleData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PeopleListForm());
        }
    }
}
