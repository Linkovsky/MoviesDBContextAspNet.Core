using System.ComponentModel.DataAnnotations;

namespace MoviesAspNetCore.DTOs;

public record GetMovieActorsDTO([Required] int MovieId);