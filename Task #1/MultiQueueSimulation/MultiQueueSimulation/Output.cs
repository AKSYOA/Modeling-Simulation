using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Output : Form
    {
        private SimulationSystem system;
        public Output(SimulationSystem system)
        {
            InitializeComponent();
            this.system = system;
        }

        private void Output_Load(object sender, EventArgs e)
        {
            populateDataView();
            loadComboBoxData();
        }
        public void loadComboBoxData()
        {
            serverComboBox.Items.Clear();
            for (int i = 1; i <= system.NumberOfServers; i++)
            {
                serverComboBox.Items.Add(i);
            }
        }

        private void populateDataView()
        {
            foreach(var simulationCase in system.SimulationTable)
            {
                int customerNumber = simulationCase.CustomerNumber;
                int interArrivalRandom = simulationCase.RandomInterArrival;
                int interArrivalTime = simulationCase.InterArrival;
                int arrivalTime = simulationCase.ArrivalTime;
                int serviceRandom = simulationCase.RandomService;
                int serviceBegin = simulationCase.StartTime;
                int serviceTime = simulationCase.ServiceTime;
                int serviceEnd = simulationCase.EndTime;
                int serverIndex = simulationCase.AssignedServer.ID;
                int timeInQueue = simulationCase.TimeInQueue;
                outputDataGridView.Rows.Add(customerNumber, interArrivalRandom, interArrivalTime, arrivalTime,
                    serviceRandom, serviceBegin, serviceTime, serviceEnd, serverIndex, timeInQueue);

            }
            averageWaitingTextBox.Text = system.PerformanceMeasures.AverageWaitingTime.ToString();
            probabilityOfWaitTextBox.Text = system.PerformanceMeasures.WaitingProbability.ToString();
            maxQueueLengthTextBox.Text = system.PerformanceMeasures.MaxQueueLength.ToString();
        }

        private void serverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = serverComboBox.SelectedIndex;
            idleProbabilityTextBox.Text = system.Servers[index].IdleProbability.ToString();
            avgServiceTimeTextBox.Text = system.Servers[index].AverageServiceTime.ToString();
            utilizationTextBox.Text = system.Servers[index].Utilization.ToString();
            
        }

        private void busyTimeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = serverComboBox.SelectedIndex;
                List<KeyValuePair<int, int>> Intervals = system.Servers[index].Intervals;
                int simulationTime = system.getSimulationTime();
                Graph serverGraph = new Graph(index, Intervals, simulationTime);
                serverGraph.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please Choose a server");
            }
        }
    }
}
