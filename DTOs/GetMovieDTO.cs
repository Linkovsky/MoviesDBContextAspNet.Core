using System.ComponentModel.DataAnnotations;

namespace MoviesAspNetCore.DTOs;

public record GetMovieDTO([Required] int Id);