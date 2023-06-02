using System.Text.Json;
using Infrastructure.Exceptions.Handlers;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Infrastructure.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly HttpExceptionHandler _httpExceptionHandler;

    private readonly IHttpContextAccessor _contextAccessor;

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor contextAccessor)
    {
        _httpExceptionHandler = new HttpExceptionHandler();
        _next = next;
        _contextAccessor = contextAccessor;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleLogException(context, exception);
            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }

    private Task HandleLogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter
            {
                Name = context.Request.Method,
                Type = context.GetType().Name,
                Value = exception.ToString()
            },
        };

        var logDetail = new LogDetail
        {
            MethodName = _next.Method.Name,
            Path = context.Request.Path,
            Message = exception.Message,
            User = _contextAccessor.HttpContext?.User.Identity?.Name ?? "Anonymous",
            ClassName = exception.TargetSite?.DeclaringType?.Name ?? "Unknown",
            InnerException = exception.InnerException?.Message ?? "Unknown",
            LogParameters = logParameters
        };
        Log.Error(JsonSerializer.Serialize(logDetail));
        return Task.CompletedTask;
    }
}