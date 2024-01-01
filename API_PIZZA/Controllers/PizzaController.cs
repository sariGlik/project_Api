
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
        public IActionResult DeletePizza(int id)
        {
            var p = _PizzaService.GetPizzaId(id);
           if(p is null)
           return NotFound();
           _PizzaService.DeleteThePizza(id);
           return NoContent();
        }
        [HttpPost]
        public ActionResult PostPizza(Pizza pizza)
        {
             _PizzaService.UpdatePizza(pizza);
            return Ok();
        }
    }

