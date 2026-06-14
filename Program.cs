using System;
using System.IO;
using System.Windows.Forms;

namespace ECS_GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}