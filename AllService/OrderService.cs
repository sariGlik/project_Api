using System;
using AllModels;
using AllModels.Interfaces;
using FileServices;

namespace AllService;

    public class OrderService:IOrder
    {
        private static readonly List<Order> orders = new List<Order>()
        { };
  
        public DateTime createDate { get; set; }
           
        public void AddPizzaToOrder(Order order)
        {
          orders.Add(new Order() {CustomerId=order.CustomerId,Date=order.Date,TotalAmount=order.TotalAmount});   
        }
    }
