using System;
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
}