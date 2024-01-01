using MiddleWares;
namespace MiddleWares.Extensions;
public static class RequestCultureMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestCulture(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActionLogbMiddleware>();
    }
}