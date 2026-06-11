namespace RentACar.Domain.Entities;

public abstract class BaseEntity
{
   
    public  Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; } //kaydı ekleyenin IDsi tutmak adına
    public DateTime? UpdatedAt { get; protected set; }
    public string? UpdatedBy { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public string? DeletedBy { get; protected set; }
    public bool IsDeleted { get; protected set; }


    //obje sadece bu sınıfta kullanılabilen içinde objectler olan bir liste oluşturduk
    private readonly List<object> _domainEvents = new();

   //o objeleri sadece oku işlemi yaptık
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    //sepete ekleme işlemi yaptık 
    public void AddDomainEvent(object domainEvent) => _domainEvents.Add(domainEvent);

    //temizleme işlemi yaptık
    public void ClearDomainEvents() => _domainEvents.Clear();

    protected BaseEntity()
    {
        Id = Guid.CreateVersion7();
        IsDeleted = false;
    }
    public void MarkAsDeleted()
    {
        IsDeleted = true;
    }

}
