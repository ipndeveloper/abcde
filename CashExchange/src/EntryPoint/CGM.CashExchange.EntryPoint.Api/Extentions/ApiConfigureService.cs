using CGM.CashExchange.EntryPoint.Api.Middlewares;

namespace CGM.CashExchange.EntryPoint.Api.Extentions
{
    public static class ApiConfigureService
    {
        public static IApplicationBuilder UseCustomErrorHandlingMiddleware(this IApplicationBuilder app) =>
              app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
