using System.Collections.Generic;
using System.Threading.Tasks;
using RestNbaPlayers.Domain;
using RestNbaPlayers.Infrastructure.DatabaseModel;

namespace RestNbaPlayers.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<PlayerDocument> FindById(string id);
        Task AddPlayer(Player player);
        Task<List<PlayerDocument>> GetAllPlayersByLastName(string lastName);
        Task UpdatePlayerInformation(string id, Player player);
        Task DeletePlayer(string id);
        Task<List<PlayerDocument>> GetAllPlayers();
    }
}