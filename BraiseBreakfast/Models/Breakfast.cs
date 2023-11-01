using BraiseBreakfast.Contracts.Breakfast;
using BraiseBreakfast.ServiceErrors;
using ErrorOr;
namespace BraiseBreakfast.Models;

public class Breakfast
{

    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;

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

    public static ErrorOr<Breakfast>
    Create(string name, string description, string imageUrl,
           DateTime startDateTime, DateTime endDateTime, List<string> savory,
           List<string> sweet, Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Breakfast(id ?? Guid.NewGuid(), name, description, imageUrl,
                             startDateTime, endDateTime, DateTime.UtcNow, savory,
                             sweet);
    }

    public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
    {
        return Create(request.Name, request.Description, request.ImageUrl,
                      request.StartDateTime, request.EndDateTime, request.Savory,
                      request.Sweet);
    }

    public static ErrorOr<Breakfast> From(Guid id,
                                          UpsertBreakfastRequest request)
    {
        return Create(request.Name, request.Description, request.ImageUrl,
                      request.StartDateTime, request.EndDateTime, request.Savory,
                      request.Sweet, id);
    }
}
