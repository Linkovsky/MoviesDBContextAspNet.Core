using MoviesAspNetCore.Data;
using MoviesAspNetCore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("MovieDB");
builder.Services.AddSqlite<MovieContext>(connString);

var app = builder.Build();
app.MapMoviesEndpoints();
app.MigrateDB();
app.Run();
