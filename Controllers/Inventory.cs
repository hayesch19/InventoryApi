using System.Collections.Generic;
using System.Linq;
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

    // Create Item (POST)
    [HttpPost]
    public ActionResult<Item> CreateItem([FromBody]Item entry)
    {
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;
    }

    // Get All Items (GET)
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAllItems()
    {
      var items = context.Items.OrderByDescending(item => item.DateOrdered);
      return items.ToList();
    }

    // Get Each Item (GET)
    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var item = context.Items.FirstOrDefault(i => i.ID == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }
    // Update Item (PUT)
    [HttpPut("{id}")]

    public ActionResult<Item> UpdateItem([FromBody]Item entry, int id)
    {
      var itemToUpdate = context.Items.FirstOrDefault(item => item.ID == id);
      context.Items.Update(itemToUpdate);
      context.SaveChanges();
      return itemToUpdate;
    }

    // Delete Item (DELETE)

    // Select Out Of Stock Items (GET)

    // Select Items By SKU (GET)
  }
}