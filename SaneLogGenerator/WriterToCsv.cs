using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaneLogGenerator
{
    internal class WriterToCsv
    {
        public static void WriteEventsToCsv(Config config, List<List<string>> variants)
        {
            DateTime initialStartDateTime = config.StartDateTime;

            using var writer = new StreamWriter(config.PathToFile);
            using var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";
            csvWriter.Configuration.HasHeaderRecord = true;
            csvWriter.Configuration.AutoMap<CsvTemplate>();

            csvWriter.WriteHeader<CsvTemplate>();
            csvWriter.NextRecord();
            List<string> variant = new List<string>();
            List<string> disposableVariant = new List<string>();
            while (config.NumberOfEvents > 0)
            {
                variant = DataGenerator.GetRandomVariant(config, variants);
                disposableVariant = variant.GetRange(0, variant.Count);
                int totalVariantCount = disposableVariant.Count;

                while (disposableVariant.Count > 0 && config.NumberOfEvents > 0)
                {
                    if (disposableVariant.Count == totalVariantCount)
                    {
                        // GENERATE FIRST EVENT

                        DateTime start = initialStartDateTime.AddDays(config.Rnd.Next(0, 365)).AddMinutes(config.Rnd.Next(0, 1000));
                        TimeSpan duration = DataGenerator.GenerateDuration(config.Rnd, config.NumberOfEvents);
                        string activity = disposableVariant[0];
                        System.Diagnostics.Debug.WriteLine("FIRST EVENT: " + disposableVariant[0]);

                        string resource1 = DataGenerator.GenerateResourceForEvent(config.Rnd, activity, config.Activities, config.Resources1);
                        string resource2 = DataGenerator.GenerateResourceForEvent(config.Rnd, activity, config.Activities, config.Resources2);
                        var data = new[]

                        {
                            new CsvTemplate {
                                CaseID = config.Counter+1 ,
                                Activity = activity,
                                Resource1 = resource1,
                                Resource2 = resource2,
                                Start = start,
                                Duration = duration,
                                End = start.Add(duration),
                                FinCase = DataGenerator.GenerateFinCase(config),
                                FinEvent = DataGenerator.GenerateFinEvent(config, activity),
                                FinRes = DataGenerator.GenerateFinRes(config, resource1),
                                AttributeCase = DataGenerator.GenerateAttributeCase(config),
                                AttributeEvent = DataGenerator.GeneratAttributeEvent(config, activity)
                                }
                            };
                        {
                            csvWriter.WriteRecords(data);
                            disposableVariant.RemoveAt(0);
                            config.NumberOfEvents--;
                            config.CaseDateTime = start.Add(duration).AddMinutes(config.Rnd.Next(0, 180));
                        }
                    }
                    else if (disposableVariant.Count == 1)
                    {
                        // GENERATE LAST EVENT

                        //TimeSpan endTimeSpan = new TimeSpan(2, 0, 0, 0);
                        string activity = disposableVariant[0];
                        System.Diagnostics.Debug.WriteLine("LAST EVENT: " + disposableVariant[0]);
                        DateTime start;
                        if (config.Parallel)
                        {
                            start = config.CaseDateTime.AddHours(-2);
                        }
                        else
                        {
                            start = config.CaseDateTime.AddMilliseconds(config.InitialNumberOfEvents - config.NumberOfEvents).AddSeconds(config.Rnd.Next(0, 200));
                        }
                        TimeSpan duration = DataGenerator.GenerateDuration(config.Rnd, config.NumberOfEvents);
                        string resource1 = DataGenerator.GenerateResourceForEvent(config.Rnd, activity, config.Activities, config.Resources1);
                        string resource2 = DataGenerator.GenerateResourceForEvent(config.Rnd, activity, config.Activities, config.Resources2);
                        var data = new[]

                        {
                            new CsvTemplate {
                                CaseID = config.Counter+1 ,
                                Activity = activity,
                                Resource1 = resource1,
                                Resource2 = resource2,
                                Start = start,
                                Duration = duration,
                                End = start.Add(duration),
                                FinCase = DataGenerator.GenerateFinCase(config),
                                FinEvent = DataGenerator.GenerateFinEvent(config, activity),
                                FinRes = DataGenerator.GenerateFinRes(config, resource1),
                                AttributeCase = DataGenerator.GenerateAttributeCase(config),
                                AttributeEvent = DataGenerator.GeneratAttributeEvent(config, activity)
                                }
                            };
                        {
                            csvWriter.WriteRecords(data);

                            config.CaseDateTime = start.AddMinutes(config.Rnd.Next(0, 150));
                            config.NumberOfEvents--;
                            disposableVariant.RemoveAt(0);
                            config.Counter++;
                        }
                    }
                    else
                    {// GENERATE RANDOM EVENT
                        DateTime start = config.CaseDateTime.AddSeconds(config.InitialNumberOfEvents - config.NumberOfEvents).AddMilliseconds(config.Rnd.Next(0, 800));
                        TimeSpan duration = DataGenerator.GenerateDuration(config.Rnd, config.NumberOfEvents);
                        string activity = disposableVariant[0];
                        string resource1 = DataGenerator.GenerateResourceForEvent(config.Rnd, activity, config.Activities, config.Resources1);
                        string resource2 = DataGenerator.GenerateResourceForEvent(config.Rnd, activity, config.Activities, config.Resources2);

                        var data = new[]

                        {
                            new CsvTemplate {
                                CaseID = config.Counter+1 ,
                                Activity =activity,
                                Resource1 = resource1,
                                Resource2 = resource2,
                                Start = start,
                                Duration = duration,
                                End = start.Add(duration),
                                FinCase = DataGenerator.GenerateFinCase(config),
                                FinEvent = DataGenerator.GenerateFinEvent(config, activity),
                                FinRes = DataGenerator.GenerateFinRes(config, resource1),
                                AttributeCase = DataGenerator.GenerateAttributeCase(config),
                                AttributeEvent = DataGenerator.GeneratAttributeEvent(config, activity)
                                }
                            };
                        {
                            csvWriter.WriteRecords(data);

                            config.CaseDateTime = start.Add(duration).AddHours(config.Rnd.Next(0, 2));
                            config.NumberOfEvents--;
                            disposableVariant.RemoveAt(0);
                        }
                    }
                }
            }
        }
    }
}