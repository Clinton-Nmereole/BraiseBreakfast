namespace BraiseBreakfast.Contracts.Breakfast

    public record BreakfastResponse(Guid Id, string Name, string Description,
                                    string ImageUrl, DateTime StartDateTime,
                                    DateTime EndDateTime, DateTime LastModified,
                                    List<string> Savory, List<string> Sweet);
