using BlogAPI.Application.Interfaces;
using BlogAPI.Domain.Entities;
using BlogAPI.DTOs;

namespace BlogAPI.Application.Serveices;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;

    public PostService(IPostRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<List<PostReadDto>> GetAllAsync()
    {
        var posts = await _repository.GetAllAsync();
        
        return posts.Select(p => new PostReadDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            CreatedAt = p.CreatedAt
        }).ToList();
    }

    public async Task<PostReadDto?> GetByIdAsync(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null) return null;

        return new PostReadDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        };
    }

    public async Task<PostReadDto> CreateAsync(PostCreateDto dto)
    {
        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
        };
        await _repository.AddAsync(post);
        await _repository.SaveChangesAsync();

        return new PostReadDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, PostCreateDto dto)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null) return false;
        
        post.Title = dto.Title;
        post.Content = dto.Content;
        
        await _repository.UpdateAsync(post);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null) return false;

        await _repository.DeleteAsync(post);
        await _repository.SaveChangesAsync();
        return true;
    }
}