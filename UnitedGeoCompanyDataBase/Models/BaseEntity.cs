namespace UnitedGeoCompanyDataBase.Models;

/// <summary>
/// Базовый класс для описания модели базы данных
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// ID
    /// </summary>
    public long ID { get; set; }

    /// <summary>
    /// Создает и возвращает копию текущего объекта.
    /// </summary>
    public object Clone() => MemberwiseClone();
}