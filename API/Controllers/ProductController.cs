using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Storage;
using Api.Storage.Entities;
using Api.Helpers;
using Api.Service.Repository.Products.ProductService;

namespace Api.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly AppDbContext _appDBContext;

        public ProductController(IProductService productService, AppDbContext appDBContext)
        {
            _productService = productService;
            _appDBContext = appDBContext;
        }
        #region GET

        [AllowAnonymous]
        [HttpGet()]
        public ActionResult GetAllProducts([FromQuery] PaginationQuery query)
        {

            return Ok(_appDBContext.Products.Include(x=>x.Category).Include(x=>x.Images).AsPagination(query));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public Product GetProductById(int id) => _productService.GetProductById(id)!;
        [AllowAnonymous]
        [HttpGet("by-category/{id}")]
        public IQueryable<Product> GetProductsByCategoryId(int id)
            => _productService.GetAllProductsByCategoryId(id);
        #endregion
        #region POST
        [Authorize]
        [HttpPost()]
        public IResult AddNewProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Results.Ok();
        }

        #endregion
        #region PUT

        [Authorize]
        [HttpPut()]
        public IResult EditProduct([FromBody] Product product)
        {
            _productService.EditProduct(product);
            return Results.Ok();
        }
        #endregion
        #region DELETE

        [Authorize]
        [HttpDelete("{id}")]
        public IResult DeleteProduct(int id)
        {
            _productService.DeleteProductById(id);
            return Results.Ok();
        }
        #endregion
    }
}
