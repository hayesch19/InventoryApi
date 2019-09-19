using System;
using System.Collections.Generic;

namespace InventoryApi.Models
{
  public class Item
  {
    public int ID { get; set; }
    public int SKU { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public int NumberInStock { get; set; }
    public int Price { get; set; }
    public DateTime DateOrdered { get; set; }


    public List<Locations> Location { get; set; } = new List<Locations>();

  }
}
