using System.ComponentModel.DataAnnotations;

namespace MoviesAspNetCore.DTOs;

public record GetMovieActorDTO([Required] int MovieId, [Required] string ActorName);