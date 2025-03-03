using UnitedGeoCompany.Repository.Interfaces;
using UnitedGeoCompanyDataBase;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Repository.Implementations;

public class ApplicationRepository : DataContextRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(DataContext context) : base(context)
    {
    }
}
