using FRIWOCenter.WebHost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FRIWOCenter.WebHost.Logging
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private readonly IDbContextFactory<LoggingBlazorWASMContext> _contextFactory;

        public ApplicationLoggerProvider(IDbContextFactory<LoggingBlazorWASMContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_contextFactory);
        }

        public void Dispose()
        {

        }
    }
}
