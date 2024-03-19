using Microsoft.Extensions.DependencyInjection;
using SortedExam.Model.App.Shared;
using SortedExam.Service.Implementations;
using SortedExam.Service.Interfaces;

namespace SortedExam.Service
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, ConfigurationOption configurationOption)
        {
            var rainfallSourceUrl = configurationOption.RainfallSourceUrl;
            if (string.IsNullOrWhiteSpace(rainfallSourceUrl))
                throw new ArgumentNullException("rainfallSourceUrl is empty.");

            services.AddHttpClient(Constants.RAINFALL_CLIENT, client =>
            {
                client.BaseAddress = new Uri(rainfallSourceUrl);
            });

            services.AddScoped<IRainfallService, RainfallService>();

            return services;
        }
    }
}
