using FRIWOCenter.WebAPIs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FRIWOCenter.WebAPIs.Logging
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private readonly IDbContextFactory<LoggingFRIWOConnectContext> _contextFactory;

        private readonly ILogger<DatabaseLogger> _logger;

        public ApplicationLoggerProvider(IDbContextFactory<LoggingFRIWOConnectContext> contextFactory,ILogger<DatabaseLogger> logger)
        {
            _contextFactory = contextFactory;
            _logger = logger;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }

        public void Dispose()
        {

        }
    }
}
