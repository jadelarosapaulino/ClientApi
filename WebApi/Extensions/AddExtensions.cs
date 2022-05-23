using Microsoft.AspNetCore.Builder;
using WebApi.Middlewares;

namespace WebApi.Extensions;

public static class AddExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddlewares>();
    }
}
