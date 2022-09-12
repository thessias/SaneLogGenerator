using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneLogGenerator
{
    public class Context
    {
        public Random Rnd { get; set; }
        public int Counter { get; set; }
        public DateTime CaseDateTime { get; set; }
        public int InitialNumberOfEvents { get; set; }

        public Context(DateTime startDateTime, int numberOfEvents)
        {
            this.Rnd = new Random((int)DateTime.Now.Ticks);
            this.Counter = 0;
            this.CaseDateTime = startDateTime.AddMilliseconds(Rnd.Next(0, 200));
            this.InitialNumberOfEvents = numberOfEvents;
        }
    }
}