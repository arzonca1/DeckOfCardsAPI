using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class PileCreate
    {
        public int? Count { get; set; }

        public PileCreate()
        {
            Count = 1;
        }
    }
}