using BraiseBreakfast.Services.Breakfasts;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}
var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
