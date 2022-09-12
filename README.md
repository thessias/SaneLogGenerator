# SaneLogGenerator
Command-line app for creating "sane" event logs in CSV that can be used for testing of process mining apps.

Output file consists of following columns:
- CaseID
- Activity
- Resource1
- Resource2 (Different than Resource1)
- Start
- Duration
- End
- FinCase (Financial per Case)
- FinEvent (Financial per Event)
- FinRes (Financial per Resource)
- AttributeCase (Generic Case-level Attribute)
- AttributeEvent (Generic Event-level Attribute)

All attributes are consistent on their level.

App allows you to choose:
- total number of events you want in your log 
- minimum and maximum number of events per case
- total number of variants used in log
- start date for the first event
- number of unique activities
- number of unique resources
- if you want to use special characters in log (Russian)
- if you want to have paralell activities

**Note: It's not always possible to create log that matches all the settings!**

Number of events is always a priority - that means that the last case in file can contain less events in case than the minimum number of events per case defines and also since the last case may be "incomplete" it can affect the total number of variants. 

Example usage:
~~~
SaneLogGenerator.exe -e 100 -v 10 -x 5 -y 10 -a 10 -r 10 -d "08/28/2000 9:00" -p -f "C:\out.csv"
~~~

All options:
~~~
SaneLogGenerator.exe --help

  -e, --events                     Required. Total number of events in log. (int)

  -v, --variants                   Required. Total number of variants used in log. (int)

  -x, --min-activities-per-case    Required. Min number of activities per case. (int)

  -y, --max-activities-per-case    Required. Max number of activities per case. (int)

  -a, --activities                 Required. Number of different activities used in log. (int)

  -r, --resources                  Required. Number of different resources used in log. (int)

  -d, --start-datetime             Required. Start DateTime used in log.

  -p, --parallel                   (Default: false) Parallel activities in log. (no value needed)

  -s, --special-chars              (Default: false) Special characters used in log. (no value needed)

  -f, --path-to-file               Required. Path to output file.

  --help                           Display this help screen.

  --version                        Display version information.
~~~
