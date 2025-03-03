namespace UnitedGeoCompany.DataTransfer.Brigades;

public record BrigadesStatisticDto(IReadOnlyCollection<BrigadeStatisticDto> BrigadesStatistic);

public record BrigadeStatisticDto(string BrigadeName, int CompletedObjectivesCount, BrigadeObjectivesStatisticDto ObjectivesStatisticDto);

public record BrigadeObjectivesStatisticDto(long ID, string Duration);
