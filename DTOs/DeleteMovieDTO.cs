using System.ComponentModel.DataAnnotations;

namespace MoviesAspNetCore.DTOs;

public record DeleteMovieDTO([Required] int Id);