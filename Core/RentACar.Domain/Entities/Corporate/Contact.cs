using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class Contact:AggregateRoot
{
    public string Name { get; private set; } 
    public string Email { get; private set; }
    public string Subject { get; private set; } 
    public string Message { get; private set; } 

    private Contact()
    {
        Name = null!;
        Email = null!;
        Subject = null!;
        Message = null!;
    }

    public Contact(string name, string email, string subject, string message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(subject);
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        Name = name;
        Email = email;
        Subject = subject;
        Message = message;
    }

}
