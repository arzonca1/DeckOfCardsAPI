using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class CardDrawRequest
    {
        public int? Count { get; set; }
        public CardDrawRequest()
        {
            Count = 1; 
        }
    }
}