using BlogAPI.Application.DTOs;
using BlogAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("post/{postId}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<CommentReadDto>>> GetByPostId(int postId)
        {
            var comments = await _commentService.GetAllByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentReadDto>> Create([FromBody] CommentCreateDto dto)
        {
            var comment = await _commentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByPostId), new {postId = comment.PostId}, comment);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _commentService.DeleteAsync(id);
            if (!delete)
                return NotFound();
            
            return NoContent();
        }
    }
}
