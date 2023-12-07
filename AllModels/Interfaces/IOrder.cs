

namespace AllModels.Interfaces;

    public interface IOrder
    {
        public DateTime createDate { get; set; }
        public void AddPizzaToOrder(Order order);
    }

