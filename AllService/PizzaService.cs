using AllModels;
using AllModels.Interfaces;
using FileServices;
using System.Text.Json;
namespace AllService;

    public class PizzaService:IPizza
    {
     private IFile  _fileService;
        static int length=3;
    //   private static readonly List<Pizza> pizzas = new List<Pizza>()
    // {
    //  new Pizza() { Id=1,Name="Pizza1",IsGluten=true},
    //  new Pizza() { Id=2,Name="Pizza2",IsGluten=false}
    // };
     private List<Pizza> pizzas { get; set; }

      public PizzaService(IFile fileService)
            {
              _fileService=fileService;
              pizzas =  _fileService.Get<Pizza>();
            }  
        public List<Pizza> GetPizza()
        {     
            return pizzas;
        }
        public Pizza? GetPizzaId(int id)
        {  
            foreach (var Pizza in pizzas)
            {
                if (Pizza.Id == id)
                    return Pizza;
            }
            return null;
        }
        public Pizza? AddPizza(int id, string name)
        {
            foreach (var Pizza in pizzas)
            {
                if (Pizza.Id == id)
                {
                    Pizza.Name = name;
                    _fileService.Update(pizzas);
                    return Pizza;
                }
            }
            return null;
        }
        public void DeleteThePizza(int id)
        {
            var pizza=GetPizzaId(id);
            if(pizza is null)
            return;
            pizzas.Remove(pizza);
          _fileService.Update(pizzas);
        }
        public void UpdatePizza(Pizza pizza)
        {
        pizza.Id=length++;
        if(pizza!=null)
        {
        _fileService.AddItem(pizza);
        pizzas.Add(pizza);
        }
    }
    }