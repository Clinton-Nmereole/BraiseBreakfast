using BraiseBreakfast.Models;
namespace BraiseBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{

    private readonly Dictionary<Guid, Breakfast> _breakfasts = new();

    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast GetBreakfast(Guid id) { return _breakfasts[id]; }
}
