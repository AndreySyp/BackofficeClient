namespace BackofficeClient.Models.Database;

public class TradeSign
{
    public int TradeSignId { get; set; }

    public string TradeSign1 { get; set; } = null!;

    public string? TradeSignName { get; set; }

    public string? TradeSignFullname { get; set; }

    public string? TradeSignNote { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<SupplyPosition> SupplyPositions { get; set; } = new List<SupplyPosition>();
}