

using BlogAPI.Domain.Entities;
using BlogAPI.DTOs;

namespace BlogAPI.Application.Interfaces;

public interface IPostService
{
   Task<List<PostReadDto>> GetAllAsync();
   Task<PostReadDto?> GetByIdAsync(int id);
   Task<PostReadDto> CreateAsync(PostCreateDto dto);
   Task<bool> UpdateAsync(int id, PostCreateDto dto);
   Task<bool> DeleteAsync(int id);
}

