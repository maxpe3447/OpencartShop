using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Storage;
using Api.Storage.Entities;
using Api.Helpers;
using Api.Service.Repository.OrderService;
using Api.Service.Repository.ReturnProductService;
using Api.Service.UserDataService;

namespace Api.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly AppDbContext appDBContext;
        private readonly IReturnProductService _returnProductService;
        private readonly IUserDataService _userDataService;
        public OrderController(IOrderService orderService,
            AppDbContext appDBContext,
                               IReturnProductService returnProductService,
                               IUserDataService userDataService)
        {
            _orderService = orderService;
            this.appDBContext = appDBContext;
            _returnProductService = returnProductService;
            _userDataService = userDataService;
        }

        #region GET
        [Authorize]
        [HttpGet()]
        public ActionResult GetAllOrder([FromQuery] PaginationQuery query) => Ok(appDBContext.Orders.AsPagination(query));

        [Authorize]
        [HttpGet("by-customer/{id?}")]
        public IQueryable<Order> GetOrderByCustomerId(int? id)
            => _orderService.GetAllByUserId(id ?? _userDataService.GetUserId());

        [Authorize]
        [HttpGet("{id}")]
        public Order GetOrderById(int id) => _orderService.GetOrderById(id);

        [Authorize]
        [HttpGet("[action]")]
        public IQueryable<ReturnProduct> GetAllReturnProducts() => _returnProductService.GetAll();

        [Authorize]
        [HttpGet("[action]/{id}")]
        public ReturnProduct GetReturnProductByOrderId(int id) => _returnProductService.GetByOrderId(id);

        [Authorize]
        [HttpGet("by-phone-or-email/{data}")]
        public ReturnProduct GetByPhoneEmail(string data) => _returnProductService.GetByPhoneEmail(data);


        #endregion
        #region POST
        [Authorize]
        [HttpPost]
        public void AddOrder([FromBody] Order order) => _orderService.AddOrder(order);

        //[Authorize]
        //[HttpPost("[action]")]
        //public void AddReturnProduct([FromBody] ReturnProduct returnProduct) => _returnProductService.Add(returnProduct);

        #endregion

        #region PUT
        [Authorize]
        [HttpPut("{id}/cancel")]
        public IResult CancelOrder(int id) => _orderService.CancelOrder(id)
                                              ? Results.Ok()
                                              : Results.Problem();

        [Authorize]
        [HttpPut("{id}/cancel-return-order")]
        public void CancelReturnOrder(int id) => _returnProductService.Cancel(id);
        #endregion
    }
}
