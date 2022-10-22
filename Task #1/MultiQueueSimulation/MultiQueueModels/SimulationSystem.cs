using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }
        
         //calculating cumulative probability for Interarrival distribution & setting min and max range
        public void calculateCummProbability()
        {
            for (int i = 0; i < InterarrivalDistribution.Count; i++) {

                if (i == 0)
                {
                    InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i].Probability;
                    InterarrivalDistribution[i].MinRange = 1;
                }
                else {
                    InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i-1].CummProbability + InterarrivalDistribution[i].Probability;
                    InterarrivalDistribution[i].MinRange = InterarrivalDistribution[i - 1].MaxRange + 1;
                }
                InterarrivalDistribution[i].MaxRange = Decimal.ToInt32(InterarrivalDistribution[i].CummProbability * 100);
            }

            foreach(var server in Servers)
            {
                server.calculateCummProbability();
            }
        }

        //testing
        public void displayTables()
        {
            Console.WriteLine("Interarrival Distribution");
            Console.WriteLine("Time Probability CummProbability minRange MaxRange");
            foreach(var inter in InterarrivalDistribution)
            {
                Console.WriteLine(inter.Time + " " + inter.Probability + " " + inter.CummProbability + " " + inter.MinRange + " "+ inter.MaxRange );
            }
            Console.WriteLine();
            foreach(var server in Servers)
            {
                Console.WriteLine("server");
                foreach(var inter in server.TimeDistribution)
                {
                    Console.WriteLine(inter.Time + " " + inter.Probability + " " + inter.CummProbability + " " + inter.MinRange + " " + inter.MaxRange);

                }
            }
        }

    }
}
