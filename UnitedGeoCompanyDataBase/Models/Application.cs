namespace UnitedGeoCompanyDataBase.Models;

/// <summary>
/// Заявка на выполнения работ.
/// </summary>
public class Application: BaseEntity
{
    /// <summary>
    /// Имя клиента.
    /// </summary>
    public string ClientName { get; set; }

    /// <summary>
    /// Контактные данные клиента.
    /// </summary>
    public string ContactInfo { get; set; }

    /// <summary>
    /// Дата заключения даявки.
    /// </summary>
    public DateTime RequestDate { get; set; }

    /// <summary>
    /// Статус выполнения заявки.
    /// </summary>
    public ApplicationStatus ApplicationStatus { get; set; }

    /// <summary>
    /// Задача сформированная по заявке.
    /// </summary>
    public Objective? Objective { get; set; }
}

/// <summary>
/// Статус выполнения заявки.
/// </summary>
public enum ApplicationStatus
{
    Pending = 0,
    InProgress = 1,
    Completed = 2,
    Cancelled = 3
}
