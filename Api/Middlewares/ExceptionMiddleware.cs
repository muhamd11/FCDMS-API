using App.Core.Consts.GeneralModels;
using App.Core.Resources.General;
using Azure;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly Stopwatch watch = new();
        private object response = new();

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            watch.Start();
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = HandleExceptionAsync(httpContext);
                var jsonResponse = JsonSerializer.Serialize(response);
                var byteArray = Encoding.UTF8.GetBytes(jsonResponse);

                await httpContext.Response.Body.WriteAsync(byteArray);
            }
        }

        private object HandleExceptionAsync(HttpContext context)
        {
            watch.Stop();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)EnumStatus.success;

            return new
            {
                status = EnumStatus.catchStatus,
                msg = GeneralMessagesAr.errorSomthingWrong,
                executionTimeMilliseconds = watch.ElapsedMilliseconds
            };

        }
    }
}