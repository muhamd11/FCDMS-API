using App.Core.Consts.GeneralModels;
using App.Core.Resources.General;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly Stopwatch watch = new();

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
                await HandleExceptionAsync(httpContext);
            }
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            watch.Stop();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            var response = new
            {
                status = EnumStatus.catchStatus,
                msg = GeneralMessagesAr.errorSomthingWrong,
                executionTimeMilliseconds = watch.ElapsedMilliseconds
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            var byteArray = Encoding.UTF8.GetBytes(jsonResponse);

            return context.Response.Body.WriteAsync(byteArray, 0, byteArray.Length);
        }
    }
}