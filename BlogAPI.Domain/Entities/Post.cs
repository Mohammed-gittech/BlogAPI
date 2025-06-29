using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Domain.Entities;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;
    
    [Required]
    [MaxLength(2000)]
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public List<Comment> Comments { get; set; } = new();
}