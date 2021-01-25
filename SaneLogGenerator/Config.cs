using System;
using System.Collections.Generic;
using System.Text;

namespace SaneLogGenerator
{
    public class Config
    {
        public int NumberOfEvents { get; set; }

        public int NumberOfVariants { get; set; }
        public int MinActivitiesPerCase { get; set; }
        public int MaxActivitiesPerCase { get; set; }
        public int NumberOfActivities { get; set; }
        public int NumberOfResources { get; set; }
        public DateTime StartDateTime { get; set; }
        public string PathToFile { get; set; }
        public int InitialNumberOfEvents { get; set; }
        public List<string> Activities { get; set; }
        public List<string> Resources { get; set; }
        public Random Rnd { get; set; }
        public int Counter { get; set; }
        public DateTime CaseDateTime { get; set; }

        public Config(int numberOfEvents, int numberOfVariants, int minActivitiesPerCase, int maxActivitiesPerCase, int numberOfActivities,
                       int numberOfResources, DateTime startDateTime, string pathTiFile, List<string> activities, List<string> resources)
        {
            this.NumberOfEvents = numberOfEvents;
            this.NumberOfVariants = numberOfVariants;
            this.MaxActivitiesPerCase = maxActivitiesPerCase;
            this.MinActivitiesPerCase = minActivitiesPerCase;
            this.NumberOfActivities = numberOfActivities;
            this.NumberOfResources = numberOfResources;
            this.StartDateTime = startDateTime;
            this.PathToFile = pathTiFile;
            this.InitialNumberOfEvents = numberOfEvents;
            this.Activities = activities;
            this.Resources = resources;
            this.Rnd = new Random((int)DateTime.Now.Ticks);
            this.Counter = 0;
            this.CaseDateTime = startDateTime.AddMilliseconds(Rnd.Next(0, 200));
        }
    }
}