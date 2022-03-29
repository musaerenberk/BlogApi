using BlogApi.Models;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _blogRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlogs(int id)
        {
            return await _blogRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlogs([FromBody] Blog blog)
        {
            var newBlog = await _blogRepository.Create(blog);
            return CreatedAtAction(nameof(GetBlogs), new { id = newBlog.Id }, newBlog);
        }

        [HttpPut]
        public async Task<ActionResult> PutBlogs(int id, [FromBody] Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            await _blogRepository.Update(blog);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var blogToDelete = await _blogRepository.Get(id);
            if (blogToDelete == null)
                return NotFound();

            await _blogRepository.Delete(blogToDelete.Id);
            return NoContent();
        }
    }
}