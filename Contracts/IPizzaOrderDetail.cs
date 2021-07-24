using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPizzaOrderDetail : IRepositoryBase<PizzaOrderDetails>
    {
        int SavePizzaOrder(PizzaOrderDetails pizzaOrderDetail);
    }
}
