using MoviesAspNetCore.DTOs;
using MoviesAspNetCore.Endpoints;
using MoviesAspNetCore.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapMoviesEndpoints();

app.Run();
