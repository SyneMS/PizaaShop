using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PizzaIngradientOrderDetail : RepositoryBase<Entities.Models.PizzaIngradientOrderDetails>, IPizzaIngradientOrderDetail
    {

        public PizzaIngradientOrderDetail(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void SavePizaaIngradients(PizzaIngradientOrderDetails pizzaIngradientOrderDetail)
        {
            Create(pizzaIngradientOrderDetail);
        }
    }
}
