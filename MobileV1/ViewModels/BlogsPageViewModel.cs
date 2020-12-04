using MobileV1.Models.Blogs;
using MobileV1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileV1.ViewModels
{
    class BlogsPageViewModel
    {
        public ObservableCollection<CategoriesForBlog> CategoryItems { get; set; } = new ObservableCollection<CategoriesForBlog>();
        public BlogsPageViewModel()
        {
            var Categories = new BlogService().GetBlogCategories();
            foreach (var item in Categories)
            {
                CategoryItems.Add(item);
            }
        }

    }
}
