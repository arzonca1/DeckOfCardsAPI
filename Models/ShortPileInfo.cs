using DeckOfCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class ShortPileInfo
    {
        public string PileName { get; set; }
        public int CardCount { get; set; }
        public List<string> CardCodes { get; set; }

        public ShortPileInfo()
        {

        }

        public ShortPileInfo(Pile pile)
        {
            PileName = pile.Name;
            CardCodes = new List<string>();
            foreach(var card in pile.Cards)
            {
                if(card.PileId == pile.Id)  CardCodes.Add(card.Code);
            }
            CardCount = CardCodes.Count(); 
        }
    }
}