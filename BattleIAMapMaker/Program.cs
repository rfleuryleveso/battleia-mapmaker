using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleIAMapMaker
{
    static class Program
    {
        public static Form1 mainForm;
        public static Map map;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            map = new Map(50, 50);
            mainForm = new Form1();
            mainForm.displayGrid();
            Application.Run(mainForm);

        }

        
    }
}
