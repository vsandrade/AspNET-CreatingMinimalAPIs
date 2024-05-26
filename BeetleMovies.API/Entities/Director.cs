using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BeetleMovies.API;

public class Director
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(150)]
  public required string Name { get; set; }
  public ICollection<Movie> Movies { get; set; } = [];

  public Director() { }

  [SetsRequiredMembers]
  public Director(int id, string name) 
  {
    Id = id;
    Name = name;
  }
}
