using System;
using System.Collections.Generic;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class Error
    {
        public long IdError { get; set; }
        public DateTime Created { get; set; }
        public int? IdLogLevel { get; set; }
        public string Level { get; set; }
        public string CallerMethodFullName { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Detail { get; set; }
        public string SqlStatement { get; set; }
        public int? IdUser { get; set; }
        public string ClientIp { get; set; }
        public string Environment { get; set; }
        public string ClientAgent { get; set; }
        public string ExceptionMessage { get; set; }
        public string RequestPath { get; set; }
        public string RequestId { get; set; }
        public string RequestMethod { get; set; }
        public string MachineName { get; set; }
        public string ProcesId { get; set; }
        public string ThreadId { get; set; }

        public virtual LogLevel IdLogLevelNavigation { get; set; }
    }
}
