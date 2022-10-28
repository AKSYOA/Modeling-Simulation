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
    public partial class Graph : Form
    {
        private int serverIndex;
        private List<KeyValuePair<int, int>> Intervals;
        private int simulationTime;
        public Graph(int serverIndex, List<KeyValuePair<int,int>> Intervals , int simulationTime)
        {
            InitializeComponent();
            this.serverIndex = serverIndex;
            this.Intervals = Intervals;
            this.simulationTime = simulationTime;

        }

        private void Graph_Load(object sender, EventArgs e)
        {
            serverNameLabel.Text = "Server:" + (serverIndex + 1);
            serverChart.Series[0].Name = "Busy Time";
            serverChart.ChartAreas[0].AxisY.Minimum = 0;
            serverChart.ChartAreas[0].AxisY.Maximum = 1;
            serverChart.ChartAreas[0].AxisX.Minimum = 0;
            serverChart.ChartAreas[0].AxisX.Title = "Time";
            serverChart.ChartAreas[0].AxisY.Title = "Idle / Busy";
            if (simulationTime > 100)
                serverChart.ChartAreas[0].AxisX.Interval = 10;
            else
                serverChart.ChartAreas[0].AxisX.Interval = 1;
            
            serverChart.Series[0]["PointWidth"] = "1";

            for (int i =0; i < Intervals.Count; i++)
            {
                int startInterval = Intervals[i].Key,
                    endInterval = Intervals[i].Value;
                while (startInterval <= endInterval)
                {
                    Console.WriteLine(startInterval);
                    serverChart.Series[0].Points.AddXY(startInterval, 1);
                    startInterval++;
                }
            }
        }
    }
}
