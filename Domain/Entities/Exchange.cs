using Domain.Enums;

namespace Domain.Entities;

public class Exchange
{
    public int ExchangeId { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string Country { get; set; }
    public ExchangeTypes ExchangeType { get; set; }
}