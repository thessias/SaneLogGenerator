using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace SaneLogGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int numberOfEvents = 1000;
            int numberOfVariants = 10;
            int minActivitiesPerCase = 10;
            int maxActivitiesPerCase = 25;
            int numberOfActivities = 2;
            int numberOfResources = 7;
            DateTime startDateTime = new DateTime(2000, 1, 1, 9, 0, 0);
            string pathToFile = @"C:\Users\slavk\Desktop\SLG\out.csv";

            List<string> resources = DataGenerator.GenerateResources(numberOfResources);
            List<string> activities = DataGenerator.GenerateActivities(numberOfActivities);

            Config config = new Config(numberOfEvents, numberOfVariants, minActivitiesPerCase, maxActivitiesPerCase,
                                          numberOfActivities, numberOfResources, startDateTime, pathToFile,
                                           activities, resources);
            List<List<string>> variants = DataGenerator.GenerateVariants(config);

            WriterToCsv.WriteEventsToCsv(config, variants);
        }
    }
}