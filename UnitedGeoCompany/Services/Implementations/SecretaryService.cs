using MapsterMapper;
using OneOf.Types;
using UnitedGeoCompany.DataTransfer.Application;
using UnitedGeoCompany.Repository.Interfaces;
using UnitedGeoCompany.Services.Interfaces;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Services.Implementations;

public class SecretaryService : ISecretaryService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IBrigadeRepository _brigadeRepository;
    private readonly IObjectiveRepository _objectiveRepository;
    private readonly IMapper _mapper;

    public SecretaryService(
        IApplicationRepository applicationRepository,
        IMapper mapper,
        IBrigadeRepository brigadeRepository,
        IObjectiveRepository objectiveRepository)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _brigadeRepository = brigadeRepository;
        _objectiveRepository = objectiveRepository;
    }

    public async Task AddApplication(
        ApplicationDto application) 
            => await _applicationRepository.AddAsync(_mapper.From(application).AdaptToType<Application>());

    public async Task<string> ApplicationStatus(long applicationId, CancellationToken cancellationToken = default)
    {
        if (await _applicationRepository
            .GetAsync(application => application.ID == applicationId, cancellationToken) is not { } application)
            throw new Exception("Такой заявки не существует");

        return application.ApplicationStatus.ToString();
    }

    public async Task<Error<string>?> GiveObjectiveToBrigade(
        long applicationID,
        long brigadeId,
        CancellationToken cancellationToken = default)
    {
        if (await _applicationRepository.GetAsync(
            application => application.ID == applicationID, 
            cancellationToken, 
            include: application => application.Objective) 
                is not { } application)
            return new Error<string>("Заявки с таким ID не существует.");

        if(application.Objective is not null)
            return new Error<string>("Заявка уже имеет задание и бригаду.");

        if(await _brigadeRepository.GetAsync(brigade => brigade.ID == brigadeId,cancellationToken,brigade => brigade.Objectives) is not { } brigade)
            return new Error<string>("Бригады с таким ID не существует.");

        if(brigade.Objectives?.Where(x => x.CompletionDate is null) is { } notCompletedObjective)
        {
            application.Objective = new Objective()
            {
                AssignmentDate = DateTime.Now,
                Application = application,
                ApplicationId = application.ID,
                Brigade = brigade,
                BrigadeId = brigadeId,
            };

            await _applicationRepository.Update(application, cancellationToken);

            return null;
        }

        return new Error<string>("Бригада имеет активное задание.");
    }

    public async Task<CompleteApplicationResult> UpdateApplicationStatus(
        long applicationID, 
        ApplicationStatus newStatus, 
        CancellationToken cancellationToken = default)
    {
        if (await _applicationRepository.GetAsync(application => application.ID == applicationID, cancellationToken) is not { } applicationForChange)
            return new Error<string>("Заявки с таким ID не существует.");

        if(applicationForChange.ApplicationStatus == newStatus)
            return new Error<string>("Нельзя поменять одинаковые статусы заявок.");

        applicationForChange.ApplicationStatus = newStatus;
        await _applicationRepository.Update(applicationForChange, cancellationToken);

        return applicationForChange;
    }
}
