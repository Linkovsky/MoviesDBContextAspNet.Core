using MoviesAspNetCore.DTOs;
using MoviesAspNetCore.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Movie> movies = new List<Movie>();

app.MapGet("/movies/{id}", (int id) =>
{
    var movie = movies.FirstOrDefault(m => m.Id == id);
    return movie is null ? Results.NotFound() : Results.Ok(movie);
}).WithName("GetMovie");

app.MapPost("/movies", (CreateMovieDTO movie) =>
{
    Movie movieDBO = new Movie()
    {
        Id = movies.Count + 1,
        Title = movie.Title,
        Description = movie.Description,
        Genre = movie.Genre,
        ReleaseDate = movie.ReleaseDate,
        Actors = movie.Actors
    };

    movies.Add(movieDBO);

    return Results.CreatedAtRoute("GetMovie", new { id = movieDBO.Id }, movieDBO);
}).WithParameterValidation();

app.Run();
