using BlogAPI.Application.DTOs;
using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;

namespace BlogAPI.Application.Serveices;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;
    private readonly IPostRepository _postRepository;

    public CommentService(ICommentRepository repository, IPostRepository postRepository)
    {
        _repository = repository;
        _postRepository = postRepository;
    }
    
    public async Task<List<CommentReadDto>> GetAllByPostIdAsync(int postId)
    {
        var comments = await _repository.GetAllByPostIdAsync(postId);
        return comments.Select(c => new CommentReadDto
        {
            Id = c.Id,
            Content = c.Content,
            CreatedAt = c.CreatedAt,
            PostId = c.PostId
        }).ToList();
    }

    public async Task<CommentReadDto> CreateAsync(CommentCreateDto dto)
    {
        var post = await _postRepository.GetByIdAsync(dto.PostId);
        if (post == null) throw new Exception("Post not found");

        var comment = new Comment
        {
            Content = dto.Content,
            PostId = dto.PostId
        };
        await _repository.AddAsync(comment);
        await _repository.SaveChangesAsync();

        return new CommentReadDto
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            PostId = comment.PostId
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if(comment == null) return false;
        
        await _repository.DeleteAsync(comment);
        await _repository.SaveChangesAsync();
        return true;
    }
}