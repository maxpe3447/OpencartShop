using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.Catalog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpencartShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;
        public CatalogController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }
        #region GET
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IQueryable<Catalog> Catalogs() => _catalogManager.GetAll<Catalog>();

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IQueryable<Category> Categories() => _catalogManager.GetAll<Category>();

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IQueryable<SubCatalog> SubCatalogs() => _catalogManager.GetAll<SubCatalog>();

        #endregion
        #region Get?id={...}
        // GET /<CatalogController>/catalog/5
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public Catalog GetCatalog(int id)
        {
            return _catalogManager.GetById<Catalog>(id) as Catalog ?? new Catalog();
        }
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public Category GetCategory(int id)
        {
            return _catalogManager.GetById<Category>(id) as Category ?? new Category();
        }
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public SubCatalog GetSubCatalog(int id)
        {
            return _catalogManager.GetById<SubCatalog>(id) as SubCatalog ?? new SubCatalog();
        }

        #endregion
        #region POST /[action]
        // POST <CatalogController>
        [Authorize]
        [HttpPost("[action]")]
        public IResult AddCatalog([FromBody] Catalog catalog)
        {
            try
            {
                _catalogManager.Save(catalog);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.Ok();
        }
        [Authorize]
        [HttpPost("[action]")]
        public IResult AddCategory([FromBody] Category category)
        {
            try
            {
                _catalogManager.Save(category);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.Ok();
        }
        [Authorize]
        [HttpPost("[action]")]
        public IResult AddSubCatalog([FromBody] SubCatalog subCatalog)
        {
            try
            {
                _catalogManager.Save(subCatalog);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.Ok();
        }
        #endregion
        #region PUT /[action]/{id}?title=<newTitle>
        // PUT api/<CatalogController>
        [Authorize]
        [HttpPut("[action]")]
        public IResult EditCatalog([FromBody] Catalog catalog)
        {
            try
            {
                _catalogManager.Save(catalog);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        [Authorize]
        [HttpPut("[action]")]
        public IResult EditCategory([FromBody] Category category)
        {
            try
            {
                _catalogManager.Save(category);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        [Authorize]
        [HttpPut("[action]")]
        public IResult EditSubCatalog([FromBody] SubCatalog catalog)
        {
            try
            {
                _catalogManager.Save(catalog);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        #endregion
        #region DELETE /[action]/{id}
        // DELETE api/<CatalogController>/5
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteCatalog(int id)
        {
            try
            {
                _catalogManager.Delete<Catalog>(id);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteCategory(int id)
        {
            try
            {
                _catalogManager.Delete<Category>(id);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        [Authorize]
        [HttpDelete("[action]/{id}")]
        public IResult DeleteSubCatalog(int id)
        {
            try
            {
                _catalogManager.Delete<SubCatalog>(id);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        #endregion
    }
}
