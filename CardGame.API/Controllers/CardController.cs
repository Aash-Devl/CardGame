using CardGame.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using NonActionAttribute = Microsoft.AspNetCore.Mvc.NonActionAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CardGame.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private readonly ILogger<CardController> _logger;

        public CardController()
        {
        }

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        [Route("AllCards")]
        [HttpGet]
        public IActionResult AllCards()
        {
            try
            {
                var cardDeck = new Deck().FillDeck();
                if (cardDeck != null)
                {
                    return Ok(cardDeck.Select(x => x.Name));
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            finally { }
        }

        [Route("SortCards")]
        [HttpPost]
        public IActionResult SortCards([FromBody] CardVM data)
        {
            try
            {
                if (data != null && data.input != null && data.input.Count > 0)
                {
                    var cardDeck = new Deck().SortDeck(data.input);
                    if (cardDeck != null && cardDeck.Count > 0)
                    {
                        return Ok(cardDeck);
                    }
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            finally { }
        }
    }
}
