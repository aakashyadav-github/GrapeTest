using GrapeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapeTest.BlogData
{
    public class SqlBlogData : IBlogData
    {
        private BlogContext _blogContext;
        public SqlBlogData(BlogContext blogcontext)
        {
            _blogContext = blogcontext;
        }

        public Blog AddBlog(Blog blog)
        {
            blog.Id = Guid.NewGuid();
            _blogContext.blogs.Add(blog);
            _blogContext.SaveChanges();
            return blog;
        }

        public void DeleteBlog(Blog blog)
        {
            _blogContext.blogs.Remove(blog);
            _blogContext.SaveChanges();
        }

        public Blog EditBlog(Blog blog)
        {
            var existingBlog = _blogContext.blogs.Find(blog.Id);
            if (existingBlog != null)
            {
                existingBlog.Name = blog.Name;
                _blogContext.blogs.Update(existingBlog);
                _blogContext.SaveChanges();
            }
            return blog;
        }

        public List<Blog> GetBlogs()
        {
            return _blogContext.blogs.ToList();
        }

        public Blog GetBlogs(Guid id)
        {
            var blog = _blogContext.blogs.Find(id);
            return blog;
        }
    }
}
