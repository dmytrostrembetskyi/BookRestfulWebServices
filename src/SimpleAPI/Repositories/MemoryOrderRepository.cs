using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAPI.Models;

namespace SimpleAPI.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {
        public MemoryOrderRepository()
        {
            _orders = new List<Order>();
        }

        private IList<Order> _orders { get; }

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public Order Delete(Guid orderId)
        {
            var target = _orders.First(o => o.Id == orderId);
            target.IsInactive = true;
            Update(orderId, target);
            return target;
        }

        public IEnumerable<Order> Get()
        {
            return _orders.Where(o => !o.IsInactive);
        }

        public Order Get(Guid orderId)
        {
            return _orders
                .Where(o => !o.IsInactive)
                .FirstOrDefault(o => o.Id == orderId);
        }

        public void Update(Guid orderId, Order order)
        {
            var result = _orders.FirstOrDefault(o => o.Id == orderId);

            if (result != null)
                result.ItemsIds = order.ItemsIds;
        }
    }
}