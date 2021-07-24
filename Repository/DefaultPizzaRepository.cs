using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DefaultPizzaRepository : RepositoryBase<PizzaDetails>, IDefaultPizzaRepository
    {
        public DefaultPizzaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<PizzaDetails> GetAllDefaultFizza()
        {
            return FindAll()
                .OrderBy(ow => ow.PizzaName)
                .ToList();
        }
    }
}
