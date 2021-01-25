using System;
using System.Collections.Generic;
using System.Text;

namespace SaneLogGenerator
{
    public class CsvTemplate
    {
        public int CaseID { get; set; }
        public string Activity { get; set; }
        public string Resource1 { get; set; }
        public string Resource2 { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime End { get; set; }
        public int FinCase { get; set; }
        public int FinEvent { get; set; }
        public int FinRes { get; set; }
    }
}