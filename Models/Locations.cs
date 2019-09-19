namespace InventoryApi.Models
{
  public class Locations
  {
    public int ID { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public int PhoneNumber { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

  }
}