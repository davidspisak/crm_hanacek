using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.InfrastructureServices.Logging.DBLogger
{
	[ProviderAlias("PostgresDbLogger")]
	public class PostgresDbLoggerProvider : ILoggerProvider
	{
		private readonly PostgresDbLoggerConfig _config;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public PostgresDbLoggerProvider(PostgresDbLoggerConfig config, IHttpContextAccessor httpContextAccessor)
		{
			_config = config;
			_httpContextAccessor = httpContextAccessor;
		}

		public ILogger CreateLogger(string categoryName)
		{
			if (_config == null)
				throw new NullReferenceException($"{nameof(PostgresDbLoggerConfig)}");

			if (_httpContextAccessor == null)
				throw new NullReferenceException($"{nameof(IHttpContextAccessor)}");

			return new PostgresDbLogger(categoryName, _config, _httpContextAccessor);
		}

		public void Dispose()
		{
		}
	}
}
