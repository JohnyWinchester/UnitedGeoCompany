using OneOf.Types;
using UnitedGeoCompany.DataTransfer.Application;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Services.Interfaces;

public interface ISecretaryService
{
    /// <summary>
    /// Добавление нговой заявки.
    /// </summary>
    /// <param name="application">Заявка</param>
    /// <returns></returns>
    Task AddApplication(ApplicationDto application);

    /// <summary>
    /// Присвоить уже созданную заявку бригаде.
    /// </summary>
    /// <param name="applicationID">ID заявки.</param>
    /// <returns></returns>
    Task<Error<string>?> GiveObjectiveToBrigade(long applicationID, long brigadeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить статус заявки.
    /// </summary>
    /// <param name="applicationID">ID заявки.</param>
    /// <param name="newStatus">Новый статус</param>
    /// <returns>Возвращает результат обновления статуса.</returns>
    Task<CompleteApplicationResult> UpdateApplicationStatus(long applicationID, ApplicationStatus newStatus,CancellationToken cancellationToken = default);

    /// <summary>
    /// Запрашивает статус заявки.
    /// </summary>
    /// <param name="applicationId">ID заявки.</param>
    /// <returns>Возвращает статус заявки.</returns>
    Task<string> ApplicationStatus(long applicationId, CancellationToken cancellationToken = default);
}
