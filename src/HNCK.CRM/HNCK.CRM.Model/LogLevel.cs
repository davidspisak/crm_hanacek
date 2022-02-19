using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class LogLevel
    {
        public LogLevel()
        {
            Errors = new HashSet<Error>();
            Traces = new HashSet<Trace>();
        }

        public int IdLogLevel { get; set; }
        public string LogLevel1 { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual ICollection<Error> Errors { get; set; }
        public virtual ICollection<Trace> Traces { get; set; }
    }
}
