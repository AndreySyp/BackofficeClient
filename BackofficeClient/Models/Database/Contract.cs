namespace BackofficeClient.Models.Database;

public class Contract
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long ContractId { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string? ContractName { get; set; }

    /// <summary>
    /// Номер Контракта
    /// </summary>
    public string ContractNum { get; set; } = null!;

    /// <summary>
    /// Дата Контракта
    /// </summary>
    public DateOnly ContractDate { get; set; }

    /// <summary>
    /// Тип Контракта
    /// </summary>
    public string? ContractType { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public long? CustomerId { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public string? SupName { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public long? SupplierId { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Дата и время последнего изменения
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public string ContractDoc { get; set; } = null!;

    /// <summary>
    /// Предмет
    /// </summary>
    public string? ContractSubject { get; set; }

    /// <summary>
    /// Вышестоящий договор
    /// </summary>
    public long? ContractIdParent { get; set; }

    /// <summary>
    /// Агентский договор
    /// </summary>
    public bool IsAgent { get; set; }

    public long? SourceNum { get; set; }

    public long? SourceNumParent { get; set; }

    public virtual ICollection<ContractState> ContractStates { get; set; } = new List<ContractState>();

    public virtual ICollection<Spec> SpecContractIdCustomerNavigations { get; set; } = new List<Spec>();

    public virtual ICollection<Spec> SpecContractIdSupNavigations { get; set; } = new List<Spec>();
}
