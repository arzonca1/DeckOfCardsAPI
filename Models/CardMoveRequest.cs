using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class CardMoveRequest
    {
        public string Cards { get; set; }
        public CardMoveRequest()
        {
            Cards = ""; 
        }
    }
}