using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CommandLine;
using CommandLine.Text;

namespace SaneLogGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            int numberOfEvents = 0;
            int numberOfVariants = 0;
            int minActivitiesPerCase = 0;
            int maxActivitiesPerCase = 0;
            int numberOfActivities = 0;
            int numberOfResources = 0;
            DateTime startDateTime = new DateTime(2000, 1, 1, 9, 0, 0);

            bool parallel = false;
            bool specialChars = false;
            //bool emptyFields = false;

            string pathToFile = string.Empty;

            var options = new Options();
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o =>
            {
                numberOfEvents = o.NumberOfEvents;
                if (numberOfEvents.Equals(0))
                {
                }
                numberOfVariants = o.NumberOfVariants;
                minActivitiesPerCase = o.MinActivitiesPerCase;
                maxActivitiesPerCase = o.MaxActivitiesPerCase;
                numberOfActivities = o.NumberOfActivities;
                numberOfResources = o.NumberOfResources;
                startDateTime = o.StartDateTime;

                parallel = o.Parallel;
                specialChars = o.SpecialChars;
                //emptyFields = o.EmptyField;
                pathToFile = o.PathToFile;
            }
            );

            bool isPathToFileEmpty = string.IsNullOrEmpty(pathToFile);
            if (isPathToFileEmpty.Equals(false))
                try
                {
                    Console.WriteLine("Total number of events: " + numberOfEvents);
                    Console.WriteLine("Total number of variants: " + numberOfVariants);
                    Console.WriteLine("Min number of activities per case: " + minActivitiesPerCase);
                    Console.WriteLine("Max number of activities per case: " + maxActivitiesPerCase);
                    Console.WriteLine("Number of activities: " + numberOfActivities);
                    Console.WriteLine("Number of resources: " + numberOfResources);
                    Console.WriteLine("Start DateTime: " + startDateTime);
                    Console.WriteLine("Parallel activities present: " + parallel);
                    Console.WriteLine("Special characters present: " + specialChars);
                    Console.WriteLine("Path to output file: " + pathToFile);

                    List<string> resources1 = DataGenerator.GenerateResources(numberOfResources, specialChars, 1);
                    List<string> resources2 = DataGenerator.GenerateResources(numberOfResources, specialChars, 2);
                    List<string> activities = DataGenerator.GenerateActivities(numberOfActivities, specialChars);

                    Config config = new Config(numberOfEvents, numberOfVariants, minActivitiesPerCase, maxActivitiesPerCase,
                                                  numberOfActivities, numberOfResources, startDateTime, specialChars, parallel, pathToFile,
                                                   activities, resources1, resources2);
                    List<List<string>> variants = DataGenerator.GenerateVariants(config);

                    WriterToCsv.WriteEventsToCsv(config, variants);
                    Console.WriteLine("Finished.");
                    Console.WriteLine("Press any key to close.");

                    Console.Read();
                }
                catch
                {
                    Console.Read();
                    return;
                }
        }
    }
}