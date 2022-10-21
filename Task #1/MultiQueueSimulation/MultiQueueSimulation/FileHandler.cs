using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    class FileHandler
    {
        public static  SimulationSystem system = new SimulationSystem();

        public static void ReadTestCase(string testCasePath)
        {
            Stream stream = File.Open(testCasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(stream);
            string ln;
            while ((ln = sr.ReadLine()) != null)
            {
                if (ln.Equals("NumberOfServers"))
                {
                    system.NumberOfServers = Int32.Parse(sr.ReadLine());
                }
                else if (ln.Equals("StoppingNumber"))
                {
                    system.StoppingNumber = Int32.Parse(sr.ReadLine());
                }
                else if (ln.Equals("StoppingCriteria"))
                {
                    int stoppingCriteria = Int32.Parse(sr.ReadLine());
                    if (stoppingCriteria == 1)
                        system.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                    else
                        system.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                }
                else if (ln.Equals("SelectionMethod"))
                {
                    int selectionCriteria = Int32.Parse(sr.ReadLine());
                    if (selectionCriteria == 1)
                        system.SelectionMethod = Enums.SelectionMethod.HighestPriority;
                    else if (selectionCriteria == 2)
                        system.SelectionMethod = Enums.SelectionMethod.Random;
                    else
                        system.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                }
                else if (ln.Equals("InterarrivalDistribution"))
                {
                    
                    while (!String.IsNullOrEmpty(ln = sr.ReadLine()))
                    {
                        ln = ln.Replace(" ", string.Empty);
                        string[] values =  ln.Split(',');
                        int time = Int32.Parse(values[0]);
                        decimal probability = Decimal.Parse(values[1]);
                        system.InterarrivalDistribution.Add(new TimeDistribution(time, probability));
                    }
                }else if (ln.Equals("ServiceDistribution_Server1"))
                {
                    for (int i =1; i <= system.NumberOfServers; i++)
                    {
                        Server server = new Server();
                        server.ID = i;
                        while (!String.IsNullOrEmpty(ln = sr.ReadLine()))
                        {
                            ln = ln.Replace(" ", string.Empty);
                            string[] values = ln.Split(',');
                            int time = Int32.Parse(values[0]);
                            decimal probability = Decimal.Parse(values[1]);
                            server.TimeDistribution.Add(new TimeDistribution(time, probability));
                        }
                        ln = sr.ReadLine();
                        system.Servers.Add(server);
                    }

                }

                /*
                if (String.IsNullOrEmpty(ln))
                {
                    Console.WriteLine("Empty");
                }else
                {
                    Console.WriteLine(ln);

                }
                */

            }
        }

    }
}
