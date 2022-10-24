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
        public void createTableUsingCustomersNo()
        {

            for (int i = 0; i < StoppingNumber; i++)
            {
                SimulationCase s = new SimulationCase();

                s.CustomerNumber = i + 1;
                s.RandomInterArrival = s.generateRand();
                s.RandomService = s.generateRand();
                s.EndTime = s.StartTime + s.ServiceTime;
                s.InterArrival = calculateInterArrival(ref s);
                s.ServiceTime = calculateServiceTime(ref s);

                if (i == 0)
                {
                    s.ArrivalTime = 0;
                }
                else
                {
                    s.ArrivalTime = s.InterArrival + SimulationTable[i - 1].ArrivalTime;
                }
                s.AssignedServer = serverAssignment(ref s);
                s.AssignedServer.FinishTime = s.EndTime;
                SimulationTable.Add(s);
            }
        }
        public void createTableUsingEndTime()
        {
            int maxTimeReached = 0, index = 0;

            while (maxTimeReached <= StoppingNumber)
            {
                SimulationCase s = new SimulationCase();

                s.CustomerNumber = index + 1;
                s.RandomInterArrival = s.generateRand();
                s.RandomService = s.generateRand();
                s.EndTime = s.StartTime + s.ServiceTime;
                s.InterArrival = calculateInterArrival(ref s);
                s.ServiceTime = calculateServiceTime(ref s);

                if (index == 0)
                {
                    s.ArrivalTime = 0;
                }
                else
                {
                    s.ArrivalTime = s.InterArrival + SimulationTable[index - 1].ArrivalTime;

                }
                s.AssignedServer = serverAssignment(ref s);
                s.AssignedServer.FinishTime = s.EndTime;
                SimulationTable.Add(s);
                maxTimeReached = s.EndTime;
                index++;
            }

        }
        public int calculateInterArrival(ref SimulationCase s)
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
        public int calculateServiceTime(ref SimulationCase s)
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
        //Assigning a server to a customer
        public Server serverAssignment(ref SimulationCase s)
        {

            if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {
                return assignServerWithPriority(ref s);
            }
            else
            {
                return assignServerRandomly(ref s);
            }
        }
        public Server assignServerWithPriority(ref SimulationCase s)
        {
            //to track the highest prio server that will finish early first
            int earliestFinishTime = StoppingNumber, serverIndex = Servers.Count;

            for (int i = 0; i < Servers.Count; i++)
            {

                if (s.ArrivalTime >= Servers[i].FinishTime)
                {
                    s.StartTime = Servers[i].FinishTime;
                    s.TimeInQueue = 0;
                    return Servers[i];
                }
                else
                {
                    if (Servers[i].FinishTime < earliestFinishTime && i < serverIndex)
                    {
                        earliestFinishTime = Servers[i].FinishTime;
                        serverIndex = i;
                    }
                }
            }
            if (s.ArrivalTime >= Servers[serverIndex].FinishTime)
            {
                s.TimeInQueue = 0;
                s.StartTime = s.ArrivalTime;
            }
            else {
                s.TimeInQueue = Servers[serverIndex].FinishTime - s.ArrivalTime;
                s.StartTime= Servers[serverIndex].FinishTime;
            }
            return Servers[serverIndex];
        }
        public Server assignServerRandomly(ref SimulationCase s)
        {
            List<Server> IdleServers = new List<Server>();
            int earliestFinishTime = StoppingNumber, serverIndex = Servers.Count;
            for (int i = 0; i < Servers.Count; i++)
            {

                if (s.ArrivalTime >= Servers[i].FinishTime)
                {
                    IdleServers.Add(Servers[i]);
                }
                else
                {
                    if (Servers[i].FinishTime < earliestFinishTime)
                    {
                        earliestFinishTime = Servers[i].FinishTime;
                        serverIndex = i;
                    }
                }
            }
            if (IdleServers.Count == 0)
            {
                if (s.ArrivalTime >= Servers[serverIndex].FinishTime)
                {
                    s.TimeInQueue = 0;
                    s.StartTime = s.ArrivalTime;
                }
                else
                {
                    s.TimeInQueue = Servers[serverIndex].FinishTime - s.ArrivalTime;
                    s.StartTime= Servers[serverIndex].FinishTime;
                }
                return Servers[serverIndex];
            }
            else
            {
                Random rnd = new Random();
                int index = rnd.Next(IdleServers.Count);

                if (s.ArrivalTime >= Servers[serverIndex].FinishTime)
                {
                    s.TimeInQueue = 0;
                    s.StartTime = s.ArrivalTime;
                }
                else
                {
                    s.TimeInQueue = Servers[serverIndex].FinishTime - s.ArrivalTime;
                    s.StartTime = Servers[serverIndex].FinishTime;
                }
                return IdleServers[index];
            }
        }
    }
}
