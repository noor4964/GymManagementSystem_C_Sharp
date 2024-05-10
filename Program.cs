using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Welcome());
            //Application.Run(new SignUp());
            //Application.Run(new ServiceStaff());
            //Application.Run(new AttendanceForm());
            //Application.Run(new ManagerForm());
            //Application.Run(new Package());
            //Application.Run(new BKashTransaction());
            Application.Run(new Member());
        }
    }
}
