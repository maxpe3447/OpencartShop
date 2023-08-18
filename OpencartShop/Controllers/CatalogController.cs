using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.Catalog;
using System.Linq.Expressions;

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

        [Route("[action]")]
        [HttpGet]
        public IQueryable<Catalog> Catalogs()
        {
            return _catalogManager.GetAll<Catalog>();
        }
        [Route("[action]")]
        [HttpGet]
        public IQueryable<Category> Categories()
        {
            return _catalogManager.GetAll<Category>();
        }
        [Route("[action]")]
        [HttpGet]
        public IQueryable<SubCatalog> SubCatalogs()
        {
            return _catalogManager.GetAll<SubCatalog>();
        }
        #endregion
        #region Get?id={...}
        // GET /<CatalogController>/catalog?id=5
        [Route("[action]")]
        [HttpGet]
        public Catalog GetCatalog(int id)
        {
            return _catalogManager.GetById<Catalog>(id) as Catalog ?? new Catalog();
        }
        [Route("[action]")]
        [HttpGet]
        public Category GetCategory(int id)
        {
            return _catalogManager.GetById<Category>(id) as Category ?? new Category();
        }
        [Route("[action]")]
        [HttpGet]
        public SubCatalog GetSubCatalog(int id)
        {
            return _catalogManager.GetById<SubCatalog>(id) as SubCatalog ?? new SubCatalog();
        }

        #endregion
        #region POST /[action]?title=<title>
        // POST <CatalogController>
        [Route("[action]")]
        [HttpPost]
        public IResult AddCatalog(string title)
        {
            try
            {
                _catalogManager.Save(new Catalog { Title = title });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.Ok();
        }
        public IResult AddCategory(string title)
        {
            try
            {
                _catalogManager.Save(new Category { Title = title });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.Ok();
        }
        public IResult AddSubCatalog(string title)
        {
            try
            {
                _catalogManager.Save(new SubCatalog { Title = title });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.Ok();
        }
        #endregion
        #region PUT /[action]/{id}?title=<newTitle>
        // PUT api/<CatalogController>/5?title=<newTitle>
        [HttpPut("[action]/{id}")]
        public IResult EditCatalog(int id, string title)
        {
            try
            {
                _catalogManager.Save(new Catalog { Title = title, Id = id });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        // PUT api/<CatalogController>/5?title=<newTitle>
        [HttpPut("[action]/{id}")]
        public IResult EditCategory(int id, string title)
        {
            try
            {
                _catalogManager.Save(new Category { Title = title, Id = id });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
        // PUT api/<CatalogController>/5?title=<newTitle>
        [HttpPut("[action]/{id}")]
        public IResult EditSubCatalog(int id, string title)
        {
            try
            {
                _catalogManager.Save(new SubCatalog { Title = title, Id = id });
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
        [HttpDelete("[action]/{id}")]
        public IResult DeleteCatalog(int id)
        {
            try
            {
                _catalogManager.Delete<Catalog>(id );
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            return Results.Ok();
        }
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
