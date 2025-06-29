using BlogAPI.Application.DTOs;
using BlogAPI.Domain.Entities;

namespace BlogAPI.Application.Interfaces;

public interface ICommentService
{
    Task<List<CommentReadDto>> GetAllByPostIdAsync(int postId);
    Task<CommentReadDto> CreateAsync(CommentCreateDto commentCreateDto);
    Task<bool> DeleteAsync(int id);
    
}