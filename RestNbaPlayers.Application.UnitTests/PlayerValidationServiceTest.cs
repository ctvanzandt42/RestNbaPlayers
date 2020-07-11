using System;
using FluentAssertions;
using NUnit.Framework;
using RestNbaPlayers.Domain;

namespace RestNbaPlayers.Application.UnitTests
{
    public class PlayerValidationServiceTest
    {
        private readonly PlayerValidationService _service;

        public PlayerValidationServiceTest()
        {
            _service = new PlayerValidationService();
        }
        
        [Test]
        public void ValidatePlayer_PlayerValid_MethodReturns()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                LastName = "Vanzandt",
                IsActive = true,
                JerseyNum = 43,
                Team = new Team()
                {
                    City = "Murfreesboro",
                    Name = "Jaguars"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void ValidatePlayer_PlayerFirstNameNull_ExceptionThrown()
        {
            var player = new Player()
            {
                LastName = "Vanzandt",
                IsActive = true,
                JerseyNum = 43,
                Team = new Team()
                {
                    City = "Murfreesboro",
                    Name = "Jaguars"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Test]
        public void ValidatePlayer_PlayerLastNameNull_ExceptionThrown()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                IsActive = true,
                JerseyNum = 43,
                Team = new Team()
                {
                    City = "Murfreesboro",
                    Name = "Jaguars"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Test]
        public void ValidatePlayer_JerseyNumNull_ExceptionThrown()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                LastName = "Vanzandt",
                IsActive = true,
                Team = new Team()
                {
                    City = "Murfreesboro",
                    Name = "Jaguars"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Test]
        public void ValidatePlayer_JerseyNumOutOfRange_ExceptionThrown()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                LastName = "Vanzandt",
                IsActive = true,
                JerseyNum = -43,
                Team = new Team()
                {
                    City = "Murfreesboro",
                    Name = "Jaguars"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
        
        [Test]
        public void ValidatePlayer_TeamNull_ExceptionThrown()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                LastName = "Vanzandt",
                IsActive = true,
                JerseyNum = 43,
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Test]
        public void ValidatePlayer_TeamCityNull_ExceptionThrown()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                LastName = "Vanzandt",
                IsActive = true,
                JerseyNum = 43,
                Team = new Team()
                {
                    Name = "Jaguars"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Test]
        public void ValidatePlayer_TeamNameNull_ExceptionThrown()
        {
            var player = new Player()
            {
                FirstName = "Curtis",
                LastName = "Vanzandt",
                IsActive = true,
                JerseyNum = 43,
                Team = new Team()
                {
                    City = "Murfreesboro"
                }
            };
            
            var action = new Action(() => _service.ValidatePlayer(player));

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Test]
        public void ValidatePlayer_PlayerObjectNull_ExceptionThrown()
        {
            var action = new Action(() => _service.ValidatePlayer(null));

            action.Should().Throw<ArgumentNullException>();
        }
    }
}