using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PizzaOrderDetail : RepositoryBase<Entities.Models.PizzaOrderDetails>, IPizzaOrderDetail
    {
        public PizzaOrderDetail(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public int SavePizzaOrder(PizzaOrderDetails pizzaOrderDetail)
        {
            Create(pizzaOrderDetail);
            return pizzaOrderDetail.OrderId;
        }
    }
}
