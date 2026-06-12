namespace RentACar.Domain.Entities.Common;

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



    protected BaseEntity()
    {
        Id = Guid.CreateVersion7();
        CreatedAt = DateTime.UtcNow;
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
