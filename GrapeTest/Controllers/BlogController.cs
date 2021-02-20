using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrapeTest.Authentication;
using GrapeTest.BlogData;
using GrapeTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GrapeTest.Controllers
{
    [Authorize]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogData _blogData;
         
        private readonly IJwtAuthenticatorManager jwtAuthenticatorManager;

        public BlogController(IBlogData blogData, IJwtAuthenticatorManager jwtAuthenticatorManager)
        {
            _blogData = blogData;
            this.jwtAuthenticatorManager = jwtAuthenticatorManager;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetBlog()
        {
            return Ok(_blogData.GetBlogs());
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddBlog(Blog blog)
        {
            _blogData.AddBlog(blog);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + blog.Id, blog);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteBlog(Guid id)
        {
            var blog = _blogData.GetBlogs(id);

            if(blog != null)
            {
                _blogData.DeleteBlog(blog);
                return Ok();
            }
            return NotFound("Blog not found...");
             
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateBlog(Guid id, Blog blog)
        {
            var existingBlog = _blogData.GetBlogs(id);

            if (existingBlog != null)
            {
                 blog.Id = existingBlog.Id;
                _blogData.EditBlog(blog);
            }
            return Ok(blog);

        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jwtAuthenticatorManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);

        }
    }
}
