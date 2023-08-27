using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.FavoriteProductsService;
using OpencartShop.Service.Repository.Products.ProductColors;
using OpencartShop.Service.Repository.Products.ProductService;
using OpencartShop.Service.Repository.Products.ProductSizes;
using OpencartShop.Service.UserDataService;
using System.Drawing;

namespace OpencartShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductColorsService _productColorsService;
        private readonly IProductSizesService _productSizesService;
        private readonly IProductService _productService;
        private readonly IFavoriteProductService _favoriteProductService;
        private readonly IUserDataService _userDataService;
        public ProductController(IProductColorsService productColorsService,
                                 IProductSizesService productSizesService,
                                 IProductService productService,
                                 IFavoriteProductService favoriteProductService,
                                 IUserDataService userDataService)
        {
            _productColorsService = productColorsService;
            _productSizesService = productSizesService;
            _productService = productService;
            _favoriteProductService = favoriteProductService;
            _userDataService = userDataService;
        }
        #region GET
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IQueryable<Domain.Entities.Color> GetAllColors() => _productColorsService.GetAllColors();
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IQueryable<ProductSize> GetAllSizes() => _productSizesService.GetAllSizes();
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IEnumerable<Product> GetAllProducts()
        {
            var pr = _productService.GetAllProducts().ToList();
            return pr;
        }


        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public Domain.Entities.Color GetColor(int id) => _productColorsService.GetColorById(id)!;
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public ProductSize GetSize(int id) => _productSizesService.GetSizeById(id)!;
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public IQueryable<ProductSize> GetSizesByProductId(int id) 
            => _productSizesService.GetSizesByProductId(id);
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public Product GetProductById(int id) => _productService.GetProductById(id)!;
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public IQueryable<Product> GetProductsByCategoryId(int id)
            => _productService.GetAllProductsByCategoryId(id);


        [Authorize]
        [HttpGet("[action]/{id}")]
        public IResult GetCountFavoriteProducts(int id)
            => Results.Json(new
            {
                Id = _favoriteProductService.GetFavoriteCountByProduct(id)
            });

        [Authorize]
        [HttpGet("[action]")]
        public IQueryable<FavoriteProduct> GetMyFavoriteProducts()
            => _favoriteProductService.GetProductsByUser(_userDataService.GetUserId());
        #endregion
        #region POST
        [Authorize]
        [HttpPost("[action]")]
        public IResult AddNewColor([FromBody] Domain.Entities.Color color)
        {
            _productColorsService.AddColors(color);
            return Results.Ok();
        }
        [Authorize]
        [HttpPost("[action]")]
        public IResult AddNewSize([FromBody] ProductSize size)
        {
            _productSizesService.AddSize(size);
            return Results.Ok();
        }
        [Authorize]
        [HttpPost("[action]")]
        public IResult AddNewProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Results.Ok();
        }
        [Authorize]
        [HttpPost("[action]")]
        public IResult BindColor([FromBody] ProductColor productColor)
        {
            _productColorsService.Bind(productColor.ColorsId, productColor.ProductId);
            return Results.Ok();
        }


        [Authorize]
        [HttpPost("[action]")]
        public IResult AddNewFavoriteProducts([FromBody] FavoriteProduct favoriteProduct)
        {
            favoriteProduct.CustomerId = _userDataService.GetUserId();
            _favoriteProductService.AddNewFavoriteProduct(favoriteProduct);
            return Results.Ok();
        }
        #endregion
        #region PUT
        [Authorize]
        [HttpPut("[action]")]
        public IResult EditColor([FromBody] Domain.Entities.Color color)
        {
            _productColorsService.EditColors(color);
            return Results.Ok();
        }
        [Authorize]
        [HttpPut("[action]")]
        public IResult EditSize([FromBody] ProductSize size)
        {
            _productSizesService.EditSize(size);
            return Results.Ok();
        }
        [Authorize]
        [HttpPut("[action]")]
        public IResult EditProduct([FromBody] Product product)
        {
            _productService.EditProduct(product);
            return Results.Ok();
        }
        #endregion
        #region DELETE
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteColor(int id)
        {
            _productColorsService.DeleteColorById(id);
            return Results.Ok();
        }
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteSize(int id)
        {
            _productSizesService.DeleteSizeById(id);
            return Results.Ok();
        }
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteProduct(int id)
        {
            _productService.DeleteProductById(id);
            return Results.Ok();
        }
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteBindColor(int id)
        {
            _productColorsService.RemoveBind(id);
            return Results.Ok();
        }

        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteFavoriteProduct(int id)
        {
            _favoriteProductService.DeleteFavoriteProduct(id);
            return Results.Ok();
        }
        #endregion
    }
}
