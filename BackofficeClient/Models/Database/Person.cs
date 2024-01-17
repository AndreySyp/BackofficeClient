namespace BackofficeClient.Models.Database;

public class Person
{
    public long PersonId { get; set; }

    public string LoginText { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Lastname { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Является Закупщиком (могут ли на него назначаться закупка Позиций МТР)
    /// </summary>
    public bool IsCustomer { get; set; }

    public string? Manager { get; set; }

    public bool IsForwarder { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsContractDept { get; set; }

    public bool IsReadonly { get; set; }

    public virtual ICollection<SqlLog> SqlLogs { get; set; } = new List<SqlLog>();

    public virtual ICollection<SupChangeAction> SupChangeActions { get; set; } = new List<SupChangeAction>();

    public virtual ICollection<SupColumnUser> SupColumnUsers { get; set; } = new List<SupColumnUser>();
}