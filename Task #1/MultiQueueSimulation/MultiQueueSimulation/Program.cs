using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;
//sb7 ya 3m goda
namespace MultiQueueSimulation
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
            Main form = new Main();
            Application.Run(form);
            //SimulationSystem system = new SimulationSystem();
            //string result = TestingManager.Test(system, form.getFileName());
            //MessageBox.Show(result);
        }
    }
}
