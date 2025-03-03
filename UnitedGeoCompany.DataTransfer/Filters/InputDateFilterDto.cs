namespace UnitedGeoCompany.DataTransfer.Filters;

public record InputDateFilterDTO(int FromMonth, int FromYear, int? BeforeMonth, int? BeforeYear)
{
    public readonly DateTimeOffset FromDate = new DateTime(FromYear, FromMonth, 1);
    public readonly DateTimeOffset? BeforeDate = BeforeMonth is { } beforeMonth && BeforeYear is { } beforeYear
            ? new DateTime(beforeYear, beforeMonth, DateTime.DaysInMonth(beforeYear, beforeMonth))
            : null;
}
