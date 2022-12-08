using Domain.Enums;

namespace Domain.Entities;

public class Trade
{
    public int TradeId { get; set; }
    public decimal ExecutionPrice { get; set; }
    public decimal ExecutedQuantity { get; set; }
    public TradeSide TradeSide { get; set; }
    public ExecutionType ExecutionType { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public Settlement Settlement { get; set; }
    public Order Order { get; set; }
}