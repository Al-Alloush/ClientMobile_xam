﻿using MobileV1.Models;
using MobileV1.Models.Blogs;
using MobileV1.Models.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    class ConnectionAPIService : IConnectionAPIService
    {
        private readonly string ROOT_URL = Configuration.Settings["API:Server"];
        private readonly string BLOG_CATEGORIES_ENDPOINT_URI = Configuration.Settings["API:EndPointURI:Blogs:CategoriesList"];
        private readonly string BLOGS_ENDPOINT_URI = Configuration.Settings["API:EndPointURI:Blogs:BlogsList"];
        private readonly HttpClient _client = new HttpClient();

        public async Task<List<CategoriesForBlog>> GetBlogCategories()
        {
            try
            {
                var categoryContent = await _client.GetAsync(ROOT_URL + BLOG_CATEGORIES_ENDPOINT_URI);
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

        public async Task<Pagination<Blog>> GetAllBlogs(string par = null)
        {
            try
            {
                var content = await _client.GetAsync(ROOT_URL + BLOGS_ENDPOINT_URI + "?" + par);
                content.EnsureSuccessStatusCode();
                string responseBody = await content.Content.ReadAsStringAsync();
                var pagination = JsonConvert.DeserializeObject<Pagination<Blog>>(responseBody);

                var count = pagination.Data.Count;

                if (count <= 0)
                    return null;

                return pagination;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }


        public async Task<UserLogined> Login(LoginModel loginF)
        {
            try
            {

                var json = JsonConvert.SerializeObject(loginF);
                // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                StringContent loginHttpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var login = await _client.PostAsync(ROOT_URL + "/api/account/login", loginHttpContent);
                login.EnsureSuccessStatusCode();
                string categoryContentResponseBody = await login.Content.ReadAsStringAsync();
                UserLogined user = JsonConvert.DeserializeObject<UserLogined>(categoryContentResponseBody);
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR In Service: " + ex.Message);
                return null;
            }
        }
    }
}
