using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.OrderService;

namespace OpencartShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #region GET
        [Authorize]
        [HttpGet("[action]")]
        public IQueryable<Order> GetAllOrder() => _orderService.GetAll();

        [Authorize]
        [HttpGet("[action]/{id?}")]
        public IQueryable<Order> GetOrderByCustomerId(int? id)
            => _orderService.GetAllByUserId(id ?? int.Parse(HttpContext.User
                                                             .Identities
                                                             .FirstOrDefault()
                                                             ?.Claims.FirstOrDefault(x=>x.Type == "userId")?.Value ??"0"));

        [Authorize]
        [HttpGet("[action]/{id}")]
        public Order GetOrderById(int id) => _orderService.GetOrderById(id);

        [Authorize]
        [HttpGet("[action]/{id}")]
        public IResult CancelOrder(int id) => _orderService.CancelOrder(id) 
                                              ? Results.Ok()
                                              : Results.Problem();
        #endregion
        #region POST
        [Authorize]
        [HttpPost("[action]")]
        public void AddOrder([FromBody] Order order) => _orderService.AddOrder(order);
        #endregion
    }
}
