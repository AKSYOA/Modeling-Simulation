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
        }

        private void outputDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
