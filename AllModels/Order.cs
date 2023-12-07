﻿
namespace AllModels;

    public class Order
    {
        public string? CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Pizza> Items { get; set; }

        public Order()
        {
          Items = new List<Pizza>();
        }
    }
