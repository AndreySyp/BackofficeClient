namespace BackofficeClient.Models.Database;

/// <summary>
/// Данные по Поставщикам
/// </summary>
public class Supplier
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SupplierId { get; set; }

    /// <summary>
    /// Краткое наименование Поставщика
    /// </summary>
    public string? Supplier1 { get; set; }

    /// <summary>
    /// Полное наименование Поставщика
    /// </summary>
    public string? SupplierFullname { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? Inn { get; set; }

    /// <summary>
    /// КПП
    /// </summary>
    public string? Kpp { get; set; }

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

    public string? Email { get; set; }

    /// <summary>
    /// UUID из Процессора
    /// </summary>
    public Guid? ProcUuid { get; set; }

    /// <summary>
    /// ФИО внесшего изменения
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Дата и время последнего обновления
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public bool? IsAutomaticInit { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Принадлежность поставщика
    /// </summary>
    public string? Affiliation { get; set; }

    /// <summary>
    /// Краткое ОПФ
    /// </summary>
    public string? OpfShort { get; set; }

    /// <summary>
    /// Полное ОПФ
    /// </summary>
    public string? OpfFull { get; set; }

    /// <summary>
    /// Краткое наименование без ОПФ
    /// </summary>
    public string? SupplierNoOpf { get; set; }

    /// <summary>
    /// Наименование для отчета
    /// </summary>
    public string? SupplierNameReport { get; set; }

    /// <summary>
    /// Иностранный поставщик (признак отстутствия ИНН, КПП и ОГРН в РФ)
    /// </summary>
    public bool IsForeignSupplier { get; set; }

    /// <summary>
    /// Создано
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Логин
    /// </summary>
    public string? CreatedBy { get; set; }
}
