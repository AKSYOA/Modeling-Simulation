using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            this.IdleProbability = 0;
            this.AverageServiceTime = 0;
            this.Utilization = 0;
            this.FinishTime = 0;
            this.TotalWorkingTime = 0;
            this.numberOfCustomers = 0;
            this.Intervals = new List<KeyValuePair<int, int>>();
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        public List<KeyValuePair<int, int>> Intervals;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public int numberOfCustomers { get; set; }
        public void calculateCummProbability()
        {
            for (int i = 0; i < TimeDistribution.Count; i++)
            {

                if (i == 0)
                {
                    TimeDistribution[i].CummProbability = TimeDistribution[i].Probability;
                    TimeDistribution[i].MinRange = 1;
                }
                else
                {
                    TimeDistribution[i].CummProbability = TimeDistribution[i - 1].CummProbability + TimeDistribution[i].Probability;
                    TimeDistribution[i].MinRange = TimeDistribution[i - 1].MaxRange + 1;
                }
                TimeDistribution[i].MaxRange = Decimal.ToInt32(TimeDistribution[i].CummProbability * 100);
            }
        }

        public void calculateAverageServiceTime()
        {
            if(numberOfCustomers!=0)
            AverageServiceTime = (decimal)TotalWorkingTime / (decimal)numberOfCustomers;
        }

        public void calculateIdleProbability(int totalSimulationTime)
        {
            int totalIdleTime = totalSimulationTime - TotalWorkingTime;
            IdleProbability = (decimal)totalIdleTime / (decimal)totalSimulationTime;
        }

        public decimal calculateUtilization(int totalSimulationTime)
        {
            if (totalSimulationTime != 0)
                return Utilization = (decimal)TotalWorkingTime / (decimal)totalSimulationTime;
            else
                return 0;
        }

        //testing
        public void displayIntervals()
        {
            Console.WriteLine("Server:" + ID);
            
            for (int i =0; i < Intervals.Count; i++)
            {
                Console.WriteLine(Intervals[i].Key + " " + Intervals[i].Value);
            }
            Console.WriteLine();
        }
    }
}
