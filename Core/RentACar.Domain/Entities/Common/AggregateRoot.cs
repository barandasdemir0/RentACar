namespace RentACar.Domain.Entities.Common;

public abstract class AggregateRoot : BaseEntity
{

    //obje sadece bu sınıfta kullanılabilen içinde objectler olan bir liste oluşturduk
    private readonly List<object> _domainEvents = new();

    //o objeleri sadece oku işlemi yaptık
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    //sepete ekleme işlemi yaptık 
    public void AddDomainEvent(object domainEvent) => _domainEvents.Add(domainEvent);

    //temizleme işlemi yaptık
    public void ClearDomainEvents() => _domainEvents.Clear();
}
