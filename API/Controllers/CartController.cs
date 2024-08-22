using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Storage;
using Api.Storage.Entities;
using Api.Service.UserDataService;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("cart")]
public class CartController : ControllerBase
{
    private readonly AppDbContext appDBContext;
    private readonly IUserDataService userDataService;

    public CartController(
        AppDbContext appDBContext,
        IUserDataService userDataService)
    {
        this.appDBContext = appDBContext;
        this.userDataService = userDataService;
    }

    [HttpGet]
    public ActionResult GetCart()
    {
        var items = appDBContext.CartItems
            .Include(x => x.Products)
            .Where(x => x.UserId == userDataService.GetUserId());
        return Ok(items);
    }

    [HttpPost]
    public ActionResult AddItem([FromBody] Item item)
    {
        var cart = new CartItem
        {
            CreateTime = DateTime.UtcNow,
            ProductsId = item.ProductsId,
            Quantity = item.Quantity,
            UserId = userDataService.GetUserId(),
        };

        appDBContext.CartItems.Add(cart);
        appDBContext.SaveChanges();

        return Ok();
    }

    [HttpPut("increment/{id}")]
    public ActionResult Increment(int id)
    {
        var item = appDBContext.CartItems.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return BadRequest();
        }

        item.Quantity++;
        appDBContext.SaveChanges();

        return Ok(item);
    }

    [HttpPut("decrement/{id}")]
    public ActionResult Decrement(int id)
    {
        var item = appDBContext.CartItems.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        if (item == null || item.Quantity == 1)
        {
            return BadRequest();
        }
        item.Quantity--;
        appDBContext.SaveChanges();

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var item = appDBContext.CartItems.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return BadRequest();
        }
        appDBContext.Remove(item);
        appDBContext.SaveChanges();

        return Ok();
    }
}

public class Item
{
    public int Quantity { get; set; } = 1;
    public int ProductsId { get; set; }
}