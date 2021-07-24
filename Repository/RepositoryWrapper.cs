using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IDefaultPizzaRepository _pizzaDetails;
        private IPizzaIngradients _pizzaIngradients;
        private IPizzaOrderDetail _pizzaOrderDetail;
        private IPizzaIngradientOrderDetail _pizzaIngradientOrderDetail;
        private IIngradient _ingradient;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IDefaultPizzaRepository PizzaDetails
        {
            get
            {
                if (_pizzaDetails == null)
                {
                    _pizzaDetails = new DefaultPizzaRepository(_repoContext);
                }
                return _pizzaDetails;
            }
        }

        public IPizzaIngradients PizzaIngradients
        {
            get
            {
                if (_pizzaIngradients == null)
                {
                    _pizzaIngradients = new PizzaIngradients(_repoContext);
                }
                return _pizzaIngradients;
            }
        }

        public IPizzaOrderDetail PizzaOrderDetail
        {
            get
            {
                if (_pizzaOrderDetail == null)
                {
                    _pizzaOrderDetail = new PizzaOrderDetail(_repoContext);
                }
                return _pizzaOrderDetail;
            }
        }

        public IPizzaIngradientOrderDetail PizzaIngradientOrderDetail
        {
            get
            {
                if (_pizzaIngradientOrderDetail == null)
                {
                    _pizzaIngradientOrderDetail = new PizzaIngradientOrderDetail(_repoContext);
                }
                return _pizzaIngradientOrderDetail;
            }
        }

        public IIngradient Ingradient
        {
            get
            {
                if (_ingradient == null)
                {
                    _ingradient = new Ingradient(_repoContext);
                }
                return _ingradient;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
