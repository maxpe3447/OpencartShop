using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.OrderService
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        IQueryable<Order> GetAll();
        IQueryable<Order> GetAllByUserId(int id);
        Order GetOrderById(int id);
        bool CancelOrder(int id);
    }
}
