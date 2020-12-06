using MobileV1.Models.Blogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    class BlogCategorisService : IBlogCategorisService
    {
        private readonly string ROOT_URL = Configuration.Settings["API:Server"];
        private readonly string BLOG_CATEGORY_URL = Configuration.Settings["API:EndPointURI:Blogs:CategoriesList"];

        private readonly HttpClient _client = new HttpClient();

        public async Task<List<CategoriesForBlog>> GetBlogCategories()
        {
            try
            {
                var categoryContent = await _client.GetAsync(ROOT_URL + BLOG_CATEGORY_URL);
                categoryContent.EnsureSuccessStatusCode();
                string categoryContentResponseBody = await categoryContent.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoriesForBlog>>(categoryContentResponseBody);
                return categories;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                throw;
            }
        }
    }
}
