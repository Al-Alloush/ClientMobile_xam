using MobileV1.Models;
using MobileV1.Models.Blogs;
using MobileV1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileV1.ViewModels
{
    class BlogsPageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<CategoriesForBlog> CategoryItems { get; set; } = new ObservableCollection<CategoriesForBlog>();

        public ObservableCollection<Blog> BlogsItems { get; set; } = new ObservableCollection<Blog>();

        string paginationInfo = string.Empty;
        public string PaginationInfo
        {
            get { return paginationInfo; }
            set { SetProperty(ref paginationInfo, value); }
        }

        readonly BlogService blogService = new BlogService();

        public BlogsPageViewModel()
        {
            GetCategoryItems();
            GetBlogsItems();
        }

        private async void GetCategoryItems()
        {
            var Categories = await blogService.GetBlogCategories();
            foreach (var item in Categories)
            {
                CategoryItems.Add(item);
            }
        }

        private async void GetBlogsItems()
        {
            var Pagination = await blogService.GetAllBlogs();
            
            PaginationInfo = $"Page: {Pagination.PageIndex.ToString()} " +
                             $"from: {Pagination.PagesCount.ToString()}, " +
                             $"Blogs:{Pagination.PageSize.ToString()}, " +
                             $"Result: {Pagination.Count.ToString()} ";

            foreach (var item in Pagination.Data)
            {
                BlogsItems.Add(item);
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
