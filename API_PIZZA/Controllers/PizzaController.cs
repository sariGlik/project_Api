
using Microsoft.AspNetCore.Mvc;
using AllService;
using AllModels;
using AllModels.Interfaces;

// using Microsoft.AspNetCore.Mvc.ActionConstraints;
namespace API_PIZZA.Controllers;
    //מידע על כולם
    [ApiController]
    [Route("Api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private IPizza _PizzaService;
        public PizzaController(IPizza pizzaService)
        {
            _PizzaService = pizzaService;
        }
        [HttpGet]
        public List<Pizza> Get()
        {
            return _PizzaService.GetPizza();
        }
        [HttpGet("{id}")]
        public Pizza? GetPizzaById(int id)
        {
            var p = _PizzaService.GetPizzaId(id);
            return p;

        }
        [HttpPut("{id}/{name}")]
        public ActionResult<Pizza> PutPizza(int id, string name)
        {
            var p = _PizzaService.AddPizza(id, name);
            if (p != null)
                return p;
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePizza(int id)
        {
            _PizzaService.DeleteThePizza(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult<List<Pizza>>PostPizza(Pizza pizza)
        {
            var p = _PizzaService.UpdatePizza(pizza);
            if (p != null)
                return p;
            else
                return NotFound();
        }
    }

