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
      itemToUpdate.SKU = entry.SKU;
      itemToUpdate.Name = entry.Name;
      itemToUpdate.ShortDescription = entry.ShortDescription;
      itemToUpdate.NumberInStock = entry.NumberInStock;
      itemToUpdate.Price = entry.Price;
      itemToUpdate.DateOrdered = entry.DateOrdered;
      context.SaveChanges();
      return itemToUpdate;
    }

    // Delete Item (DELETE)
    [HttpDelete("{id}")]
    public ActionResult<Item> DeleteEntry([FromBody]Item entry, int id)

    {
      var itemToDelete = context.Items.FirstOrDefault(item => item.ID == id);
      context.Items.Remove(itemToDelete);
      context.SaveChanges();
      return itemToDelete;
    }

    // Select Out Of Stock Items (GET)
    [HttpGet("outofstock")]
    public ActionResult GetSOItem()
    {
      var item = context.Items.Where(i => i.NumberInStock == 0);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }

    // Select Items By SKU (GET)
    [HttpGet("sku/{SKU}")]
    public ActionResult GetItemSKU(int SKU)
    {
      var item = context.Items.FirstOrDefault(i => i.SKU == SKU);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }

    }
  }
}