using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace DeckOfCards.Data
{
    public class PileRepository : IPileRepository
    {
        async public Task<Pile> AddCardToPileAsync(string deckId, string pileName, string cards)
        {
            string[] cardArr = cards.Split(',');
            using (var context = new DeckContext())
            {
                Deck deck = await context.Decks
                    .Include(x => x.Cards)
                    .SingleAsync(x => x.DeckId.Equals(deckId));

                Deck deckPiles = await context.Decks
                    .Include(x => x.Piles)
                    .SingleAsync(x => x.DeckId.Equals(deckId));

                //Couldn't figure out how to do multiple includes so I made two 

                Pile pile;
                try
                {
                    pile = deckPiles.Piles.Single(x => x.Name.Equals(pileName) && x.DeckId == deckPiles.Id);
                }
                catch(Exception)
                {
                    pile = new Pile();
                    pile.Deck = deckPiles;
                    pile.DeckId = deckPiles.Id;
                    pile.Name = pileName;
                    pile.Cards = new List<Card>();
                    deckPiles.Piles.Add(pile);
                }

                foreach(var card in cardArr)
                {

                    Card Card = deck.Cards.Single(x => x.Code.Equals(card));
                    Card.Drawn = true; // we took it out so it's out of the deck
                    if (pile.Cards.Contains(Card)) continue; //small check so we won't put multiple instances of the same card in the pile
                    pile.Cards.Add(Card);
                    Card.Pile = pile; 
                }

                await context.SaveChangesAsync();

                return pile;

            }
        }

        async public Task<Pile> PileShuffleAsync(string deckId, string pileName)
        {
            using(var context = new DeckContext())
            {
                Pile pile = await context.Piles
                    .Include(x => x.Cards)
                    .SingleAsync(x => x.Name.Equals(pileName));

                //no try catch this time because if you try to shuffle a pile that doesn't exist you deserve to have the API scream at you
                /*Pile pile = deckPiles.Piles.Single(x => x.Name.Equals(pileName) && x.DeckId == deckPiles.Id);*/
                var rnd = new Random();
                var shuffledPile = pile.Cards.OrderBy(x => rnd.Next()).ToList();

                pile.Cards = shuffledPile;

                await context.SaveChangesAsync();

                return pile;
            }
        }
    }
}