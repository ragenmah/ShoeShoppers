using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class OrderService
    {
        private readonly OrderRepository _repository;

        public OrderService(OrderRepository orderRepository)
        {
            _repository = orderRepository;
        }


        public void AddOrder(Order order)
        {
            _repository.AddOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAllOrders();
        }


       
        public void DeleteOrder(int orderId)
        {
            _repository.DeleteOrder(orderId);
        }
    }
}