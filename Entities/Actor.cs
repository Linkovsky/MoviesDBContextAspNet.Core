namespace MoviesAspNetCore.Entities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }
    public int Age { get; set; }
    public List<Movie> Movies { get; set; }
}