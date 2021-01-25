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
            int numberOfActivities = 20;
            int numberOfResources = 10;
            DateTime startDateTime = new DateTime(2000, 1, 1, 9, 0, 0);

            bool parallel = true;
            bool specialChars = true;
            bool emptyFields = true;

            string pathToFile = @"C:\Users\slavk\Desktop\SLG\out.csv";

            List<string> resources1 = DataGenerator.GenerateResources(numberOfResources, specialChars, 1);
            List<string> resources2 = DataGenerator.GenerateResources(numberOfResources, specialChars, 2);
            List<string> activities = DataGenerator.GenerateActivities(numberOfActivities, specialChars);

            Config config = new Config(numberOfEvents, numberOfVariants, minActivitiesPerCase, maxActivitiesPerCase,
                                          numberOfActivities, numberOfResources, startDateTime, specialChars, pathToFile,
                                           activities, resources1, resources2);
            List<List<string>> variants = DataGenerator.GenerateVariants(config);

            WriterToCsv.WriteEventsToCsv(config, variants);
        }
    }
}