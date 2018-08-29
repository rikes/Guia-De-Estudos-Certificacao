using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._5_System_event_log
{
    static class Program
    {
        /// <summary>
        /// App que grava um registro de eventos no Windows no programa "Visualizador de eventos" (Requer adm)
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
