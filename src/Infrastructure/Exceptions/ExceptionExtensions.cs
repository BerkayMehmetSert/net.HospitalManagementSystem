using Infrastructure.Exceptions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Exceptions;

public static class ExceptionExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}