using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPizzaIngradients : IRepositoryBase<PizzaIngradients>
    {
        IEnumerable<PizzaIngradients> GetPizzaIngradients(int pizzaId);
    }
}
