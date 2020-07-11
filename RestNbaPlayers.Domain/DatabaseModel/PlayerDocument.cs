using System;
using Cosmonaut.Attributes;
using Newtonsoft.Json;
using RestNbaPlayers.Domain;

namespace RestNbaPlayers.Infrastructure.DatabaseModel
{
    [CosmosCollection("nbaPlayer")]
    public class PlayerDocument
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("jerseyNum")]
        public int? JerseyNum { get; set; }
        
        [JsonProperty("team")]
        public Team Team { get; set; }
        
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        public static PlayerDocument GenerateFromDomain(string id, Player player)
        {
            return new PlayerDocument()
            {
                Id = id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                JerseyNum = player.JerseyNum,
                Team = player.Team,
                IsActive = player.IsActive
            };
        }
    }
}