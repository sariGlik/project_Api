
namespace AllModels.Interfaces;

    public interface IPizza
    {
        List<Pizza> GetPizza();
        Pizza? GetPizzaId(int id);
         Pizza?  AddPizza(int id,string name);
         void DeleteThePizza(int id);
         void UpdatePizza(Pizza pizza);

    }

