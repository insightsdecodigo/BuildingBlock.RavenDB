using System;
using BuildingBlock.RavenDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BuildingBlock.RavenDB.Configurations
{
    public static class Configurations
    {
        public static IServiceCollection AddRavenDB(this IServiceCollection services, IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration?["RAVENDB_INSTANCE_NAME"]))
                throw new ArgumentException("O parametro RAVENDB_INSTANCE_NAME está null ou empty");

            if (string.IsNullOrEmpty(configuration?["RAVENDB_CONFIGURATION_URL"]))
                throw new ArgumentException("O parametro RAVENDB_CONFIGURATION_URL está null ou empty");

            if (string.IsNullOrEmpty(configuration?["RAVENDB_MAX_NUMBER_OF_REQUESTS_PER_SESSION"]))
                throw new ArgumentException("O parametro RAVENDB_MAX_NUMBER_OF_REQUESTS_PER_SESSION está null ou empty");

            if (string.IsNullOrEmpty(configuration?["RAVENDB_OPTIMISTIC_CONCURRENCY"]))
                throw new ArgumentException("O parametro RAVENDB_OPTIMISTIC_CONCURRENCY está null ou empty");

            if (string.IsNullOrEmpty(configuration?["RAVENDB_COLLECTIONNAME"]))
                throw new ArgumentException("O parametro RAVENDB_COLLECTIONNAME está null ou empty");

            if (string.IsNullOrEmpty(configuration?["RAVENDB_PATH_CERTIFICATE"]))
                throw new ArgumentException("O parametro RAVENDB_PATH_CERTIFICATE está null ou empty");

            services.AddSingleton<IRavenDataBase, RavenDataBase>();
            return services;
        }
    }
}