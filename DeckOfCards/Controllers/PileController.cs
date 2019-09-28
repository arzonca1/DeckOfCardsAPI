using DeckOfCards.Data;
using DeckOfCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data.Entity; 

namespace DeckOfCards.Controllers
{
    [RoutePrefix("api/decks")]
    public class PileController : ApiController
    {
        private IPileRepository _repository;

        public PileController(IPileRepository repository)
        {
            _repository = repository;
        }

        [Route("{deckId}/pile/{pileName}/add")]
        async public Task<ShortPileInfo> Patch(string deckID, string pileName, CardMoveRequest cards) //add card to pile and possibly create the pile
        {
            Pile pile = await _repository.AddCardToPileAsync(deckID, pileName, cards.Cards);
            return new ShortPileInfo(pile);

        }

        [Route("{deckId}/pile/{pileName}/shuffle")]
        async public Task<ShortPileInfo> Post(string deckID, string pileName) //shuffle
        {
            Pile pile = await _repository.PileShuffleAsync(deckID, pileName);
            return new ShortPileInfo(pile);
        }
    }
}



