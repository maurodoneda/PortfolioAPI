using Domain.Enums;

namespace Domain.Entities;

public class OrderUpdate
{
    public int OrderId { get; set; }
    public string Direction { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public OrderTypes OrderType { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string OrderStatus { get; set; }
    public User User { get; set; }
    public Asset Asset { get; set; }
}