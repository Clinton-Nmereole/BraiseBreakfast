namespace BraiseBreakfast.Services.Breakfasts;
using BraiseBreakfast.Models;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);

    Breakfast GetBreakfast(Guid id);
}
