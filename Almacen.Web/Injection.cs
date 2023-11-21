namespace Almacen.Web
{
    public static class Injection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services,
     IConfiguration configuration)
        {
            return services;
        }

    }
}
