namespace UnitedGeoCompany.DataTransfer.Application;
using OneOf;
using OneOf.Types;
using UnitedGeoCompanyDataBase.Models;

[GenerateOneOf]
public partial class ApplicationChangeStatusResult :
    OneOfBase<Application,
    Error<string>?>
{
}
