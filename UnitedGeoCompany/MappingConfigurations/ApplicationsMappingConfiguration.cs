using Mapster;
using UnitedGeoCompany.DataTransfer.Application;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.MappingConfigurations;

public class ApplicationsMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config
            .NewConfig<ApplicationDto, Application>() 
            .Map(model => model.RequestDate, dto => DateTime.Now)
            .Map(dest => dest.ApplicationStatus, src => ApplicationStatus.Pending)
            .CompileProjection();

    }
}
