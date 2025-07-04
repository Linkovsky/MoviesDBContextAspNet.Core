using Microsoft.EntityFrameworkCore;

namespace MoviesAspNetCore.Data;

public static class DataExtensions
{
    public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();
        dbContext.Database.Migrate();
    }
}