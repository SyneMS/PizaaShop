using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Ingradient : RepositoryBase<Entities.Models.Ingradients>, IIngradient
    {

        public Ingradient(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Ingradients> GetAllIngradients()
        {
            return FindAll().OrderBy(i => i.Name);
        }
    }
}
