using MobileV1.Models.Blogs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    interface IBlogCategorisService
    {
        Task<List<CategoriesForBlog>> GetBlogCategories();
    }
}
