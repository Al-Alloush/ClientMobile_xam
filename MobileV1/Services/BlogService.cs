using MobileV1.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileV1.Services
{
    class BlogService
    {
        public List<CategoriesForBlog> GetBlogCategories()
        {
            List<CategoriesForBlog> CategoriesList = new List<CategoriesForBlog>
            {
               new CategoriesForBlog() { Id = 1, Name = "catcatcatcatcat 1" },
               new CategoriesForBlog() { Id = 2, Name = "cat 2" },
               new CategoriesForBlog() { Id = 3, Name = "cat 3" },
               new CategoriesForBlog() { Id = 4, Name = "cat 4" },
               new CategoriesForBlog() { Id = 5, Name = "cat 5" },
               new CategoriesForBlog() { Id = 6, Name = "cat 6" }
            };
            return CategoriesList;
        }
    }
}
