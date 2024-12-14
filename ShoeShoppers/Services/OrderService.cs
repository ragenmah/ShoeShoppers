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


        public int AddOrder(Order order)
        {
            
            int orderId = _repository.AddOrder(order);
            return orderId;
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAllOrders();
        }

           public Order GetOrderDetailsById(int orderId, int userId)
        {
            return _repository.GetOrderDetailsById( orderId,  userId);
        }

        public List<Order> GetAllOrderByUserId( int userId)
        {
            return _repository.GetAllOrderByUserId( userId);
        }

        public void DeleteOrder(int orderId)
        {
            _repository.DeleteOrder(orderId);
        }
        public void CancelOrder(int orderId)
        {
            _repository.CancelOrder(orderId);
        } 
        public void ReOrder(int orderId)
        {
            _repository.ReOrder(orderId);
        }
    }
}