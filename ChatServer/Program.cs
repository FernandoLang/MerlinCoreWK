using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemTrayApp;
namespace systemtray
{
    static class Program
    {

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContextMenus a = new ContextMenus();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (ProcessIcon pi = new ProcessIcon())
            {
                if(a.actvate)
                {
                    pi.Display();
                }
                // Make sure the application runs!
                Application.Run();
            }
        }
    }
}
