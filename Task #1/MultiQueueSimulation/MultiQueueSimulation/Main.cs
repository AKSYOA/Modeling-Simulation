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

        public void displayData()
        {
            numberOfServersTextBox.Text = FileHandler.system.NumberOfServers.ToString();
            stoppingNumberTextBox.Text = FileHandler.system.StoppingNumber.ToString();
            stoppingCriteriaTextBox.Text = FileHandler.system.StoppingCriteria.ToString();
            selectionMethodTextBox.Text = FileHandler.system.SelectionMethod.ToString();
            for (int i = 0; i < FileHandler.system.InterarrivalDistribution.Count; i++)
            {
                int interarrivalTime = FileHandler.system.InterarrivalDistribution[i].Time;
                decimal Probability = FileHandler.system.InterarrivalDistribution[i].Probability;
                interarrivalDistributionDataTable.Rows.Add(interarrivalTime, Probability);
            }
           
        }

        private void openTestCaseButton_Click(object sender, EventArgs e)
        {
            testCaseFileDialog = new OpenFileDialog();
            DialogResult fileResult = testCaseFileDialog.ShowDialog();
           
            if (fileResult == DialogResult.OK)
            {
                fileName = testCaseFileDialog.SafeFileName;
                FileHandler.ReadTestCase(testCaseFileDialog.FileName);
                displayData();

                #region // comments
                /*
                Console.WriteLine(fileName);
                Console.WriteLine(FileHandler.system.NumberOfServers);
                Console.WriteLine(FileHandler.system.StoppingNumber);
                Console.WriteLine(FileHandler.system.SelectionMethod);
                Console.WriteLine(FileHandler.system.StoppingCriteria);
                for (int i =0; i < FileHandler.system.InterarrivalDistribution.Count; i++)
                {
                    Console.WriteLine(FileHandler.system.InterarrivalDistribution[i].Time + " " + FileHandler.system.InterarrivalDistribution[i].Probability);
                }
                for (int i =0; i< FileHandler.system.Servers.Count; i++)
                {
                    Console.WriteLine(FileHandler.system.Servers[i].ID);
                    for (int j =0; j < FileHandler.system.Servers[i].TimeDistribution.Count; j++)
                    {
                    Console.WriteLine(FileHandler.system.Servers[i].TimeDistribution[j].Time + " " + FileHandler.system.Servers[i].TimeDistribution[j].Probability);
                    }
                }
                */
                #endregion


            }
        }

    }
}
