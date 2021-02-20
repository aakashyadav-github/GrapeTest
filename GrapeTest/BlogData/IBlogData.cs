using GrapeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapeTest.BlogData
{
    public interface IBlogData
    {
        List<Blog> GetBlogs();

        Blog AddBlog(Blog blog);

        void DeleteBlog(Blog blog);

        Blog EditBlog(Blog blog);
        Blog GetBlogs(Guid id);
    }
}
