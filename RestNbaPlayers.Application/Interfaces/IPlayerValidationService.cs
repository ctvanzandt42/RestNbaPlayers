using RestNbaPlayers.Domain;

namespace RestNbaPlayers.Application.Interfaces
{
    public interface IPlayerValidationService
    {
        void ValidatePlayer(Player player);
    }
}