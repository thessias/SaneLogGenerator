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


Example output:
~~~
CaseID;Activity;Resource1;Resource2;Start;Duration;End;FinCase;FinEvent;FinRes;AttributeCase;AttributeEvent
1;Activity_1;Resource_1;User_1;02/22/2001 18:25:00;03:53:04.8150000;02/22/2001 22:18:04;10001;11;10;CaseAttribute_1;EventAttribute_1
1;Activity_4;Resource_4;User_4;02/23/2001 01:03:06;04:52:54.3880000;02/23/2001 05:56:00;10001;14;13;CaseAttribute_1;EventAttribute_4
1;Activity_2;Resource_2;User_2;02/23/2001 06:56:03;02:12:26.5520000;02/23/2001 09:08:29;10001;12;11;CaseAttribute_1;EventAttribute_2
1;Activity_10;Resource_10;User_10;02/23/2001 09:08:33;07:21:25.8820000;02/23/2001 16:29:59;10001;20;19;CaseAttribute_1;EventAttribute_10
1;Activity_10;Resource_10;User_10;02/23/2001 15:29:59;01:12:38.3290000;02/23/2001 16:42:37;10001;20;19;CaseAttribute_1;EventAttribute_10
2;Activity_1;Resource_1;User_1;07/20/2001 22:10:00;07:13:47.1540000;07/21/2001 05:23:47;10002;11;10;CaseAttribute_2;EventAttribute_1
2;Activity_8;Resource_8;User_8;07/21/2001 05:45:48;03:06:25.5970000;07/21/2001 08:52:13;10002;18;17;CaseAttribute_2;EventAttribute_8
2;Activity_10;Resource_10;User_10;07/21/2001 09:52:16;01:52:12.1920000;07/21/2001 11:44:28;10002;20;19;CaseAttribute_2;EventAttribute_10
2;Activity_2;Resource_2;User_2;07/21/2001 11:44:31;07:38:33.4510000;07/21/2001 19:23:04;10002;12;11;CaseAttribute_2;EventAttribute_2
2;Activity_4;Resource_4;User_4;07/21/2001 19:23:08;01:41:41.8410000;07/21/2001 21:04:50;10002;14;13;CaseAttribute_2;EventAttribute_4
2;Activity_6;Resource_6;User_6;07/21/2001 21:04:55;07:27:28.0990000;07/22/2001 04:32:23;10002;16;15;CaseAttribute_2;EventAttribute_6
2;Activity_3;Resource_3;User_3;07/22/2001 04:32:30;00:13:56.9480000;07/22/2001 04:46:27;10002;13;12;CaseAttribute_2;EventAttribute_3
2;Activity_10;Resource_10;User_10;07/22/2001 02:46:27;04:41:47.9520000;07/22/2001 07:28:14;10002;20;19;CaseAttribute_2;EventAttribute_10
~~~
