using RentACar.Domain.Entities.Common.Interfaces;

namespace RentACar.WebApi.Extensions;

public class FakeCurrentUserService : ICurrentUserService
{
    public Guid? UserId => Guid.Empty;
}
