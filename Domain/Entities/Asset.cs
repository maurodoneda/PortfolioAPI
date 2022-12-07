using Domain.Enums;

namespace Domain.Entities;

public class Asset
{
    public int AssetId { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public int DecimalPrecision { get; set; }
    public AssetTypes AssetType { get; set; }
}