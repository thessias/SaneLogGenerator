# SaneLogGenerator
Command-line app for creating "sane" event logs that can be used for testing of process mining apps.

Output file consists of following columns:
- CaseID
- Activity
- Resource1
- Resource2 (different than Resource1)
- Start
- Duration
- End
- FinCase (Financal per Case)
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
- if you want to use special characters in log (russian)
- if you want to have paralell activities

Example usage:
~~~
SaneLogGenerator.exe -e 100 -v 10 -x 5 -y 10 -a 10 -r 10 -d "08/08/2000 9:00" -p -f "C:\out.csv"
~~~
