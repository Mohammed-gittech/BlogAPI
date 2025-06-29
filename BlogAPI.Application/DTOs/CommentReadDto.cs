namespace BlogAPI.Application.DTOs;

public class CommentReadDto
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int PostId { get; set; }
}