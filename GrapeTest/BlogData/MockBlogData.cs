using GrapeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapeTest.BlogData
{
    public class MockBlogData : IBlogData 
    {

        private List<Blog> blogs = new List<Blog>()
        {
            new Blog()
            {
                Id = Guid.NewGuid(),
                Name = "Blog 1"
            }, new Blog()
            {
                Id = Guid.NewGuid(),
                Name = "Blog 2"
            }
        };
        public Blog AddBlog(Blog blog)
        { 
            blog.Id = Guid.NewGuid();
            blogs.Add(blog);
            return blog;
        }

        public void DeleteBlog(Blog blog)
        {
            blogs.Remove(blog);
        }

        public Blog EditBlog(Blog blog)
        {
            var existingBlog = GetBlogs(blog.Id);
            existingBlog.Name = blog.Name;
            return blog;
        }

        public List<Blog> GetBlogs()
        {
            return blogs;
        }

        public Blog GetBlogs(Guid id)
        {
            return blogs.SingleOrDefault(x => x.Id == id);
        }
    }
}
