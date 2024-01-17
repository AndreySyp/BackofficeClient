namespace BackofficeClient.Models.Database;

public class Bidder
{
    public long BidderId { get; set; }

    public string BidderName { get; set; } = null!;

    public long? ProcedureId { get; set; }

    public string? ProcedureGpb { get; set; }

    public DateTime? UpdateOnRegistry { get; set; }

    public DateTime? UpdateOnReport2022 { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Email { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Inn { get; set; }

    public string? Kpp { get; set; }

    public string? BidderFullname { get; set; }

    /// <summary>
    /// ОГРН
    /// </summary>
    public string? Ogrn { get; set; }

    /// <summary>
    /// Должность руководителя
    /// </summary>
    public string? BossPost { get; set; }

    /// <summary>
    /// ФИО Руководителя
    /// </summary>
    public string? BossFio { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Принадлежность поставщика
    /// </summary>
    public string? Affiliation { get; set; }

    /// <summary>
    /// Связанное значение поставщика. Устанавливается после загрузки ТКП в import.supplier_tkp_table_apply
    /// </summary>
    public long? SupplierId { get; set; }

    public virtual Procedure? Procedure { get; set; }
}