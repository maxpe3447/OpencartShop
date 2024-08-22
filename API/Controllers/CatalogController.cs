using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Storage;
using Api.Storage.Entities;

namespace Api.Controllers
{
    [Route("catalogs")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly AppDbContext appDBContext;

        public CatalogController(
            AppDbContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        #region GET

        [AllowAnonymous]
        [HttpGet()]
        public IQueryable<Category> Categories() => appDBContext.Categories;

        #endregion
        #region Get?id={...}
        // GET /<CatalogController>/catalog/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return appDBContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        #endregion
        #region POST /[action]
        [Authorize]
        [HttpPost()]
        public IActionResult AddCategory([FromBody] Category category)
        {
            appDBContext.Categories.Add(category);
            appDBContext.SaveChanges();
            return Ok(category);
        }
        #endregion
        #region PUT /[action]/{id}?title=<newTitle>

        [Authorize]
        [HttpPut()]
        public IActionResult EditCategory([FromBody] Category category)
        {
            appDBContext.Categories.Update(category);
            appDBContext.SaveChanges();
            return Ok(category);
        }

        #endregion
        #region DELETE /[action]/{id}
        // DELETE api/<CatalogController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            appDBContext.Categories.Remove(new Category { Id = id });
            appDBContext.SaveChanges();

            return Ok();
        }
        #endregion
    }
}
