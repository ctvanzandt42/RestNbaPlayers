using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestNbaPlayers.Infrastructure.DatabaseModel;

namespace RestNbaPlayers.WebAPI
{
    public static class DependencyMapper
    {
        public static void AddCosmosDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosSettings = new CosmosStoreSettings("nbaplayers", 
                "https://cvzeu2playersapicdb.documents.azure.com:443/", 
            "A37an6Ph0HbdFbteDC2cwwVeFIZyKYEdfjbINxd0tEQJ5driobTd7wmYLbTMUQspYmnkxSnhfwKbfkUOqucn7A==");

            services.AddCosmosStore<PlayerDocument>(cosmosSettings);
        }
    }
}