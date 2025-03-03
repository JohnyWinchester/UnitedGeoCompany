namespace UnitedGeoCompanyDataBase.Models;

/// <summary>
/// Бригада.
/// </summary>
public class Brigade: BaseEntity
{
    /// <summary>
    /// Имя бригады.
    /// </summary>
    public string BrigadeName { get; set; }

    /// <summary>
    /// Лидер бригады.
    /// </summary>
    public string BrigadeLeader { get; set; }

    /// <summary>
    /// Задача.
    /// </summary>
    public List<Objective>? Objectives { get; set; }
}
