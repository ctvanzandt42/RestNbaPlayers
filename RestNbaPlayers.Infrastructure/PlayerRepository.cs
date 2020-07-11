using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;
using RestNbaPlayers.Application.Interfaces;
using RestNbaPlayers.Domain;
using RestNbaPlayers.Infrastructure.DatabaseModel;

namespace RestNbaPlayers.Infrastructure
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ICosmosStore<PlayerDocument> _cosmosStore;
        private readonly IPlayerValidationService _validation;

        public PlayerRepository(ICosmosStore<PlayerDocument> cosmosStore, IPlayerValidationService validation)
        {
            _cosmosStore = cosmosStore;
            _validation = validation;
        }

        public async Task<PlayerDocument> FindById(string id)
        {
            var player = await _cosmosStore.FindAsync(id);
            return player;
        }

        public async Task AddPlayer(Player player)
        {
            _validation.ValidatePlayer(player);
            var playerDoc = PlayerDocument.GenerateFromDomain(Guid.NewGuid().ToString(), player);
            await _cosmosStore.UpsertAsync(playerDoc);
        }

        public async Task<List<PlayerDocument>> GetAllPlayersByLastName(string lastName)
        {
            var players = await _cosmosStore.Query().Where(p => p.LastName == lastName).ToListAsync();
            return players;
        }

        public async Task UpdatePlayerInformation(string id, Player player)
        {
            _validation.ValidatePlayer(player);
            var playerDoc = PlayerDocument.GenerateFromDomain(id, player);
            await _cosmosStore.UpdateAsync(playerDoc);
        }

        public async Task DeletePlayer(string id)
        {
            await _cosmosStore.RemoveByIdAsync(id);
        }

        public async Task<List<PlayerDocument>> GetAllPlayers()
        {
            var players = await _cosmosStore.Query("select * from c").ToListAsync();
            return players;
        }
    }
}