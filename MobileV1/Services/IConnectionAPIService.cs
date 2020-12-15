using MobileV1.Models;
using MobileV1.Models.Blogs;
using MobileV1.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    interface IConnectionAPIService
    {
        Task<List<CategoriesForBlog>> GetBlogCategories();
        Task<Pagination<Blog>> GetAllBlogs(string par = null);

        Task<UserLogined> Login(LoginModel loginF);
    }
}
