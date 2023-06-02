
namespace MoviesTime.Contract.DbModels;

public class Genres
{
    public int ID { get; set; }
    public string? GenreName { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<MovieGenreMapping> MovieGenreMappings { get; set; }
}
