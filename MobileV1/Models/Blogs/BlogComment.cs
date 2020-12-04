using System;
using System.Collections.Generic;
using System.Text;

namespace MobileV1.Models.Blogs
{
    class BlogComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int BlogId { get; set; }
        public string UserId { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
    }
}
