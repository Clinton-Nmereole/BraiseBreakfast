namespace BraiseBreakfast.Services.Breakfasts;
using BraiseBreakfast.Models;
using ErrorOr;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);

    ErrorOr<Breakfast> GetBreakfast(Guid id);

    void UpsertBreakfast(Breakfast breakfast);

    void DeleteBreakfast(Guid id);
}
