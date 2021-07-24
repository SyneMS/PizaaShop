using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PizzaIngradients : RepositoryBase<Entities.Models.PizzaIngradients>, IPizzaIngradients
    {
        public PizzaIngradients(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Entities.Models.PizzaIngradients> GetPizzaIngradients(int pizzaID)
        {
            return FindByCondition(p => p.PizzaId.Equals(pizzaID));
        }
    }
}
