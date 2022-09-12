﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaneLogGenerator
{
    public record Config(
         int NumberOfEvents,
         int NumberOfVariants,
         int MinActivitiesPerCase,
         int MaxActivitiesPerCase,
         int NumberOfActivities,
         int NumberOfResources,
         DateTime StartDateTime,
         bool SpecialChars,
         bool Parallel,
         string PathToFile,
         List<string> Activities,
         List<string> Resources1,
         List<string> Resources2
        );

    //public class Config
    //{
    //    public int NumberOfEvents { get; set; }

    //    public int NumberOfVariants { get; set; }
    //    public int MinActivitiesPerCase { get; set; }
    //    public int MaxActivitiesPerCase { get; set; }
    //    public int NumberOfActivities { get; set; }
    //    public int NumberOfResources { get; set; }
    //    public DateTime StartDateTime { get; set; }
    //    public bool SpecialChars { get; set; }

    //    public bool Parallel { get; set; }
    //    public string PathToFile { get; set; }
    //    public int InitialNumberOfEvents { get; set; }
    //    public List<string> Activities { get; set; }
    //    public List<string> Resources1 { get; set; }
    //    public List<string> Resources2 { get; set; }
    //    public Random Rnd { get; set; }
    //    public int Counter { get; set; }
    //    public DateTime CaseDateTime { get; set; }

    //    public Config(int numberOfEvents, int numberOfVariants, int minActivitiesPerCase, int maxActivitiesPerCase, int numberOfActivities,
    //                   int numberOfResources, DateTime startDateTime, bool specialChars, bool parallel, string pathTiFile, List<string> activities, List<string> resources1, List<string> resources2)
    //    {
    //        this.NumberOfEvents = numberOfEvents;
    //        this.NumberOfVariants = numberOfVariants;
    //        this.MaxActivitiesPerCase = maxActivitiesPerCase;
    //        this.MinActivitiesPerCase = minActivitiesPerCase;
    //        this.NumberOfActivities = numberOfActivities;
    //        this.NumberOfResources = numberOfResources;
    //        this.StartDateTime = startDateTime;
    //        this.SpecialChars = specialChars;
    //        this.Parallel = parallel;
    //        this.PathToFile = pathTiFile;
    //        this.InitialNumberOfEvents = numberOfEvents;
    //        this.Activities = activities;
    //        this.Resources1 = resources1;
    //        this.Resources2 = resources2;
    //        this.Rnd = new Random((int)DateTime.Now.Ticks);
    //        this.Counter = 0;
    //        this.CaseDateTime = startDateTime.AddMilliseconds(Rnd.Next(0, 200));
    //    }
    //}
}