using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models;

public class Rating
{
    [Key]
    public int RatingId { get; set; }

    [Required]
    [Range(1, 6)]
    public int Score { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public int MovieId { get; set; }
    public Movie? Movie { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
