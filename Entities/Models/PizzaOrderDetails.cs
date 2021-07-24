using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class PizzaOrderDetails
    {
        //public IEnumerable<PizzaDetails> OrderedPizzas { get; set; }

        [Key]
        public int OrderId { get; set; }

        public int PizzaId { get; set; }
        public decimal FinalPrize { get; set; }

        public ICollection<PizzaIngradientOrderDetails> Ingradients { get; set; }
    }
}
