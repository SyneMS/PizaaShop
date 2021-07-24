using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class PizzaIngradientOrderDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PizzaOrderDetails))]
        public int OrderId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        public decimal Prize { get; set; }


        public PizzaOrderDetails PizzaOrderDetails { get; set; }

    }
}
