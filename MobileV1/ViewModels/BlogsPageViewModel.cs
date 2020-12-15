using MobileV1.Models;
using MobileV1.Models.Blogs;
using MobileV1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MobileV1.ViewModels
{
    class BlogsPageViewModel : BaseViewModel
    {
        public Command<CategoriesForBlog> CategoryClicked { get; }

        public Command NextPageClicked { get; }
        public Command PreviousPageClicked { get; }
 
        //
        public ObservableCollection<CategoriesForBlog> CategoryItems { get; set; } = new ObservableCollection<CategoriesForBlog>();

        //
        private ObservableCollection<Blog> _BlogsItems = new ObservableCollection<Blog>();
        public ObservableCollection<Blog> BlogsItems
        {
            get { return _BlogsItems; }
            set { SetProperty(ref _BlogsItems, value); }
        }

        //
        string paginationInfo = string.Empty;
        public string PaginationInfo
        {
            get { return paginationInfo; }
            set { SetProperty(ref paginationInfo, value); }
        }

        readonly BlogService blogService = new BlogService();

        BlogSpecParameters pageFilter;

        public BlogsPageViewModel()
        {
            // select the category
            CategoryClicked = new Command<CategoriesForBlog>(OnCategorySelected);
            NextPageClicked = new Command(GetNextBlogsPage);
            PreviousPageClicked = new Command(GetPreviousBlogPage);
            pageFilter = new BlogSpecParameters();
            GetCategoryItems();
            GetBlogsItems();
        }

        private void GetPreviousBlogPage()
        {
            if(pageFilter.PageIndex > 1)
            {
                // remve all old Blogs and Pagination info
                UpdateBlogsAndPaginationInfo();
                pageFilter.PageIndex--;
                GetBlogsItems();
            }
        }

        private void GetNextBlogsPage()
        {
            if (pageFilter.PageIndex < pageFilter.PagesCount)
            {
                // remve all old Blogs and Pagination info
                UpdateBlogsAndPaginationInfo();
                pageFilter.PageIndex++;
                GetBlogsItems();
            }
        }

        private async void GetCategoryItems()
        {
            var Categories = await blogService.GetBlogCategories();
            CategoryItems.Add(new CategoriesForBlog { Id=0, Name="Reset" });
            foreach (var item in Categories)
            {
                CategoryItems.Add(item);
            }
        }

        private async void GetBlogsItems()
        {
            //
            var Pagination = await blogService.GetAllBlogs(pageFilter.GetParURL());

            if (Pagination != null)
            {
                // update Pagination Info and blogs Parameters
                pageFilter.PageIndex = Pagination.PageIndex;
                pageFilter.PagesCount = Pagination.PagesCount;
                pageFilter.Count = Pagination.Count;
                // Update data after get Request
                UpdateBlogsAndPaginationInfo();

                if (Pagination.PagesCount > 0  )
                {
                    foreach (var item in Pagination.Data)
                    {
                        BlogsItems.Add(item);
                    }
                }
            }
        }

        private async void OnCategorySelected(CategoriesForBlog Category)
        {
            if (Category.Id == 0)
                pageFilter = new BlogSpecParameters();
            else
            {
                pageFilter.PageIndex = 1;
                pageFilter.CategoryId = Category.Id;
            }

            // remove all old Blogs and Pagination info
            UpdateBlogsAndPaginationInfo();
            GetBlogsItems();
        }

        private void UpdateBlogsAndPaginationInfo()
        {
            // to remove old Blogs List
            BlogsItems = new ObservableCollection<Blog>();
            PaginationInfo = pageFilter.GetPaginationInfo();
        }

    }
}
