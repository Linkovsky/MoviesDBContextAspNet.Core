using MoviesAspNetCore.DTOs;
using MoviesAspNetCore.Entities;
using MoviesAspNetCore.Mapping;

namespace MoviesAspNetCore.Endpoints;

public static class MoviesEndpoints
{
    private const string MOVIES_ENDPOINT = "movies";
    private const string MOVIE_WITH_NAME = "GetMovie";
    private static List<Movie> _movies = new List<Movie>();
    
    public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication application)
    {
        var group = application.MapGroup(MOVIES_ENDPOINT).WithParameterValidation();

        group.MapGet("/", () => Results.Ok(_movies));
        
        group.MapGet("/{id}", (int id) =>
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            return movie is null ? Results.NotFound() : Results.Ok(movie);
        }).WithName(MOVIE_WITH_NAME);

        group.MapPost("/", (CreateMovieDTO movie) =>
        {
            Movie movieDBO = movie.ToMovie();
            movieDBO.Id = _movies.Count + 1;

            _movies.Add(movieDBO);

            return Results.CreatedAtRoute(MOVIE_WITH_NAME, new { id = movieDBO.Id }, movieDBO);
        });

        group.MapPut("/{id}", (int id, UpdateMovieDTO movie) =>
        {
            Movie movieDBO = _movies.FirstOrDefault(m => m.Id == id);

            if (movieDBO is null)
            {
                return Results.NotFound();
            }

            movieDBO.Title = movie.Title;
            movieDBO.Description = movie.Description;
            movieDBO.Genre = movie.Genre;
            movieDBO.ReleaseDate = movie.ReleaseDate;
            movieDBO.Actors = movie.Actors;
            
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Movie movieDBO = _movies.FirstOrDefault(m => m.Id == id);
            
            if (movieDBO is null)
            {
                return Results.NotFound();
            }

            _movies.Remove(movieDBO);
            return Results.NoContent();
        });

        return group;
    }
}