using System;
using System.Windows.Forms;

namespace ZooApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with LoginForm FIRST
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
