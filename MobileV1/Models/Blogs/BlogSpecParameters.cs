using System;
using System.Collections.Generic;
using System.Text;

namespace MobileV1.Models.Blogs
{
    class BlogSpecParameters
    {
        private const int MaxPageSize = 30;
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public int? CategoryId { get; set; }
        public int Count { get; set; }

        public string Sort { get; set; }

        private string _search;

        public string Search { get; set; }

        public BlogSpecParameters()
        {
            this.PageIndex = 1;
            this.PageSize = MaxPageSize;
            this.Sort = "dateDesc";
        }

        public BlogSpecParameters(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex < 1 ? 1 : pageIndex;
            this.PageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
            this.Sort = "dateDesc";
        }

        public string GetParURL()
        {
            
            return  $"sort={Sort}&" +
                    $"PageIndex={PageIndex}&" +
                    $"PageSize={PageSize}&" +
                    $"categoryId={CategoryId}&" +
                    $"Search={Search}";
        }

        public string GetPaginationInfo()
        {
            var pagesText = PagesCount > 1 ? "Pages" : "Page";
            return $"Page: {PageIndex} from: {PagesCount} {pagesText}, Result: {Count} ";
        }
    }
}
