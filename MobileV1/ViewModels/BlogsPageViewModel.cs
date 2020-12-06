using MobileV1.Models.Blogs;
using MobileV1.Services;
using System.Collections.ObjectModel;

namespace MobileV1.ViewModels
{
    class BlogsPageViewModel
    {
        public ObservableCollection<CategoriesForBlog> CategoryItems { get; set; } = new ObservableCollection<CategoriesForBlog>();
        readonly BlogCategorisService CategorisService = new BlogCategorisService();
        public BlogsPageViewModel()
        {
            GetCategoryItems();
        }

        private async void GetCategoryItems()
        {
            var Categories = await CategorisService.GetBlogCategories();
            foreach (var item in Categories)
            {
                CategoryItems.Add(item);
            }
        }
    }
}
