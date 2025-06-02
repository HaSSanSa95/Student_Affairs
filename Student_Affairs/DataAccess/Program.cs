using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using DXApplication6;
using StoresApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Student_Affairs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Dashboard());


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginFrm());
            //// Show the splash screen
            //SplashScreenManager.ShowForm(typeof(SplashScreen1));

            //// Simulate loading process (you can load resources, initialize app, etc.)
            //System.Threading.Thread.Sleep(2500); // For demonstration purposes

            //// Close the splash screen
            //if (SplashScreenManager.Default != null)
            //{
            //    SplashScreenManager.CloseForm();
            //}

            //// Show the login form after the splash screen
            //LoginFrm loginForm = new LoginFrm();
            //if (loginForm.ShowDialog() == DialogResult.OK) // If login is successful
            //{
            //    // Proceed to the main form
            //    Application.Run(new Dashboard());
            //}


        }
    }
}
