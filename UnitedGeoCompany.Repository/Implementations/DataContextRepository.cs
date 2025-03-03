using UnitedGeoCompanyDataBase;

namespace UnitedGeoCompany.Repository.Implementations;

public class DataContextRepository<T> : Repository<T, DataContext>
    where T : class
{
    public DataContextRepository(DataContext context) : base(context)
    {
    }
}
