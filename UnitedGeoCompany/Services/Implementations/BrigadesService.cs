using System.Linq.Expressions;
using UnitedGeoCompany.DataTransfer.Brigades;
using UnitedGeoCompany.DataTransfer.Filters;
using UnitedGeoCompany.Repository.Interfaces;
using UnitedGeoCompany.Services.Interfaces;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Services.Implementations;

public class BrigadesService : IBrigadesService
{
    private readonly IObjectiveRepository _objectiveRepository;
    private readonly IBrigadeRepository _brigadeRepository;
    private readonly IApplicationRepository _applicationRepository;

    public BrigadesService(
        IObjectiveRepository objectiveRepository,
        IBrigadeRepository brigadeRepository,
        IApplicationRepository applicationRepository)
    {
        _objectiveRepository = objectiveRepository;
        _brigadeRepository = brigadeRepository;
        _applicationRepository = applicationRepository;
    }

    public async Task CompledBrigadeObjective(long brigadeId, long applicationId,string notes, CancellationToken cancellationToken)
    {
        var includeExpressions = new Expression<Func<Brigade, object?>>[]
        {
            brigade => brigade.Objectives,
        };

        if( await _brigadeRepository.GetAsync(brigade => brigade.ID == brigadeId, cancellationToken, includeExpressions) 
                is not { } brigade)
            return;

        var application = await _applicationRepository.GetAsync(application => application.ID == applicationId);
        var objectiveToComplete = application.Objective;

        objectiveToComplete.Notes = notes;
        objectiveToComplete.CompletionDate = DateTime.Now;
        application.ApplicationStatus = ApplicationStatus.Completed;

        await _objectiveRepository.Update(objectiveToComplete, cancellationToken);
        await _applicationRepository.Update(application, cancellationToken);
    }

    public async Task<BrigadesStatisticDto> GetStatistic(InputDateFilterDTO dateFilter, CancellationToken cancellationToken)
    {
        var includeExpressions = new Expression<Func<Objective, object?>>[]
        {
            objective => objective.Brigade,
            objective => objective.Application,
        }; 

        var objectives = await _objectiveRepository.GetAllAsync(objective => 
            objective.CompletionDate <= dateFilter.BeforeDate &&
            objective.AssignmentDate >= dateFilter.FromDate, 100, cancellationToken, includeExpressions);

        if (objectives is null)
            return null;

        return new(objectives
        .GroupBy(o => o.Brigade.BrigadeName)
        .Select(g => new BrigadeStatisticDto(
            BrigadeName: g.Key,
            CompletedObjectivesCount: g.Count(),
            ObjectivesStatisticDto: new BrigadeObjectivesStatisticDto(
                ID: g.First().ApplicationId, 
                Duration: CalculateAverageDuration(g)
            )
        ))
        .ToList());
    }

    private string CalculateAverageDuration(IEnumerable<Objective> objectives)
    {
        var totalDays = 0;
        var count = 0;

        foreach (var objective in objectives)
        {
            if (objective.CompletionDate.HasValue)
            {
                var duration = objective.CompletionDate.Value - objective.AssignmentDate;
                totalDays += duration.Days;
                count++;
            }
        }

        if (count == 0)
        {
            return "No completed objectives";
        }

        var averageDuration = totalDays / count;
        return $"{averageDuration} days";
    }
}
