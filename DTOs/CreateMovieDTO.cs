using System.ComponentModel.DataAnnotations;
using MoviesAspNetCore.Entities;

namespace MoviesAspNetCore.DTOs;

public record CreateMovieDTO(
    [Required][StringLength(15)] string Title,
    [Required][StringLength(150)]string Description,
    [Required] Genre Genre,
    [Required] DateOnly ReleaseDate,
    [Required] List<Actor> Actors);