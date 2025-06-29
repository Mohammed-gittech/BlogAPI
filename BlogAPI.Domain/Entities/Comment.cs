using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Domain.Entities;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(1000)]
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}