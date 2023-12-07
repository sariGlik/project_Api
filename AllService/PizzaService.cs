using AllModels;
using AllModels.Interfaces;
using FileServices;
using System.Text.Json;
namespace AllService;

    public class PizzaService:IPizza
    {
    private IFile  _fileService {get; set;}
        static int length=3;
      private static readonly List<Pizza> pizzas = new List<Pizza>()
    {
     new Pizza() { Id=1,Name="Pizza1",IsGluten=true},
     new Pizza() { Id=2,Name="Pizza2",IsGluten=false}
    };
      public PizzaService(IFile fileService)
            {
              _fileService=fileService;
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
                    return Pizza;
                }
            }
            return null;
        }
        public void DeleteThePizza(int id)
        {
            foreach (var Pizza in pizzas)
            {
               if (Pizza.Id == id)
               {
               pizzas.Remove(Pizza);
               }
            }
        }
        public List<Pizza> UpdatePizza(Pizza pizza)
        {
        pizza.Id=length++;
          pizzas.Add(pizza);
            return pizzas;
        }
    }
