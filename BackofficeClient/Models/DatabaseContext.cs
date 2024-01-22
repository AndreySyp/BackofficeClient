using BackofficeClient.Models.Database;
using BackofficeClient.Models.Database.Views;
using Microsoft.EntityFrameworkCore;

namespace BackofficeClient;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VRequestForm> VRequestForms { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<VPosition> VPositions { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<TradeSign> TradeSigns { get; set; }

#if DEBUG
    private static readonly string str = "Server=localhost; Port=5432; User Id=postgres; Database=request_report; ApplicationName = 'BackOfficeDBClient'; Password=1111; User Id= asamoilov; ";
#else
    private static readonly string str = "Server=192.168.201.15; Port=5432; Database=base_1; ApplicationName = 'BackOfficeDBClient';  Password=1111; Pooling=false; Timeout=15; CommandTimeout=300; User Id= asamoilov; ";
#endif

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(str);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<VPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_position", "src");

            entity.Property(e => e.ExchangeRate).HasColumnName("exchange_rate");
            entity.Property(e => e.PositionId).HasColumnName("ID");
            entity.Property(e => e.IncPriceCur).HasColumnName("inc_price_cur");
            entity.Property(e => e.IncPriceCurNds).HasColumnName("inc_price_cur_nds");
            entity.Property(e => e.OutPrice).HasColumnName("out_price");
            entity.Property(e => e.OutPriceCur).HasColumnName("out_price_cur");
            entity.Property(e => e.OutPriceCurNds).HasColumnName("out_price_cur_nds");
            entity.Property(e => e.OutPriceNds).HasColumnName("out_price_nds");
            entity.Property(e => e.Basis).HasColumnName("Базис поставки");
            entity.Property(e => e.IncPrice).HasColumnName("Вх. стоимость товара без НДС, руб.");
            entity.Property(e => e.IncPriceNds)
                .HasPrecision(20, 2)
                .HasColumnName("Вх. стоимость товара с НДС, руб.");
            entity.Property(e => e.GroupMtr).HasColumnName("Группа МТР");
            entity.Property(e => e.DateCustomerQuery).HasColumnName("Дата запроса в адрес Заказчика ТТ");
            entity.Property(e => e.DateAgreement).HasColumnName("Дата отправки Заказчику на согл-е");
            entity.Property(e => e.DateDocs).HasColumnName("Дата получения от Заказчика ТТ/ТУ");
            entity.Property(e => e.DateAs).HasColumnName("Дата согласования АС Заказчиком");
            entity.Property(e => e.RequestDate).HasColumnName("Дата создания заявки");
            entity.Property(e => e.DocNtd).HasColumnName("Документ (НТД)");
            entity.Property(e => e.Measure).HasColumnName("Ед. измерения");
            entity.Property(e => e.Amount).HasColumnName("Кол-во");
            entity.Property(e => e.TimingMax).HasColumnName("Максимальный срок поставки по АС");
            entity.Property(e => e.MtrName).HasColumnName("Наименование МТР");
            entity.Property(e => e.Nmck).HasColumnName("Начальная максимальная цена");
            entity.Property(e => e.DeliveryTime).HasColumnName("Необходимый срок поставки");
            entity.Property(e => e.RequestNum).HasColumnName("Номер заявки");
            entity.Property(e => e.PositionNum).HasColumnName("№ позиции");
            entity.Property(e => e.ProcedureGpb).HasColumnName("Процедура ГПБ");
            entity.Property(e => e.ProcedureGpb4).HasColumnName("Процедура ГПБ на 4");
            entity.Property(e => e.Timing).HasColumnName("Сроки поставки по АС");
            entity.Property(e => e.SupState).HasColumnName("Статус закупки");
            entity.Property(e => e.Condition).HasColumnName("Условия оплаты");
            entity.Property(e => e.Currency).HasColumnName("Валюта");
            entity.Property(e => e.Manufacturer).HasColumnName("Изготовитель");
            entity.Property(e => e.Person).HasColumnName("Ответственный");
            entity.Property(e => e.SupName).HasColumnName("Победитель");

        });

        modelBuilder.Entity<Bidder>(entity =>
        {
            entity.HasKey(e => e.BidderId).HasName("bidder_pkey");

            entity.ToTable("bidder", "src", tb => tb.HasComment("Участники"));

            entity.HasIndex(e => e.Inn, "ix_src_bidder_inn");

            entity.HasIndex(e => e.Kpp, "ix_src_bidder_kpp");

            entity.HasIndex(e => e.Ogrn, "ix_src_bidder_ogrn");

            entity.HasIndex(e => e.ProcedureId, "ix_src_bidder_sup_state");

            entity.HasIndex(e => e.BidderName, "ix_src_bidder_sup_state_id");

            entity.HasIndex(e => new { e.ProcedureId, e.BidderName }, "uix_src_bidder_procedure_gpb").IsUnique();

            entity.Property(e => e.BidderId).HasColumnName("bidder_id");
            entity.Property(e => e.Affiliation)
                .HasComment("Принадлежность поставщика")
                .HasColumnName("affiliation");
            entity.Property(e => e.BidderFullname).HasColumnName("bidder_fullname");
            entity.Property(e => e.BidderName).HasColumnName("bidder_name");
            entity.Property(e => e.BossFio)
                .HasComment("ФИО Руководителя")
                .HasColumnName("boss_fio");
            entity.Property(e => e.BossPost)
                .HasDefaultValueSql("'Директор'::text")
                .HasComment("Должность руководителя")
                .HasColumnName("boss_post");
            entity.Property(e => e.City)
                .HasComment("Город")
                .HasColumnName("city");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("inn");
            entity.Property(e => e.Kpp)
                .HasMaxLength(9)
                .HasColumnName("kpp");
            entity.Property(e => e.Ogrn)
                .HasMaxLength(13)
                .HasComment("ОГРН")
                .HasColumnName("ogrn");
            entity.Property(e => e.ProcedureGpb).HasColumnName("procedure_gpb");
            entity.Property(e => e.ProcedureId).HasColumnName("procedure_id");
            entity.Property(e => e.SupplierId)
                .HasComment("Связанное значение поставщика. Устанавливается после загрузки ТКП в import.supplier_tkp_table_apply")
                .HasColumnName("supplier_id");
            entity.Property(e => e.UpdateOnRegistry)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_registry");
            entity.Property(e => e.UpdateOnReport2022)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_report2022");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Procedure).WithMany(p => p.Bidders)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("src_bidder_procedure_id_fkey");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("cnt_contract_pkey");

            entity.ToTable("contract", "cnt", tb => tb.HasComment("Договора"));

            entity.HasIndex(e => e.ContractIdParent, "ix_cnt_contact_contract_id_parent");

            entity.HasIndex(e => e.Customer, "ix_cnt_contract_customer");

            entity.HasIndex(e => e.Customer, "ix_cnt_contract_customer_id");

            entity.HasIndex(e => e.SupName, "ix_cnt_contract_sup_name");

            entity.HasIndex(e => e.SupplierId, "ix_cnt_contract_supplier_id");

            entity.HasIndex(e => new { e.ContractDoc, e.ContractNum, e.ContractDate, e.ContractType }, "uix_cnt_contract_contract_doc_contract_num_contract_date_contra").IsUnique();

            entity.HasIndex(e => new { e.ContractDoc, e.ContractNum, e.ContractDate, e.ContractType }, "uix_contract_doc_contract_num_contract_date_contract_type").IsUnique();

            entity.Property(e => e.ContractId)
                .HasComment("Идентификатор")
                .HasColumnName("contract_id");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.ContractDate)
                .HasComment("Дата Контракта")
                .HasColumnName("contract_date");
            entity.Property(e => e.ContractDoc)
                .HasDefaultValueSql("'Договор'::text")
                .HasComment("Вид документа")
                .HasColumnName("contract_doc");
            entity.Property(e => e.ContractIdParent)
                .HasComment("Вышестоящий договор")
                .HasColumnName("contract_id_parent");
            entity.Property(e => e.ContractName)
                .HasComment("Наименование")
                .HasColumnName("contract_name");
            entity.Property(e => e.ContractNum)
                .HasComment("Номер Контракта")
                .HasColumnName("contract_num");
            entity.Property(e => e.ContractSubject)
                .HasComment("Предмет")
                .HasColumnName("contract_subject");
            entity.Property(e => e.ContractType)
                .HasDefaultValueSql("'Исходящий'::text")
                .HasComment("Тип Контракта")
                .HasColumnName("contract_type");
            entity.Property(e => e.Customer)
                .HasComment("Клиент")
                .HasColumnName("customer");
            entity.Property(e => e.CustomerId)
                .HasComment("Клиент")
                .HasColumnName("customer_id");
            entity.Property(e => e.IsAgent)
                .HasDefaultValue(false)
                .HasComment("Агентский договор")
                .HasColumnName("is_agent");
            entity.Property(e => e.SourceNum).HasColumnName("source_num");
            entity.Property(e => e.SourceNumParent).HasColumnName("source_num_parent");
            entity.Property(e => e.SupName)
                .HasComment("Поставщик")
                .HasColumnName("sup_name");
            entity.Property(e => e.SupplierId)
                .HasComment("Поставщик")
                .HasColumnName("supplier_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<ContractState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("state_pkey");

            entity.ToTable("contract_state", "cnt", tb => tb.HasComment("Статусы Договоров"));

            entity.HasIndex(e => e.ContractId, "ix_cnt_state_contract_id");

            entity.HasIndex(e => e.StateName, "ix_cnt_state_state_name");

            entity.HasIndex(e => new { e.ContractId, e.StateName, e.StateDate }, "uix_cnt_state_contract_id_state_name_state_date").IsUnique();

            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.StateComment).HasColumnName("state_comment");
            entity.Property(e => e.StateDate)
                .HasDefaultValueSql("(now())::date")
                .HasColumnName("state_date");
            entity.Property(e => e.StateName)
                .HasDefaultValueSql("'новый'::text")
                .HasColumnName("state_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractStates)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("contract_id_fkey");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.DealId).HasName("cnt_deal_pkey");

            entity.ToTable("deal", "cnt", tb => tb.HasComment("Условия Сделок"));

            entity.HasIndex(e => e.DealId, "ix_cnt_deal_condition_deal_id");

            entity.HasIndex(e => e.Customer, "ix_cnt_deal_customer");

            entity.HasIndex(e => e.CustomerId, "ix_cnt_deal_customer_id");

            entity.HasIndex(e => new { e.DocNum, e.DocDate }, "ix_cnt_deal_doc_num_doc_date");

            entity.HasIndex(e => e.DocRequestNum, "ix_cnt_deal_doc_request_num");

            entity.HasIndex(e => e.ProcedureGpb, "ix_cnt_deal_procedure_gpb");

            entity.HasIndex(e => e.ProcedureId, "ix_cnt_deal_procedure_id");

            entity.HasIndex(e => new { e.ProcedureGpb, e.Supplier }, "uix_cnt_deal_procedure_gpb_supplier").IsUnique();

            entity.Property(e => e.DealId)
                .HasComment("Идентификатор")
                .HasColumnName("deal_id");
            entity.Property(e => e.Agent)
                .HasComment("Агент")
                .HasColumnName("agent");
            entity.Property(e => e.AgentDateType)
                .HasComment("Агент - Дата")
                .HasColumnName("agent_date_type");
            entity.Property(e => e.AgentDaysAmount)
                .HasComment("Агент - Количество дней")
                .HasColumnName("agent_days_amount");
            entity.Property(e => e.AgentDaysType)
                .HasComment("Агент - Тип дней")
                .HasColumnName("agent_days_type");
            entity.Property(e => e.AgnetDoc)
                .HasComment("Агент - Документ")
                .HasColumnName("agnet_doc");
            entity.Property(e => e.CashGapDaysAvg)
                .HasComment("Среднее количество дней кассового разрыва")
                .HasColumnName("cash_gap_days_avg");
            entity.Property(e => e.CashRate)
                .HasComment("Стоимость ДС, год")
                .HasColumnName("cash_rate");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.CommissionPercent)
                .HasComment("Комиссия, %")
                .HasColumnName("commission_percent");
            entity.Property(e => e.CommissionPercentFact)
                .HasComment("Комиссия Фактическая, % (для попозиционной разбивки в сложных и простых сделках)")
                .HasColumnName("commission_percent_fact");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Создано")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedAtXls)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at_xls");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Логин")
                .HasColumnName("created_by");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'RUB'::character varying")
                .HasComment("Валюта ISO 4217")
                .HasColumnName("currency");
            entity.Property(e => e.Customer)
                .HasComment("Заказчик")
                .HasColumnName("customer");
            entity.Property(e => e.CustomerDateType)
                .HasComment("Заказчик - Дата")
                .HasColumnName("customer_date_type");
            entity.Property(e => e.CustomerDaysAmount)
                .HasComment("Заказчик - Количество дней")
                .HasColumnName("customer_days_amount");
            entity.Property(e => e.CustomerDaysType)
                .HasComment("Заказчик - Тип дней")
                .HasColumnName("customer_days_type");
            entity.Property(e => e.CustomerDoc)
                .HasComment("Заказчик - Документ")
                .HasColumnName("customer_doc");
            entity.Property(e => e.CustomerId)
                .HasComment("Заказчик")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerPriceCurNds)
                .HasComment("Объем с НДС, Заказчик, Валюта")
                .HasColumnName("customer_price_cur_nds");
            entity.Property(e => e.CustomerPriceNds)
                .HasComment("Объем поставки, с НДС Заказчик")
                .HasColumnName("customer_price_nds");
            entity.Property(e => e.CustomerPriceSource)
                .HasComment("Исходный объем поставки, с НДС Заказчик")
                .HasColumnName("customer_price_source");
            entity.Property(e => e.DealName)
                .HasComment("Наименование сделки Документооборот")
                .HasColumnName("deal_name");
            entity.Property(e => e.DealState)
                .HasComment("Статус")
                .HasColumnName("deal_state");
            entity.Property(e => e.DealUuid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasComment("UUID сделки")
                .HasColumnName("deal_uuid");
            entity.Property(e => e.DeliveryDateFact)
                .HasComment("Дата поставки фактическая")
                .HasColumnName("delivery_date_fact");
            entity.Property(e => e.DeliveryDatePlan)
                .HasComment("Дата поставки плановая")
                .HasColumnName("delivery_date_plan");
            entity.Property(e => e.DirectionCzs)
                .HasComment("Направление ЦЗС (Продукт)")
                .HasColumnName("direction_czs");
            entity.Property(e => e.DocDate)
                .HasComment("Дата")
                .HasColumnName("doc_date");
            entity.Property(e => e.DocNum)
                .HasComment("Регистрационный номер")
                .HasColumnName("doc_num");
            entity.Property(e => e.DocRequestNum)
                .HasComment("Номер заявки Документооборот")
                .HasColumnName("doc_request_num");
            entity.Property(e => e.ExchangeRate)
                .HasComment("Курс")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.ExpenseAgent)
                .HasDefaultValueSql("0")
                .HasComment("Д/з Агентское в-е")
                .HasColumnName("expense_agent");
            entity.Property(e => e.ExpenseIc)
                .HasDefaultValueSql("0")
                .HasComment("Д/з ИК")
                .HasColumnName("expense_ic");
            entity.Property(e => e.ExpenseLogistic)
                .HasDefaultValueSql("0")
                .HasComment("Д/з Логистика")
                .HasColumnName("expense_logistic");
            entity.Property(e => e.ExpenseOther)
                .HasDefaultValueSql("0")
                .HasComment("Д/з Прочие")
                .HasColumnName("expense_other");
            entity.Property(e => e.FileNum)
                .HasComment("Номер из файла")
                .HasColumnName("file_num");
            entity.Property(e => e.GroupMtr)
                .HasComment("Номенклатура - группа МТР")
                .HasColumnName("group_mtr");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.IsComplicated)
                .HasComment("Сложная сделка")
                .HasColumnName("is_complicated");
            entity.Property(e => e.IsObsAccount)
                .HasComment("ОБС счет")
                .HasColumnName("is_obs_account");
            entity.Property(e => e.IsSended1cdoc)
                .HasComment("Отправлено в 1С-Документооборот")
                .HasColumnName("is_sended_1cdoc");
            entity.Property(e => e.MarginPercent)
                .HasComment("Маржинальность сделки, %")
                .HasColumnName("margin_percent");
            entity.Property(e => e.PersonBo)
                .HasComment("Закупщик")
                .HasColumnName("person_bo");
            entity.Property(e => e.PersonLogin)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Ответственный по сделке")
                .HasColumnName("person_login");
            entity.Property(e => e.PriceDsPercent)
                .HasComment("Стоимость ДС, %")
                .HasColumnName("price_ds_percent");
            entity.Property(e => e.ProcedureGpb)
                .HasComment("Номер лота")
                .HasColumnName("procedure_gpb");
            entity.Property(e => e.ProcedureId)
                .HasComment("Процедура ГПБ")
                .HasColumnName("procedure_id");
            entity.Property(e => e.ProductionTime)
                .HasComment("Срок изготовления, дн")
                .HasColumnName("production_time");
            entity.Property(e => e.QueryDateStr)
                .HasComment("Дата запроса")
                .HasColumnName("query_date_str");
            entity.Property(e => e.Scheme)
                .HasComment("Схема")
                .HasColumnName("scheme");
            entity.Property(e => e.StrRequestNum)
                .HasComment("Номер заявки")
                .HasColumnName("str_request_num");
            entity.Property(e => e.Supplier)
                .HasComment("Поставщик")
                .HasColumnName("supplier");
            entity.Property(e => e.SupplierDateType)
                .HasComment("Поставщик - Дата")
                .HasColumnName("supplier_date_type");
            entity.Property(e => e.SupplierDaysAmount)
                .HasComment("Поставщик - Количество дней")
                .HasColumnName("supplier_days_amount");
            entity.Property(e => e.SupplierDaysType)
                .HasComment("Поставщик - Тип дней")
                .HasColumnName("supplier_days_type");
            entity.Property(e => e.SupplierDoc)
                .HasComment("Поставщик - Документ")
                .HasColumnName("supplier_doc");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplierPriceCurNds)
                .HasComment("Объем с НДС, Поставщик, Валюта")
                .HasColumnName("supplier_price_cur_nds");
            entity.Property(e => e.SupplierPriceNds)
                .HasComment("Объем поставки, с НДС Поставщик")
                .HasColumnName("supplier_price_nds");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedAtXls)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at_xls");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Procedure).WithMany(p => p.Deals)
                .HasForeignKey(d => d.ProcedureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cnt_deal_procedure_id_fkey");
        });

        modelBuilder.Entity<DealCondition>(entity =>
        {
            entity.HasKey(e => e.DealConditionId).HasName("cnt_deal_condition_pkey");

            entity.ToTable("deal_condition", "cnt");

            entity.Property(e => e.DealConditionId).HasColumnName("deal_condition_id");
            entity.Property(e => e.CashGapDaysAvg)
                .HasComment("Среднее количество дней кассового разрыва")
                .HasColumnName("cash_gap_days_avg");
            entity.Property(e => e.CashRate)
                .HasComment("Стоимость ДС, год")
                .HasColumnName("cash_rate");
            entity.Property(e => e.CommissionPercent)
                .HasComment("Комиссия, %")
                .HasColumnName("commission_percent");
            entity.Property(e => e.Customer)
                .HasComment("Заказчик")
                .HasColumnName("customer");
            entity.Property(e => e.CustomerDate).HasColumnName("customer_date");
            entity.Property(e => e.CustomerDaysAmount)
                .HasComment("Заказчик - Количество дней")
                .HasColumnName("customer_days_amount");
            entity.Property(e => e.CustomerDaysType)
                .HasComment("Заказчик - Тип дней")
                .HasColumnName("customer_days_type");
            entity.Property(e => e.CustomerDoc)
                .HasComment("Заказчик - Документ")
                .HasColumnName("customer_doc");
            entity.Property(e => e.CustomerPrice)
                .HasComment("Объем поставки, тыс.руб. с НДС Заказчик")
                .HasColumnName("customer_price");
            entity.Property(e => e.CustomerPriceCur)
                .HasComment("Объем поставки с НДС, Заказчик, Валюта")
                .HasColumnName("customer_price_cur");
            entity.Property(e => e.CustomerPriceSource)
                .HasComment("Исходный объем поставки, с НДС Заказчик")
                .HasColumnName("customer_price_source");
            entity.Property(e => e.CustomerPriceSourceCur)
                .HasComment("Объем поставки с НДС, Заказчик, Валюта")
                .HasColumnName("customer_price_source_cur");
            entity.Property(e => e.DealConditionUuid).HasColumnName("deal_condition_uuid");
            entity.Property(e => e.DealId)
                .HasComment("Идентификатор")
                .HasColumnName("deal_id");
            entity.Property(e => e.DeliveryDateFact)
                .HasComment("Дата поставки фактическая")
                .HasColumnName("delivery_date_fact");
            entity.Property(e => e.DeliveryDatePlan)
                .HasComment("Дата поставки плановая")
                .HasColumnName("delivery_date_plan");
            entity.Property(e => e.Expense).HasColumnName("expense");
            entity.Property(e => e.ExpenseAgent)
                .HasComment("Д/з Агентское в-е")
                .HasColumnName("expense_agent");
            entity.Property(e => e.ExpenseAgentCur)
                .HasComment("Доп. затраты, Агентские, Валюта")
                .HasColumnName("expense_agent_cur");
            entity.Property(e => e.ExpenseAgentPercent)
                .HasComment("Д/з Агентское в-е %")
                .HasColumnName("expense_agent_percent");
            entity.Property(e => e.ExpenseCur)
                .HasComment("Доп. затраты, Всего, Валюта")
                .HasColumnName("expense_cur");
            entity.Property(e => e.ExpenseIc)
                .HasComment("Д/з ИК")
                .HasColumnName("expense_ic");
            entity.Property(e => e.ExpenseIcCur)
                .HasComment("Доп. затраты, ИК, Валюта")
                .HasColumnName("expense_ic_cur");
            entity.Property(e => e.ExpenseIcPercent)
                .HasComment("Д/з ИК %")
                .HasColumnName("expense_ic_percent");
            entity.Property(e => e.ExpenseLogistic)
                .HasComment("Д/з Логистика")
                .HasColumnName("expense_logistic");
            entity.Property(e => e.ExpenseLogisticCur)
                .HasComment("Доп. затраты, Логистика, Валюта")
                .HasColumnName("expense_logistic_cur");
            entity.Property(e => e.ExpenseLogisticPercent)
                .HasComment("Д/з Логистика %")
                .HasColumnName("expense_logistic_percent");
            entity.Property(e => e.ExpenseOther)
                .HasComment("Д/з Прочие")
                .HasColumnName("expense_other");
            entity.Property(e => e.ExpenseOtherCur)
                .HasComment("Доп. затраты, Прочие, Валюта")
                .HasColumnName("expense_other_cur");
            entity.Property(e => e.ExpenseOtherPercent)
                .HasComment("Д/з Прочие  %")
                .HasColumnName("expense_other_percent");
            entity.Property(e => e.ExpensePercent).HasColumnName("expense_percent");
            entity.Property(e => e.IsComplicated)
                .HasComment("Сложная сделка")
                .HasColumnName("is_complicated");
            entity.Property(e => e.IsObsAccount)
                .HasComment("ОБС счет")
                .HasColumnName("is_obs_account");
            entity.Property(e => e.MarginPercent)
                .HasComment("Маржинальность сделки, %")
                .HasColumnName("margin_percent");
            entity.Property(e => e.PriceDsPercent)
                .HasComment("Стоимость ДС, %")
                .HasColumnName("price_ds_percent");
            entity.Property(e => e.ProductPercent).HasColumnName("product_percent");
            entity.Property(e => e.Scheme)
                .HasComment("Схема")
                .HasColumnName("scheme");
            entity.Property(e => e.SumIncPriceCurNds)
                .HasComment("Объем поставки с НДС, Поставщик, Валюта")
                .HasColumnName("sum_inc_price_cur_nds");
            entity.Property(e => e.SumIncPriceNds)
                .HasComment("Объем поставки, тыс.руб. с НДС Поставщик")
                .HasColumnName("sum_inc_price_nds");
            entity.Property(e => e.SupName)
                .HasComment("Поставщик")
                .HasColumnName("sup_name");
            entity.Property(e => e.SupplierDate).HasColumnName("supplier_date");
            entity.Property(e => e.SupplierDaysAmount)
                .HasComment("Поставщик - Количество дней")
                .HasColumnName("supplier_days_amount");
            entity.Property(e => e.SupplierDaysType)
                .HasComment("Поставщик - Тип дней")
                .HasColumnName("supplier_days_type");
            entity.Property(e => e.SupplierDoc)
                .HasComment("Поставщик - Документ")
                .HasColumnName("supplier_doc");
            entity.Property(e => e.SupplierPercent).HasColumnName("supplier_percent");
            entity.Property(e => e.TotalPriceCurNds)
                .HasComment("Объем поставки с НДС, Поставщик, Валюта")
                .HasColumnName("total_price_cur_nds");
            entity.Property(e => e.TotalPriceNds).HasColumnName("total_price_nds");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Deal).WithMany(p => p.DealConditions)
                .HasForeignKey(d => d.DealId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cnt_deal_condition_deal_id_fkey");
        });

        modelBuilder.Entity<DeliverySchedule>(entity =>
        {
            entity.HasKey(e => e.DeliveryScheduleId).HasName("pk_sup_delivery_schedule");

            entity.ToTable("delivery_schedule", "sup", tb => tb.HasComment("График Поставки"));

            entity.HasIndex(e => e.SupState, "ix_sup_delivery_schedule_sup_state");

            entity.HasIndex(e => e.SupplyPositionId, "ix_sup_delivery_schedule_supply_position_id");

            entity.Property(e => e.DeliveryScheduleId)
                .HasComment("Внутренний идентификатор частичной отгрузки")
                .HasColumnName("delivery_schedule_id");
            entity.Property(e => e.Amount)
                .HasComment("Количество")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'2023-02-28 17:58:21.289218'::timestamp without time zone")
                .HasComment("Создано")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .HasDefaultValueSql("'RUB'::bpchar")
                .IsFixedLength()
                .HasComment("Валюта")
                .HasColumnName("currency");
            entity.Property(e => e.CustomerPrice)
                .HasPrecision(20, 2)
                .HasComment("Стоимость с Заказчиком, без НДС")
                .HasColumnName("customer_price");
            entity.Property(e => e.CustomerPriceCur)
                .HasPrecision(20, 2)
                .HasComment("Стоимость Заказчик с НДС, Валюта")
                .HasColumnName("customer_price_cur");
            entity.Property(e => e.DeliveryScheduleComment)
                .HasComment("Комментарий")
                .HasColumnName("delivery_schedule_comment");
            entity.Property(e => e.ExchangeRate)
                .HasPrecision(20, 2)
                .HasComment("Обменный курс к рублю")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.IncUpdDate)
                .HasComment("УПД, дата")
                .HasColumnName("inc_upd_date");
            entity.Property(e => e.IncUpdNum)
                .HasComment("УПД, номер")
                .HasColumnName("inc_upd_num");
            entity.Property(e => e.Measure)
                .HasComment("Единица измерения")
                .HasColumnName("measure");
            entity.Property(e => e.ShippingDate)
                .HasComment("Прогнозная дата")
                .HasColumnName("shipping_date");
            entity.Property(e => e.SupState)
                .HasDefaultValueSql("'законтрактовано'::bpchar")
                .HasComment("Статус")
                .HasColumnName("sup_state");
            entity.Property(e => e.SupplierPriceNds)
                .HasPrecision(20, 2)
                .HasComment("Стоимость с Поставщиком, с НДС")
                .HasColumnName("supplier_price_nds");
            entity.Property(e => e.SupplierPriceNdsCur)
                .HasPrecision(20, 2)
                .HasComment("Стоимость Поставщик с НДС, Валюта")
                .HasColumnName("supplier_price_nds_cur");
            entity.Property(e => e.SupplierPriceUnit)
                .HasPrecision(20, 2)
                .HasComment("Цена Поставщик, руб.")
                .HasColumnName("supplier_price_unit");
            entity.Property(e => e.SupplierPriceUnitCur)
                .HasPrecision(20, 2)
                .HasComment("Цена Поставщик, валюта")
                .HasColumnName("supplier_price_unit_cur");
            entity.Property(e => e.SupplyPositionId)
                .HasComment("Идентификатор позиции поставки")
                .HasColumnName("supply_position_id");
            entity.Property(e => e.UpdatedAt)
                .HasComment("Обновлено")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Обновлено (логин)")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.SupplyPosition).WithMany(p => p.DeliverySchedules)
                .HasForeignKey(d => d.SupplyPositionId)
                .HasConstraintName("fk_sup_delivery_schedule_supply_position_id");
        });

        modelBuilder.Entity<PaymentUpd>(entity =>
        {
            entity.HasKey(e => e.PaymentUpdId).HasName("cnt_payment_upd_pkey");

            entity.ToTable("payment_upd", "cnt", tb => tb.HasComment("Платежи"));

            entity.HasIndex(e => e.SpecPositionId, "ix_cnt_payment_upd_spec_position_id");

            entity.Property(e => e.PaymentUpdId)
                .HasComment("Платеж")
                .HasColumnName("payment_upd_id");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.PaymentUpdDate)
                .HasComment("Дата УПД")
                .HasColumnName("payment_upd_date");
            entity.Property(e => e.PaymentUpdName)
                .HasComment("Наименование УПД")
                .HasColumnName("payment_upd_name");
            entity.Property(e => e.PaymentUpdNum)
                .HasComment("Номер УПД")
                .HasColumnName("payment_upd_num");
            entity.Property(e => e.PaymentUpdSum)
                .HasPrecision(20, 2)
                .HasComment("Объем по УПД")
                .HasColumnName("payment_upd_sum");
            entity.Property(e => e.SpecPositionId)
                .HasComment("Позиция Спецификации")
                .HasColumnName("spec_position_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.SpecPosition).WithMany(p => p.PaymentUpds)
                .HasForeignKey(d => d.SpecPositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cnt_payment_upd_spec_position_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("person_pkey");

            entity.ToTable("person", "ref", tb => tb.HasComment("Ответственные"));

            entity.HasIndex(e => e.LoginText, "ix_ref_person_login_text");

            entity.HasIndex(e => e.PersonId, "ix_ref_person_person_id");

            entity.HasIndex(e => e.LoginText, "uix_ref_person_login_text").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Firstname).HasColumnName("firstname");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.IsAdmin)
                .HasDefaultValue(false)
                .HasColumnName("is_admin");
            entity.Property(e => e.IsContractDept)
                .HasDefaultValue(false)
                .HasColumnName("is_contract_dept");
            entity.Property(e => e.IsCustomer)
                .HasDefaultValue(false)
                .HasComment("Является Закупщиком (могут ли на него назначаться закупка Позиций МТР)")
                .HasColumnName("is_customer");
            entity.Property(e => e.IsForwarder)
                .HasDefaultValue(false)
                .HasColumnName("is_forwarder");
            entity.Property(e => e.IsReadonly)
                .HasDefaultValue(false)
                .HasColumnName("is_readonly");
            entity.Property(e => e.Lastname).HasColumnName("lastname");
            entity.Property(e => e.LoginText).HasColumnName("login_text");
            entity.Property(e => e.Manager).HasColumnName("manager");
            entity.Property(e => e.Middlename).HasColumnName("middlename");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("position_pkey");

            entity.ToTable("position", "src", tb => tb.HasComment("Позиции МТР"));

            entity.HasIndex(e => e.ProcedureGpb, "ix_src_position_procedure_gpb");

            entity.HasIndex(e => e.ProcedureId, "ix_src_position_procedure_id");

            entity.HasIndex(e => e.RequestId, "ix_src_position_request_id");

            entity.HasIndex(e => e.RequestNum, "ix_src_position_request_num");

            entity.Property(e => e.PositionId)
                .HasComment("ID")
                .HasColumnName("position_id");
            entity.Property(e => e.Amount)
                .HasComment("Количество")
                .HasColumnName("amount");
            entity.Property(e => e.Basis)
                .HasComment("Базис поставки")
                .HasColumnName("basis");
            entity.Property(e => e.Condition)
                .HasComment("Условия оплаты")
                .HasColumnName("condition");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Время создания Позиции Заявки")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Логин создавшего Позицию Заявки")
                .HasColumnName("created_by");
            entity.Property(e => e.Currency)
                .HasDefaultValueSql("'RUB'::text")
                .HasComment("Валюта")
                .HasColumnName("currency");
            entity.Property(e => e.CustomerEnd)
                .HasComment("Конечный заказчик")
                .HasColumnName("customer_end");
            entity.Property(e => e.DateAgreement)
                .HasComment("Дата отправки Заказчику на согласование АС/ТКП")
                .HasColumnName("date_agreement");
            entity.Property(e => e.DateAs)
                .HasComment("Дата согласования АС/ТКП")
                .HasColumnName("date_as");
            entity.Property(e => e.DateCustomerQuery)
                .HasComment("Дата запроса в адрес Заказчика ТТ/ТЗ/ТУ")
                .HasColumnName("date_customer_query");
            entity.Property(e => e.DateDocs)
                .HasComment("Дата получения от Заказчика всей требуемой технической документации")
                .HasColumnName("date_docs");
            entity.Property(e => e.DeliveryTime)
                .HasComment("Необходимый срок поставки")
                .HasColumnName("delivery_time");
            entity.Property(e => e.DocNtd)
                .HasComment("Нормативный документ")
                .HasColumnName("doc_ntd");
            entity.Property(e => e.ExchangeRate)
                .HasComment("Курс")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.GroupMtr)
                .HasComment("Группа МТР")
                .HasColumnName("group_mtr");
            entity.Property(e => e.GroupMtrId)
                .HasComment("Идентификатор группы МТР")
                .HasColumnName("group_mtr_id");
            entity.Property(e => e.GroupMtrPrcUuid).HasColumnName("group_mtr_prc_uuid");
            entity.Property(e => e.IncPrice)
                .HasComment("Вх. стоимость товара без НДС, руб.")
                .HasColumnName("inc_price");
            entity.Property(e => e.IncPriceCur)
                .HasComment("Вх. стоимость товара без НДС, валюта.")
                .HasColumnName("inc_price_cur");
            entity.Property(e => e.IncPriceCurNds)
                .HasComment("Вх. стоимость товара с НДС, валюта.")
                .HasColumnName("inc_price_cur_nds");
            entity.Property(e => e.IncPriceNds)
                .HasComment("Вх. стоимость товара с НДС, руб.")
                .HasColumnName("inc_price_nds");
            entity.Property(e => e.IncUpdDate)
                .HasComment("Входящее УПД. Счет фактура. Дата")
                .HasColumnName("inc_upd_date");
            entity.Property(e => e.IncUpdNum)
                .HasComment("Входящее УПД. Счет фактура. №")
                .HasColumnName("inc_upd_num");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.IsShipped)
                .HasDefaultValue(false)
                .HasComment("Признак отгрузки")
                .HasColumnName("is_shipped");
            entity.Property(e => e.Manufacturer)
                .HasComment("Изготовитель")
                .HasColumnName("manufacturer");
            entity.Property(e => e.MaterialSap)
                .HasComment("Материал SAP")
                .HasColumnName("material_sap");
            entity.Property(e => e.Measure)
                .HasComment("Единица измерения")
                .HasColumnName("measure");
            entity.Property(e => e.MtrName)
                .HasComment("Наименование МТР")
                .HasColumnName("mtr_name");
            entity.Property(e => e.MtrNameFull)
                .HasComment("ПОЛНОЕ наименование и марка Товара")
                .HasColumnName("mtr_name_full");
            entity.Property(e => e.MtrNameSrc).HasColumnName("mtr_name_src");
            entity.Property(e => e.MtrRequirements).HasColumnName("mtr_requirements");
            entity.Property(e => e.Nmck)
                .HasComment("Начальная максимальная цена")
                .HasColumnName("nmck");
            entity.Property(e => e.OutPrice)
                .HasComment("Исходящая стоимость товара без НДС, руб.")
                .HasColumnName("out_price");
            entity.Property(e => e.OutPriceCur)
                .HasComment("Исходящая стоимость товара без НДС, Валюта.")
                .HasColumnName("out_price_cur");
            entity.Property(e => e.OutPriceCurNds)
                .HasComment("Исходящая стоимость товара c НДС, Валюта.")
                .HasColumnName("out_price_cur_nds");
            entity.Property(e => e.OutPriceNds)
                .HasComment("Исходящая стоимость товара c НДС, руб.")
                .HasColumnName("out_price_nds");
            entity.Property(e => e.PaymentTerms).HasColumnName("payment_terms");
            entity.Property(e => e.Person)
                .HasComment("Ответственный")
                .HasColumnName("person");
            entity.Property(e => e.PersonForwarder)
                .HasComment("Ответственный")
                .HasColumnName("person_forwarder");
            entity.Property(e => e.PersonUid).HasColumnName("person_uid");
            entity.Property(e => e.PositionDealId)
                .HasComment("Связанное значение сделки. Устанавливается после инициализации и обновлении условий сделки в cnt.trf_cnt_deal_biu")
                .HasColumnName("position_deal_id");
            entity.Property(e => e.PositionNum)
                .HasComment("Номер позиции")
                .HasColumnName("position_num");
            entity.Property(e => e.PositionSap)
                .HasComment("Позиция SAP")
                .HasColumnName("position_sap");
            entity.Property(e => e.PositionUuid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasComment("Процедура ЭТП на 4 (идентификатор на площадке)")
                .HasColumnName("position_uuid");
            entity.Property(e => e.PriceUnit)
                .HasPrecision(20, 2)
                .HasColumnName("price_unit");
            entity.Property(e => e.ProcedureGpb)
                .HasComment("Процедура ЭТП")
                .HasColumnName("procedure_gpb");
            entity.Property(e => e.ProcedureGpb4).HasColumnName("procedure_gpb4");
            entity.Property(e => e.ProcedureId)
                .HasComment("Процедура ЭТП")
                .HasColumnName("procedure_id");
            entity.Property(e => e.ProcedureUuid).HasColumnName("procedure_uuid");
            entity.Property(e => e.RequestId)
                .HasComment("Заявка")
                .HasColumnName("request_id");
            entity.Property(e => e.RequestNum)
                .HasComment("Номер заявки")
                .HasColumnName("request_num");
            entity.Property(e => e.RequestSap)
                .HasComment("Заявка SAP")
                .HasColumnName("request_sap");
            entity.Property(e => e.RequestUuid).HasColumnName("request_uuid");
            entity.Property(e => e.ShippingDate)
                .HasComment("Прогнозная дата отгрузки")
                .HasColumnName("shipping_date");
            entity.Property(e => e.ShippingDateFact)
                .HasComment("Фактическая дата отгрузки")
                .HasColumnName("shipping_date_fact");
            entity.Property(e => e.StatePrc).HasColumnName("state_prc");
            entity.Property(e => e.SupComment)
                .HasComment("Комментарий")
                .HasColumnName("sup_comment");
            entity.Property(e => e.SupName)
                .HasComment("Победитель")
                .HasColumnName("sup_name");
            entity.Property(e => e.SupObject)
                .HasComment("Объект")
                .HasColumnName("sup_object");
            entity.Property(e => e.SupState)
                .HasComment("Статус закупки")
                .HasColumnName("sup_state");
            entity.Property(e => e.SupStateId)
                .HasComment("Ссылка на последнее добавленное значение статуса")
                .HasColumnName("sup_state_id");
            entity.Property(e => e.SupUpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата обновления Поставки")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sup_updated_at");
            entity.Property(e => e.SupUpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Обновлена Поставка")
                .HasColumnName("sup_updated_by");
            entity.Property(e => e.SupplierId)
                .HasComment("Поставщик")
                .HasColumnName("supplier_id");
            entity.Property(e => e.Timing)
                .HasComment("Сроки поставки по АС")
                .HasColumnName("timing");
            entity.Property(e => e.TimingMax)
                .HasComment("Максимальный срок поставки по АС")
                .HasColumnName("timing_max");
            entity.Property(e => e.Tolerance).HasColumnName("tolerance");
            entity.Property(e => e.UpdateOnData)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_data");
            entity.Property(e => e.UpdateOnRegistry)
                .HasComment("Обновлено из процессора в рамках периодической загрузки")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_registry");
            entity.Property(e => e.UpdateOnReport2022)
                .HasComment("Загружено из Отчет 2022")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_report2022");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата последнего обновления")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Обновлена Позиция МТР")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Procedure).WithMany(p => p.Positions)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("procedure_id_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.Positions)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("request_id_fkey");
        });

        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(e => e.ProcedureId).HasName("procedure_pkey");

            entity.ToTable("procedure", "src", tb => tb.HasComment("Процедуры ЭТП"));

            entity.HasIndex(e => e.ProcedureId, "ix_src_procedure_procedure_id");

            entity.HasIndex(e => e.SupState, "ix_src_procedure_sup_state");

            entity.HasIndex(e => e.SupStateId, "ix_src_procedure_sup_state_id");

            entity.HasIndex(e => e.ProcedureGpb, "uix_src_procedure_procedure_gpb").IsUnique();

            entity.Property(e => e.ProcedureId).HasColumnName("procedure_id");
            entity.Property(e => e.AssessedValue)
                .HasPrecision(20, 2)
                .HasComment("Оценочная стоимость лота")
                .HasColumnName("assessed_value");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.LastTkpLink)
                .HasComment("Ссылка на последнее загруженное ТКП")
                .HasColumnName("last_tkp_link");
            entity.Property(e => e.Members).HasColumnName("members");
            entity.Property(e => e.ProcedureComment).HasColumnName("procedure_comment");
            entity.Property(e => e.ProcedureDateBeg)
                .HasComment("Дата публикации")
                .HasColumnName("procedure_date_beg");
            entity.Property(e => e.ProcedureDateEnd).HasColumnName("procedure_date_end");
            entity.Property(e => e.ProcedureGpb).HasColumnName("procedure_gpb");
            entity.Property(e => e.ProcedureGpb4).HasColumnName("procedure_gpb4");
            entity.Property(e => e.ProcedureName).HasColumnName("procedure_name");
            entity.Property(e => e.ProcedureUuid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("procedure_uuid");
            entity.Property(e => e.SupState).HasColumnName("sup_state");
            entity.Property(e => e.SupStateId).HasColumnName("sup_state_id");
            entity.Property(e => e.Suppliers).HasColumnName("suppliers");
            entity.Property(e => e.UpdateOnData)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_data");
            entity.Property(e => e.UpdateOnRegistry)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_registry");
            entity.Property(e => e.UpdateOnReport2022)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_report2022");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Обновлена Процедура")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<ProcedureComment>(entity =>
        {
            entity.HasKey(e => e.ProcedureCommentId).HasName("procedure_comment_pkey");

            entity.ToTable("procedure_comment", "cm", tb => tb.HasComment("Статусы Закупки (Процедуры)"));

            entity.HasIndex(e => e.LoginText, "ix_cm_procedure_comment_login_text");

            entity.HasIndex(e => e.ProcedureId, "ix_cm_procedure_comment_procedure_id");

            entity.HasIndex(e => e.SupStateId, "ix_cm_procedure_comment_sup_state_id");

            entity.HasIndex(e => new { e.ProcedureId, e.IsActual }, "uix_cm_procedure_comment_procedure_id_is_actual")
                .IsUnique()
                .HasFilter("(is_actual = true)");

            entity.Property(e => e.ProcedureCommentId).HasColumnName("procedure_comment_id");
            entity.Property(e => e.CommentDate).HasColumnName("comment_date");
            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.IsActual)
                .HasDefaultValue(false)
                .HasColumnName("is_actual");
            entity.Property(e => e.LoginText).HasColumnName("login_text");
            entity.Property(e => e.PersonFullname).HasColumnName("person_fullname");
            entity.Property(e => e.ProcedureId).HasColumnName("procedure_id");
            entity.Property(e => e.SupStateId).HasColumnName("sup_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Procedure).WithMany(p => p.ProcedureComments)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("procedure_id_fkey");

            entity.HasOne(d => d.SupState).WithMany(p => p.ProcedureComments)
                .HasForeignKey(d => d.SupStateId)
                .HasConstraintName("sup_state_id_fkey");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("request_pkey");

            entity.ToTable("request", "src", tb => tb.HasComment("Заявки"));

            entity.HasIndex(e => e.Customer, "ix_src_request_customer");

            entity.HasIndex(e => e.RequestId, "ix_src_request_request_id");

            entity.HasIndex(e => e.RequestNum, "uix_src_request_request_num").IsUnique();

            entity.Property(e => e.RequestId)
                .HasComment("Заявка")
                .HasColumnName("request_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Время обновления")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Пользователь, который внес изменения")
                .HasColumnName("created_by");
            entity.Property(e => e.Customer)
                .HasComment("Контрагент (D4-DATA, D4-REG, customer-r22)")
                .HasColumnName("customer");
            entity.Property(e => e.CustomerId)
                .HasComment("Заказчик")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerUuid)
                .HasComment("ID заказчика (E5-DATA)")
                .HasColumnName("customer_uuid");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.PersonManager).HasColumnName("person_manager");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.RequestComment).HasColumnName("request_comment");
            entity.Property(e => e.RequestCommentProcessor)
                .HasComment("Комментарий (процессор) (G7-DATA)")
                .HasColumnName("request_comment_processor");
            entity.Property(e => e.RequestDate)
                .HasComment("Дата создания заявки (K11-DATA, E5-REG, request_date-r22)")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestName)
                .HasComment("Наименование заявки (C3-DATA, C3-REG, request_name-r22)")
                .HasColumnName("request_name");
            entity.Property(e => e.RequestNum)
                .HasComment("№ заявки (B2-DATA, A1-REG, request_num-r22)")
                .HasColumnName("request_num");
            entity.Property(e => e.RequestState)
                .HasComment("Статус заявки (процессор) (I9-DATA, B2-REG, request_state-r22) ")
                .HasColumnName("request_state");
            entity.Property(e => e.RequestUuid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasComment("ID заявки (A1-DATA)")
                .HasColumnName("request_uuid");
            entity.Property(e => e.SupState).HasColumnName("sup_state");
            entity.Property(e => e.SupStateId).HasColumnName("sup_state_id");
            entity.Property(e => e.ToReserve)
                .HasDefaultValue(false)
                .HasComment("Признак интеграции с ПК \"Резерв\"")
                .HasColumnName("to_reserve");
            entity.Property(e => e.ToWarehouse)
                .HasDefaultValue(false)
                .HasComment("Признак закупки продукции \"На склад\"\n(не должно отмечаться в Прогнозе Выручки)")
                .HasColumnName("to_warehouse");
            entity.Property(e => e.TradeSign)
                .HasDefaultValueSql("'АЗ'::text")
                .HasComment("Признак сделки (АЗ/ТТ/ТК)\nАЗ – аутсорсинг закупок\nТТ – товарный трейдинг\nТК – товарный кредит\n")
                .HasColumnName("trade_sign");
            entity.Property(e => e.UpdateOnData)
                .HasComment("Время обновления из файла с общей датой (процессор)")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_data");
            entity.Property(e => e.UpdateOnRegistry)
                .HasComment("Время обновления из файла с рег. выгрузкой (процессор)")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_registry");
            entity.Property(e => e.UpdateOnReport2022)
                .HasComment("Время обновления из таблицы Отчет2022")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_report2022");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Время обновления")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Пользователь, который внес изменения")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.TradeSignNavigation).WithMany(p => p.Requests)
                .HasPrincipalKey(p => p.TradeSign1)
                .HasForeignKey(d => d.TradeSign)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_src_request_trade_sign");
        });

        modelBuilder.Entity<RequestComment>(entity =>
        {
            entity.HasKey(e => e.RequestCommentId).HasName("request_comment_pkey");

            entity.ToTable("request_comment", "cm", tb => tb.HasComment("Статусы Заявки"));

            entity.HasIndex(e => e.LoginText, "ix_cm_request_comment_login_text");

            entity.HasIndex(e => e.RequestId, "ix_cm_request_comment_request_id");

            entity.HasIndex(e => e.SupStateId, "ix_cm_request_comment_sup_state_id");

            entity.HasIndex(e => new { e.RequestId, e.IsActual }, "uix_cm_request_comment_request_id_is_actual")
                .IsUnique()
                .HasFilter("is_actual");

            entity.Property(e => e.RequestCommentId).HasColumnName("request_comment_id");
            entity.Property(e => e.CommentDate).HasColumnName("comment_date");
            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.IsActual)
                .HasDefaultValue(false)
                .HasColumnName("is_actual");
            entity.Property(e => e.LoginText).HasColumnName("login_text");
            entity.Property(e => e.PersonFullname).HasColumnName("person_fullname");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.SupStateId).HasColumnName("sup_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestComments)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("request_id_fkey");

            entity.HasOne(d => d.SupState).WithMany(p => p.RequestComments)
                .HasForeignKey(d => d.SupStateId)
                .HasConstraintName("sup_state_id_fkey");
        });

        modelBuilder.Entity<Spec>(entity =>
        {
            entity.HasKey(e => e.SpecId).HasName("cnt_spec_pkey");

            entity.ToTable("spec", "cnt", tb => tb.HasComment("Спецификации"));

            entity.HasIndex(e => e.ContractIdCustomer, "ix_cnt_spec_contract_id_customer");

            entity.HasIndex(e => e.ContractIdSup, "ix_cnt_spec_contract_id_sup");

            entity.HasIndex(e => e.ProcedureId, "ix_cnt_spec_procedure_id");

            entity.HasIndex(e => e.RequestId, "ix_cnt_spec_request_id");

            entity.HasIndex(e => e.DealId, "uix_cnt_spec_deal_id").IsUnique();

            entity.HasIndex(e => new { e.SpecNameCustomer, e.SpecNameSup, e.SpecNumCustomer, e.SpecNumSup }, "uix_cnt_spec_spec_name_customer_spec_name_sup_spec_num_customer").IsUnique();

            entity.Property(e => e.SpecId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_id");
            entity.Property(e => e.AttachmentsCount)
                .HasComment("Количество Приложений")
                .HasColumnName("attachments_count");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.ContractIdCustomer)
                .HasComment("Договор с Поставщиком")
                .HasColumnName("contract_id_customer");
            entity.Property(e => e.ContractIdSup).HasColumnName("contract_id_sup");
            entity.Property(e => e.ContractNameCustomer)
                .HasComment("Наименование Договора с Поставщиком")
                .HasColumnName("contract_name_customer");
            entity.Property(e => e.ContractNameSup).HasColumnName("contract_name_sup");
            entity.Property(e => e.CountAdjustment)
                .HasDefaultValue(0)
                .HasComment("Количество корректировок")
                .HasColumnName("count_adjustment");
            entity.Property(e => e.Customer)
                .HasComment("Заказчик")
                .HasColumnName("customer");
            entity.Property(e => e.CustomerId)
                .HasComment("Заказчик")
                .HasColumnName("customer_id");
            entity.Property(e => e.DateSendCustomer)
                .HasComment("Дата подачи Заказчику")
                .HasColumnName("date_send_customer");
            entity.Property(e => e.DateSendSup)
                .HasComment("Дата подачи Поставщику")
                .HasColumnName("date_send_sup");
            entity.Property(e => e.DateSignAll)
                .HasComment("Дата подписания всех сторон")
                .HasColumnName("date_sign_all");
            entity.Property(e => e.DateSignCustomer)
                .HasComment("Дата подписания Заказчиком")
                .HasColumnName("date_sign_customer");
            entity.Property(e => e.DateSignSup)
                .HasComment("Дата подписания Поставщиком")
                .HasColumnName("date_sign_sup");
            entity.Property(e => e.DealId)
                .HasComment("Заявка")
                .HasColumnName("deal_id");
            entity.Property(e => e.GroupMtr)
                .HasComment("Группа МТР")
                .HasColumnName("group_mtr");
            entity.Property(e => e.IsAutoInitSpecNumCustomer)
                .HasDefaultValue(true)
                .HasColumnName("is_auto_init_spec_num_customer");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.LastAdjustmentDate)
                .HasComment("Дата последней корректировки")
                .HasColumnName("last_adjustment_date");
            entity.Property(e => e.MarginPercent)
                .HasComment("Процент наценки")
                .HasColumnName("margin_percent");
            entity.Property(e => e.MtrRequirements).HasColumnName("mtr_requirements");
            entity.Property(e => e.PaymentTerms).HasColumnName("payment_terms");
            entity.Property(e => e.Person).HasColumnName("person");
            entity.Property(e => e.PersonLogin)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Ответственный - логин")
                .HasColumnName("person_login");
            entity.Property(e => e.ProcedureGpb)
                .HasComment("Процедура")
                .HasColumnName("procedure_gpb");
            entity.Property(e => e.ProcedureId)
                .HasComment("Процедура")
                .HasColumnName("procedure_id");
            entity.Property(e => e.RequestId)
                .HasComment("Заявка")
                .HasColumnName("request_id");
            entity.Property(e => e.RequestNum)
                .HasComment("Заявка")
                .HasColumnName("request_num");
            entity.Property(e => e.SpecDateCustomer)
                .HasComment("Дата спецификации с Клиентом")
                .HasColumnName("spec_date_customer");
            entity.Property(e => e.SpecDateSup)
                .HasComment("Дата спецификации с Поставщиком")
                .HasColumnName("spec_date_sup");
            entity.Property(e => e.SpecNameCustomer)
                .HasComment("Наименование спецификации с Клиентом")
                .HasColumnName("spec_name_customer");
            entity.Property(e => e.SpecNameSup)
                .HasComment("Наименование спецификации с Поставщиком")
                .HasColumnName("spec_name_sup");
            entity.Property(e => e.SpecNumCustomer)
                .HasComment("Номер спецификации с Клиентом")
                .HasColumnName("spec_num_customer");
            entity.Property(e => e.SpecNumSup)
                .HasComment("Номер спецификации с Поставщиком")
                .HasColumnName("spec_num_sup");
            entity.Property(e => e.SpecState).HasColumnName("spec_state");
            entity.Property(e => e.SpecStateCustomer)
                .HasComment("Статус спецификации с Заказчиком")
                .HasColumnName("spec_state_customer");
            entity.Property(e => e.SpecStateFull).HasColumnName("spec_state_full");
            entity.Property(e => e.SpecStateSup)
                .HasComment("Статус спецификации с Поставщиком")
                .HasColumnName("spec_state_sup");
            entity.Property(e => e.SupName)
                .HasComment("Поставщик")
                .HasColumnName("sup_name");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Tolerance)
                .HasComment("Толеранс")
                .HasColumnName("tolerance");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.ContractIdCustomerNavigation).WithMany(p => p.SpecContractIdCustomerNavigations)
                .HasForeignKey(d => d.ContractIdCustomer)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cnt_spec_contract_id_customer_fkey");

            entity.HasOne(d => d.ContractIdSupNavigation).WithMany(p => p.SpecContractIdSupNavigations)
                .HasForeignKey(d => d.ContractIdSup)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cnt_spec_contract_id_sup_fkey");

            entity.HasOne(d => d.Procedure).WithMany(p => p.Specs)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("cnt_spec_procedure_id_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.Specs)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("cnt_spec_request_id_fkey");
        });

        modelBuilder.Entity<SpecAdjustment>(entity =>
        {
            entity.HasKey(e => e.SpecAdjustmentId).HasName("cnt_spec_adjustment_pkey");

            entity.ToTable("spec_adjustment", "cnt", tb => tb.HasComment("История Корректировок Спецификации"));

            entity.HasIndex(e => e.SpecId, "ix_cnt_spec_adjustment_spec_id");

            entity.Property(e => e.SpecAdjustmentId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_adjustment_id");
            entity.Property(e => e.AdjustmentDate)
                .HasDefaultValueSql("(now())::date")
                .HasComment("Дата")
                .HasColumnName("adjustment_date");
            entity.Property(e => e.AdjustmentText)
                .HasComment("Комментарий")
                .HasColumnName("adjustment_text");
            entity.Property(e => e.SpecId)
                .HasComment("Спецификации")
                .HasColumnName("spec_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Spec).WithMany(p => p.SpecAdjustments)
                .HasForeignKey(d => d.SpecId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cnt_spec_adjustment_spec_id_fkey");
        });

        modelBuilder.Entity<SpecComment>(entity =>
        {
            entity.HasKey(e => e.SpecCommentId).HasName("cnt_spec_comment_pkey");

            entity.ToTable("spec_comment", "cnt", tb => tb.HasComment("История Комментариев Спецификации"));

            entity.HasIndex(e => e.SpecId, "ix_cnt_spec_comment_spec_id");

            entity.Property(e => e.SpecCommentId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_comment_id");
            entity.Property(e => e.CommentDate)
                .HasComment("Дата комментария")
                .HasColumnName("comment_date");
            entity.Property(e => e.CommentText)
                .HasComment("Комментарий")
                .HasColumnName("comment_text");
            entity.Property(e => e.SpecId)
                .HasComment("Спецификации")
                .HasColumnName("spec_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Spec).WithMany(p => p.SpecComments)
                .HasForeignKey(d => d.SpecId)
                .HasConstraintName("cnt_spec_comment_spec_id_fkey");
        });

        modelBuilder.Entity<SpecPosition>(entity =>
        {
            entity.HasKey(e => e.SpecPositionId).HasName("cnt_spec_position_pkey");

            entity.ToTable("spec_position", "cnt", tb => tb.HasComment("Позиции спецификаций"));

            entity.HasIndex(e => e.PositionId, "ix_cnt_spec_position_position_id");

            entity.HasIndex(e => e.SpecId, "ix_spec_position_spec_id");

            entity.HasIndex(e => e.SpecState, "ix_spec_position_spec_state");

            entity.Property(e => e.SpecPositionId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_position_id");
            entity.Property(e => e.Amount)
                .HasComment("Количество")
                .HasColumnName("amount");
            entity.Property(e => e.Basis)
                .HasComment("Базис")
                .HasColumnName("basis");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.ContractSup).HasColumnName("contract_sup");
            entity.Property(e => e.DocNtd)
                .HasComment("Нормативный документ")
                .HasColumnName("doc_ntd");
            entity.Property(e => e.IncomeUpd)
                .HasComment("Входящее УПД")
                .HasColumnName("income_upd");
            entity.Property(e => e.Manufacturer)
                .HasComment("Изготовитель")
                .HasColumnName("manufacturer");
            entity.Property(e => e.MarginPercent)
                .HasComment("Процент наценки")
                .HasColumnName("margin_percent");
            entity.Property(e => e.Measure)
                .HasComment("Единица измерения")
                .HasColumnName("measure");
            entity.Property(e => e.MtrName)
                .HasComment("Наименование МТР")
                .HasColumnName("mtr_name");
            entity.Property(e => e.Person)
                .HasComment("Ответственный")
                .HasColumnName("person");
            entity.Property(e => e.PosSupDate)
                .HasComment("Дата поставки по договору")
                .HasColumnName("pos_sup_date");
            entity.Property(e => e.PosTermDate)
                .HasComment("Срок поставки по договору")
                .HasColumnName("pos_term_date");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionNum).HasColumnName("position_num");
            entity.Property(e => e.PriceCustomer)
                .HasPrecision(20, 2)
                .HasComment("Стоимость (клиент)")
                .HasColumnName("price_customer");
            entity.Property(e => e.PriceCustomerNds)
                .HasPrecision(20, 2)
                .HasComment("Стоимость с НДС (клиент)")
                .HasColumnName("price_customer_nds");
            entity.Property(e => e.PriceSup)
                .HasPrecision(20, 2)
                .HasComment("Стоимость (поставщик)")
                .HasColumnName("price_sup");
            entity.Property(e => e.PriceSupNds)
                .HasPrecision(20, 2)
                .HasComment("Стоимость с НДС (поставщик)")
                .HasColumnName("price_sup_nds");
            entity.Property(e => e.PriceUnitCustomer)
                .HasPrecision(20, 2)
                .HasComment("Цена (клиент)")
                .HasColumnName("price_unit_customer");
            entity.Property(e => e.PriceUnitSup)
                .HasPrecision(20, 2)
                .HasComment("Цена (поставщик)")
                .HasColumnName("price_unit_sup");
            entity.Property(e => e.ProcedureGpb).HasColumnName("procedure_gpb");
            entity.Property(e => e.RequestNum).HasColumnName("request_num");
            entity.Property(e => e.SpecId)
                .HasComment("Спецификация")
                .HasColumnName("spec_id");
            entity.Property(e => e.SpecState)
                .HasComment("Статус cпецификации")
                .HasColumnName("spec_state");
            entity.Property(e => e.SpecStateFull)
                .HasComment("Статус (с комментарием)")
                .HasColumnName("spec_state_full");
            entity.Property(e => e.SpecSupplierId)
                .HasComment("Множественная связь с поставщиками")
                .HasColumnName("spec_supplier_id");
            entity.Property(e => e.SupName)
                .HasComment("Поставщик")
                .HasColumnName("sup_name");
            entity.Property(e => e.SupplierId)
                .HasComment("Поставщик")
                .HasColumnName("supplier_id");
            entity.Property(e => e.Timing)
                .HasComment("Срок поставки")
                .HasColumnName("timing");
            entity.Property(e => e.TimingMax)
                .HasComment("Максимальный срок поставки")
                .HasColumnName("timing_max");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Position).WithMany(p => p.SpecPositions)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("cnt_spec_position_spec_position_id_fkey");

            entity.HasOne(d => d.Spec).WithMany(p => p.SpecPositions)
                .HasForeignKey(d => d.SpecId)
                .HasConstraintName("cnt_spec_position_spec_id_fkey");

            entity.HasOne(d => d.SpecSupplier).WithMany(p => p.SpecPositions)
                .HasForeignKey(d => d.SpecSupplierId)
                .HasConstraintName("cnt_spec_position_spec_supplier_id_fkey");
        });

        modelBuilder.Entity<SpecPositionComment>(entity =>
        {
            entity.HasKey(e => e.SpecPositionCommentId).HasName("cnt_spec_position_comment_pkey");

            entity.ToTable("spec_position_comment", "cnt", tb => tb.HasComment("История статусов Позиций Спецификации"));

            entity.HasIndex(e => e.SpecPositionId, "ix_cnt_spec_position_comment_spec_position_id");

            entity.Property(e => e.SpecPositionCommentId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_position_comment_id");
            entity.Property(e => e.CommentDate)
                .HasComment("Дата комментария")
                .HasColumnName("comment_date");
            entity.Property(e => e.CommentText)
                .HasComment("Комментарий")
                .HasColumnName("comment_text");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.SpecPositionId)
                .HasComment("Позиция Спецификации")
                .HasColumnName("spec_position_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.SpecPosition).WithMany(p => p.SpecPositionComments)
                .HasForeignKey(d => d.SpecPositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cnt_spec_position_comment_spec_position_id_fkey");
        });

        modelBuilder.Entity<SpecPositionState>(entity =>
        {
            entity.HasKey(e => e.SpecPositionStateId).HasName("cnt_spec_position_state_pkey");

            entity.ToTable("spec_position_state", "cnt", tb => tb.HasComment("История статусов Позиций Спецификации"));

            entity.HasIndex(e => e.SpecPositionId, "ix_cnt_spec_position_state_spec_position_id");

            entity.Property(e => e.SpecPositionStateId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_position_state_id");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.SpecPositionId)
                .HasComment("Позиция Спецификации")
                .HasColumnName("spec_position_id");
            entity.Property(e => e.StateDate)
                .HasComment("Дата статуса")
                .HasColumnName("state_date");
            entity.Property(e => e.StateText)
                .HasComment("Статус")
                .HasColumnName("state_text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.SpecPosition).WithMany(p => p.SpecPositionStates)
                .HasForeignKey(d => d.SpecPositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cnt_spec_position_state_spec_position_id_fkey");
        });

        modelBuilder.Entity<SpecSupplier>(entity =>
        {
            entity.HasKey(e => e.SpecSupplierId).HasName("cnt_spec_supplier_pkey");

            entity.ToTable("spec_supplier", "cnt", tb => tb.HasComment("Множественная связь поставщиков для клиентской спецификации"));

            entity.HasIndex(e => e.SpecId, "ix_spec_supplier_spec_id");

            entity.Property(e => e.SpecSupplierId)
                .HasComment("Идентификатор")
                .HasColumnName("spec_supplier_id");
            entity.Property(e => e.Comment)
                .HasComment("Комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.ContractId)
                .HasComment("Договор")
                .HasColumnName("contract_id");
            entity.Property(e => e.ContractName)
                .HasComment("Договор")
                .HasColumnName("contract_name");
            entity.Property(e => e.MarginPercent)
                .HasComment("Процент наценки")
                .HasColumnName("margin_percent");
            entity.Property(e => e.SpecDateSup)
                .HasComment("Дата спецификации с Поставщиком")
                .HasColumnName("spec_date_sup");
            entity.Property(e => e.SpecId)
                .HasComment("Спецификация")
                .HasColumnName("spec_id");
            entity.Property(e => e.SpecNameSup)
                .HasComment("Наименование спецификации с Поставщиком")
                .HasColumnName("spec_name_sup");
            entity.Property(e => e.SpecNumSup)
                .HasComment("Номер спецификации с Поставщиком")
                .HasColumnName("spec_num_sup");
            entity.Property(e => e.SupName)
                .HasComment("Поставщик")
                .HasColumnName("sup_name");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Spec).WithMany(p => p.SpecSuppliers)
                .HasForeignKey(d => d.SpecId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cnt_spec_supplier_spec_supplier_id_fkey");
        });

        modelBuilder.Entity<SqlLog>(entity =>
        {
            entity.HasKey(e => e.SqlLogId).HasName("pk_usr_sql_log");

            entity.ToTable("sql_log", "usr", tb => tb.HasComment("Лог пользовательских SQL"));

            entity.Property(e => e.SqlLogId)
                .HasComment("Идентификатор")
                .HasColumnName("sql_log_id");
            entity.Property(e => e.ColumnName)
                .HasComment("Изменяемый параметр, в случае если он - единственный")
                .HasColumnName("column_name");
            entity.Property(e => e.IsExecuted)
                .HasDefaultValue(false)
                .HasComment("Признак выполнения")
                .HasColumnName("is_executed");
            entity.Property(e => e.Method)
                .HasComment("Метод")
                .HasColumnName("method");
            entity.Property(e => e.SqlText)
                .HasComment("Текст")
                .HasColumnName("sql_text");
            entity.Property(e => e.TableName)
                .HasComment("Изменяемая таблица, в случае если она - единственная")
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'2023-02-10 17:03:40.330058'::timestamp without time zone")
                .HasComment("Время обработки записи")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Логин")
                .HasColumnName("updated_by");
            entity.Property(e => e.UserLogin).HasColumnName("user_login");

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.SqlLogs)
                .HasPrincipalKey(p => p.LoginText)
                .HasForeignKey(d => d.UserLogin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usr_sql_log_user_login");
        });

        modelBuilder.Entity<SupChangeAction>(entity =>
        {
            entity.HasKey(e => e.SupChangeActionId).HasName("pk_usr_sup_change_action");

            entity.ToTable("sup_change_action", "usr", tb => tb.HasComment("Действия пользователей в рамках работы с таблицей Поставок"));

            entity.HasIndex(e => e.SupColumnName, "ix_usr_sup_change_action_sup_column_id");

            entity.HasIndex(e => e.SupplyPositionId, "ix_usr_sup_change_action_supply_position_id");

            entity.HasIndex(e => e.UserLogin, "ix_usr_sup_change_action_user_login");

            entity.Property(e => e.SupChangeActionId).HasColumnName("sup_change_action_id");
            entity.Property(e => e.IsRolledBack)
                .HasDefaultValue(false)
                .HasColumnName("is_rolled_back");
            entity.Property(e => e.SupChangeActionComment).HasColumnName("sup_change_action_comment");
            entity.Property(e => e.SupColumnName).HasColumnName("sup_column_name");
            entity.Property(e => e.SupplyPositionId).HasColumnName("supply_position_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'2023-02-10 17:04:27.587744'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("updated_by");
            entity.Property(e => e.UserLogin).HasColumnName("user_login");
            entity.Property(e => e.ValueNew).HasColumnName("value_new");
            entity.Property(e => e.ValueOld).HasColumnName("value_old");

            entity.HasOne(d => d.SupColumnNameNavigation).WithMany(p => p.SupChangeActions)
                .HasPrincipalKey(p => p.SupColumnName)
                .HasForeignKey(d => d.SupColumnName)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usr_sup_change_action_sup_column_name");

            entity.HasOne(d => d.SupplyPosition).WithMany(p => p.SupChangeActions)
                .HasForeignKey(d => d.SupplyPositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usr_sup_change_supply_position_id");

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.SupChangeActions)
                .HasPrincipalKey(p => p.LoginText)
                .HasForeignKey(d => d.UserLogin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usr_sup_change_action_user_login");
        });

        modelBuilder.Entity<SupColumn>(entity =>
        {
            entity.HasKey(e => e.SupColumnId).HasName("pk_sup_column");

            entity.ToTable("sup_column", "usr", tb => tb.HasComment("Перечень столбцов таблицы Поставок"));

            entity.HasIndex(e => e.SupColumnName, "ix_usr_sup_column_sup_column_name").IsUnique();

            entity.HasIndex(e => e.SupColumnNote, "ix_usr_sup_column_sup_column_note");

            entity.HasIndex(e => e.SupColumnName, "uix_usr_sup_column_sup_column_name").IsUnique();

            entity.HasIndex(e => e.SupColumnNote, "uix_usr_sup_column_sup_column_note").IsUnique();

            entity.Property(e => e.SupColumnId).HasColumnName("sup_column_id");
            entity.Property(e => e.IsVisibleDefault)
                .HasDefaultValue(true)
                .HasColumnName("is_visible_default");
            entity.Property(e => e.SupColumnDesc).HasColumnName("sup_column_desc");
            entity.Property(e => e.SupColumnName).HasColumnName("sup_column_name");
            entity.Property(e => e.SupColumnNote)
                .HasComment("Наименование для отображения на форме")
                .HasColumnName("sup_column_note");
            entity.Property(e => e.SupColumnType).HasColumnName("sup_column_type");
        });

        modelBuilder.Entity<SupColumnUser>(entity =>
        {
            entity.HasKey(e => e.SupColumnUserId).HasName("pk_usr_sup_column_user");

            entity.ToTable("sup_column_user", "usr", tb => tb.HasComment("Настройки полей таблицы Поставок для пользователей"));

            entity.HasIndex(e => e.SupColumnName, "ix_usr_sup_column_user_sup_column_name");

            entity.HasIndex(e => new { e.SupColumnName, e.UserLogin }, "ix_usr_sup_column_user_sup_column_name_user_login").IsUnique();

            entity.HasIndex(e => e.UserLogin, "ix_usr_sup_column_user_user_login");

            entity.Property(e => e.SupColumnUserId).HasColumnName("sup_column_user_id");
            entity.Property(e => e.IsVisible)
                .HasDefaultValue(true)
                .HasColumnName("is_visible");
            entity.Property(e => e.Sorting)
                .HasComment("Наличие ORDER BY: true - asc, false - desc, null - отсутствие сортировки")
                .HasColumnName("sorting");
            entity.Property(e => e.SupColumnName).HasColumnName("sup_column_name");
            entity.Property(e => e.SupColumnUserComment).HasColumnName("sup_column_user_comment");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'2023-02-10 17:04:53.893367'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("updated_by");
            entity.Property(e => e.UserLogin).HasColumnName("user_login");

            entity.HasOne(d => d.SupColumnNameNavigation).WithMany(p => p.SupColumnUsers)
                .HasPrincipalKey(p => p.SupColumnName)
                .HasForeignKey(d => d.SupColumnName)
                .HasConstraintName("fk_usr_sup_column_user_sup_column_name");

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.SupColumnUsers)
                .HasPrincipalKey(p => p.LoginText)
                .HasForeignKey(d => d.UserLogin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usr_sup_column_user_user_login");
        });

        modelBuilder.Entity<SupState>(entity =>
        {
            entity.HasKey(e => e.SupStateId).HasName("sup_state_pkey");

            entity.ToTable("sup_state", "src", tb => tb.HasComment("Статусы позиции МТР"));

            entity.HasIndex(e => e.PositionId, "ix_src_sup_state_position_id");

            entity.HasIndex(e => e.SupStateName, "ix_src_sup_state_sup_state_name");

            entity.HasIndex(e => new { e.PositionId, e.SupStateName, e.SupStateDate }, "uix_src_sup_state_position_id_sup_state_name_sup_state_date").IsUnique();

            entity.Property(e => e.SupStateId).HasColumnName("sup_state_id");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.MtrName).HasColumnName("mtr_name");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionNum).HasColumnName("position_num");
            entity.Property(e => e.ProcedureGpb).HasColumnName("procedure_gpb");
            entity.Property(e => e.RequestNum).HasColumnName("request_num");
            entity.Property(e => e.SupStateDate).HasColumnName("sup_state_date");
            entity.Property(e => e.SupStateName)
                .HasDefaultValueSql("'подготовка к публикации закупки'::text")
                .HasColumnName("sup_state_name");
            entity.Property(e => e.UpdateOnReport2022)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_report2022");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Position).WithMany(p => p.SupStates)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("position_id_fkey");
        });

        modelBuilder.Entity<SupStateDeleted>(entity =>
        {
            entity.HasKey(e => e.SupStateDeletedId).HasName("sup_state_deleted_pkey");

            entity.ToTable("sup_state_deleted", "src", tb => tb.HasComment("Удаленные статусы позиции МТР"));

            entity.HasIndex(e => e.PositionId, "ix_src_sup_state_deleted_position_id");

            entity.HasIndex(e => e.SupStateId, "ix_src_sup_state_deleted_sup_state_id");

            entity.HasIndex(e => e.SupStateName, "ix_src_sup_state_deleted_sup_state_name");

            entity.Property(e => e.SupStateDeletedId).HasColumnName("sup_state_deleted_id");
            entity.Property(e => e.IsAutomaticInit)
                .HasDefaultValue(false)
                .HasColumnName("is_automatic_init");
            entity.Property(e => e.MtrName).HasColumnName("mtr_name");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionNum).HasColumnName("position_num");
            entity.Property(e => e.ProcedureGpb).HasColumnName("procedure_gpb");
            entity.Property(e => e.RequestNum).HasColumnName("request_num");
            entity.Property(e => e.SupStateDate).HasColumnName("sup_state_date");
            entity.Property(e => e.SupStateId).HasColumnName("sup_state_id");
            entity.Property(e => e.SupStateName)
                .HasDefaultValueSql("'подготовка к публикации закупки'::text")
                .HasColumnName("sup_state_name");
            entity.Property(e => e.UpdateOnReport2022)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_on_report2022");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Position).WithMany(p => p.SupStateDeleteds)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("position_id_fkey");
        });

        modelBuilder.Entity<SupplyPosition>(entity =>
        {
            entity.HasKey(e => e.SupplyPositionId).HasName("supply_position_pkey");

            entity.ToTable("supply_position", "sup", tb => tb.HasComment("Данные по поставкам"));

            entity.HasIndex(e => e.Customer, "ix_sup_supply_position_customer");

            entity.HasIndex(e => e.DealId, "ix_sup_supply_position_deal_id");

            entity.HasIndex(e => e.RequestNum, "ix_sup_supply_position_request_num");

            entity.HasIndex(e => e.SupName, "ix_sup_supply_position_sup_name");

            entity.HasIndex(e => e.SupState, "ix_sup_supply_position_sup_state");

            entity.HasIndex(e => e.PositionId, "uix_sup_supply_position_position_id").IsUnique();

            entity.Property(e => e.SupplyPositionId).HasColumnName("supply_position_id");
            entity.Property(e => e.AdvancePaymentDate)
                .HasComment("Дата оплаты аванса")
                .HasColumnName("advance_payment_date");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ContractIdCustomer).HasColumnName("contract_id_customer");
            entity.Property(e => e.ContractIdSupplier).HasColumnName("contract_id_supplier");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время создания записи")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasComment("Пользователь, создавший запись по Поставке")
                .HasColumnName("created_by");
            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .HasDefaultValueSql("'RUB'::bpchar")
                .IsFixedLength()
                .HasComment("Валюта")
                .HasColumnName("currency");
            entity.Property(e => e.Customer).HasColumnName("customer");
            entity.Property(e => e.CustomerContract).HasColumnName("customer_contract");
            entity.Property(e => e.CustomerEnd)
                .HasComment("Конечный заказчик")
                .HasColumnName("customer_end");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerPrice)
                .HasPrecision(20, 2)
                .HasColumnName("customer_price");
            entity.Property(e => e.CustomerPriceCur)
                .HasPrecision(20, 2)
                .HasComment("Стоимость Заказчик с НДС, Валюта")
                .HasColumnName("customer_price_cur");
            entity.Property(e => e.CustomerPriceUpd)
                .HasPrecision(20, 2)
                .HasComment("Ответственный по Направлению")
                .HasColumnName("customer_price_upd");
            entity.Property(e => e.CustomerPriceUpdCur)
                .HasPrecision(20, 2)
                .HasComment("Стоимость по УПД, Валюта")
                .HasColumnName("customer_price_upd_cur");
            entity.Property(e => e.CustomerSpecDate).HasColumnName("customer_spec_date");
            entity.Property(e => e.CustomerSpecNum).HasColumnName("customer_spec_num");
            entity.Property(e => e.DateSignAll)
                .HasComment("Дата подписания с двух сторон")
                .HasColumnName("date_sign_all");
            entity.Property(e => e.DateSignCustomer)
                .HasComment("Дата подписания Заказчиком")
                .HasColumnName("date_sign_customer");
            entity.Property(e => e.DateSignSup)
                .HasComment("Дата подписания Поставщиком")
                .HasColumnName("date_sign_sup");
            entity.Property(e => e.DealId).HasColumnName("deal_id");
            entity.Property(e => e.DepartmentOrigin)
                .HasComment("Отдел ведущий данные поставки")
                .HasColumnName("department_origin");
            entity.Property(e => e.ExchangeRate)
                .HasPrecision(20, 2)
                .HasComment("Обменный курс к рублю")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.FileOrigin)
                .HasComment("Файл из которого произведена загрузка")
                .HasColumnName("file_origin");
            entity.Property(e => e.GroupMtr).HasColumnName("group_mtr");
            entity.Property(e => e.GroupMtrId).HasColumnName("group_mtr_id");
            entity.Property(e => e.IncUpdDate).HasColumnName("inc_upd_date");
            entity.Property(e => e.IncUpdNum).HasColumnName("inc_upd_num");
            entity.Property(e => e.IsImportInit).HasColumnName("is_import_init");
            entity.Property(e => e.IsUserImport)
                .HasDefaultValue(false)
                .HasComment("Загружено пользователем из файла")
                .HasColumnName("is_user_import");
            entity.Property(e => e.Measure).HasColumnName("measure");
            entity.Property(e => e.MtrName).HasColumnName("mtr_name");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.PersonForwarder)
                .HasDefaultValueSql("'Карле Татьяна'::text")
                .HasColumnName("person_forwarder");
            entity.Property(e => e.PersonManager)
                .HasDefaultValueSql("'Трейдинг'::text")
                .HasComment("Направление ЦЗС, по которому происходит закупка/поставка")
                .HasColumnName("person_manager");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.ProcedureGpb).HasColumnName("procedure_gpb");
            entity.Property(e => e.ProcedureId).HasColumnName("procedure_id");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.RequestNum).HasColumnName("request_num");
            entity.Property(e => e.Segmentation)
                .HasDefaultValueSql("'Прочие'::text")
                .HasColumnName("segmentation");
            entity.Property(e => e.ShippingDate).HasColumnName("shipping_date");
            entity.Property(e => e.ShippingDateFact).HasColumnName("shipping_date_fact");
            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.SupComment).HasColumnName("sup_comment");
            entity.Property(e => e.SupCommentAdd)
                .HasComment("Комментарий из Списка")
                .HasColumnName("sup_comment_add");
            entity.Property(e => e.SupDate).HasColumnName("sup_date");
            entity.Property(e => e.SupName).HasColumnName("sup_name");
            entity.Property(e => e.SupObject).HasColumnName("sup_object");
            entity.Property(e => e.SupState).HasColumnName("sup_state");
            entity.Property(e => e.SupplierContract).HasColumnName("supplier_contract");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplierPriceNds)
                .HasPrecision(20, 2)
                .HasColumnName("supplier_price_nds");
            entity.Property(e => e.SupplierPriceNdsCur)
                .HasPrecision(20, 2)
                .HasComment("Стоимость Поставщик с НДС, Валюта")
                .HasColumnName("supplier_price_nds_cur");
            entity.Property(e => e.SupplierPriceUnit)
                .HasPrecision(20, 2)
                .HasColumnName("supplier_price_unit");
            entity.Property(e => e.SupplierPriceUnitCur)
                .HasPrecision(20, 2)
                .HasComment("Цена Поставщик, Валюта")
                .HasColumnName("supplier_price_unit_cur");
            entity.Property(e => e.SupplierSpecDate).HasColumnName("supplier_spec_date");
            entity.Property(e => e.SupplierSpecNum).HasColumnName("supplier_spec_num");
            entity.Property(e => e.SupplyPositionUuid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasComment("Уникальный идентификатор записи")
                .HasColumnName("supply_position_uuid");
            entity.Property(e => e.TimingMax).HasColumnName("timing_max");
            entity.Property(e => e.ToWarehouse)
                .HasDefaultValue(false)
                .HasComment("Признак закупки продукции \"На склад\"\n(не должно отмечаться в Прогнозе Выручки)")
                .HasColumnName("to_warehouse");
            entity.Property(e => e.TradeSign)
                .HasDefaultValueSql("'АЗ'::text")
                .HasComment("Признак сделки (АЗ/ТТ/ТК)\nАЗ – аутсорсинг закупок\nТТ – товарный трейдинг\nТК – товарный кредит\n")
                .HasColumnName("trade_sign");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.TradeSignNavigation).WithMany(p => p.SupplyPositions)
                .HasPrincipalKey(p => p.TradeSign1)
                .HasForeignKey(d => d.TradeSign)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sup_supply_position_trade_sign");
        });

        modelBuilder.Entity<SupplyPositionComment>(entity =>
        {
            entity.HasKey(e => e.SupplyPositionCommentId).HasName("sup_supply_position_comment_pkey");

            entity.ToTable("supply_position_comment", "sup", tb => tb.HasComment("История статусов Позиций Спецификации"));

            entity.HasIndex(e => e.SupplyPositionId, "ix_sup_supply_position_comment_supply_position_id");

            entity.Property(e => e.SupplyPositionCommentId)
                .HasComment("Идентификатор")
                .HasColumnName("supply_position_comment_id");
            entity.Property(e => e.CommentDate)
                .HasComment("Дата комментария")
                .HasColumnName("comment_date");
            entity.Property(e => e.CommentText)
                .HasComment("Комментарий")
                .HasColumnName("comment_text");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.SupplyPositionId)
                .HasComment("Позиция Спецификации")
                .HasColumnName("supply_position_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время последнего изменения")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("Логин пользователя")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.SupplyPosition).WithMany(p => p.SupplyPositionComments)
                .HasForeignKey(d => d.SupplyPositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sup_supply_position_comment_supply_position_id_fkey");
        });

        modelBuilder.Entity<TradeSign>(entity =>
        {
            entity.HasKey(e => e.TradeSignId).HasName("trade_sign_pkey");

            entity.ToTable("trade_sign", "ref", tb => tb.HasComment("Перечень признаков сделки\nАЗ – аутсорсинг закупок\nТТ – товарный трейдинг\nТК – товарный кредит\n"));

            entity.HasIndex(e => e.TradeSign1, "trade_sign_trade_sign_key").IsUnique();

            entity.Property(e => e.TradeSignId).HasColumnName("trade_sign_id");
            entity.Property(e => e.TradeSign1).HasColumnName("trade_sign");
            entity.Property(e => e.TradeSignFullname).HasColumnName("trade_sign_fullname");
            entity.Property(e => e.TradeSignName).HasColumnName("trade_sign_name");
            entity.Property(e => e.TradeSignNote).HasColumnName("trade_sign_note");
        });

        modelBuilder.Entity<VRequestForm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_request_form", "src");

            entity.Property(e => e.Customer)
                .HasComment("Контрагент")
                .HasColumnName("customer");
            entity.Property(e => e.GroupMtr)
                .HasComment("Группа МТР")
                .HasColumnName("group_mtr");
            entity.Property(e => e.NameShort)
                .HasComment("Сегментация клиента")
                .HasColumnName("name_short");
            entity.Property(e => e.Nl)
                .HasComment("Количество лотов")
                .HasColumnName("nl");
            entity.Property(e => e.Np)
                .HasComment("Количество позиций")
                .HasColumnName("np");
            entity.Property(e => e.PersonManager).HasColumnName("person_manager");
            entity.Property(e => e.Priority)
                .HasComment("Приоритет")
                .HasColumnName("priority");
            entity.Property(e => e.RequestComment)
                .HasComment("Комментарий")
                .HasColumnName("request_comment");
            entity.Property(e => e.RequestDate)
                .HasComment("Дата создания заявки")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestId)
                .HasComment("ID")
                .HasColumnName("request_id");
            entity.Property(e => e.RequestName)
                .HasComment("Наименование заявки")
                .HasColumnName("request_name");
            entity.Property(e => e.RequestNum)
                .HasComment("Номер заявки")
                .HasColumnName("request_num");
            entity.Property(e => e.SumIncPrice)
                .HasComment("Вх. стоимость; руб. без НДС.")
                .HasColumnName("sum_inc_price");
            entity.Property(e => e.SupState)
                .HasComment("Статус заявки")
                .HasColumnName("sup_state");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
