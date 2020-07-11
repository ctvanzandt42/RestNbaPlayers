using System;
using RestNbaPlayers.Application.Interfaces;
using RestNbaPlayers.Domain;

namespace RestNbaPlayers.Application
{
    public class PlayerValidationService : IPlayerValidationService
    {
        public void ValidatePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("Player object is null");
            if (string.IsNullOrEmpty(player.FirstName))
                throw new ArgumentNullException("First name is null");
            if (string.IsNullOrEmpty(player.LastName))
                throw new ArgumentNullException("Last name is null");
            if (player.JerseyNum == null)
                throw new ArgumentNullException("Jersey num is null");
            if (player.JerseyNum < 0)
                throw new ArgumentOutOfRangeException("Jersey num cannot be negative");
            if (player.Team == null)
                throw new ArgumentNullException("Team is null");
            if (string.IsNullOrEmpty(player.Team.City))
                throw new ArgumentNullException("City is null");
            if (string.IsNullOrEmpty(player.Team.Name))
                throw new ArgumentNullException("Team name is null");
            if (player.IsActive == null)
                throw new ArgumentNullException("IsActive is null");
        }
    }
}