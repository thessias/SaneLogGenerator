using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaneLogGenerator
{
    public class WriterToCsv
    {
        public static void WriteEventsToCsv(Config config, Context context, List<List<string>> variants)
        {
            DateTime initialStartDateTime = config.StartDateTime;

            using var writer = new StreamWriter(config.PathToFile);
            using var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";
            csvWriter.Configuration.HasHeaderRecord = true;
            csvWriter.Configuration.AutoMap<CsvTemplate>();

            csvWriter.WriteHeader<CsvTemplate>();
            csvWriter.NextRecord();
            List<string> variant = new();
            List<string> disposableVariant = new();
            int numberOfEvents = config.NumberOfEvents;

            while (numberOfEvents > 0)
            {
                variant = DataGenerator.GetRandomVariant(config, context, variants);
                disposableVariant = variant.GetRange(0, variant.Count);
                int totalVariantCount = disposableVariant.Count;

                while (disposableVariant.Count > 0 && numberOfEvents > 0)
                {
                    if (disposableVariant.Count == totalVariantCount)
                    {
                        // GENERATE FIRST EVENT

                        DateTime start = initialStartDateTime.AddDays(context.Rnd.Next(0, 365)).AddMinutes(context.Rnd.Next(0, 1000));
                        TimeSpan duration = DataGenerator.GenerateDuration(context.Rnd, config.NumberOfEvents);
                        string activity = disposableVariant[0];
                        string resource1 = DataGenerator.GenerateResourceForEvent(context.Rnd, activity, config.Activities, config.Resources1);
                        string resource2 = DataGenerator.GenerateResourceForEvent(context.Rnd, activity, config.Activities, config.Resources2);
                        var data = new[]

                        {
                            new CsvTemplate {
                                CaseID = context.Counter+1,
                                Activity = activity,
                                Resource1 = resource1,
                                Resource2 = resource2,
                                Start = start,
                                Duration = duration,
                                End = start.Add(duration),
                                FinCase = DataGenerator.GenerateFinCase(context),
                                FinEvent = DataGenerator.GenerateFinEvent(config, activity),
                                FinRes = DataGenerator.GenerateFinRes(config, resource1),
                                AttributeCase = DataGenerator.GenerateAttributeCase(config, context),
                                AttributeEvent = DataGenerator.GeneratAttributeEvent(config, activity)
                                }
                            };
                        {
                            csvWriter.WriteRecords(data);
                            disposableVariant.RemoveAt(0);
                            --numberOfEvents;
                            context.CaseDateTime = start.Add(duration).AddMinutes(context.Rnd.Next(0, 180));
                        }
                    }
                    else if (disposableVariant.Count == 1)
                    {
                        // GENERATE LAST EVENT

                        string activity = disposableVariant[0];
                        DateTime start;
                        if (config.Parallel)
                        {
                            start = context.CaseDateTime.AddHours(-2);
                        }
                        else
                        {
                            start = context.CaseDateTime.AddMilliseconds(context.InitialNumberOfEvents - config.NumberOfEvents).AddSeconds(context.Rnd.Next(0, 200));
                        }
                        TimeSpan duration = DataGenerator.GenerateDuration(context.Rnd, config.NumberOfEvents);
                        string resource1 = DataGenerator.GenerateResourceForEvent(context.Rnd, activity, config.Activities, config.Resources1);
                        string resource2 = DataGenerator.GenerateResourceForEvent(context.Rnd, activity, config.Activities, config.Resources2);
                        var data = new[]

                        {
                            new CsvTemplate {
                                CaseID = context.Counter+1 ,
                                Activity = activity,
                                Resource1 = resource1,
                                Resource2 = resource2,
                                Start = start,
                                Duration = duration,
                                End = start.Add(duration),
                                FinCase = DataGenerator.GenerateFinCase(context),
                                FinEvent = DataGenerator.GenerateFinEvent(config, activity),
                                FinRes = DataGenerator.GenerateFinRes(config, resource1),
                                AttributeCase = DataGenerator.GenerateAttributeCase(config, context),
                                AttributeEvent = DataGenerator.GeneratAttributeEvent(config, activity)
                                }
                            };
                        {
                            csvWriter.WriteRecords(data);

                            context.CaseDateTime = start.AddMinutes(context.Rnd.Next(0, 150));
                            --numberOfEvents;
                            disposableVariant.RemoveAt(0);
                            ++context.Counter;
                        }
                    }
                    else
                    {// GENERATE RANDOM EVENT
                        DateTime start = context.CaseDateTime.AddSeconds(context.InitialNumberOfEvents - numberOfEvents).AddMilliseconds(context.Rnd.Next(0, 800));
                        TimeSpan duration = DataGenerator.GenerateDuration(context.Rnd, config.NumberOfEvents);
                        string activity = disposableVariant[0];
                        string resource1 = DataGenerator.GenerateResourceForEvent(context.Rnd, activity, config.Activities, config.Resources1);
                        string resource2 = DataGenerator.GenerateResourceForEvent(context.Rnd, activity, config.Activities, config.Resources2);

                        var data = new[]

                        {
                            new CsvTemplate {
                                CaseID = context.Counter+1 ,
                                Activity = activity,
                                Resource1 = resource1,
                                Resource2 = resource2,
                                Start = start,
                                Duration = duration,
                                End = start.Add(duration),
                                FinCase = DataGenerator.GenerateFinCase(context),
                                FinEvent = DataGenerator.GenerateFinEvent(config, activity),
                                FinRes = DataGenerator.GenerateFinRes(config, resource1),
                                AttributeCase = DataGenerator.GenerateAttributeCase(config, context),
                                AttributeEvent = DataGenerator.GeneratAttributeEvent(config, activity)
                                }
                            };
                        {
                            csvWriter.WriteRecords(data);

                            context.CaseDateTime = start.Add(duration).AddHours(context.Rnd.Next(0, 2));
                            --numberOfEvents;
                            disposableVariant.RemoveAt(0);
                        }
                    }
                }
            }
        }
    }
}