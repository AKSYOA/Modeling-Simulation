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
            this.StoppingCriteria = new Enums.StoppingCriteria();
            this.SelectionMethod = new Enums.SelectionMethod();
            this.random = new Random();
            this.totalSimulationTime = 0;
            this.totalWaitTime = 0;
            this.totalCustomersWaited = 0;
        }
        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        private Random random;

        private int totalSimulationTime;
        private int totalWaitTime;
        private int totalCustomersWaited;


        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        //calculating cumulative probability for Interarrival distribution & setting min and max range
        public void calculateCummProbability()
        {
            for (int i = 0; i < InterarrivalDistribution.Count; i++)
            {

                if (i == 0)
                {
                    InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i].Probability;
                    InterarrivalDistribution[i].MinRange = 1;
                }
                else
                {
                    InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i - 1].CummProbability + InterarrivalDistribution[i].Probability;
                    InterarrivalDistribution[i].MinRange = InterarrivalDistribution[i - 1].MaxRange + 1;
                }
                InterarrivalDistribution[i].MaxRange = Decimal.ToInt32(InterarrivalDistribution[i].CummProbability * 100);
            }

            foreach (var server in Servers)
            {
                server.calculateCummProbability();
            }
        }

        //testing
        public void displayTables()
        {
            Console.WriteLine("Interarrival Distribution");
            Console.WriteLine("Time Probability CummProbability minRange MaxRange");
            foreach (var inter in InterarrivalDistribution)
            {
                Console.WriteLine(inter.Time + " " + inter.Probability + " " + inter.CummProbability + " " + inter.MinRange + " " + inter.MaxRange);
            }
            Console.WriteLine();
            foreach (var server in Servers)
            {
                Console.WriteLine("server");
                foreach (var inter in server.TimeDistribution)
                {
                    Console.WriteLine(inter.Time + " " + inter.Probability + " " + inter.CummProbability + " " + inter.MinRange + " " + inter.MaxRange);

                }
            }
        }
        //Table creation 
        public void createSimulationTable()
        {
            if (StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                createTableUsingCustomersNo();
            }
            else
            {
                createTableUsingEndTime();
            }
        }
        //Table creation using Customer numbers
        public void createTableUsingCustomersNo()
        {

            for (int i = 0; i < StoppingNumber; i++)
            {
                SimulationCase customerCase = new SimulationCase();
                customerCase.CustomerNumber = i + 1;

                if (i == 0)
                {
                    customerCase.RandomInterArrival = 1;
                    customerCase.InterArrival = 0;
                    customerCase.ArrivalTime = 0;
                }else
                {
                    customerCase.RandomInterArrival = random.Next(1, 100);
                    customerCase.InterArrival = calculateInterArrival(customerCase);
                    customerCase.ArrivalTime = customerCase.InterArrival + SimulationTable[i - 1].ArrivalTime;

                }

                int assignedServerIndex = assignServer(customerCase.ArrivalTime);
                customerCase.AssignedServer = Servers[assignedServerIndex];
                customerCase.StartTime = Math.Max(customerCase.ArrivalTime, customerCase.AssignedServer.FinishTime);
                customerCase.TimeInQueue = customerCase.StartTime - customerCase.ArrivalTime;
                totalWaitTime += customerCase.TimeInQueue;

                customerCase.RandomService = random.Next(1, 100);
                customerCase.ServiceTime = calculateServiceTime(customerCase);
                customerCase.EndTime = customerCase.StartTime + customerCase.ServiceTime;
                //Console.WriteLine("Randoms:" +customerCase.RandomInterArrival + " " + customerCase.RandomService);
                Servers[assignedServerIndex].FinishTime = customerCase.EndTime;
                Servers[assignedServerIndex].TotalWorkingTime += customerCase.ServiceTime;
                Servers[assignedServerIndex].numberOfCustomers++;

                totalSimulationTime = Math.Max(totalSimulationTime, customerCase.EndTime);
                SimulationTable.Add(customerCase);
            
            }
        }
        public void createTableUsingEndTime()
        {
            int maxTimeReached = 0, index = 0;
            while (maxTimeReached <= StoppingNumber)
            {
                SimulationCase s = new SimulationCase();

                s.CustomerNumber = index + 1;
                s.RandomInterArrival = random.Next(1, 100);
                s.RandomService = random.Next(1, 100);
                s.EndTime = s.StartTime + s.ServiceTime;
                s.InterArrival = calculateInterArrival(s);
                s.ServiceTime = calculateServiceTime(s);

                if (index == 0)
                {
                    s.ArrivalTime = 0;
                    s.StartTime = 0;
                }
                else
                {
                    s.ArrivalTime = s.InterArrival + SimulationTable[index - 1].ArrivalTime;

                }
                //server assignment متعملتش
                SimulationTable.Add(s);
                maxTimeReached = s.EndTime;
                index++;
            }

        }
        public int calculateInterArrival(SimulationCase s)
        {

            for (int i = 0; i < InterarrivalDistribution.Count; i++)
            {
                if (s.RandomInterArrival <= InterarrivalDistribution[i].MaxRange && s.RandomInterArrival >= InterarrivalDistribution[i].MinRange)
                {
                    return InterarrivalDistribution[i].Time;

                }
            }
            return 0;
        }
        public int calculateServiceTime(SimulationCase s)
        {

            for (int i = 0; i < s.AssignedServer.TimeDistribution.Count; i++)
            {
                if (s.RandomService <= s.AssignedServer.TimeDistribution[i].MaxRange && s.RandomService >= s.AssignedServer.TimeDistribution[i].MinRange)
                {
                    return s.AssignedServer.TimeDistribution[i].Time;
                }
            }
            return 0;
        }

        public int assignServer(int arrivalTime)
        {
            if (SelectionMethod.Equals(Enums.SelectionMethod.HighestPriority))
            {
                // if there is avaliable server
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (arrivalTime >= Servers[i].FinishTime)
                    {
                        return i;
                    }
                }
                // if there is no idle server, wait in the queue and find first server to finish
                int index = -1, earliestFinishTime = 99999999;
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (earliestFinishTime > Servers[i].FinishTime)
                    {
                        earliestFinishTime = Servers[i].FinishTime;
                        index = i;
                    }
                }
                totalCustomersWaited++;
                return index;
            }

            return 0;
        }

        public void calculateServersPerformanceMeasures()
        {
            foreach(var server in Servers)
            {
                server.calculateAverageServiceTime();
                server.calculateIdleProbability(totalSimulationTime);
                server.calculateUtilization(totalSimulationTime);
            }
        }
        public void calculateSystemPerformanceMeasures()
        {
            PerformanceMeasures.AverageWaitingTime = (decimal)totalWaitTime / (decimal)StoppingNumber;
            PerformanceMeasures.WaitingProbability = (decimal)totalCustomersWaited / (decimal)StoppingNumber;
            PerformanceMeasures.MaxQueueLength = 0;

        }

        public void Simulate()
        {
            calculateCummProbability();
            createTableUsingCustomersNo();
            calculateServersPerformanceMeasures();
            calculateSystemPerformanceMeasures();

        }
    }
}
