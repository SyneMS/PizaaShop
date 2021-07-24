using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IDefaultPizzaRepository : IRepositoryBase<PizzaDetails>
    {
        IEnumerable<PizzaDetails> GetAllDefaultFizza();
    }
}
