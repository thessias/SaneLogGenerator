using System;
using System.Collections.Generic;
using System.Text;

namespace SaneLogGenerator
{
    internal class DataGenerator
    {
        public static List<string> GenerateResources(int numberOfResources, bool specialChars, int resourceListIndex)
        {
            List<string> resources = new List<string>();
            string resourcePrefix;
            if (specialChars)
            {
                if (resourceListIndex == 1)
                {
                    resourcePrefix = "Пользователь_";
                }
                else
                {
                    resourcePrefix = "Ресурс_";
                }
            }
            else
            {
                if (resourceListIndex == 1)
                {
                    resourcePrefix = "Resource_";
                }
                else
                {
                    resourcePrefix = "User_";
                }
            }
            while (numberOfResources > 0)
            {
                resources.Add(resourcePrefix + numberOfResources);
                numberOfResources--;
            }
            resources.Reverse();
            return resources;
        }

        public static List<string> GenerateActivities(int numberOfActivities, bool specialChars)
        {
            List<string> activities = new List<string>();
            string activityPrefix; ;
            if (specialChars)
            {
                activityPrefix = "Деятельность_";
            }
            else
            {
                activityPrefix = "Activity_";
            }
            while (numberOfActivities > 0)
            {
                activities.Add(activityPrefix + numberOfActivities);
                numberOfActivities--;
            }
            activities.Reverse();
            return activities;
        }

        public static string GetFirstEventFromList(List<string> list, Random rnd)
        {
            int count = list.Count;
            int r;
            if (count <= 10)
            {
                r = rnd.Next(0, 1);
            }
            else if (count >= 25)
            {
                r = rnd.Next(0, 3);
            }
            else
            {
                r = rnd.Next(0, 4);
            }

            return list[r];
        }

        public static string GetLastEventFromList(List<string> list, Random rnd)
        {
            int count = list.Count;
            int r;
            if (count <= 10)
            {
                r = rnd.Next(count - 1, count);
            }
            else if (count >= 25)
            {
                r = rnd.Next(count - 2, count);
            }
            else
            {
                r = rnd.Next(count - 3, count);
            }

            return list[r];
        }

        public static string GenerateResourceForEvent(Random rnd, string activity, List<string> activities, List<string> resources)
        {
            int numberOfResources = resources.Count;
            int numberOfActivities = activities.Count;

            int indexOfActivity = activities.IndexOf(activity);
            int indexOfResource;

            if (numberOfActivities == numberOfResources)
            {
                indexOfResource = indexOfActivity;
                return resources[indexOfResource];
            }
            else if (numberOfActivities < numberOfResources)
            {
                int quotient = numberOfResources / numberOfActivities;
                int remainder = numberOfResources % numberOfActivities;

                if (remainder == 0)
                {
                    List<int> possibleResources = new List<int>();
                    possibleResources.Add(indexOfActivity);
                    while (quotient > 1)
                    {
                        possibleResources.Add(((indexOfActivity + 1) * quotient) - 1);
                        quotient--;
                    }
                    int randomFromRange = rnd.Next(0, possibleResources.Count);

                    return resources[possibleResources[randomFromRange]];
                }
                else
                {
                    List<int> possibleResources = new List<int>();
                    possibleResources.Add(indexOfActivity);
                    while (quotient > 0)
                    {
                        possibleResources.Add(indexOfActivity * quotient);
                        quotient--;
                    }
                    int i = 1;
                    while (remainder > 0)
                    {
                        possibleResources.Add(numberOfResources - i);
                        remainder--;
                        i++;
                    }

                    indexOfResource = GetRandomIntFromList(possibleResources, rnd);
                    return resources[indexOfResource];
                }
            }
            else
            {
                int quotient = numberOfActivities / numberOfResources;
                int remainder = numberOfActivities % numberOfResources;

                if (remainder == 0)
                {
                    if (indexOfActivity + 1 < numberOfResources)
                    {
                        return resources[indexOfActivity];
                    }
                    else if ((((indexOfActivity + 1) / quotient) - 1) < 0)
                    {
                        return resources[0];
                    }
                    else
                    {
                        return resources[(((indexOfActivity + 1) / quotient) - 1)];
                    }
                }
                else
                {
                    if (indexOfActivity + 1 < numberOfResources)
                    {
                        return resources[indexOfActivity];
                    }
                    else
                    {
                        List<int> possibleResources = new List<int>();
                        while (remainder > 0)
                        {
                            possibleResources.Add((indexOfActivity + 1) % quotient);
                            remainder--;
                        }
                        indexOfResource = GetRandomIntFromList(possibleResources, rnd);
                        return resources[indexOfResource];
                    }
                }
            }
        }

        public static string GetRandomFromList(List<string> list, Random rnd)
        {
            int r = rnd.Next(list.Count);
            return list[r];
        }

        public static int GetRandomIntFromList(List<int> list, Random rnd)
        {
            int r = rnd.Next(list.Count);
            return list[r];
        }

        public static TimeSpan GenerateDuration(Random rnd, int numberOfEvents)
        {
            TimeSpan start;
            TimeSpan end;
            int maxMillis;
            int millis;
            TimeSpan t;
            if (numberOfEvents <= 10000)
            {
                start = TimeSpan.FromHours(0);
                end = TimeSpan.FromHours(8);
                maxMillis = (int)((end - start).TotalMilliseconds);

                millis = rnd.Next(maxMillis);
                t = start.Add(TimeSpan.FromMilliseconds(millis));
                return t;
            }
            else if (numberOfEvents <= 100000)
            {
                start = TimeSpan.FromHours(0);
                end = TimeSpan.FromHours(6);
                maxMillis = (int)((end - start).TotalMilliseconds);

                millis = rnd.Next(maxMillis);
                t = start.Add(TimeSpan.FromMilliseconds(millis));
                return t;
            }
            else if (numberOfEvents <= 1000000)
            {
                start = TimeSpan.FromHours(0);
                end = TimeSpan.FromHours(4);
                maxMillis = (int)((end - start).TotalMilliseconds);

                millis = rnd.Next(maxMillis);
                t = start.Add(TimeSpan.FromMilliseconds(millis));
                return t;
            }
            else if (numberOfEvents <= 10000000)
            {
                start = TimeSpan.FromHours(0);
                end = TimeSpan.FromHours(3);
                maxMillis = (int)((end - start).TotalMilliseconds);

                millis = rnd.Next(maxMillis);
                t = start.Add(TimeSpan.FromMilliseconds(millis));
                return t;
            }
            else
            {
                start = TimeSpan.FromHours(0);
                end = TimeSpan.FromHours(2);
                maxMillis = (int)((end - start).TotalMilliseconds);

                millis = rnd.Next(maxMillis);
                t = start.Add(TimeSpan.FromMilliseconds(millis));
                return t;
            }
        }

        public static int GenerateFinCase(Config config)
        {
            int finCase = config.Counter + 1 + 10000;
            return finCase;
        }

        public static int GenerateFinEvent(Config config, string activity)
        {
            int indexOfActivity = config.Activities.IndexOf(activity);

            int finEvent = indexOfActivity + 1 + 10;
            return finEvent;
        }

        public static string GeneratAttributeEvent(Config config, string activity)
        {
            int indexOfActivity = config.Activities.IndexOf(activity) + 1;
            string attEventPrefix;
            if (config.SpecialChars)
            {
                attEventPrefix = "СобытиеАтрибут_";
            }
            else
            {
                attEventPrefix = "EventAttribute_";
            }

            string attEvent = attEventPrefix + indexOfActivity;
            return attEvent;
        }

        public static string GenerateAttributeCase(Config config)
        {
            int attCaseNumber = config.Counter + 1;
            string attCasePrefix;

            if (config.SpecialChars)
            {
                attCasePrefix = "CлучайАтрибут_";
            }
            else
            {
                attCasePrefix = "CaseAttribute_";
            }
            string attCase = attCasePrefix + attCaseNumber;
            return attCase;
        }

        public static int GenerateFinRes(Config config, string resource)
        {
            int indexOfResource = config.Resources1.IndexOf(resource);
            int finRes = indexOfResource + 10;
            return finRes;
        }

        public static List<List<string>> GenerateVariants(Config config)
        {
            int activitiesPerCase;
            List<List<string>> variants = new List<List<string>>();

            while (config.NumberOfVariants > 0)
            {
                List<string> variant = new List<string>();

                activitiesPerCase = config.Rnd.Next(config.MinActivitiesPerCase, config.MaxActivitiesPerCase);
                string firstEvent = GetFirstEventFromList(config.Activities, config.Rnd);
                variant.Add(firstEvent);

                while (activitiesPerCase - 2 > 0)
                {
                    string anyEvent = DataGenerator.GetRandomFromList(config.Activities, config.Rnd);
                    variant.Add(anyEvent);
                    activitiesPerCase--;
                }
                string lastEvent = GetLastEventFromList(config.Activities, config.Rnd);
                variant.Add(lastEvent);
                config.NumberOfVariants--;
                variants.Add(variant);
            }
            return variants;
        }

        public static List<string> GetRandomVariant(Config config, List<List<string>> variants)
        {
            int r = config.Rnd.Next(variants.Count);
            return variants[r];
        }
    }
}