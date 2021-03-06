using System;
using FRIWOCenter.WebAPIs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FRIWOCenter.WebAPIs.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly IDbContextFactory<LoggingFRIWOConnectContext> _contextFactory;

        private readonly ILogger<DatabaseLogger> _logger;

        public DatabaseLogger(IDbContextFactory<LoggingFRIWOConnectContext> contextFactory, ILogger<DatabaseLogger> logger)
        {
            _contextFactory = contextFactory;
            _logger = logger;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //No need to log UserId as the userId is already coming from the client error log
            long userId = 0;

            Log log = new();
            log.LogLevel = logLevel.ToString();
            log.UserId = Convert.ToInt64(userId);
            log.ExceptionMessage = exception?.Message;
            log.StackTrace = exception?.StackTrace;
            log.Source = "Server";
            log.CreatedDate = DateTime.Now.ToString();

            using var context = _contextFactory.CreateDbContext();
            context.Logs.Add(log);
            context.SaveChanges();
        }
    }
}
