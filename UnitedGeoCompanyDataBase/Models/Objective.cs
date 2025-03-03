namespace UnitedGeoCompanyDataBase.Models;

/// <summary>
/// Задача для выполнения бригадой по заявке.
/// </summary>
public class Objective: BaseEntity
{
    /// <summary>
    /// Дата начала выполнения задания.
    /// </summary>
    public DateTime AssignmentDate { get; set; }

    /// <summary>
    /// Дата конца выполнения задания.
    /// </summary>
    public DateTime? CompletionDate { get; set; }

    /// <summary>
    /// Заметки.
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// ID заявки.
    /// </summary>
    public long ApplicationId { get; set; }

    /// <summary>
    /// Заявка.
    /// </summary>
    public Application Application { get; set; }

    /// <summary>
    /// ID бригады.
    /// </summary>
    public long BrigadeId { get; set; }

    /// <summary>
    /// Бригада.
    /// </summary>
    public Brigade Brigade { get; set; }
}
