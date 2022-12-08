using Domain.Enums;

namespace Domain.Entities;

public class Order
{
    public int OrderId { get; set; }
    public string Direction { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public OrderTypes OrderType { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public User User { get; set; }
    public Asset Asset { get; set; }
}