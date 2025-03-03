using UnitedGeoCompany.Repository.Interfaces;
using UnitedGeoCompanyDataBase;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Repository.Implementations;

public class BrigadeRepository : DataContextRepository<Brigade>, IBrigadeRepository
{
    public BrigadeRepository(DataContext context) : base(context)
    {
    }
}
