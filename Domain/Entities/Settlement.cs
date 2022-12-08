using Domain.Enums;

namespace Domain.Entities;

public class Settlement
{
    public int SettlementId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Adjustment { get; set; }
    public decimal TradingFee { get; set; }
    public decimal CustodyFee { get; set; }
    public decimal Tax { get; set; }
    public TransactionType TransactionType { get; set; }
    public Asset Asset { get; set; }
    public User User { get; set; }
}