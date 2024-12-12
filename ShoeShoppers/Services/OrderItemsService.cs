using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class OrderItemsService
    {
        private readonly OrderItemRepository _repository;

        public OrderItemsService(OrderItemRepository orderItemRepository)
        {
            _repository = orderItemRepository;
        }

        public void AddOrderItems(OrderItem orderItem)
        {
            _repository.AddOrderItems(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _repository.UpdateOrderItem(orderItem);
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            return _repository.GetOrderItems(orderId);
        }

        public void DeleteOrderItem(int orderItemId)
        {
            _repository.DeleteOrderItem(orderItemId);
        }
    }
}