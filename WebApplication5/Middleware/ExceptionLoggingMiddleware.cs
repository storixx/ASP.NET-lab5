namespace WebApplication5.Middleware
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string logPath = "logs.txt";

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionAsync(ex);
                throw;
            }
        }

        private async Task LogExceptionAsync(Exception ex)
        {
            await File.AppendAllTextAsync(logPath, $"{DateTime.Now}: {ex.Message}\n");
        }
    }
}