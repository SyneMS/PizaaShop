using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("PizzaDetails")]
    public class PizzaDetails
    {
        [Key]
        public int PizzaId { get; set; }

        [StringLength(200)]
        public string PizzaName { get; set; }

        [StringLength(1000)]
        public string PizzaPic { get; set; }

        public decimal PizzaPrize { get; set; }
        public ICollection<PizzaIngradients> PizzaIngradients { get; set; }
    }
}
