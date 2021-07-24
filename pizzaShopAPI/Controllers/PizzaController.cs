using System;
using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entities.Models;

namespace pizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;

        public PizzaController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }

        [HttpGet("GetDefaultPizzDetails")]
        public IActionResult GetDefaultPizzDetails()
        {
            var result = _repoWrapper.PizzaDetails.GetAllDefaultFizza();
            return Ok(result);
        }

        [HttpGet("GetAllIngradients")]
        public IActionResult GetAllIngradients()
        {
            var result = _repoWrapper.Ingradient.GetAllIngradients();
            return Ok(result);
        }

        [HttpGet("GetPizzIngradients/{pizzaId}")]
        public IActionResult GetPizzIngradients(int pizzaId)
        {
            var result = _repoWrapper.PizzaIngradients.GetPizzaIngradients(pizzaId);
            return Ok(result);
        }

        [HttpPost("SavePizzaDetails")]
        public IActionResult SavePizzaDetails([FromBody] PizzaWithIngradientDetails pizzaWithIngradientDetails)
        {
            int orderId = 0;
            foreach (PizzaDetails item in pizzaWithIngradientDetails.pizzaDetails)
            {
                PizzaOrderDetails pizza = new PizzaOrderDetails();
                pizza.FinalPrize = pizzaWithIngradientDetails.FinalPrize;
                pizza.PizzaId = item.PizzaId;
                var result = _repoWrapper.PizzaOrderDetail.SavePizzaOrder(pizza);
                _repoWrapper.Save();

                orderId = pizza.OrderId;
                foreach (PizzaIngradients item2 in item.PizzaIngradients)
                {
                    PizzaIngradientOrderDetails pid = new PizzaIngradientOrderDetails();
                    pid.Name = item2.Name;
                    pid.OrderId = pizza.OrderId;
                    pid.Prize = item2.Prize;

                    _repoWrapper.PizzaIngradientOrderDetail.SavePizaaIngradients(pid);
                }

            }

            _repoWrapper.Save();

            return Ok(orderId);
        }
    }
}
