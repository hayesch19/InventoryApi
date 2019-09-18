using inventoryapi;
using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {
    private DatabaseContext context;

    public InventoryController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpPost]
    public ActionResult<Item> CreateItem([FromBody]Item entry)
    {
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;
    }
  }
}