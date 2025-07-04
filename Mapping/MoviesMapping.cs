using MoviesAspNetCore.DTOs;
using MoviesAspNetCore.Entities;

namespace MoviesAspNetCore.Mapping;

public static class MoviesMapping
{
    public static Movie ToMovie(this CreateMovieDTO movieDto)
    {
        Movie movie = new Movie()
        {
            Title = movieDto.Title,
            Description = movieDto.Description,
            Genre = movieDto.Genre,
            ReleaseDate = movieDto.ReleaseDate,
            Actors = movieDto.Actors
        };
        
        return movie;
    }

}