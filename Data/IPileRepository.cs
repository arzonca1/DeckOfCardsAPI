using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DeckOfCards.Data
{
    public interface IPileRepository
    {
        Task<Pile> AddCardToPileAsync(string deckID, string pileName, string cards);
        Task<Pile> PileShuffleAsync(string deckId, string pileName);


    }
}