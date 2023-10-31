namespace BraiseBreakfast.Contracts.Breakfast;

public record CreateBreakfastRequest(string Name, string Description,
                                     string ImageUrl, DateTime StartDateTime,
                                     DateTime EndDateTime, List<string> Savory,
                                     List<string> Sweet);
