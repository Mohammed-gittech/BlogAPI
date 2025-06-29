namespace BlogAPI.Application.DTOs;

public class CommentCreateDto
{
    public string Content { get; set; } = null!;
    public int PostId { get; set; }
}