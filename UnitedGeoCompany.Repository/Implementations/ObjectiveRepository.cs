using UnitedGeoCompany.Repository.Interfaces;
using UnitedGeoCompanyDataBase;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Repository.Implementations;

public class ObjectiveRepository : DataContextRepository<Objective>, IObjectiveRepository
{
    public ObjectiveRepository(DataContext context) : base(context)
    {
    }
}
