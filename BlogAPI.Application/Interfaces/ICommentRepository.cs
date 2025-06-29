using BlogAPI.Domain.Entities;

namespace BlogAPI.Application.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllByPostIdAsync(int postId);
    Task<Comment?> GetByIdAsync(int id);
    Task AddAsync(Comment comment);
    Task DeleteAsync(Comment comment);
    Task SaveChangesAsync();
    
}