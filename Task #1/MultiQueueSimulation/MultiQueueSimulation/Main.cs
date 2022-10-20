using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Main : Form
    {
        private string fileName;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string getFileName()
        {
            return fileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testCaseFileDialog = new OpenFileDialog();
            DialogResult fileResult = testCaseFileDialog.ShowDialog();
           
            if (fileResult == DialogResult.OK)
            {
                    fileName = testCaseFileDialog.SafeFileName;
                    //Console.WriteLine(fileName);
            }
        }

    }
}
