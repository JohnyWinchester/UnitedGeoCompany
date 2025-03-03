using UnitedGeoCompany.DataTransfer.Brigades;
using UnitedGeoCompany.DataTransfer.Filters;

namespace UnitedGeoCompany.Services.Interfaces;

public interface IBrigadesService
{
    /// <summary>
    /// Закрыть задачу бригады.
    /// </summary>
    /// <param name="brigadeId">ID бригады.</param>
    Task CompledBrigadeObjective(long brigadeId, long applicationId, string notes, CancellationToken cancellationToken);

    /// <summary>
    /// Сбор статистики по датам.
    /// </summary>
    /// <param name="dateFilter">Фильтр дат.</param>
    /// <returns>Сгрупированную статистику по бригадам.</returns>
    Task<BrigadesStatisticDto> GetStatistic(InputDateFilterDTO dateFilter, CancellationToken cancellationToken);
}
