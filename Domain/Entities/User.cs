namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Settlement> Settlements { get; set; }
    public ICollection<OrderUpdate> OrderUpdates { get; set; }
}