using Microsoft.Extensions.Logging;
using System;

namespace HNCK.CRM.InfrastructureServices.Logging
{
	public interface ILogMessage
	{
		string CallerMethodFullName { get; set; }
		string ClientAgent { get; set; }
		string ClientIp { get; set; }
		DateTime CreatedAt { get; set; }
		string Environment { get; set; }
		long? ErrorId { get; set; }
		Exception Exception { get; set; }
		string ExceptionMessage { get; set; }
		int? IdUser { get; set; }
		LogLevel LogLevel { get; set; }
		int? LogLevelId { get; set; }
		string MachineName { get; set; }
		string Message { get; set; }
		string ProcesId { get; set; }
		string RequestId { get; set; }
		string RequestMethod { get; set; }
		string RequestPath { get; set; }
		string SqlStatement { get; set; }
		string ThreadId { get; set; }
		string User { get; set; }
	}
}