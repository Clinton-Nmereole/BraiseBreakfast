namespace BraiseBreakfast.Models;

public class Breakfast
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string ImageUrl { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModified { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    public Breakfast(Guid id, string name, string description, string imageUrl,
                     DateTime startDateTime, DateTime endDateTime,
                     DateTime lastModified, List<string> savory,
                     List<string> sweet)
    {
        // enfore invariants
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModified = lastModified;
        Savory = savory;
        Sweet = sweet;
    }
}
