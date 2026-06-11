namespace RentACar.Domain.Entities;

public class Contact
{
    public int ContactID { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactSubject { get; set; }
    public string? ContactMessage { get; set; }
    public DateTime SendDate { get; set; }
}
