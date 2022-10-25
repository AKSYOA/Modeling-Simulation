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
                Servers[assignedServerIndex].FinishTime = customerCase.EndTime;
                Servers[assignedServerIndex].TotalWorkingTime += customerCase.ServiceTime;
                Servers[assignedServerIndex].numberOfCustomers++;

                totalSimulationTime = Math.Max(totalSimulationTime, customerCase.EndTime);
                SimulationTable.Add(customerCase);
            
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
            else if (SelectionMethod.Equals(Enums.SelectionMethod.Random))
            {
                List<int> idleServers = new List<int>();
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (arrivalTime >= Servers[i].FinishTime)
                        idleServers.Add(i);
                }

                if (idleServers.Count > 0) // there is avaliable servers
                {
                    int idleServerIndex = random.Next(0, idleServers.Count);
                    Console.WriteLine(idleServerIndex);
                    Console.WriteLine(idleServers[idleServerIndex]);
                    return idleServers[idleServerIndex];
                }else
                {
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
            }
            else
            {
                decimal leastUtilization = 2;
                int index = -1;
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (arrivalTime >= Servers[i].FinishTime)
                    {
                        decimal utilization = Servers[i].calculateUtilization(arrivalTime);
                        if (utilization < leastUtilization)
                        {
                            leastUtilization = utilization;
                            index = i;
                        }
                    }
                }
              
                if (index != -1)
                {
                    return index;
                }else
                {
                    int earliestFinishTime = 99999999;
                    for (int i = 0; i < Servers.Count; i++)
                    {
                        if (earliestFinishTime > Servers[i].FinishTime)
                        {
                            earliestFinishTime = Servers[i].FinishTime;
                        }
                    }
                    index = -1; leastUtilization = 2;
                    for (int i = 0; i < Servers.Count; i++)
                    {
                        if (Servers[i].FinishTime == earliestFinishTime)
                        {
                            decimal utilization = Servers[i].calculateUtilization(earliestFinishTime);
                            if (utilization < leastUtilization)
                            {
                                leastUtilization = utilization;
                                index = i;
                            }
                        }
                    }
                    totalCustomersWaited++;
                    return index;
                }

            }
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
