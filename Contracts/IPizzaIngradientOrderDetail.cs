using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPizzaIngradientOrderDetail : IRepositoryBase<PizzaIngradientOrderDetails>
    {
        void SavePizaaIngradients(PizzaIngradientOrderDetails pizzaIngradientOrderDetail);
    }
}
