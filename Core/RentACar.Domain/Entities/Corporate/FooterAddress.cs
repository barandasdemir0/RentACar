using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class FooterAddress:AggregateRoot
{
    public string Description { get; private set; }
    public string Address { get; private set; }
    public string Mail { get; private set; }
    public string Phone { get; private set; }
    private FooterAddress()
    {
        Description = null!;
        Address = null!;
        Mail = null!;
        Phone = null!;
    }

    public FooterAddress(string description, string address, string mail, string phone)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        ArgumentException.ThrowIfNullOrWhiteSpace(mail);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);

        Description = description;
        Address = address;
        Mail = mail;
        Phone = phone;
    }

    public void UpdateFooterAddress(string description, string address, string mail, string phone)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        ArgumentException.ThrowIfNullOrWhiteSpace(mail);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);

        Description = description;
        Address = address;
        Mail = mail;
        Phone = phone;
    }
}
