namespace BackofficeClient.Models.Database;

public class Spec
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SpecId { get; set; }

    /// <summary>
    /// Процедура
    /// </summary>
    public string? ProcedureGpb { get; set; }

    /// <summary>
    /// Процедура
    /// </summary>
    public long? ProcedureId { get; set; }

    /// <summary>
    /// Заявка
    /// </summary>
    public string? RequestNum { get; set; }

    /// <summary>
    /// Заявка
    /// </summary>
    public long? RequestId { get; set; }

    /// <summary>
    /// Заказчик
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Заказчик
    /// </summary>
    public long? CustomerId { get; set; }

    /// <summary>
    /// Наименование Договора с Поставщиком
    /// </summary>
    public string? ContractNameCustomer { get; set; }

    /// <summary>
    /// Договор с Поставщиком
    /// </summary>
    public long? ContractIdCustomer { get; set; }

    /// <summary>
    /// Наименование спецификации с Клиентом
    /// </summary>
    public string? SpecNameCustomer { get; set; }

    /// <summary>
    /// Номер спецификации с Клиентом
    /// </summary>
    public string? SpecNumCustomer { get; set; }

    /// <summary>
    /// Дата спецификации с Клиентом
    /// </summary>
    public DateOnly? SpecDateCustomer { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public string? SupName { get; set; }

    public long? SupplierId { get; set; }

    public string? ContractNameSup { get; set; }

    public long? ContractIdSup { get; set; }

    /// <summary>
    /// Наименование спецификации с Поставщиком
    /// </summary>
    public string? SpecNameSup { get; set; }

    /// <summary>
    /// Номер спецификации с Поставщиком
    /// </summary>
    public string? SpecNumSup { get; set; }

    /// <summary>
    /// Дата спецификации с Поставщиком
    /// </summary>
    public DateOnly? SpecDateSup { get; set; }

    /// <summary>
    /// Группа МТР
    /// </summary>
    public string? GroupMtr { get; set; }

    public string? SpecState { get; set; }

    public string? SpecStateFull { get; set; }

    /// <summary>
    /// Процент наценки
    /// </summary>
    public decimal? MarginPercent { get; set; }

    public bool? IsAutoInitSpecNumCustomer { get; set; }

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
    /// Заявка
    /// </summary>
    public long? DealId { get; set; }

    /// <summary>
    /// Дата подачи Заказчику
    /// </summary>
    public DateOnly? DateSendCustomer { get; set; }

    /// <summary>
    /// Дата подачи Поставщику
    /// </summary>
    public DateOnly? DateSendSup { get; set; }

    /// <summary>
    /// Дата подписания Заказчиком
    /// </summary>
    public DateOnly? DateSignCustomer { get; set; }

    /// <summary>
    /// Дата подписания Поставщиком
    /// </summary>
    public DateOnly? DateSignSup { get; set; }

    /// <summary>
    /// Дата подписания всех сторон
    /// </summary>
    public DateOnly? DateSignAll { get; set; }

    /// <summary>
    /// Количество Приложений
    /// </summary>
    public int? AttachmentsCount { get; set; }

    /// <summary>
    /// Толеранс
    /// </summary>
    public string? Tolerance { get; set; }

    public bool? IsAutomaticInit { get; set; }

    public string? Person { get; set; }

    public string? PaymentTerms { get; set; }

    public string? MtrRequirements { get; set; }

    /// <summary>
    /// Статус спецификации с Заказчиком
    /// </summary>
    public string? SpecStateCustomer { get; set; }

    /// <summary>
    /// Статус спецификации с Поставщиком
    /// </summary>
    public string? SpecStateSup { get; set; }

    /// <summary>
    /// Ответственный - логин
    /// </summary>
    public string? PersonLogin { get; set; }

    /// <summary>
    /// Дата последней корректировки
    /// </summary>
    public DateOnly? LastAdjustmentDate { get; set; }

    /// <summary>
    /// Количество корректировок
    /// </summary>
    public int? CountAdjustment { get; set; }

    public virtual Contract? ContractIdCustomerNavigation { get; set; }

    public virtual Contract? ContractIdSupNavigation { get; set; }

    public virtual Procedure? Procedure { get; set; }

    public virtual Request? Request { get; set; }

    public virtual ICollection<SpecAdjustment> SpecAdjustments { get; set; } = new List<SpecAdjustment>();

    public virtual ICollection<SpecComment> SpecComments { get; set; } = new List<SpecComment>();

    public virtual ICollection<SpecPosition> SpecPositions { get; set; } = new List<SpecPosition>();

    public virtual ICollection<SpecSupplier> SpecSuppliers { get; set; } = new List<SpecSupplier>();
}