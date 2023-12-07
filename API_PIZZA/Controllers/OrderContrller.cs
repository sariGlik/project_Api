using Microsoft.AspNetCore.Mvc;
using AllModels;
using AllModels.Interfaces;
using AllService;

//using Microsoft.AspNetCore.Mvc.ActionConstraints;
namespace API_PIZZA.Controllers
{
  [ApiController]

[Route("Api/[controller]")]
    public class OrderContrller:ControllerBase
    {
        private IOrder _orderService;
    public OrderContrller(IOrder orderService)
        {
            _orderService = orderService;
            _orderService.createDate = DateTime.Now;
        }
        // public IOrder OrderService { get => _orderService; set => _orderService = value; }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            _orderService.AddPizzaToOrder(order);
            return Ok();
        }
    }

   
}
