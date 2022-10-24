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
            this.FinishTime = 0;
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }

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
    }
}
