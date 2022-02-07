using BlazorWASM.WebAPI.Logging;
using BlazorWASM.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorWASM.WebAPI.Logging
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
