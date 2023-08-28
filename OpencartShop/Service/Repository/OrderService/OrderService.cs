﻿using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly AppDBContext _dbContext;
        public OrderService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public void AddOrder(Order order) => _dbContext.Orders.Add(order);

        public bool CancelOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (order is null)
            {
                return false;
            }

            order.IsCancel = true;
            _dbContext.SaveChanges();

            return true;
        }

        public IQueryable<Order> GetAll() => _dbContext.Orders;

        public IQueryable<Order> GetAllByUserId(int id)
        {
            return _dbContext.Customers.Include(c=>c.Orders)
                                                    !.ThenInclude(x=>x.OrderItems)
                                                        !.ThenInclude(o=>o.Product)
                                               .FirstOrDefault(c => c.Id == id)
                                               ?.Orders
                                               ?.AsQueryable() ?? 
                   Enumerable.Empty<Order>().AsQueryable();
        }

        public Order GetOrderById(int id) 
            => _dbContext.Orders.FirstOrDefault(x => x.Id == id) ?? new();
    }
}
