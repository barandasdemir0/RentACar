namespace RentACar.Domain.Entities.Common;

public abstract class BaseEntity
{
   
    public  Guid Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; protected set; }
    public Guid CreatedBy { get; protected set; } //kaydı ekleyenin IDsi tutmak adına
    public DateTimeOffset? UpdatedAt { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }
    public DateTimeOffset? DeletedAt { get; protected set; }
    public Guid? DeletedBy { get; protected set; }
    public bool IsDeleted { get; protected set; }



    protected BaseEntity()
    {
        Id = Guid.CreateVersion7();
        CreatedAt = DateTimeOffset.UtcNow;
        IsDeleted = false;
    }
    public void MarkAsDeleted()
    {
        if (IsDeleted)
        {
            return;
        }
        
        IsDeleted = true;
    }

}
