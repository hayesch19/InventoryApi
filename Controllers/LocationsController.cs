using System.Collections.Generic;
using System.Linq;
using inventoryapi;
using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private DatabaseContext context;

    public LocationsController(DatabaseContext _context)
    {
      this.context = _context;
    }

    // Create Location (POST)
    [HttpPost]
    public ActionResult<Locations> CreateItem([FromBody]Locations entry)
    {
      context.Location.Add(entry);
      context.SaveChanges();
      return entry;
    }

    // Get All Locations (GET)
    [HttpGet]
    public ActionResult<IEnumerable<Locations>> GetAllItems()
    {
      var location = context.Location.OrderByDescending(locations => locations.ID);
      return location.ToList();
    }
  }
}