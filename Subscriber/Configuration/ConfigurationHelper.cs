namespace Subscriber.Configuration
{
    public static class ConfigurationHelper
    {
        public static void ConfigureDynamicConfiguration(this IServiceCollection services)
        {
            services.AddHostedService<ConfigurationService>();
            services.AddSingleton<ConfigurationStore>();
            services.AddMemoryCache();            
        }
    }
}
