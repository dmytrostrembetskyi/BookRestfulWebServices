using System;
using System.Collections.Generic;
using SimpleAPI.Models;

namespace SimpleAPI.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();
        Order GetOrder(Guid orderId);
        void Add(Order order);
        void Update(Guid orderId, Order order);
        Order Delete(Guid orderId);
    }
}
