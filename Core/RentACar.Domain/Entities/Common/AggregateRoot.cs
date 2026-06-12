namespace RentACar.Domain.Entities.Common;

public interface IDomainEvent { }
public abstract class AggregateRoot : BaseEntity
{

    //obje sadece bu sınıfta kullanılabilen içinde objectler olan bir liste oluşturduk
    private readonly List<IDomainEvent> _domainEvents = new();

    //o objeleri sadece oku işlemi yaptık
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    //sepete ekleme işlemi yaptık 
    public void AddDomainEvent(IDomainEvent domainEvent) 
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _domainEvents.Add(domainEvent);
    }

    //temizleme işlemi yaptık
    public void ClearDomainEvents() => _domainEvents.Clear();
}
