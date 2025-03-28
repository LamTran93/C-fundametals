using asp.net_fundamental.Services;
using asp.net_fundamental.Services.Interfaces;

namespace asp.net_fundamental.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;

        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogginService<LogData> service)
        {
            try
            {
                // Get request data
                var request = context.Request;
                var streamReader = new StreamReader(request.Body);
                var logData = new LogData()
                {
                    Schema = request.Scheme,
                    Host = request.Host.Host,
                    Path = request.Path.ToString(),
                    QueryString = request.QueryString.ToString(),
                    RequestBody = await streamReader.ReadToEndAsync()
                };
                // Log data using log service
                service.Log(logData);

                await _next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Log failed - Exception: {ex}");
            }
        }
    }
}
