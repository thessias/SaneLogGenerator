using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace SaneLogGenerator
{
    internal class Options
    {
        [Option('e', "events", Required = true, HelpText = "Total number of events in log. (int)")]
        public int NumberOfEvents { get; set; }

        [Option('v', "variants", Required = true, HelpText = "Total number of variants used in log. (int)")]
        public int NumberOfVariants { get; set; }

        [Option('x', "min-activities-per-case", Required = true, HelpText = "Min number of activities per case. (int)")]
        public int MinActivitiesPerCase { get; set; }

        [Option('y', "max-activities-per-case", Required = true, HelpText = "Max number of activities per case. (int)")]
        public int MaxActivitiesPerCase { get; set; }

        [Option('a', "activities", Required = true, HelpText = "Number of different activities used in log. (int)")]
        public int NumberOfActivities { get; set; }

        [Option('r', "resources", Required = true, HelpText = "Number of different resources used in log. (int)")]
        public int NumberOfResources { get; set; }

        [Option('d', "start-datetime", Required = true, HelpText = "Start DateTime used in log.")]
        public DateTime StartDateTime { get; set; }

        [Option('p', "parallel", Default = false, HelpText = "Parallel activities in log. (no value needed)")]
        public bool Parallel { get; set; }

        [Option('s', "special-chars", Default = false, HelpText = "Special characters used in log. (no value needed)")]
        public bool SpecialChars { get; set; }

        [Option('f', "path-to-file", Required = true, HelpText = "Path to output file.")]
        public string PathToFile { get; set; }

        public static string GetUsage()
        {
            var result = Parser.Default.ParseArguments<Options>(new string[] { "--help" });
            return HelpText.RenderUsageText(result);
        }
    }
}