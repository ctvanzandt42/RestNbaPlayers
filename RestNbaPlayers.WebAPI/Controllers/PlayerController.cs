using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestNbaPlayers.Application.Interfaces;
using RestNbaPlayers.Domain;
using RestNbaPlayers.Infrastructure.DatabaseModel;

namespace RestNbaPlayers.WebAPI.Controllers
{
    [Route("/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _repository;
        private readonly ILogger _logger;

        public PlayerController(IPlayerRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentException("Repository missing");
            _logger = logger;
        }

        // Add player
        [HttpPost("/addplayer")]
        public async Task AddPlayer([FromBody] Player player)
        {
            await _repository.AddPlayer(player);
            _logger.LogInformation("Player added");
        }

        [HttpGet("/{id}")]
        public async Task<PlayerDocument> GetPlayerById(string id)
        {
            return await _repository.FindById(id);
        }

        [HttpPut("/{id}")]
        public async Task UpdatePlayerInformation(string id, [FromBody] Player player)
        {
            await _repository.UpdatePlayerInformation(id, player);
        }

        [HttpGet("/")]
        public async Task<List<PlayerDocument>> ListPlayers()
        {
            return await _repository.GetAllPlayers();
        }

        [HttpDelete]
        public async Task DeletePlayerById(string id)
        {
            await _repository.DeletePlayer(id);
        }
    }
}