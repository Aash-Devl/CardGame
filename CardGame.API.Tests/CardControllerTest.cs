using CardGame.API.Controllers;
using CardGame.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace CardGame.API.Tests
{
    public class CardControllerTest
    {
        private readonly CardController _controller;
        private readonly ILogger<CardController> _logger;

        public CardControllerTest() {
            _controller = new CardController(_logger);
        }

        [Fact]
        public void AllCards_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.AllCards();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SortCards_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var _cards = new CardVM();
            _cards.input = new System.Collections.Generic.List<string> { "3H", "4H" };

            // Act
            var okResult = _controller.SortCards(_cards);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SortCards_WhenCalled_ReturnsBadResult()
        {
            // Arrange
            var _cards = new CardVM();
            _cards.input = new System.Collections.Generic.List<string> { "TEST" };

            // Act
            var badResponse = _controller.SortCards(_cards);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
    }
}