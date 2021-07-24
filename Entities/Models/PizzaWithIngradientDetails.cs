using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class PizzaWithIngradientDetails
    {
        public ICollection<PizzaDetails> pizzaDetails { get; set; }

        public decimal FinalPrize { get; set; }
    }
}
