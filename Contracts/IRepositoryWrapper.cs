using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDefaultPizzaRepository PizzaDetails { get; }
        IPizzaIngradients PizzaIngradients { get; }
        IPizzaOrderDetail PizzaOrderDetail { get; }
        IPizzaIngradientOrderDetail PizzaIngradientOrderDetail { get; }

        IIngradient Ingradient { get; }
        void Save();
    }
}
