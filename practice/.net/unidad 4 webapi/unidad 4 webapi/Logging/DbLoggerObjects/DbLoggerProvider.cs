using Microsoft.Extensions.Options;

namespace unidad_4_webapi.Logging.DbLoggerObjects
{
    [ProviderAlias("Database")]
    public class DbLoggerProvider : ILoggerProvider
    {
        public readonly DbLoggerOptions Options;

        public DbLoggerProvider(IOptions<DbLoggerOptions> _options)
        {
            //guarda las opciones
            Options = _options.Value;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this);
        }

        public void Dispose()
        {

        }
    }
}
