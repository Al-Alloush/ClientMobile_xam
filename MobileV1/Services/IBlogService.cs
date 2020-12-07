using MobileV1.Models.Blogs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    interface IBlogService
    {
        Task<List<CategoriesForBlog>> GetBlogCategories();
    }
}
