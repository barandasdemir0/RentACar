using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class Testimonial:AggregateRoot
{
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Comment { get; private set; }
    public string? ImageUrl { get; private set; }

    private Testimonial()
    {
        Name = null!;
        Title = null!;
        Comment = null!;
    }
    public Testimonial(string name, string title, string comment, string? imageUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(comment);

        Name = name;
        Title = title;
        Comment = comment;
        ImageUrl = imageUrl;
    }
    public void UpdateTestimonial(string name, string title, string comment, string? imageUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(comment);

        Name = name;
        Title = title;
        Comment = comment;
        ImageUrl = imageUrl;
    }
}
