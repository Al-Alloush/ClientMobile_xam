using System;
using System.Collections.Generic;
using System.Text;

namespace MobileV1.Models.Blogs
{
    class Blog
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int Id { get; set; }
        public bool Display { get; set; }
        public DateTime? DisplayDate { get; set; }
        public bool Commentable { get; set; }
        public bool AtTop { get; set; }
        public DateTime? AtTopEndDate { get; set; }
        public List<CategoriesForBlog> CategoriesForBlogs { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public string DefaultImage { get; set; }
        public List<BlogImage> BlogImages { get; set; }
        public int CommentsCount { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
    }
}
