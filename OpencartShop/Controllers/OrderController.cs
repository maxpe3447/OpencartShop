using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.OrderService;
using OpencartShop.Service.Repository.ReturnProductService;
using OpencartShop.Service.UserDataService;

namespace OpencartShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IReturnProductService _returnProductService;
        private readonly IUserDataService _userDataService;
        public OrderController(IOrderService orderService,
                               IReturnProductService returnProductService,
                               IUserDataService userDataService)
        {
            _orderService = orderService;
            _returnProductService = returnProductService;
            _userDataService = userDataService;
        }

        #region GET
        [Authorize]
        [HttpGet("[action]")]
        public IQueryable<Order> GetAllOrder() => _orderService.GetAll();

        [Authorize]
        [HttpGet("[action]/{id?}")]
        public IQueryable<Order> GetOrderByCustomerId(int? id)
            => _orderService.GetAllByUserId(id ?? _userDataService.GetUserId());

        [Authorize]
        [HttpGet("[action]/{id}")]
        public Order GetOrderById(int id) => _orderService.GetOrderById(id);

        [Authorize]
        [HttpGet("[action]/{id}")]
        public IResult CancelOrder(int id) => _orderService.CancelOrder(id) 
                                              ? Results.Ok()
                                              : Results.Problem();

        [Authorize]
        [HttpGet("[action]")]
        public IQueryable<ReturnProduct> GetAllReturnProducts() => _returnProductService.GetAll();

        [Authorize]
        [HttpGet("[action]/{id}")]
        public ReturnProduct GetReturnProductByOrderId(int id) => _returnProductService.GetByOrderId(id);

        [Authorize]
        [HttpGet("[action]")]
        public ReturnProduct GetByPhoneEmail(string phoneEmail) => _returnProductService.GetByPhoneEmail(phoneEmail);


        #endregion
        #region POST
        [Authorize]
        [HttpPost("[action]")]
        public void AddOrder([FromBody] Order order) => _orderService.AddOrder(order);

        [Authorize]
        [HttpPost("[action]")]
        public void AddReturnProduct([FromBody] ReturnProduct returnProduct) => _returnProductService.Add(returnProduct);

        #endregion

        #region PUT
        [Authorize]
        [HttpPut("[action]/{id}")]
        public void CancelReturnOrder(int id) => _returnProductService.Cancel(id);
        #endregion
    }
}
