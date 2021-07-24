using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("PizzaIngradients")]
    public class PizzaIngradients
    {
        [Key]
        public int Id { get; set; }

        public int IngradientId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        public decimal Prize { get; set; }

        [ForeignKey(nameof(PizzaDetails))]
        public int PizzaId { get; set; }
        public PizzaDetails PizzaDetails { get; set; }
    }
}
