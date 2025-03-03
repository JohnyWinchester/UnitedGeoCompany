using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Controllers.Requests;

public record ApplicationStatusRequest(long ApplicationId, ApplicationStatus Status);
