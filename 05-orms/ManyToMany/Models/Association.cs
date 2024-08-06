using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    // this tracks the associated movie's id
    public int MovieId { get; set; }
    // navigational property
    public Movie? Movie { get; set; }

    // this tracks the associated genre's id
    public int GenreId { get; set; }
    // navigational property
    public Genre? Genre { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"GenreId: {GenreId}, MovieId{MovieId}";
    }
}
