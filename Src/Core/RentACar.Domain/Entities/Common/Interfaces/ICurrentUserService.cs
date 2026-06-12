namespace RentACar.Domain.Entities.Common.Interfaces;

public interface ICurrentUserService
{
    //giriş yapan kullanıcının ıdsini istedik
    Guid? UserId { get; }
}
